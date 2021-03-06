//can swap passengers with others

namespace BusstopTask.Model.Bus
{
    interface ISwappingPassengers:ICarringPassengers
    {
        public void Send(ISwappingPassengers swapper, int count);

        public ISwappingPassengers FindSwapping();

        public ISwappingPassengers SwappingTarget { get; }
    }
}
