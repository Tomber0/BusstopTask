using BusstopTask.Model.Bus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusstopTask.Model.Station
{
    class Station : IStation
    {
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
        private int _passengers;

        public string Name { get; set; }

        public List<IStationRouting> Transports { get; set; }

        public int Capacity { get; init; }

        public void AddPassengers(int passengers)
        {
            Passengers += passengers;
        }

        public bool AddTransport(IStationRouting transport)
        {
            if (Capacity<(Transports.Count+1))
            {
                Transports.Add(transport);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void RemovePassengers(int passengers)
        {
            Passengers -= passengers;
        }

        public void RemoveTransport(IStationRouting transport)
        {
            Transports.Remove(transport);
        }
    }
}
