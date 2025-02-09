using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public abstract partial class Technic : Products
    {
        public int Price { get; set; }
        public string Name { get; set; }
        public Lifespan Lf { get; set; }

        public abstract void DisplayInfo();
        public override string ToString()
        {
            return $"{GetType()} {Price} {Name}";
        }

    }
}
