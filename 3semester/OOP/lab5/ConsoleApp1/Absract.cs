using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public abstract class BaseClone
    {
        public virtual bool DoClone(object Obj)
        {
            Console.WriteLine("Копирование нет");
            return false;
        }
    }
}
