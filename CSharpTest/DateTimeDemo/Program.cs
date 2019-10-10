using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateTimeDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine((int)DateTime.Now.DayOfWeek);

            Console.WriteLine(WeekOfYear(DateTime.Now));

            var ci = new CultureInfo("zh-CN");

            var dt = DateTime.Parse("2019-09-06");

            var date = dt.AddDays(- 1 * (int)dt.DayOfWeek);

            Console.WriteLine();

            Console.WriteLine(date.ToString());

            Console.WriteLine(ci.Calendar.AddWeeks(DateTime.Parse("2019-01-01"), 36));

            var ret = ci.Calendar.AddWeeks(date, -1);
            Console.WriteLine(ret.ToString());

            Console.WriteLine();

            var year = 2019;
            var weekNum = 12;

            var a = GetWeekFirstDay(year, weekNum);

            Console.WriteLine($"{year} Year {weekNum} Week First Day: " + a.ToString("yyyy-MM-dd"));


            Form1 frm = new Form1();
            frm.ShowDialog();


            Console.ReadKey();
        }

        public static int WeekOfYear(DateTime dt, CultureInfo ci = null)
        {
            if (null == ci)
            {
                ci = new CultureInfo("zh-CN");
            }

            return ci.Calendar.GetWeekOfYear(dt, ci.DateTimeFormat.CalendarWeekRule, ci.DateTimeFormat.FirstDayOfWeek);
        }

        public static DateTime GetWeekFirstDay(int year, int weekNum)
        {
            var now = DateTime.Now;
            int currWeek = WeekOfYear(now);
            var currWeekFirstDay = now.AddDays(-1 * (int)now.DayOfWeek);
            int addDays = (weekNum - currWeek) * 7;

            return currWeekFirstDay.AddDays(addDays);
        }


    }
}
