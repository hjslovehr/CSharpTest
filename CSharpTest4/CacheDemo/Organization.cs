using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheDemo
{
    public class Organization
    {
        public Guid ID { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public Guid? PID { get; set; }

    }
}
