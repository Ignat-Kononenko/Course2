using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Scaner : Technic
    {
        public string Model { get; set; }

        public Scaner():base() { Price = 600; Name = "Scanf"; Model = "AA4"; }

        public Scaner(int price, string name, string model, string made):base()
        {
            Price = price;
            Name = name;
            Model = model;
            Made = made;
        }

        public override void DisplayInfo() 
        {
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            return $"{GetType()} {Name} {Price} {Model} {Made}";
        }
    }
}
