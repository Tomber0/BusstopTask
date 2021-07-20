//can swap passengers with others

namespace BusstopTask.Bus
{
    interface ISwappingPassengers
    {
        public void Swap(ISwappingPassengers swapper, int count);

        public ISwappingPassengers FindSwapping();

        public ISwappingPassengers SwappingTarget { get; }
    }
}
