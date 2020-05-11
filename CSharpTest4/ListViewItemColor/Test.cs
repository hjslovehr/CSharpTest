using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListViewItemColor
{
    public class Test
    {
        public Action<string, int> Process { get; set; }

        public void Do(int count)
        {
            Task.Run(() =>
            {
                for (var i = 0; i < count; i++)
                {
                    if (0 == (i % 3))
                    {
                        Process?.Invoke($"{nameof(Test)}.{nameof(Do)} >> {(i + 1).ToString()}", 2);
                    }
                    else if (0 == (i % 5))
                    {
                        Process?.Invoke($"{nameof(Test)}.{nameof(Do)} >> {(i + 1).ToString()}", 3);
                    }
                    else
                    {
                        Process?.Invoke($"{nameof(Test)}.{nameof(Do)} >> {(i + 1).ToString()}", 1);
                    }
                }
            });
        }
    }
}
