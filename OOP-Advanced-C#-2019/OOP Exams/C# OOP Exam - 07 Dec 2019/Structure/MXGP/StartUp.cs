﻿using System;

namespace MXGP
{
    using Models.Motorcycles;
    using MXGP.Core;

    public class StartUp
    {
        public static void Main()
        {
            var engine = new Engine();
            engine.Run();
        }
    }
}
