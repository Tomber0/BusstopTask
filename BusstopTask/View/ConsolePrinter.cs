using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusstopTask.View
{
    class ConsolePrinter:Printer
    {
        public static object locker;

        public static object GetLock() 
        {
            return locker;
        }

        public override void Print(string message)
        {
            Console.WriteLine(message);
        }
    }
}
