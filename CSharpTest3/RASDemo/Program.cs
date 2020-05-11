/*
 * 由SharpDevelop创建。
 * 用户： DLAX
 * 日期: 2020/3/5
 * 时间: 12:00
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace RASDemo
{
    class Program
    {
        public static readonly string PUBLICKEY = "<RSAKeyValue><Modulus>55kvFtsFHKokEQxrYpjO2nM01h3xJnx+BhnouyNS67qch5mAndz7oxdDNOOXsA6Ih13LrKUlIZDe8inSLBRDy6l3BOYXros3OHKP8M4uZ/RyI7AV4YQF2kg4j2FD4+Au4wlcZLhXzLK2RYqKMazs7QM+o++pbSCE50A3giDk8x0=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
        public static readonly string PRIVATEKEY = "<RSAKeyValue><Modulus>55kvFtsFHKokEQxrYpjO2nM01h3xJnx+BhnouyNS67qch5mAndz7oxdDNOOXsA6Ih13LrKUlIZDe8inSLBRDy6l3BOYXros3OHKP8M4uZ/RyI7AV4YQF2kg4j2FD4+Au4wlcZLhXzLK2RYqKMazs7QM+o++pbSCE50A3giDk8x0=</Modulus><Exponent>AQAB</Exponent><P>/KKU5/VLkmleoKRqRVdqhvZXZ9p9RI66cDMzXucncsIhAXC4ttld3ck9gh+o1vyDDs5IzoZ3fiOg3SOw3rH+jw==</P><Q>6q7faWIKEoup8TmBYh1SWvD2afcZ1PSQ6q7TFAf4xE5zZdyth4w+NAA9h4KG+i+k59IS+5WwMQ9zlgv6e9dJkw==</Q><DP>J3s5Di8VimIROcW4HfIVYdYpvr80iHxNwq8dvh0d2x9fjRwSofDCbKDAjg9okYCQ8sVmN3BoSDxFLYogYA0tHQ==</DP><DQ>ouSIe8wp859vcNkaXjC+BhN05i42huLOZ6a7Kg8yc4eEf7KB3DDSyCNWkeVerO8/Bg2BUZEfv53a+84KqcTP8w==</DQ><InverseQ>lEJEJ0olkzsTjGGgWhOYA5mmS372t6whHSESdap9pFiBuZylz6yVjBVUIKHfUTCXh1g6Dk8J0EvdBYusOKrbIQ==</InverseQ><D>DtMUW48rdZlCc8DqwsXrP7puIGKMRB1l57gS2J+7OBGa4Wcm/3Pcu6TKjYEf/YoAnUGYvvVXOh3O14trw5yMdkayJt4OreIXTH9ChefjrJqkPmpazrSgpMt2ZY9z545UvU3MTee6Y/h5D8FOmIfbgAF9xDp7H33QcgDjxpCt33U=</D></RSAKeyValue>";

        public static void Main(string[] args)
        {
            Run();

            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }

        static void Run()
        {
            try
            {
                #region
                //var src = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";

                //Console.WriteLine("src length: " + src.Length);

                //var ret = GetRangeString(src, 10);

                //Console.WriteLine();

                //var s1 = RASEncrypt(src);
                //Console.WriteLine(s1);

                //var s2 = RASDecrypt(s1);
                //Console.WriteLine(s2);
                #endregion

                //GetRangeStringTest();

                //Test1();

                //Test2();

                Test3();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void GetRangeStringTest()
        {
            //Console.WriteLine("请输入字符串: ");
            //var str = Console.ReadLine();

            var str = "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";
            var range = 100;
            var loopCount = 1000;

            Console.WriteLine("strint length: {0}", str.Length);
            Console.WriteLine("range: {0}", range);
            Console.WriteLine("loop: {0}", loopCount);
            Console.WriteLine();

            var begin = DateTime.Now.Ticks;
            for (int index = 0; index < loopCount; index++)
            {
                // 方法 1
                var temp = GetRangeString(str, range);
            }
            var end = DateTime.Now.Ticks;
            var subTime = end - begin;
            Console.WriteLine("GetRangeString loop {0} time: {1} s\n", loopCount, subTime * 1.0 / 10 / 1000 / 1000);

            begin = DateTime.Now.Ticks;
            for (int index = 0; index < loopCount; index++)
            {
                // 方法 2
                var temp = RegexGetRangeString(str, range);
            }
            end = DateTime.Now.Ticks;
            subTime = end - begin;
            Console.WriteLine("RegexGetRangeString loop {0} time: {1} s\n", loopCount, subTime * 1.0 / 10 / 1000 / 1000);

            begin = DateTime.Now.Ticks;
            for (int index = 0; index < loopCount; index++)
            {
                // 方法 3
                var temp = LinqGetRangeString(str, range);
            }
            end = DateTime.Now.Ticks;
            subTime = end - begin;
            Console.WriteLine("LinqGetRangeString loop {0} time: {1} s\n", loopCount, subTime * 1.0 / 10 / 1000 / 1000);
        }

        static void Test1()
        {
            var s1 = RASEncrypt("");
            Console.WriteLine(s1);

            s1 = RASEncrypt("          ");
            Console.WriteLine(s1);

            s1 = RASEncrypt("abcdefg");
            Console.WriteLine(s1);

            s1 = RASEncrypt("123");
            Console.WriteLine(s1);

            s1 = RASEncrypt("abcdefg");
            Console.WriteLine(s1);
        }

        static void Test2()
        {
            while (true)
            {
                Console.WriteLine("请输入字符串: ");
                var str = Console.ReadLine();
                Console.WriteLine("src length: " + str.Length);
                var ret = GetRangeString(str, 10);

                Console.WriteLine("分段后:");
                List<string> encyptList = new List<string>();
                foreach (var item in ret)
                {
                    Console.WriteLine(item);
                    var temp = RASEncrypt(item);
                    encyptList.Add(temp);
                    Console.WriteLine("==> " + temp);
                    Console.WriteLine();
                }

                Console.WriteLine("解密:");
                List<string> decryptList = new List<string>();
                foreach (var item in encyptList)
                {
                    Console.WriteLine(item);
                    var temp = RASDecrypt(item);
                    decryptList.Add(temp);
                    Console.WriteLine("==> " + temp);
                    Console.WriteLine();
                }
                var decryptResult = string.Join("", decryptList);
                Console.WriteLine("decryptResult length: {0}", decryptResult.Length);
                Console.WriteLine(decryptResult);
            }
        }

        static void Test3()
        {
            var str = "GoYReeRhnqdmZgu+9AdrxZZC230uy0yEHeRL6/OA1ipccG7d3iKYlt+etA5jjeyAQqzNbBOL9z9gpaBihXypiXi2ujsadnWFjPRMiQrQ7OG3KS4Y5ExTKwt3WuHII3BpMNpuyX4O3pjHylURtFztAQhUJlXn5hGiKiJJxCxDDbM=4cx3ZHplqHKaJIrH7ajMOyh3CEAIZHhIjYZIUTRmO/XUXVDgrR5yQDrCsRMRQtxhtbUQRrW2rKtSMtb9QFTTh25PHb+Gd8FbW+rnC2QBEw9lj3oODLAxcjy0ydvesxahJ8AjFygMnmBlMHn9qp0/ETVu162ma1X1il8t5fgXVgY=";

            if (str.Length <= 172)
            {
                Console.WriteLine(RASDecrypt(str));
            }
            else
            {
                var list = GetRangeString(str, 172);
                var arr = new List<string>();
                list.ForEach(it =>
                {
                    arr.Add(RASDecrypt(it));
                });
                Console.WriteLine(string.Join("", arr));
            }
        }

        static string RASEncrypt(string str)
        {
            using (var rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(PUBLICKEY);
                byte[] bytes = Encoding.UTF8.GetBytes(str);
                var res = rsa.Encrypt(bytes, false);
                return Convert.ToBase64String(res);
            }
        }

        static string RASDecrypt(string str)
        {
            using (var rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(PRIVATEKEY);
                byte[] bytes = Convert.FromBase64String(str);
                var res = rsa.Decrypt(bytes, false);
                return Encoding.UTF8.GetString(res);
            }
        }

        public static List<string> GetRangeString(string src, int len)
        {
            if (null == src)
            {
                return null;
            }

            var list = new List<string>();

            if (src.Length < len || len <= 0)
            {
                list.Add(src);
                return list;
            }

            var srcLen = src.Length;
            int start = 0;
            for (int i = len; i <= srcLen; i += len)
            {
                list.Add(src.Substring(start, i - start));
                start = i;
            }

            var temp = src.Length % len;
            if (0 != temp)
            {
                list.Add(src.Substring(start, temp));
            }

            return list;
        }

        static List<string> RegexGetRangeString(string src, int len)
        {
            return Regex.Matches(src, @"\w{" + len + "}").Cast<Match>().Select(m => m.Groups[0].Value).ToList();
        }

        static List<string> LinqGetRangeString(string src, int len)
        {
            var array = new List<string>();

            var pageCount = (int)Math.Ceiling(1.0 * src.Length / len);
            for (int i = 0; i < pageCount; i++)
            {
                var temp = src.Skip(i * 100).Take(len).ToArray();
                array.Add(new string(temp));
            }

            return array;
        }

    }
}