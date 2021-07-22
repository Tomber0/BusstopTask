//bus can drive between stations
using BusstopTask.Route;
using BusstopTask.Station;

namespace BusstopTask.Bus
{
    interface IStationRouting
    {
        public IRoute Route { get; set; }

        public IStation GetNextStation(IRoute route);

        public IStation CurrentStation { get; }

        public void MoveToStation(IStation station);
   }
}
