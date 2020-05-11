/*
 * 由SharpDevelop创建。
 * 用户： DLAX
 * 日期: 2020/2/12
 * 时间: 16:29
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace DateTimeTest
{
    class Program
    {
        public static void Main(string[] args)
        {
            var now = DateTime.Now;
            Console.WriteLine("Current datetime" + " ==> " + now.ToString("yyyy-MM-dd HH:mm:ss:ffff"));

            var timeStamp = DateTimeToUnixTimeStamp(now);
            Console.WriteLine(now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + " ==> " + timeStamp);

            DateTime dt = UnixTimeStampToDateTime(timeStamp);
            Console.WriteLine(timeStamp + " ==> " + dt.ToString("yyyy-MM-dd HH:mm:ss:ffff"));

            DateTime localTime = new DateTime(1970, 1, 1).ToLocalTime();
            var temp = localTime.AddSeconds(timeStamp);
            Console.WriteLine(temp.ToString("yyyy-MM-dd HH:mm:ss:ffff"));

            Console.WriteLine("============================================================");

            while (true)
            {
                Console.WriteLine("Please a datetime(\"yyyy-MM-ddd HH:mm:ss\"):");
                string str = Console.ReadLine();
                var time = Convert.ToDateTime(str);
                var timeStampTemp = DateTimeToUnixTimeStamp(time);
                Console.WriteLine(timeStampTemp);
            }


            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }

        static long DateTimeToUnixTimeStamp(DateTime? dt = null)
        {
            if (null == dt)
            {
                dt = DateTime.Now;
            }

            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1)); // 当地时区
            return (long)(dt.Value - startTime).TotalSeconds; // 相差秒数

        }

        static DateTime UnixTimeStampToDateTime(long unixTimeStamp)
        {
            // 将 1970-1-1 转为当地时间，然后加上时间戳的总秒数，然后转为 DateTime 对象
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1)); // 当地时区
            return startTime.AddSeconds(unixTimeStamp);
        }
    }
}