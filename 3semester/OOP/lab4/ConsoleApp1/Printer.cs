using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    sealed class Printer                                    // запечатали
    {
        public void IAmPrinting(BaseClone someobj)
        {
            Console.WriteLine(someobj.ToString());
            /*Console.WriteLine(someobj.GetType());*/
        }
    }
}
