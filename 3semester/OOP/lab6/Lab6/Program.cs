using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    public enum TechnicType
    {
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
        static void Main(string[] args)
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

            var scan = new Scaner(500, "ScanMaster", "ff", "Japan")
            {
                Lf = new Lifespan(3, 6),
                Type = TechnicType.Scaner
            };
            controller.AddTechnic(scan);

            var computer = new PC(1200, "PowerPC", "X300", "USA")
            {
                Lf = new Lifespan(5, 0),
                Type = TechnicType.PC
            };
            controller.AddTechnic(computer);

            var tabl = new Tablet("iPad", 700, "Pro", "China")
            {
                Lf = new Lifespan(2, 3),
                Type = TechnicType.Tablet
            };
            controller.AddTechnic(tablet);

            controller.DisplayAllTechnic();
            Console.WriteLine("Итоговая цена: " + controller.TotalPrice());
        }
    }


}
