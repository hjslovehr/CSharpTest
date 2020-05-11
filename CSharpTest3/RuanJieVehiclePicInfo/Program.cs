using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RuanJieVehiclePicInfo
{
    class Program
    {
        private const string KEY = "rjparking";

        private const string MethodName = "VehiclePicInfo";

        private static string apiUrl = "http://192.168.10.57:9111/parking/api/openApi";

        static void Main(string[] args)
        {
            try
            {
                Test();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.WriteLine("Press any key to close the application.");
            Console.ReadLine();
        }

        static void Test()
        {
            while (true)
            {
                Console.Write("请输入 fBusID: ");
                var fBusID = Console.ReadLine();

                var data = new
                {
                    fMethod = MethodName,
                    fBusID = fBusID
                };

                var json = JsonConvert.SerializeObject(data);
                Console.WriteLine($"Params: {json}");
                var base64 = Base64Encode(Encoding.UTF8, json);
                var key = GetMD5(KEY + json);
                var postData = new
                {
                    parm = base64,
                    key = key
                };
                Console.WriteLine($"PostData: {JsonConvert.SerializeObject(postData)}");
            }
        }

        public static string GetMD5(string myString)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            string t2 = BitConverter.ToString(md5.ComputeHash(UTF8Encoding.Default.GetBytes(myString)));
            t2 = t2.Replace("-", "");
            return t2;
        }

        public static string Base64Encode(Encoding encodeType, string source)
        {
            string encode = string.Empty;
            byte[] bytes = encodeType.GetBytes(source);
            try
            {
                encode = Convert.ToBase64String(bytes);
            }
            catch
            {
                encode = source;
            }
            return encode;
        }
    }
}
