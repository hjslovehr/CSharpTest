using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskDelayCancel
{
    using System.Threading;

    class Program
    {
        static CancellationTokenSource _source;

        static void Main(string[] args)
        {
            _source = new CancellationTokenSource();

            try
            {
                Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.WriteLine("Press '1' cancel delay.");
            var key = Console.ReadKey(true);
            if (ConsoleKey.D1 == key.Key)
            {
                Console.WriteLine("Task delay cancel.");
                _source.Cancel();
            }

            Console.WriteLine("Press any key to close the application.");
            Console.ReadKey(true);
        }

        static void Run()
        {
            Task.Run(Test);
        }

        static async Task Test()
        {
            Console.WriteLine("{0} : Tesk begin", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));

            try
            {
                await Task.Delay(5000, _source.Token);
            }
            catch (TaskCanceledException ex)
            {
                Console.WriteLine("{0} : {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

            Console.WriteLine("{0} : Tesk end", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
        }

    }
}
