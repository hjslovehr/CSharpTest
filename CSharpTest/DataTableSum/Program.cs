using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTableSum
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Test();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.WriteLine("Press any key to close the application.");
            Console.ReadKey();
        }

        static void Test()
        {
            List<string> lst = new List<string>();

            var dt = GetTable(lst);

            List<int> result = new List<int>();

            var temp = dt.AsEnumerable();

            lst.ForEach(item =>
            {
                result.Add(temp.Where(it => it["AREADID"].ToString().Equals(item)).Select(it => (int)(it["Col3"])).Sum());
            });
            
        }

        static DataTable GetTable(List<string> list)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn() { ColumnName = "AREADID", DataType = typeof(Guid) });
            dt.Columns.Add(new DataColumn() { ColumnName = "Col1", DataType = typeof(string) });
            dt.Columns.Add(new DataColumn() { ColumnName = "Col2", DataType = typeof(DateTime) });
            dt.Columns.Add(new DataColumn() { ColumnName = "Col3", DataType = typeof(int) });

            var random = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < 4; i++)
            {
                var guid = Guid.NewGuid();

                list.Add(guid.ToString());

                for (int j = 0; j < 5; j++)
                {
                    var row = dt.NewRow();
                    row["AREADID"] = guid;
                    row["Col1"] = $"{i}-{j}";
                    row["Col2"] = DateTime.Now;
                    row["Col3"] = random.Next(0, 10);

                    dt.Rows.Add(row);
                }

            }

            return dt;
        }


    }
}
