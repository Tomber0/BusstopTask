//Can carry passengers
namespace BusstopTask.Bus
{
    interface ICarringPassengers
    {
        public int Passengers {get;}
        
        public int Capacity {get;}

        public bool GetPassengers(int passengers);

        public bool DropPassengers(int passengers);
    }
}
