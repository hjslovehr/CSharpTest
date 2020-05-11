
//#undef DEBUG
#undef RELEASE

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AttributeDemo
{
    public class TestClass : IRun
    {
        #region Test Module
        public void Run()
        {
            ConsolePrint.Message("---------- DEBUG ----------");

            //CustomAttributeTest();
            //CustomAttributeTest2();
            //CustomAttributeTest3();

            var type = this.GetType();
            var methodInfoArr = type.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            var mArray = (from m in methodInfoArr where m.Name.Contains("CustomAttributeTest") select m).ToArray();
            foreach (var item in mArray)
            {
                item.Invoke(this, null);
            }
        }

        public void CustomAttributeTest()
        {
            var type = typeof(AttributeTest);
            var attributeType = typeof(MyAttributeTestAttribute);
            if (Attribute.IsDefined(type, attributeType))
            {
                ConsolePrint.Message($"Class name : {type.Name}");
                var arr = type.GetCustomAttributes(attributeType) as MyAttributeTestAttribute[];
                foreach (var item in arr)
                {
                    ConsolePrint.Message(string.Format("Creator : {0} | Create Time : {1}", item.CreateUser, item.CreateTime));
                    ConsolePrint.Message(string.Format("Modifier : {0} | Modify Time : {1}", item.ModifyUser, item.ModifyTime));
                    ConsolePrint.Message();
                }
            }
        }

        public void CustomAttributeTest2()
        {
            var type = typeof(AttributeTest);
            PropertyInfo[] proInfoArr = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            var attributeType = typeof(MyAttributeTestAttribute);
            foreach (var p in proInfoArr)
            {
                if (Attribute.IsDefined(p, attributeType))
                {
                    ConsolePrint.Message($"Property name : {p.Name}");
                    var arr = p.GetCustomAttributes(attributeType) as MyAttributeTestAttribute[];
                    foreach (var item in arr)
                    {
                        ConsolePrint.Message(string.Format("Creator : {0} | Create Time : {1}", item.CreateUser, item.CreateTime));
                        ConsolePrint.Message(string.Format("Modifier : {0} | Modify Time : {1}", item.ModifyUser, item.ModifyTime));
                        ConsolePrint.Message();
                    }
                }
            }
        }

        public void CustomAttributeTest3()
        {
            var type = typeof(AttributeTest);
            MethodInfo[] metInfoArr = type.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            var attributeType = typeof(MyAttributeTestAttribute);
            foreach (var m in metInfoArr)
            {
                if (Attribute.IsDefined(m, attributeType))
                {
                    ConsolePrint.Message($"Method name : {m.Name}");
                    var arr = m.GetCustomAttributes(attributeType) as MyAttributeTestAttribute[];
                    foreach (var item in arr)
                    {
                        ConsolePrint.Message(string.Format("Creator : {0} | Create Time : {1}", item.CreateUser, item.CreateTime));
                        ConsolePrint.Message(string.Format("Modifier : {0} | Modify Time : {1}", item.ModifyUser, item.ModifyTime));
                        ConsolePrint.Message();
                    }
                }
            }
        }
        #endregion

        #region Work Module
        [Conditional("RELEASE")]
        public void Work()
        {
            ConsolePrint.Message("---------- RELEASE ----------");
        }
        #endregion
    }
}
