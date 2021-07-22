using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusstopTask
{
    class ConsolePrinter 
    {
        public static void Print(string message)
        {
            Console.WriteLine(message);
        }
        public static object locker;

        public static object GetLock() 
        {
            return locker;
        }
    }
}
