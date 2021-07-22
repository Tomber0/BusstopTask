using BusstopTask.Bus;
using BusstopTask.Station;
using System.Collections.Generic;

namespace BusstopTask.Route
{
    class Route : IRoute
    {
        public Route(string name) 
        {
            Name = name;
        }

        public string Name { get; set; }

        public List<IStationRouting> Transports { get; set; }
        
        public List<IStation> Stations { get; set; }
    }
}
