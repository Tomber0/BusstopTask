using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BusstopTask.Model.Route;
using BusstopTask.View;
using BusstopTask.Model.Station;

namespace BusstopTask.Model.Bus
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
                if (value > 0)
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
                if (value>0)
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
                        OnMessage($"Bus {Name} have no route!\nBus have lost");
                        break;
                    }
                    if (CurrentStation == null)
                    {
                        OnMessage($"Bus {Name} on no station!");

                        Position = -1;
                        station = GetNextStation(Route);
                        MoveToStation(station);
                        Wait(100);
                        OnMessage($"Bus {Name} have moved to {station.Name}");
                    }
                    //aproaching station
                    int numberToDrop = _random.Next(0, Passengers + 1);
                    int numberToGet = _random.Next(0, CurrentStation.Passengers + 1);//bug

                    Wait(100);
                    if (DropPassengers(numberToDrop))
                    {
                        CurrentStation.AddPassengers(numberToDrop);
                        OnMessage($"Bus {Name} have dropped {numberToDrop} passengers");
                        Wait(250);

                    }

                    if (GetPassengers(numberToGet))
                    {
                        CurrentStation.RemovePassengers(numberToGet);
                        OnMessage($"Bus {Name} have gotten {numberToGet} passengers");
                        Wait(250);

                    }

                    //add swap


                    //end lock

                    //after

                    OnMessage($"Bus {Name} moving to next station");
                    Wait(250);

                    station = GetNextStation(Route);
                    OnMessage($"Bus {Name}: next station is {station.Name}");
                    Wait(250);
                    MoveToStation(station);
                    OnMessage($"Bus {Name} moving to {station.Name}");
                    Wait(250);
                    _counter--;
                }
                Wait(250);

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
