using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class PC : Technic
    {
        public string Description { get; set; }

        public PC() { Price = 1230; Name = "Lenovo"; Description = "Intel-5, GTX-1650"; }

        public PC(int price, string name, string description, string made) 
        { 
            Price = price;
            Name = name;
            Description = description;  
            Made = made;
        }

        public override void DisplayInfo()
        {
            throw new NotImplementedException();
        }
        public override string ToString()
        {
            return $"{GetType()} {Name} {Price} {Description} {Made}";
        }

    }
}
