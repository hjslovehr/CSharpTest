using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test2
{
    public class SYS_USER
    {
        public Guid USERID { get; set; }

        public string CODE { get; set; }

        public string ACCOUNT { get; set; }

        public string PASSWORD { get; set; }

        public string REALNAME { get; set; }

        public int? GENDER { get; set; }

        public string MOBILE { get; set; }

        public DateTime? BIRTHDAY { get; set; }

        public int? ENABLED { get; set; }

        public int? ISDELETED { get; set; }

        public string DESCRIPTION { get; set; }
    }
}
