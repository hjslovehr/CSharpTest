using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIShowMessageInvoke
{
    public class UIShowMessageTest
    {
        private volatile bool _cancelTestFlag;

        public bool IsRun { get; set; }

        public void Cancel()
        {
            _cancelTestFlag = true;
        }

        public void Reset()
        {
            _cancelTestFlag = false;
        }

        public void Test(int count)
        {
            IsRun = true;
            
            for (int i = 0; i < count; i++)
            {
                if (_cancelTestFlag)
                {
                    break;
                }

                ShowMessageInvoke.Invoke($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")} | loop {i + 1}");
            }

            IsRun = false;
        }
    }
}
