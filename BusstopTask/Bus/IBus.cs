﻿using System.Collections.Generic;

namespace BusstopTask.Bus
{
    interface IBus
    {
        public void Run();

        public string Name { get; }
    }
}
