using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace lab7
{
    public class Products
    {
        public string Name { get; set; }
        public int Price { get; set; }

        public override string ToString()
        {
            return $"{Name}, {Price}";
        }
    }
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Collection<Products> collection = new Collection<Products>();

            Products product1 = new Products {Name = "GEG", Price = 134 };
            Products product2 = null;
            Products product3 = new Products { Name = "ffff", Price = 12 };

            collection.AddValue(product1);
          /*  collection.AddValue(product2);*//*
            collection.RemoveValue(product3);*/

            collection += product3;
            
            foreach (Products product in collection.GetAll()) {
                Console.WriteLine(product);
            }

            /*          Collection<int> iNumbers = new Collection<int>();

                        Collection<double> dNumber = new Collection<double>();

                        Collection<string> str = new Collection<string>();*/

            Technic<string> technic1 = new Technic<string>("ggg", 24, 5);
            technic1.AddValue("fe");
            technic1.AddValue("fe2");

            foreach (var item in technic1.value)
            {
                Console.WriteLine(item +", "+ technic1);
            }

            await collection.SaveToFile("technics.txt");

            await collection.ReadFromFile("technics.txt");

            Gen<int, int> gg = new Gen<int,int> (3,6);
            Console.WriteLine(gg.GetOb());   
        }
    }

    interface IGeneralization<T>
    {
        void AddValue(T value);
        void RemoveValue(T value);
        IEnumerable<T> GetAll();
    }

    public class Collection<T> : IGeneralization<T> where T : class             // Наложение ограничения
    {
        private List<T> list = new List<T>();
        public void AddValue(T value) {

            try { 
                if(value == null)
                {
                    throw new ArgumentNullException("list");
                }
                list.Add(value);
                Console.WriteLine($"Элемент @{value}@ добавлен");
            }
            catch(ArgumentNullException ex) {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                Console.WriteLine("Finally!");
            }

        }
        public void RemoveValue(T value) {
            try
            {
                if (value == null)
                {
                    throw new ArgumentNullException("list");
                }
                if (!value.Equals(list))
                {
                    throw new KeyNotFoundException();
                }
                list.Remove(value);
                Console.WriteLine($"Элемент @{value}@ удален");
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            catch(KeyNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                Console.WriteLine("Finally!");
            }
        
        }

        public static Collection<T> operator +(Collection<T> collection, T value)
        {
            collection.AddValue(value);
            return collection;
        }

        public static Collection<T> operator -(Collection<T> collection, T value)
        {
            collection.RemoveValue(value);
            return collection;
        }

        public async Task SaveToFile(string filePath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (var item in list) // Перебор элементов в списке list
                    {
                        await writer.WriteLineAsync(item.ToString());

                    }
                    Console.WriteLine("Запись в файл");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Finally!");
            }
        }

        public async Task ReadFromFile(string filePath)
        {
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string text = await reader.ReadToEndAsync();
                    Console.WriteLine("чтение из файла: " + text);
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public IEnumerable<T> GetAll()
        {
            return list;
        }

        
    }


    class Gen<T, G>
    {
        G ob;
        T bo;
        public Gen(G o, T b)
        {
            ob = o;
            bo = b;
        }
        public T GetOb()
        {
            return bo;
        }
    }
    public class Product<T1> 
    {

        public List<T1> value = new List<T1>();
        public string Name { get; set; }
        public int Price { get; set; }

        public Product(string name, int price)
        {
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            return $"{Name}, {Price}";
        }
    }

    public class Technic<T1> : Product<T1>
    {
        public int Battery { get; set; }

        public Technic( string name, int price, int battery):base(name, price)
        {
             Battery = battery;
        }

        public void AddValue(T1 element)
        {
            value.Add(element);
            Console.WriteLine($"Элемент добавлен");
        }
        public override string ToString()
        {
            return $"{Name}, {Price}, {Battery}";
        }
    }
}
