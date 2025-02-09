// TaskMethods.cs
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class TaskMethods
    {
        public static void Print()
        {
            Console.WriteLine($"Выполняется задача {Task.CurrentId}");
            Thread.Sleep(3000);
        }

        public static void TaskContinueWith()
        {
            int a = 4, b = 5;

            Task<int> task1 = new Task<int>(() => FindSquare(a));
            Task<float> task2 = task1.ContinueWith(task => CountNumber(task.Result, b));
            Task printTask = task2.ContinueWith(task => PrintResults(task.Result));

            task1.Start();
            printTask.Wait();
        }

        public static void TaskGet()
        {
            int a = 3, b = 5;

            Task<int> task1 = new Task<int>(() => FindSquare(a));
            task1.Start();
            task1.GetAwaiter().GetResult();

            Task<float> task2 = task1.ContinueWith(task => CountNumber(task.Result, b));
            task2.GetAwaiter().GetResult();

            Task printTask = task2.ContinueWith(task => PrintResults(task.Result));
            printTask.GetAwaiter().GetResult();
            printTask.Wait();
        }

        public static void FindSimpleNumbers(CancellationToken token)
        {
            var amount = 40;
            int c = 0;
            var num = new int[amount];
            List<int> list = new List<int>();

            for (var i = 0; i < amount; i++)
            {
                num[i] = i + 1;
            }

            Parallel.For(1, amount, i =>
            {
                if (token.IsCancellationRequested)
                {
                    c++;
                    return;
                }

                bool isPrime = true;
                Thread.Sleep(200);

                for (var j = 1; j < i; j++)
                {
                    if (num[i] % num[j] == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime)
                {
                    list.Add(i + 1);
                }
            });

            list.Sort();
            Console.WriteLine("Простые числа:");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            if (c > 0)
                Console.WriteLine("Операция прервана");
        }

        public static int FindSquare(int a)
        {
            return a * a;
        }

        public static float CountNumber(int a, int b)
        {
            int x = a + b * 12 - b * a / 3;
            return x;
        }

        public static bool IsTrue(int a, int b)
        {
            return a > b;
        }

        public static void CommonTask()
        {
            int firstNum = 6, secondNum = 7;
            int firstResult = FindSquare(firstNum);
            float secondResult = CountNumber(firstNum, secondNum);
            bool thirdResult = IsTrue(firstResult, (int)secondResult);
            PrintResult(thirdResult);
        }

        public static void PrintResult(bool result) => Console.WriteLine($"Результат: {result}");

        public static void PrintResults(float result) => Console.WriteLine($"Результат: {result}");

        public static void CreateArray()
        {
            int amount = 1000000;
            int[] arr = new int[amount];

            Parallel.For(1, amount, i =>
            {
                arr[i] = i;
            });
        }

        public static void CreateStandardArray()
        {
            int amount = 1000000;
            int[] arr = new int[amount];

            for (var i = 0; i < amount; i++)
            {
                arr[i] = i;
            }
        }
    }
}
