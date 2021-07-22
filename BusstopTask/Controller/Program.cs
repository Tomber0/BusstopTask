using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusstopTask.Model.Bus;
using BusstopTask.Model.Route;
using BusstopTask.Model.Station;
using BusstopTask.View;

namespace BusstopTask.Controller
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsolePrinter printer = new ConsolePrinter();
            Route route1 = new Route("Route 1");

            Station station1 = new Station("Station 1",3, 10);
            Station station2 = new Station("Station 2",3, 10);
            Station station3 = new Station("Station 3",4, 10);


            Bus bus1 = new Bus("Bus 1", 4, 0, printer.Print);
            Bus bus2 = new Bus("Bus 2", 5, 0, printer.Print);
            Bus bus3 = new Bus("Bus 3", 6, 0, printer.Print);
            Bus bus4 = new Bus("Bus 4", 3, 0, printer.Print);

            bus1.Route = route1;
            bus2.Route = route1;
            bus3.Route = route1;
            bus4.Route = route1;

            route1.Transports.AddRange(new List<Bus> { bus1, bus2,bus3,bus4 });
            route1.Stations.AddRange(new List<Station> { station1, station2, station3 });


            Parallel.Invoke(()=>bus1.Run(), ()=>bus2.Run(), ()=>bus3.Run(),()=> bus4.Run());

/*            await Task.Run(() => bus1.Run());
            await Task.Run(() => bus2.Run());
            await Task.Run(() => bus3.Run());
*/        

        }
    }
}
