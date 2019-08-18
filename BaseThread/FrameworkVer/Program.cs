using FrameworkVer.D1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkVer
{
    class Program
    {
        static void Main(string[] args)
        {
            //创建线程
            //BaseThread.CreateThread();
            //线程休眠
            //BaseThread.SleepThread();
            //线程等待
            //BaseThread.AwaitThread();
            //中止线程core的控制台不支持
            //BaseThread.AbortThread();
            //检查线程状态
            //BaseThread.CheckThreadState();
            //线程优先级
            //BaseThread.SetThreadPriority();
            //前台线程和后台线程
            BaseThread.qahThread();
        }
    }
}
