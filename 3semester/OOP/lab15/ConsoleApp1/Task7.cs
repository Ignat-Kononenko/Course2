using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class Buy
    {
        public static void Task7()
        {
            BlockingCollection<Product> products = new BlockingCollection<Product>();
            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken token = cts.Token;

            Task provider1 = new Task(() =>
            {
                int cnt = 0;
                while (cnt < 2 && products.TryAdd(new Product($"Product {cnt + 1} from Provider 1", (uint)(new Random().Next(100, 1000)))))
                {
                    cnt++;
                    Console.WriteLine("Поставщик 1 добавил товар");
                    Thread.Sleep(1700);
                    PrintInventory(products);
                }
            });

            Task provider2 = new Task(() =>
            {
                int cnt = 0;
                while (cnt < 2 && products.TryAdd(new Product($"Product {cnt + 1} from Provider 2", (uint)(new Random().Next(100, 1000)))))
                {
                    cnt++;
                    Console.WriteLine("Поставщик 2 добавил товар");
                    Thread.Sleep(2000);
                    PrintInventory(products);
                }
            });

            Task provider3 = new Task(() =>
            {
                int cnt = 0;
                while (cnt < 2 && products.TryAdd(new Product($"Product {cnt + 1} from Provider 3", (uint)(new Random().Next(100, 1000)))))
                {
                    cnt++;
                    Console.WriteLine("Поставщик 3 добавил товар");
                    Thread.Sleep(600);
                    PrintInventory(products);
                }
            });

            Task provider4 = new Task(() =>
            {
                int cnt = 0;
                while (cnt < 2 && products.TryAdd(new Product($"Product {cnt + 1} from Provider 4", (uint)(new Random().Next(100, 1000)))))
                {
                    cnt++;
                    Console.WriteLine("Поставщик 4 добавил товар");
                    Thread.Sleep(3000);
                    PrintInventory(products);
                }
            });

            Task provider5 = new Task(() =>
            {
                int cnt = 0;
                while (cnt < 2 && products.TryAdd(new Product($"Product {cnt + 1} from Provider 5", (uint)(new Random().Next(100, 1000)))))
                {
                    cnt++;
                    Console.WriteLine("Поставщик 5 добавил товар");
                    Thread.Sleep(1250);
                    PrintInventory(products);
                }
            });

            Task[] providers = { provider1, provider2, provider3, provider4, provider5 };

            foreach (var provider in providers)
            {
                provider.Start();
            }

            Task[] clients = Enumerable.Range(1, 10).Select(i => new Task(() =>
            {
                Product prod;
                while (!token.IsCancellationRequested)
                {
                    if (products.TryTake(out prod))
                    {
                        Console.WriteLine($"Клиент {i} забрал продукт: {prod}");
                    }
                }
            }, token)).ToArray();

            foreach (var client in clients)
            {
                client.Start();
            }

            Task.WaitAll(providers);
            cts.Cancel();
            Task.WaitAll(clients);
        }

        public static void PrintInventory(BlockingCollection<Product> products)
        {
            Console.WriteLine("Текущий склад:");
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
            Console.WriteLine("-------------");
        }

        public class Product
        {
            public string Name { get; set; }
            public uint Price { get; set; }

            public Product(string name, uint price)
            {
                Name = name;
                Price = price;
            }

            public Product()
            {
                Name = String.Empty;
                Price = 0;
            }

            public override string ToString() => $"Имя: {Name}, Цена: {Price}";
        }
    }

}
