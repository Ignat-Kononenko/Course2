using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public interface ICloneable                                // поведение
    {
        bool DoClone(object Obj);
    }

    interface ITablet
    {
        void TurnOn();
        void TurnOff();
        void BrowseInternet();
        void RunApp(string AppName);
    }
}
