using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class  Products: BaseClone, ICloneable
    {
        public string Made { get; set; }
        public Products() { Made = "Belarus"; }
        public Products(string made)
        {
            Made = made;
        }
        public override bool DoClone(object Obj)
        {
            Products products = (Products)Obj;
            Made = products.Made;
            Console.WriteLine("Копирование успешно");
            return true;
        }

        bool ICloneable.DoClone(object Obj)
        {
            Products products = (Products)Obj;
            Console.WriteLine($"Сделано в {products.Made}");
            return true;
        }

    }
}
