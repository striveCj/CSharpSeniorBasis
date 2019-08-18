using FrameworkVer.D1.Other;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace FrameworkVer.D1
{
    public class BaseThread
    {
        /// <summary>
        /// 创建线程
        /// </summary>

        public static void CreateThread()
        {
            Thread t1 = new Thread(new ThreadStart(PrintNumbers));//无参数的委托
            t1.Start();

            Thread t2 = new Thread(new ParameterizedThreadStart(PrintNumbers));//有参数的委托
            t2.Start(15);
            Console.ReadLine();
        }
        /// <summary>
        /// 线程休眠
        /// </summary>
        public static void SleepThread()
        {
            Thread t1 = new Thread(PrintNumberSWithDelay);
            t1.Start();
            PrintNumbers();
            Console.ReadLine();
        }
        /// <summary>
        /// 线程等待
        /// </summary>
        public static void AwaitThread()
        {
            Console.WriteLine("线程等待开始工作");
            Thread t = new Thread(PrintNumberSWithDelay);
            t.Start();
            //使用Join暂停线程，会等到t运行完之后在执行后面的线程操作
            t.Join();
            PrintNumbers();
            Console.WriteLine("线程完成");
            Console.ReadLine();
        }
        /// <summary>
        /// 中止线程
        /// </summary>
        public static void AbortThread()
        {
            Console.WriteLine("开始运行程序");
            Thread t1 = new Thread(PrintNumberSWithDelay);
            t1.Start();
            Thread.Sleep(TimeSpan.FromSeconds(6));
            t1.Abort();
            Console.WriteLine("线程t1终止线程");
            Thread t2 = new Thread(new ThreadStart(PrintNumbers));
            PrintNumbers();
            Console.ReadLine();
        }
        /// <summary>
        /// 检查线程状态
        /// </summary>
        public static void CheckThreadState()
        {
            Console.WriteLine("程序开始运行");
            Thread t1 = new Thread(PrintNumbersWithStatus);
            Thread t2 = new Thread(DoNothing);
            Console.WriteLine(t1.ThreadState.ToString());//获取实例线程状态
            t2.Start();
            t1.Start();
            for (int i = 0; i < 30; i++)
            {
                Console.WriteLine(t1.ThreadState.ToString());

            }
            Thread.Sleep(TimeSpan.FromSeconds(6));
            t1.Abort();
            Console.WriteLine("线程t1终结");
            Console.WriteLine(t1.ThreadState.ToString());
            Console.WriteLine(t2.ThreadState.ToString());
            Console.ReadLine();

        }
        /// <summary>
        /// 线程优先级
        /// </summary>
        public static void SetThreadPriority()
        {
            Console.WriteLine($"当前线程优先级{Thread.CurrentThread.Priority}");
            Console.WriteLine("运行所有可用核心");
            RunThreads();
            Thread.Sleep(TimeSpan.FromSeconds(2));
            Console.WriteLine("运行单核心");
            Process.GetCurrentProcess().ProcessorAffinity = new IntPtr(1);
            RunThreads();
            Console.ReadLine();
        }
        /// <summary>
        /// 前台线程和后台线程
        /// </summary>
        public static void qahThread()
        {
            var sampleForground = new ThreadSample2(10);
            var sampleBackground = new ThreadSample2(20);
            var t1 = new Thread(sampleForground.CountNumbers);
            t1.Name = "ForegroundThread";   //没有明确声明的均为前台线程
            var t2 = new Thread(sampleBackground.CountNumbers);
            t2.Name = "BackgroundThread";
            t2.IsBackground = true;    //设置为后台线程

            t1.Start();
            t2.Start();
        }

        /// <summary>
        /// 运行线程
        /// </summary>
        static void RunThreads()
        {
            var sample = new ThreadSample();
            var t1 = new Thread(sample.CountNumbers);
            t1.Name = "Thread One";
            var t2 = new Thread(sample.CountNumbers);
            t2.Name = "Thread Two";

            t1.Priority = ThreadPriority.Highest;//设置线程的优先级
            t2.Priority = ThreadPriority.Lowest;
            t1.Start();
            t2.Start();
            Thread.Sleep(TimeSpan.FromSeconds(2));
            sample.Stop();

        }
        /// <summary>
        /// 输出数字方法不带参数
        /// </summary>
        static void PrintNumbers()
        {
            Console.WriteLine("开始工作...");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }
        }
        /// <summary>
        /// 输出数字方法带参数，使用ParameterizedThreadStart，定义的参数必须为Object
        /// </summary>
        /// <param name="count"></param>
        static void PrintNumbers(Object count)
        {
            Console.WriteLine("开始工作...");
            for (int i = 0; i < Convert.ToInt32(count); i++)
            {
                Console.WriteLine(i);
            }
        }
        /// <summary>
        /// 线程休眠
        /// </summary>
        static void PrintNumberSWithDelay()
        {
            Console.WriteLine("开始运行...");
            for (int i = 0; i < 10; i++)
            {
                //每运行一次线程休眠2秒
                Thread.Sleep(TimeSpan.FromSeconds(2));
                Console.WriteLine(i);
            }
        }
        /// <summary>
        /// 获取线程状态
        /// </summary>
        static void PrintNumbersWithStatus()
        {
            Console.WriteLine("开始...");
            Console.WriteLine(Thread.CurrentThread.ThreadState.ToString());//获取当前线程状态
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(TimeSpan.FromSeconds(2));
                Console.WriteLine(i);
            }
        }

        /// <summary>
        /// 啥事不做就休眠
        /// </summary>
        static void DoNothing()
        {
            Thread.Sleep(TimeSpan.FromSeconds(2));
        }
    }
}
