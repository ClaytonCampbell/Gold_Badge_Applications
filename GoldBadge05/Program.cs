﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadge02
{
    class Program
    {
        static void Main(string[] args)
        {
            IConsole console = new RealConsole();
            UI ui = new UI(console);
            ui.Run();
        }
    }    
}
