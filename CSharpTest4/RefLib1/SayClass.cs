using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefLib1
{
    public class SayClass
    {
        private string Name { get; set; }

        public SayClass(string name)
        {
            this.Name = name;
        }

        public string Say(string something)
        {
            return this.Name + "说: " + something;
        }
    }
}
