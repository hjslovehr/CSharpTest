using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace RefTest.Platform
{
    internal sealed class PlatformFactory
    {
        private static Lazy<PlatformFactory> _instance = new Lazy<PlatformFactory>(() => new PlatformFactory());

        public static PlatformFactory Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        private Dictionary<string, string> _platformMap;

        private Assembly _assembly;

        private PlatformFactory()
        {
            _platformMap = new Dictionary<string, string>();

            LoadPlatformList();
        }

        private void LoadPlatformList()
        {
            var filePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"PlatformConfig.xml");
            XElement file = XElement.Load(filePath);
            var platforms = from item in file.Elements("Platform") select item;
            foreach (var item in platforms)
            {
                _platformMap.Add(item.Attribute("Key").Value, item.Attribute("Value").Value);
            }

            _assembly = Assembly.GetExecutingAssembly();
        }

        private object CreateInstance(string platformKey)
        {
            if (_platformMap.ContainsKey(platformKey))
            {
                Type type = _assembly.GetType(_platformMap[platformKey]);
                return Activator.CreateInstance(type);
            }
            else
            {
                return null;
            }
        }

        public BasePlatform GetPlatform(string platformKey)
        {
            object obj = CreateInstance(platformKey);
            if (null == obj)
            {
                return null;
            }
            else
            {
                return (BasePlatform)obj;
            }
        }

    }
}
