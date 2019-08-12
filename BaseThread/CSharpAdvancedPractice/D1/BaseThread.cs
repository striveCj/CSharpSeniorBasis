using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CSharpAdvancedPractice.D1
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

            Thread t2 = new Thread(new ParameterizedThreadStart(PrintNumbers));
            t2.Start(15);
            Console.ReadLine();
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
        /// 输出数字方法带参数，使用ParameterizedThreadStart，定义的参数必须为object
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
                Thread.Sleep(TimeSpan.FromSeconds(2));
                Console.WriteLine(i);
            }
        }
    }
}
