using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Tablet: Technic, ITablet 
    {

        public string System {  get; set; }

        public Tablet()
        {
            Name = string.Empty; Price = 0; System = string.Empty; Made = string.Empty;
        }

        public Tablet(string name, int price, string system, string made)
        {
            Name=name; Price=price; System=system; Made=made;
        }
        public override void DisplayInfo()
        {
            Console.WriteLine(ToString());
        }
        public override string ToString()
        {
            return $"{GetType()} {Name} {Price} {System} {Made}";
        }
        
        void ITablet.BrowseInternet()
        {
            Console.WriteLine("Сюрфинг в Интернете на планшете...");
        }
        public void TurnOn()
        {
            Console.WriteLine("Включение планшета...");
        }

        public void TurnOff()
        {
            Console.WriteLine("Выключение планшета...");
        }

        public void BrowseInternet()
        {
            Console.WriteLine("Сюрфинг в Интернете на планшете...");
        }

        public void RunApp(string appName)
        {
            Console.WriteLine($"Запущен {appName} на планшете...");
        }
    }
}
