//bus can drive between stations
using BusstopTask.Model.Route;
using BusstopTask.Model.Station;

namespace BusstopTask.Model.Bus
{
    interface IStationRouting
    {
        public IRoute Route { get; set; }

        public IStation GetNextStation(IRoute route);

        public IStation CurrentStation { get; }

        public void MoveToStation(IStation station);
   }
}
