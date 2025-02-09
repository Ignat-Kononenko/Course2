using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace ConsoleApp1
{
    public enum TechnicType{
        PC,
        PrintingDevice,
        Scaner,
        Tablet
    }

    public struct Lifespan
    {
        public int Year { get; set; }
        public int Month { get; set; }

        public Lifespan(int year, int month)
        {
            Year = year;
            Month = month;
        }

        public override string ToString()
        {
            return $"{Year} год, {Month} месяц";
        }
    }
     class Program
    {

        public static void FirstLevelMethod()
        {
            try
            {
                SecondLevelMethod();
            }
            catch (MyCustomException ex)
            {
                Console.WriteLine($"Обработка в FirstLevelMethod: {ex.Message}");
                // Проброс исключения выше по стеку вызовов
                throw;
            }
        }

        public static void SecondLevelMethod()
        {
            try
            {
                ThirdLevelMethod();
            }
            catch (MyCustomException ex)
            {
                Console.WriteLine($"Обработка в SecondLevelMethod: {ex.Message}");
                // Проброс исключения выше по стеку вызовов с дополнительным сообщением
                throw new MyCustomException("Ошибка на втором уровне", ex);
            }
        }

        public static void ThirdLevelMethod()
        {
            throw new MyCustomException("Ошибка на третьем уровне");
        }
        static void Main(string[] args)
        {

            try
            {
                PC pc = new PC();

                Printer print = new Printer();
                print.IAmPrinting(pc);

                Products originalProduct = new Products();
                Products cloneProduct = new Products("Japan");


                originalProduct.DoClone(cloneProduct);                        // Вызов метода DoClone из BaseClone


                ((ICloneable)originalProduct).DoClone(cloneProduct);          // Вызов метода DoClone из ICloneable / явная реализация интерфейса

                Console.WriteLine(cloneProduct.Made);

                Technic MyScaner = new Scaner();
                Technic MyPrinterDevice = new PrintingDevice();

                if (MyScaner is Scaner scaner)                                 // Является ли объект MyScaner экземляром класса Scaner. Если проверка успешна, создается новая переменная scaner типа Scaner, которая ссылается на объект myScaner.
                {
                    scaner.DisplayInfo();
                }

                PrintingDevice printer = MyPrinterDevice as PrintingDevice;   // Оператор as пытается преобразовать объект myPrinter к типу Printer. Если преобразование успешно, переменная printer будет ссылаться на объект myPrinter.
                if (printer != null)
                {
                    printer.DisplayInfo();
                }

                Tablet tablet = new Tablet("Apple", 1599, "IOS", "Chine");
                tablet.DisplayInfo();

                ITablet tablet1 = new Tablet();
                tablet1.TurnOn();
                tablet1.BrowseInternet();
                tablet1.RunApp("Minecraft");
                tablet1.TurnOff();

                Container<Technic> container = new Container<Technic>();
                Controller controller = new Controller();

                var scan = new Scaner()
                {
                    Lf = new Lifespan(3, 6),
                    Type = TechnicType.Scaner
                };

                if((string.IsNullOrEmpty(scan.Name) || string.IsNullOrEmpty(scan.Model) || string.IsNullOrEmpty(scan.Made)))
                {
                    throw new ConfirmityException("Заполнено не все"); 
                }
                controller.AddTechnic(scan);

                var computer = new PC(1200, "PowerPC", "X300", "USA")
                {
                    Lf = new Lifespan(5, 0),
                    Type = TechnicType.PC
                };

                if (computer.Price < 0)
                {
                    throw new InvalidDataException("Цена не может быть отрицательной");
                }
                controller.AddTechnic(computer);

                var tabl = new Tablet("iPad", 2000, "Pro", "China")
                {
                    Lf = new Lifespan(2, 3),
                    Type = TechnicType.Tablet
                };

                if (tabl.Price < 0)
                {
                    throw new InvalidDataException("Цена не может быть отрицательной");
                }
                 
                controller.AddTechnic(tablet);

                controller.DisplayAllTechnic();
                Console.WriteLine("Итоговая цена: " + controller.TotalPrice());

                Technic technic = null;
                if(technic != null)
                {
                    throw new NullRefException("Пустая строка");
                }

                int[] numbers = new int[4];
                /*numbers[7] = 9;                           // выход за предел*/

                int y = 0;
               /* int result = controller.TotalPrice() / y;   // деление на ноль*/

                string filePath = "file.txt";
                string content = File.ReadAllText(filePath);

                Debug.Assert(computer.Price > 0);               // логические ошибки

                int value = 10;
         
                Debugger.Break();                               // передает отладчику

                Console.WriteLine("Значение: " + value);

                try
                {
                    FirstLevelMethod();
                }
                catch (MyCustomException ex)
                {
                    Console.WriteLine($"Обработка в Main: {ex.Message}");
                    if (ex.InnerException != null)
                    {
                        Console.WriteLine($"Вложенное исключение: {ex.InnerException.Message}");
                    }
                }

            }
            catch (InvalidDataException ex) when (ex.InnerException != null) 
            {
                Console.WriteLine($"InvalidDataException: {ex.Message}");
            }
            catch(NullRefException ex)
            {
                Console.WriteLine($"NullRefException: {ex.InnerException.Message}");
            }
            catch(ConfirmityException ex)
            {

                Console.WriteLine($"ConfirmityException: { ex.Message}");
            }
            catch(IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
                throw;                                                          // удаление из стека инфы о начальной точке не происходит
            }
            catch(FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Finally отработал");
            }

           
         }
    }
}
