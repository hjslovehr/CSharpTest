using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeDemo
{
    //[AttributeUsage(AttributeTargets.All)]
    [AttributeUsage(AttributeTargets.Class 
                    | AttributeTargets.Field 
                    | AttributeTargets.Property 
                    | AttributeTargets.Method, 
                    AllowMultiple = true, 
                    Inherited = false)]
    public class MyAttributeTestAttribute : Attribute
    {
        public string CreateUser { get; set; }

        public string CreateTime { get; set; }

        public string ModifyUser { get; set; }

        public string ModifyTime { get; set; }
    }
}
