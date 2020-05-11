using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace ConfigDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.WriteLine("Press any key to close the applicaton.");
            Console.ReadKey(true);
        }

        static void Run()
        {
            Test1();

            Console.WriteLine();

            Test2();
        }

        static void Test1()
        {
            var appSettings = ConfigurationManager.AppSettings;
            var keys = appSettings.AllKeys;
            foreach (var item in keys)
            {
                Console.WriteLine("Key:{0}    Value:{1}", item, appSettings[item]);
            }
        }

        static void Test2()
        {
            var config = ConfigurationManager.OpenMappedExeConfiguration(
                    new ExeConfigurationFileMap { ExeConfigFilename = "MyApp.config" },
                    ConfigurationUserLevel.None
                );

            var appSettings = config.AppSettings;
            var settings = appSettings.Settings;
            var allKeys = appSettings.Settings.AllKeys;
            foreach (var item in allKeys)
            {
                Console.WriteLine("Key:{0}    Value:{1}", item, settings[item].Value);
            }
            Console.WriteLine();

            var dal = allKeys.Where(it => it.Equals("DAL")).FirstOrDefault();
            Console.WriteLine("Key:{0}    Key:{1}", dal, settings[dal].Value);
            Console.WriteLine();

            var dals = allKeys.Where(it => !it.Equals("DAL")).ToList();
            foreach (var item in dals)
            {
                Console.WriteLine("Key:{0}    Value:{1}", item, settings[item].Value);
            }
        }

    }
}
