using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RuanJieApiTest
{
    class Program
    {
        private const string KEY = "rjparking";

        private static string apiUrl = "http://192.168.10.57:9111/parking/api/openApi";

        private static string fileName = $"{DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss")}.log.txt";

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
            Console.Write("请输入开始时间(yyyy-MM-dd HH:mm:ss): ");
            var fStartTime = DateTime.Parse(Console.ReadLine());

            Console.Write("请输入结束时间(yyyy-MM-dd HH:mm:ss): ");
            var stopTime = DateTime.Parse(Console.ReadLine());

            Console.Write("请输入方法名称: ");
            var fMethodName = Console.ReadLine();

            //var fStartTime = DateTime.Parse("2020-03-28 08:00:00");
            var fEndTime = fStartTime;

            var timeFormat = "yyyy-MM-dd HH:mm:ss";
            var vehicleList = new VehicleList();
            var json = string.Empty;

            var postData = new PostJson();
            var jsonStr = string.Empty;
            string key = string.Empty;
            var respose = string.Empty;

            while (true)
            {
                fEndTime = fEndTime.AddSeconds(60);

                vehicleList.fStartTime = fStartTime.ToString(timeFormat);
                vehicleList.fEndTime = fEndTime.ToString(timeFormat);

                vehicleList.fMethod = fMethodName;

                json = JsonConvert.SerializeObject(vehicleList);
                Console.WriteLine($"Params: {json}");
                File.AppendAllText(fileName, $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffff")} |  Params: {json}{Environment.NewLine}");

                postData.key = GetMD5(KEY + json);
                postData.parm = Base64Encode(Encoding.UTF8, json);

                jsonStr = JsonConvert.SerializeObject(postData);
                Console.WriteLine($"Post data: {jsonStr}");
                File.AppendAllText(fileName, $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffff")} | Post data: {jsonStr}{Environment.NewLine}");

                respose = PostJsonData(apiUrl, jsonStr, Encoding.UTF8);
                Console.WriteLine($"Response: {respose}");
                File.AppendAllText(fileName, $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffff")} | Response: {respose}{Environment.NewLine}");
                Console.WriteLine();

                if (fStartTime >= stopTime)
                {
                    Console.WriteLine($"Request over ! Result write to {fileName}.");
                    break;
                }

                fStartTime = fEndTime;

                System.Threading.Thread.Sleep(200);
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

        /// <summary>
        /// 发送json数据（UTF-8）
        /// </summary>
        /// <param name="postUrl"></param>
        /// <param name="paramData"></param>
        /// <param name="dataEncode"></param>
        public static string PostJsonData(string postUrl, string paramData, Encoding dataEncode)
        {
            return PostWebRequest(postUrl, paramData, "application/json;charset=utf-8", dataEncode);
        }

        /// <summary>
        /// http  post发送
        /// </summary>
        /// <param name="postUrl">post地址</param>
        /// <param name="paramData">post数据</param>
        /// <param name="contenttype">post格式</param>
        /// <param name="dataEncode">编码格式</param>
        /// <returns></returns>
        public static string PostWebRequest(string postUrl, string paramData, string contenttype, Encoding dataEncode)
        {
            string ret = string.Empty;
            HttpWebRequest webReq = null;
            HttpWebResponse response = null;
            StreamReader sr = null;
            Stream newStream = null;
            try
            {
                byte[] byteArray = dataEncode.GetBytes(paramData); //转化
                webReq = (HttpWebRequest)WebRequest.Create(new Uri(postUrl));
                webReq.Method = "POST";
                webReq.ContentType = contenttype;
                webReq.ContentLength = byteArray.Length;
                webReq.KeepAlive = false;
                newStream = webReq.GetRequestStream();
                newStream.Write(byteArray, 0, byteArray.Length);//写入数据流
                newStream.Close();
                response = (HttpWebResponse)webReq.GetResponse();
                sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                ret = sr.ReadToEnd();
            }
            catch (Exception ex)
            {
                ret = ex.Message;
            }
            finally
            {
                if (webReq != null)
                {
                    webReq.Abort();
                }
                if (sr != null)
                {
                    sr.Close();
                }
                if (response != null)
                {
                    response.Close();
                }
                if (newStream != null)
                {
                    newStream.Close();
                }
            }
            return ret;
        }
    }

    public class PostJson
    {
        public string parm { get; set; }
        public string key { get; set; }
    }

}
