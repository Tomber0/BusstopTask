using BusstopTask.Model.Bus;
using BusstopTask.Model.Station;
using System.Collections.Generic;

namespace BusstopTask.Model.Route
{
    class Route : IRoute
    {
        public Route(string name) 
        {
            Name = name;
            Transports = new List<IStationRouting>();
            Stations = new List<IStation>();
        }

        public string Name { get; set; }

        public List<IStationRouting> Transports { get; set; }
        
        public List<IStation> Stations { get; set; }
    }
}
