//Can carry passengers
namespace BusstopTask.Bus
{
    interface ICarringPassengers
    {
        public int Passengers {get;}

        public void GetPassengers(int passengers);

        public void DropPassengers(int passengers);
    }
}
