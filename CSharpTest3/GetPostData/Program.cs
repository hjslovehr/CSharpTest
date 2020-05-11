using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GetPostData
{
    class Program
    {
        private const string KEY = "rjparking";

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
            var timeFormat = "yyyy-MM-dd HH:mm:ss";
            var vehicleList = new VehicleList();
            var json = string.Empty;
            var postData = new PostJson();
            var jsonStr = string.Empty;

            while (true)
            {
                Console.Write("请输入开始时间(yyyy-MM-dd HH:mm:ss): ");
                var fStartTime = DateTime.Parse(Console.ReadLine());
                Console.Write("请输入结束时间(yyyy-MM-dd HH:mm:ss): ");
                var fEndTime = DateTime.Parse(Console.ReadLine());
                Console.Write("请输入方法名称: ");
                var fMethodName = Console.ReadLine();

                vehicleList.fStartTime = fStartTime.ToString(timeFormat);
                vehicleList.fEndTime = fEndTime.ToString(timeFormat);
                vehicleList.fMethod = fMethodName;

                json = JsonConvert.SerializeObject(vehicleList);
                Console.WriteLine($"Params: {json}");
                
                postData.key = GetMD5(KEY + json);
                postData.parm = Base64Encode(Encoding.UTF8, json);

                jsonStr = JsonConvert.SerializeObject(postData);
                Console.WriteLine($"Post data: {jsonStr}");
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

    public class PostJson
    {
        public string parm { get; set; }
        public string key { get; set; }
    }

}
