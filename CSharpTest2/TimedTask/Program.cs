using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimedTask
{
    class Program
    {
        static volatile bool _run = true;

        static int _interval = 3000;

        static volatile int _workState = 0;

        static Task _watch = null;

        static void Main(string[] args)
        {
            try
            {
                Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.WriteLine("Press any key to close the application.");
            Console.ReadKey(true);

            _run = false;
            System.Threading.Thread.Sleep(20);
        }

        static void Run()
        {
            _watch = Task.Run(() =>
            {
                var lastState = _workState;
                while (_run)
                {
                    System.Threading.Thread.Sleep(1);

                    if (lastState != _workState)
                    {
                        lastState = _workState;

                        if (0 == lastState)
                        {
                            Console.WriteLine("Current work task state is 'Finishd' ");
                        }
                        else
                        {
                            Console.WriteLine("Current work task state is 'Running' ");
                        }
                    }
                }
            });

            WorkTask();
        }

        static async Task WorkTask()
        {
            await Task.Delay(1000);

            while (_run)
            {
                var beginTime = DateTime.Now;

                Console.WriteLine("{0} : Do work begin!", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                DoWork();

                Console.WriteLine("{0} : Do work end!", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                Console.WriteLine();

                var endTime = DateTime.Now;
                var milliseconds = (endTime - beginTime).TotalMilliseconds;
                if (milliseconds <= _interval)
                {
                    var delayValue = _interval - Convert.ToInt32(milliseconds);
                    await Task.Delay(delayValue);
                }

                await Task.Delay(2);
            }
        }

        static void DoWork()
        {
            _workState = 1;

            Console.WriteLine("{0} : Do work!", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            System.Threading.Thread.Sleep(2000);

            _workState = 0;
        }

    }
}
