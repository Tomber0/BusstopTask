﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusstopTask
{
    interface IPrinter
    {
        public void Print(string message);

        public void Print(string message,ConsoleColor color);
    }
}
