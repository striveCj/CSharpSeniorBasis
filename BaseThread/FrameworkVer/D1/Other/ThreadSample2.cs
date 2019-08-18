using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FrameworkVer.D1.Other
{
   public class ThreadSample2
    {
        private readonly int _iteration;

        public ThreadSample2(int iteration)
        {
            _iteration = iteration;
        }

        public void CountNumbers()
        {
            for (int i = 0; i < _iteration; i++)
            {
                Thread.Sleep(TimeSpan.FromSeconds(0.5));
                Console.WriteLine($"{Thread.CurrentThread.Name} prints {i}");
            }
        }
    }
}
