﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkVer.D1.Other
{
    class Counter:CounterBase
    {
        public int Count { get; private set; }
        public override void Decrement()
        {
            Count--;
        }

        public override void Increment()
        {
            Count++;
        }
    }
}
