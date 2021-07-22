
//
using BusstopTask.Model.Bus;
using BusstopTask.Model.Station;
using System.Collections.Generic;

namespace BusstopTask.Model.Route
{
    interface IRoute
    {
        public string Name { get; }

        public List<IStationRouting> Transports { get; set; }

        public List<IStation> Stations { get; set; }
    }
}
