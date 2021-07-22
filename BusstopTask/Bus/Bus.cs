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
        public int Direction { get; set; }

        public int Position { get; set; }

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

            Position += Direction;
            if (Position>=route.Stations.Count)
            {
                Position = 0;
                //start over
            }
            return route.Stations[Position];
        }

        public void MoveToStation(IStation station)
        {
            CurrentStation = station;
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

        public bool GetPassengers(int passengers)
        {
            if (passengers+Passengers<Capacity)
            {
                Passengers += passengers;
                return true;
            }
            else
            {
                return false;

                //too big
            }
        }

        public bool DropPassengers(int passengers)
        {
            throw new NotImplementedException();
        }

        public Bus(string name, int capacity,int passengers) 
        {
            Name = name;
            Capacity = capacity;
            Passengers = passengers;
        }

        public Bus() 
        {
            Name = "Bus";
            Capacity = 10;
            Passengers = 5;
        }
    }
}
