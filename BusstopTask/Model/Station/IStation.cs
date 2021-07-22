using System.Collections.Generic;
using BusstopTask.Model.Bus;

namespace BusstopTask.Model.Station
{
    interface IStation
    {
        public int Passengers { get;}

        public string Name { get; }

        public void AddPassengers(int passengers);
        
        public void RemovePassengers(int passengers);

        public List<IStationRouting> Transports { get; }

        public bool AddTransport(IStationRouting transport);
        
        public void RemoveTransport(IStationRouting transport);

        public int Capacity { get; init; }
    }
}
