using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WndProcTest
{
    public enum UserMessage
    {
        USER_MESSAGE = 1024 + 1000,

        USER_MESSAGE_DATA = USER_MESSAGE + 1,

        USER_MESSAGE_ERROR = USER_MESSAGE + 2,

        USER_MESSAGE_DEFAULT = USER_MESSAGE + 3
    }
}
