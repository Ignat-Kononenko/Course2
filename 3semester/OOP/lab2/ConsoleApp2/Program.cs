using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {

        class A
        {
            public A() { Console.WriteLine("A"); }
            static A() { Console.WriteLine("A static"); }
        }
        static void Main(string[] args)
        {
            new A();

        }
        class Points
        {
            public readonly int a = 10;
            public static readonly Int32 b = new Int32();
            public static string c = "New";
            public Points()
            {
                c = "method";
                a = 20;
              /*  b = 30; // error*/
            }
        }

    }
}
