using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace OOP14
{
    static class Info
    {
        private static string name_file = "text.txt";
        private static Mutex mutex = new Mutex();

        /*1)Определите и выведите на консоль / в файл все запущенные процессы:id, имя, приоритет,
           время запуска, текущее состояние, сколько всего времени использовал процессор и т.д.*/
        public static void ShowProcesses()
        {



            var allProcesses = Process.GetProcesses();

            foreach (var process in allProcesses)
            {
                try
                {
                    Console.WriteLine($"Id процесса - {process.Id}\n" +
                                  $"Имя процесса - {process.ProcessName}\n" +
                                  $"Приоритет процесса - {process.BasePriority}\n" +
                                  $"Время запуска процесса - {process.StartTime}\n" +
                                  $"Текущее состояние процесса - {process.Responding}\n" +
                                  $"Время работы процесса - {process.TotalProcessorTime}\n" +
                                  $"Время загрузки процесса - {process.UserProcessorTime}\n");
                }
                catch (Exception e)
                {
                    /* Console.WriteLine("Ошибка");*/
                }
            }

            Console.WriteLine($"Количество процессов - {allProcesses.Length}");

        }


        /*2)Исследуйте текущий домен вашего приложения: имя, детали конфигурации, все сборки,
            загруженные в домен.Создайте новый домен.Загрузите туда сборку.Выгрузите домен.*/
        public static void ShowDomains()
        {


            AppDomain domain = AppDomain.CurrentDomain; // текущий домен приложения
            Console.WriteLine($"Имя домена - {domain.FriendlyName}");
            Console.WriteLine("Базовый каталог:\n" + domain.BaseDirectory);
            Console.WriteLine($"Детали конфигурации - {domain.SetupInformation}");
            Console.WriteLine("Сборки, загруженные в домен:");

            Assembly[] assemblies = domain.GetAssemblies();
            foreach (Assembly asm in assemblies)
            {
                Console.WriteLine(asm.GetName().Name);
            }

            /*
            foreach (Assembly assembly in domain.GetAssemblies())
            {
                Console.WriteLine(assembly.GetName().Name);
            }*/

            /*AppDomain newDomain = AppDomain.CreateDomain("New Domain");                                   // создание нового домена
            newDomain.Load(Assembly.GetExecutingAssembly().FullName);                                       // загрузка сборки
            AppDomain.Unload(newDomain);                                                                    // выгрузка домена + всех содержащихся в нём сборок*/
            /*Console.ForegroundColor = ConsoleColor.White;*/
        }

        /*3)Создайте в отдельном потоке следующую задачу расчета(можно сделать sleep для
             задержки) и записи в файл и на консоль простых чисел от 1 до n(задает пользователь).
             Вызовите методы управления потоком(запуск, приостановка, возобновление и т.д.) Во
             время выполнения выведите информацию о статусе потока, имени, приоритете, числовой
             идентификатор и т.д.*/
        public static void ShowSimpleNumbers()
        {

            var first = new Thread(PrintSimpleNumbers);
            first.Start();
            first.Name = "Simple_numbers";
            first.Join();
            Console.WriteLine();

        }
        public static void ShowInfo(object thread)
        {
            var z = thread as Thread;
            Console.WriteLine($"Имя потока - {z.Name}\n" +
                              $"Приоритет потока - {z.Priority}\n" +
                              $"Статус потока - {z.ThreadState}\n" +
                              $"Поток фоновый - {z.IsBackground}\n" +
                              $"Поток запущен - {z.IsAlive}\n" +

                              $"Поток приостановлен - {z.IsThreadPoolThread}\n");

        }
        public static void PrintSimpleNumbers()
        {
            var first = new Thread(ShowInfo);
            first.Start(Thread.CurrentThread);
            first.Join();

            Console.WriteLine("Введите n:");
            int n = int.Parse(Console.ReadLine());
            // Проверка на простоту
            for (int i = 2; i < n; i++)
            {
                bool isPrime = true;
                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    Console.WriteLine(i);
                    Thread.Sleep(100);
                }
            }
        }

        /*4)Создайте два потока. Первый выводит  четные числа, второй нечетные  до n и 
        записывают их  в общий файл и на консоль.Скорость расчета чисел у потоков – разная.*/
        public static void ThoThreads()
        {
            // Создаем и запускаем потоки для вывода четных и нечетных чисел
            var first = new Thread(OddNumbers)
            {
                Priority = ThreadPriority.Highest
            };
            var two = new Thread(EvenNumbers);

            first.Start();
            two.Start();

            first.Join();
            two.Join();

            FirstlyEvenSecondlyOdd();
            ShowOneByOne();
        }

        private static void ShowOneByOne()
        {
            var mutex = new Mutex();
            var even = new Thread(() => ShowNumbersWithMutex(mutex, 0, 15, 2, 0, "Четное: "));
            var odd = new Thread(() => ShowNumbersWithMutex(mutex, 1, 10, 2, 200, "Нечетное: "));

            odd.Start();
            even.Start();

            even.Join();
            odd.Join();
        }

        private static void ShowNumbersWithMutex(Mutex mutex, int start, int end, int step, int delay, string prefix)
        {
            for (var i = start; i < end; i += step)
            {
                mutex.WaitOne();
                Console.WriteLine($"{prefix} {i,2}");
                Thread.Sleep(delay);
                mutex.ReleaseMutex();
            }
        }

        private static void ShowNumbersWithoutLock(int start, int end, int step, int delay, string prefix)
        {
            for (var i = start; i < end; i += step)
            {
                Console.WriteLine($"{prefix} {i,2}");
                Thread.Sleep(delay);
            }
        }

        public static void OddNumbers()
        {
            string txt = string.Empty;
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(200);
                if (i % 2 != 0)
                {
                    txt += $"Нечетное: {i,2} ";
                    Console.WriteLine($"Нечетное: {i,2} ");
                }
            }
            txt += "\n";
            File.AppendAllText(name_file, txt);
        }

        public static void EvenNumbers()
        {
            string txt = string.Empty;
            for (int i = 0; i < 15; i++)
            {
                Thread.Sleep(300);
                if (i % 2 == 0)
                {
                    txt += $"Четное: {i,2} ";
                    Console.WriteLine($"Четное: {i,2} ");
                }
            }
            txt += "\n";
            File.AppendAllText(name_file, txt);
        }

        private static void FirstlyEvenSecondlyOdd()
        {
            var even = new Thread(() => ShowNumbersWithoutLock(0, 15, 2, 0, "Четное: "));
            var odd = new Thread(() => ShowNumbersWithoutLock(1, 10, 2, 200, "Нечетное: "));

            even.Start();
            even.Join();

            odd.Start();
            odd.Join();
        }

        public static void ReadFile()
        {
            var file = File.ReadAllText(name_file);
            Console.WriteLine(file);
        }
    }

}
