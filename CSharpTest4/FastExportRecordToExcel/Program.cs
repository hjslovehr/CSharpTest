using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastExportRecordToExcel
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //FastExport();

                var begin = DateTime.Now.Ticks;
                int recordCount = 10000 * 4;     // 9000 人，每人 4 次进出记录
                Console.WriteLine($"导出 {recordCount} 条数据...");
                ExportExcel(recordCount);              
                var end = DateTime.Now.Ticks;
                var timeSpan = new TimeSpan(end - begin);
                Console.WriteLine($"导出 {recordCount} 条数据，耗时 {timeSpan.TotalMilliseconds} ms");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.WriteLine("Press any key to close the application.");
                Console.ReadKey();
            }
        }

        static void FastExport()
        {
            using (StreamWriter fileWrite = new StreamWriter("test.xlsx"))
            {
                StringBuilder sb = new StringBuilder();
                for (var row = 0; row < 100_000; row++)
                {
                    for (var i = (int)'A'; i <= (int)'Z'; i++)
                    {
                        sb.Append($"{((char)i).ToString()}-{(i - (int)'A')}\t");
                    }

                    fileWrite.WriteLine(sb.ToString());
                    sb.Clear();

                    Console.WriteLine($"Write {row + 1} row");
                }
            }
        }

        static void ExportExcel(int recordCount)
        {
            var template_file = "Template\\进出记录.xlsx";

            var now = DateTime.Now;
            var filePath = $"TempFiles\\{now.Year}\\{now.Month}\\{now.Day}\\{now.ToString("HHmmss")}";
            var result_file = $"{filePath}\\进出记录_{DateTime.Now.ToString("yyyyMMddHHmmss")}.xlsx";

            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

            if (!Directory.Exists(filePath + "\\pics"))
            {
                Directory.CreateDirectory(filePath + "\\pics");
            }

            // 模拟文件拷贝
            File.Copy(@".\\pics\image.jpg", $"{filePath}\\pics\\image.jpg");

            var excel = new ExportExtend();
            var result = new ExportResult();
            var table = GetTestData(recordCount);

            excel.ExportExcelByTemplate(table, 1, 0, result_file, "进出记录", template_file, ref result);

            Console.WriteLine("执行结果：");
            var pre_str = "\t";
            Console.WriteLine(pre_str + result.Status);
            if (string.IsNullOrWhiteSpace(result.Message))
            {
                Console.WriteLine(pre_str + result.Message);
            }
            if (null != result.Error)
            {
                Console.WriteLine(pre_str + result.Error.ToString());
            }
        }

        static DataTable GetTestData(int rows)
        {
            DataTable table = new DataTable();

            var cols = new string[] { "人员姓名", "编号", "抓拍事件", "地点", "设备",
                                        "进出状态", "人员基础照片", "抓拍照片" };

            foreach (var col in cols)
            {
                table.Columns.Add(col, typeof(string));
            }

            for (var i = 0; i < rows; i++)
            {
                var row = table.NewRow();

                foreach (var col in cols)
                {
                    row[col] = $"{col}-{(i + 1)}";
                }

                table.Rows.Add(row);
            }

            return table;
        }

    }
}
