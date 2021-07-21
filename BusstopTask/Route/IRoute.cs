
//
using BusstopTask.Bus;
using BusstopTask.Station;
using System.Collections.Generic;

namespace BusstopTask.Route
{
    interface IRoute
    {
        public string Name { get; }

        public List<IStationRouting> Transports { get; set; }

        public List<IStation> Stations { get; set; }
    }
}
