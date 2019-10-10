using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeDemo
{
    [MyAttributeTest(CreateUser = "HJS", CreateTime = "2019-10-10 16:00:00")]
    [MyAttributeTest(ModifyUser = "HJS", ModifyTime = "2019-10-10 16:40:00")]
    public class AttributeTest
    {
        [MyAttributeTest(CreateUser = "HJS", CreateTime = "2019-10-10 16:00:00")]
        public int ID { get; set; }

        [MyAttributeTest(CreateUser = "HJS-1", CreateTime = "2019-10-10 16:40:00")]
        public Guid RoleId { get; set; } = Guid.Empty;

        [MyAttributeTest(CreateUser = "HJS-1", CreateTime = "2019-10-10 17:20:00")]
        public string ToJson()
        {
            return string.Format("{\"ID\":{0},\"RoleId\":{1}}", ID, RoleId);
        }
    }
}
