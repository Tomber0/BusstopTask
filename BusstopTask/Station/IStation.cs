
namespace BusstopTask.Station
{
    interface IStation
    {
        public int Passengers { get;}

        public string Name { get; }

        public void AddPassengers(int passengers);
        
        public void RemovePassengers(int passengers);
    }
}
