
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        async static Task Main(string[] args)
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            CancellationToken token = cancellationTokenSource.Token;

            Task task1 = new Task(() => TaskMethods.FindSimpleNumbers(token), token);

            var sw = new Stopwatch();

            sw.Start();
            Console.WriteLine($"Задача выполнена(начало)? - {task1.IsCompleted}");
            Console.WriteLine($"Статус(начало)? - {task1.Status}");
            task1.Start();
            Thread.Sleep(200);
            cancellationTokenSource.Cancel();
            Console.WriteLine($"Задача выполнена(середина)? - {task1.IsCompleted}");
            Console.WriteLine($"Статус(середина)? - {task1.Status}");
            try
            {
                task1.Wait();
            }
            catch (AggregateException ae)
            {
                foreach (var e in ae.InnerExceptions)
                {
                    if (e is TaskCanceledException)
                    {
                        Console.WriteLine("Задача была отменена.");
                    }
                    else
                    {
                        Console.WriteLine("Произошла ошибка: " + e.Message);
                    }
                }
            }
            Console.WriteLine($"Задача выполнена(конец)? - {task1.IsCompleted}");
            Console.WriteLine($"Статус(конец)? - {task1.Status}");
            sw.Stop();
            cancellationTokenSource.Dispose();

            Console.WriteLine($"Время потрачено: {sw.Elapsed}");

            TaskMethods.TaskContinueWith();
            TaskMethods.TaskGet();

            var time = new Stopwatch();
            time.Start();
            TaskMethods.CreateArray();
            time.Stop();
            Console.WriteLine($"Время потрачено (массив): {time.Elapsed}");

            var anotherTime = new Stopwatch();
            anotherTime.Start();
            TaskMethods.CreateStandardArray();
            anotherTime.Stop();
            Console.WriteLine($"Время потрачено (массив при помощи цикла): {anotherTime.Elapsed}");

            Parallel.Invoke(TaskMethods.Print, () =>
            {
                Console.WriteLine($"Выполняется задача {Task.CurrentId}");
                Thread.Sleep(3000);
            },
            () => Console.WriteLine($"Выполняется задача {Task.CurrentId} + результат выполнения: {TaskMethods.FindSquare(5)}")
            );

            Buy.Task7();

            await PrintAsync();

            Console.WriteLine("ALL done");
            Console.ReadKey();
        }

        static void Print()
        {
            Thread.Sleep(3000);     // имитация продолжительной работы
            Console.WriteLine("Hello");
        }

        static async Task PrintAsync()
        {
            Console.WriteLine("Начало метода PrintAsync"); // выполняется синхронно
            await Task.Run(Print);                         // выполняется асинхронно
            Console.WriteLine("Конец метода PrintAsync");
        }
    }
}
