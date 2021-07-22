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
        public delegate void Print(string message);
        public event Print OnMessage;

        public int Direction { get; set; } = 1;

        public int Position { get; set; } = 0;

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
        private Random _random = new Random();
        private int _counter = 1000000;
        public void Run()
        {
            while (_counter>0)
            {
                lock (ConsolePrinter.GetLock())
                {

                    IStation station;
                    if (Route == null)
                    {
                        //cant move, no route
                        //show msg
                        OnMessage("");
                        break;
                    }
                    if (CurrentStation == null)
                    {
                        Position = -1;
                        station = GetNextStation(Route);
                        MoveToStation(station);
                    }
                    //aproaching station
                    int numberToDrop = _random.Next(0, Passengers + 1);
                    int numberToGet = _random.Next(0, Passengers + 1);

                    Wait(1000);
                    if (DropPassengers(numberToDrop))
                    {
                        CurrentStation.AddPassengers(numberToDrop);
                    }

                    if (GetPassengers(numberToGet))
                    {
                        CurrentStation.RemovePassengers(numberToGet);
                    }

                    //end lock

                    //after
                    station = GetNextStation(Route);
                    MoveToStation(station);


                    _counter--;
                }
            }

        }

        public IStation GetNextStation(IRoute route)
        {

            Position += 1;//Direction;
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
            if (Passengers - passengers < 0 )
            {
                
                return false;
                //too low
            }
            else
            {
                Passengers -= passengers;
                return true;
            }
        }

        public Bus(string name, int capacity,int passengers,Print printer) 
        {
            Name = name;
            Capacity = capacity;
            Passengers = passengers;
            OnMessage += printer;
        }
        public Bus() 
        {
            Name = "Bus";
            Capacity = 10;
            Passengers = 5;
        }
    }
}
