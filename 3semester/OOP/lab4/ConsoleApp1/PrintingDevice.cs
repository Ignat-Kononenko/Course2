using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class PrintingDevice : Technic
    {

        public string Type { get; set; }

        public PrintingDevice() { Price = 699; Name = "Printo"; Type = "kgkg"; Made = "Russia"; }

        public PrintingDevice(int price, string name, string type, string made)
        {
            Price = price; Name = name; Type = type; Made = made;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            return $"{GetType()} {Name} {Price} {Type} {Made}";
        }
    }
}
