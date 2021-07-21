using BusstopTask.Bus;
using System.Collections.Generic;

namespace BusstopTask.Station
{
    interface IStation
    {
        public int Passengers { get;}

        public string Name { get; }

        public void AddPassengers(int passengers);
        
        public void RemovePassengers(int passengers);

        public List<ISwappingPassengers> Transports { get; }

        public void AddTransport(ISwappingPassengers transport);
        
        public void RemoveTransport(ISwappingPassengers transport);

        public int Capacity { get; init; }
    }
}
