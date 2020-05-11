using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateTimeAndTimeStamp
{
    class Program
    {
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
			finally
			{
				Console.WriteLine();
				Console.WriteLine("按任意键退出程序...");
				Console.ReadKey();
			}
        }

		static void Run()
		{
			var dt = DateTime.Parse("2020-04-29 10:43:59.031");
			var millisecondTimeStamp = DateTimeToMillisecondTimeStamp(dt);
			Console.WriteLine("{0} ==> {1}", "2020-04-29 10:43:59.031", millisecondTimeStamp);
			
			var dtStr = MillisecondTimeStampToDateTime(1588128239031).ToString("yyyy-MM-dd HH:mm:ss.fff");
			Console.WriteLine("{0} ==> {1}", 1588128239031, dtStr);
		}

		/// <summary>
		/// DateTime 转 Unix 秒时间戳
		/// </summary>
		/// <param name="dt"></param>
		/// <returns></returns>
		static long DateTimeToSecondTimeStamp(DateTime dt)
		{
			var startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
			long timeStamp = (long)((dt - startTime).TotalSeconds);
			return timeStamp;
		}

		/// <summary>
		/// Unix 秒时间戳转 DateTime
		/// </summary>
		/// <param name="timeStamp"></param>
		/// <returns></returns>
		static DateTime SecondTimeStampToDateTime(long timeStamp)
		{
			var startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
			var dt = startTime.AddSeconds(timeStamp);
			return dt;
		}

		/// <summary>
		/// DateTime 转 Unix 毫秒时间戳
		/// </summary>
		/// <param name="dt"></param>
		/// <returns></returns>
		static long DateTimeToMillisecondTimeStamp(DateTime dt)
		{
			var startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
			long timeStamp = (long)((dt - startTime).TotalMilliseconds);
			return timeStamp;
		}

		/// <summary>
		/// Unix 毫秒时间戳转 DateTime
		/// </summary>
		/// <param name="timeStamp"></param>
		/// <returns></returns>
		static DateTime MillisecondTimeStampToDateTime(long timeStamp)
		{
			var startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
			var dt = startTime.AddMilliseconds(timeStamp);
			return dt;
		}

	}
}
