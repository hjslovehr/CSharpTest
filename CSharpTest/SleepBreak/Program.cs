using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SleepBreak
{
    class Program
    {
        static bool _sleep = false;

        static void Main(string[] args)
        {
            _sleep = true;

            Task.Run(() =>
            {
                Console.WriteLine("{0} LongSleep Begin ", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                LongSleep(10000, ref _sleep);
                Console.WriteLine("{0} LongSleep End ", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            });

            Console.WriteLine("Press any key to stop sleep.");
            Console.ReadKey();
            _sleep = false;

            Console.WriteLine("Press any key to close the application.");
            Console.ReadKey(true);


        }

        /// <summary>
        /// 可提前结束的长休眠
        /// </summary>
        /// <param name="ms">毫秒数</param>
        /// <param name="isSleep">提前终止休眠标识</param>
        static void LongSleep(int ms, ref bool isSleep)
        {
            const int baseTime = 10;

            if (ms < baseTime)
            {
                System.Threading.Thread.Sleep(ms);
            }
            else
            {
                int loopCount = ms / baseTime;  // 除以 baseTime，代表是 baseTime 毫秒的多少倍
                int surplusMS = ms % baseTime;  // 剩余毫秒数

                while (isSleep && loopCount > 0)
                {
                    System.Threading.Thread.Sleep(baseTime);
                    --loopCount;
                }

                if (isSleep && surplusMS > 0)
                {
                    System.Threading.Thread.Sleep(surplusMS);
                }
            }
        }

    }
}
