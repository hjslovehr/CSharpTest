using System;
using System.Linq;
using System.Xml.Linq;

namespace RefTest
{
    class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Test();

                var lib1config = XElement.Load(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "lib1Config.xml"));
                var lib1dll = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, lib1config.Attribute("Key").Value);
                var assembly = System.Reflection.Assembly.LoadFile(lib1dll);
                var type = assembly.GetType((from item in lib1config.Elements("item") select item).ToList()[0].Value);
                var say = Activator.CreateInstance(type, new object[] { "毛主席" });
                Console.WriteLine((say as RefLib1.SayClass).Say("同志们好"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.Write("Press any key to continue . . . ");
                Console.ReadKey();
            }
        }

        public static void Test()
        {
            var platformKey = System.Configuration.ConfigurationManager.AppSettings["Platform"];

            var pf = Platform.PlatformFactory.Instance.GetPlatform(platformKey);

            if (null != pf)
            {
                pf.AddPersonList(new Platform.PersonList());
            }
        }
    }
}