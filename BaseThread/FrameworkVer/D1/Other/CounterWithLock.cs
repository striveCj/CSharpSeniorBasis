using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkVer.D1.Other
{
    class CounterWithLock:CounterBase
    {
        private readonly object _asyncRoot = new object();
        public int Count { get; private set; }
        public override void Decrement()
        {
            lock (_asyncRoot)
            {
                Count--;
            }
        }

        public override void Increment()
        {
            lock (_asyncRoot)
            {
                Count++;
            }
        }
    }
}
