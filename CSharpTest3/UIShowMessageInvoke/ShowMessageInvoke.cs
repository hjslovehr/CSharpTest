using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIShowMessageInvoke
{
    public interface IShowMessage
    {
        Action<string> ShowMessage { get; set; }
    }

    public static class ShowMessageInvoke
    {
        public static IShowMessage ShowMessage { get; set; }

        public static void Invoke(string message)
        {
            ShowMessage?.ShowMessage?.Invoke(message);
        }
    }
}
