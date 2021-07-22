using BusstopTask.Route;
using BusstopTask.Station;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BusstopTask.Bus
{
    class Bus : IBus, IStationRouting, IWaitable, ISwappingPassengers
    {
        public string Name { get; private set; }
        public IRoute Route { get; set; }

        public IStation CurrentStation { get; set; }

        public ISwappingPassengers SwappingTarget { get; set; }

        public int Passengers
        {
            get
            {
                return _passengers;
            }
            set
            {
                if (_passengers > 0)
                {
                    _passengers = value;
                }
            }
        }

        public int Capacity 
        {
            get 
            {
                return _capacity; 
            } 
            set 
            {
                if (_capacity>0)
                {
                    _capacity = value;
                }
            } 
        }
        private int _passengers;
        private int _capacity;
        public void Run()
        {
            
        }

        public IStation GetNextStation(IRoute route)
        {
            throw new NotImplementedException();
        }

        public void MoveToStation(IStation station)
        {
            throw new NotImplementedException();
        }

        public void Wait(int time)
        {
            Thread.Sleep(time);
        }

        public void Send(ISwappingPassengers swapper, int count)
        {
            throw new NotImplementedException();
        }

        public ISwappingPassengers FindSwapping()
        {
            throw new NotImplementedException();
        }

        public void GetPassengers(int passengers)
        {
            throw new NotImplementedException();
        }

        public void DropPassengers(int passengers)
        {
            throw new NotImplementedException();
        }

        public Bus(string name, int capacity) 
        {
            Name = name;
            Capacity = capacity;
        }
    }
}
