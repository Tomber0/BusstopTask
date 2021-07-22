using System.Collections.Generic;

namespace BusstopTask.Model.Bus
{
    interface IBus
    {
        public void Run();

        public string Name { get; }
    }
}
