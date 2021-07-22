using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusstopTask.Bus
{
    class Bus : IBus, IStationRouting, IWaitable, ISwappingPassengers
    {
        public string Name { get; private set; }

        public void Run()
        {
            
        }

        public Bus(string name, int capacity) 
        {
        
        }
    }
}
