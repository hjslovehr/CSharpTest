using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HttpAuthDemo
{
    class Program
    {
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
            Console.WriteLine("============================================================");
            Console.WriteLine("Press any key to close the application.");
            Console.ReadKey(true);
        }

        static void Test()
        {
            Test1();
        }

        static async void Test1()
        {
            using (HttpClient client = new HttpClient())
            {
                string name = "Admin";
                string pwd = "admin111";

                string base64String = Convert.ToBase64String(Encoding.Default.GetBytes(name + ":" + pwd));

                client.DefaultRequestHeaders.Add("Authorization", "Basic " + base64String);

                HttpResponseMessage response = await client.GetAsync("http://192.168.18.3/CGI/UploadCheck");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                // Above three lines can be replaced with new helper method below
                // string responseBody = await client.GetStringAsync(uri);

                Console.WriteLine(responseBody);
            }
        }


    }
}
