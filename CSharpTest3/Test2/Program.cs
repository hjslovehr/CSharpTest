using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Test2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Test1();

                //Test2();

                //Test3();

                Test4();

                //Test5();

                Form1 frm = new Form1();
                frm.ShowDialog();

                Console.WriteLine(DateTime.FromOADate(41305.7088194444));
                
                Console.WriteLine(DateTime.Now.ToOADate());

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.WriteLine("Press any key to close the application.");
            Console.ReadKey();
        }

        static void Test1()
        {
            var list = new List<string>();

            System.IO.File.AppendAllText("123.txt", list.FirstOrDefault()?.ToString());
        }

        static void Test2()
        {
            SYS_USER user = new SYS_USER();
            user.CODE = "TestAccount";
            user.ACCOUNT = user.CODE;
            user.PASSWORD = "F379EAF3C831B04DE153469D1BEC345E";
            user.GENDER = 2;

            user.USERID = Guid.Parse("08AA8B45-BA18-461A-8274-3B95ECDCF481");

            string strSQL = $@"
UPDATE SYS_USER 
SET CODE = '{user.CODE}'
    , ACCOUNT = '{user.ACCOUNT}'
    , PASSWORD = '{user.PASSWORD}'
    , REALNAME = '{(null != user.REALNAME ? user.REALNAME : "NULL")}'
    , GENDER = {(user.GENDER.HasValue ? user.GENDER.ToString() : "NULL")}
    , MOBILE = {(null != user.MOBILE ? user.MOBILE : "NULL")}
    , BIRTHDAY = {(user.BIRTHDAY.HasValue ? "'" + user.BIRTHDAY.Value.ToString("yyyy-MM-dd") + "'" : "NULL")}
    , ENABLED = {(user.ENABLED.HasValue ? user.ENABLED.ToString() : "NULL")}
    , ISDELETED = {(user.ISDELETED.HasValue ? user.ISDELETED.ToString() : "NULL")}
    , DESCRIPTION = '从 DSRP 同步人员更新'
WHERE USERID = '{user.USERID}'
";
            Console.WriteLine(strSQL);
        }

        static void Test3()
        {
            Console.WriteLine(DateTime.Now.ToString("zzz"));

            Console.WriteLine(DateTime.Now.ToString("ddd", System.Globalization.CultureInfo.CreateSpecificCulture("en-US")));
            Console.WriteLine(DateTime.Now.ToString("MMM", System.Globalization.CultureInfo.CreateSpecificCulture("en-US")));

            Console.WriteLine(ToGMTFormat(DateTime.Now));
        }

        public static string ToGMTFormat(DateTime dt)
        {
            return dt.ToString("ddd MMM dd yyyy HH':'mm':'ss 'GMT'", System.Globalization.CultureInfo.CreateSpecificCulture("en-US")) + dt.ToString("zzz").Replace(":", "");
        }

        static void Test4()
        {
            var str = "{\"start_validity\":\"1990-01-01\",\"end_validity\":null}";

            JObject jo = JObject.Parse(str);

            DateTime? start_time = jo["start_validity"].ToObject<DateTime?>();
            DateTime? end_time = jo["end_validity"].ToObject<DateTime?>();
            Console.WriteLine();

            var str2 = "{\"total\":3,\"rows\":{\"total\":0,\"rows\":[{\"updateDateTime\":\"\\/Date(1585883270500)\\/\",\"start_validity\":\"\\/Date(-62135596800000)\\/\",\"end_validity\":\"\\/Date(-62135596800000)\\/\",\"start_validity_str\":\"0001/1/1 0:00:00\",\"end_validity_str\":\"0001/1/1 0:00:00\",\"GID\":\"00000000-0000-0000-0000-000000000000\",\"GIDs\":null,\"PersonGuid\":\"fb45344e-1d14-4541-9303-000e87c0aa7a\",\"PersonIDs\":null,\"Name\":\"向钰\",\"EnName\":null,\"Gender\":2,\"GenderName\":\"女\",\"Nation\":1,\"NationName\":\"汉族\",\"Birthday\":\"\\/Date(-62135596800000)\\/\",\"BirthdayStr\":null,\"BloodType\":0,\"BloodTypeName\":null,\"Religion\":0,\"ReligionName\":null,\"NativePlace\":\"湖南省常德市武陵区\",\"Nationality\":47,\"NationalityName\":\"中国\",\"PoliticalStatus\":0,\"PoliticalStatusName\":null,\"MarriageStatusName\":null,\"MarriageStatus\":false,\"PhotoFileName\":\"http://192.168.1.159:8081\\\\upload\\\\Temp\\\\Report\\\\14054060.jpg\",\"SystemStatus\":true,\"IDCard\":\"430702199603132021\",\"WorkNO\":null,\"College\":null,\"Department\":null,\"DepartmentID\":0,\"OneCardNumber\":null,\"PersonType\":0,\"PersonTypeName\":null,\"Phone\":\"13121978922\",\"UpdateSource\":null,\"LoginName\":\"xiangyu\",\"LoginPass\":\"4297f44b13955235245b2497399d7a93\",\"AppCode\":null,\"PageSize\":0,\"PageIndex\":0,\"Condition\":null,\"SortID\":0,\"CardType\":1,\"CardTypeName\":\"身份证\",\"search_have_uersinfo\":0,\"have_uersinfo\":0,\"hvae_userstate\":0,\"State\":1,\"paperworkList\":[{\"id\":\"fd205de9-f14e-4ba8-b134-d9172e5a7437\",\"personId\":\"fb45344e-1d14-4541-9303-000e87c0aa7a\",\"paperwork\":\"430702199603132021\",\"primaryKey\":true,\"type\":1,\"source\":\"DPSIMP\",\"cardTypeName\":null,\"createTime\":\"\\/Date(1585883269627)\\/\",\"rank\":0,\"remark1\":null,\"remark2\":null,\"remark3\":null,\"remark4\":null,\"remark5\":null}],\"paperworkLists\":null,\"getType\":0,\"superGUIDstr\":null,\"PaperworkPrimaryKeyType\":0,\"hvae_regionname\":null,\"room_name\":null,\"floor_name\":null,\"building_name\":null,\"studentInfo\":null,\"teacherInfo\":null,\"staffInfoModel\":null,\"org_name\":null,\"centerServicePhone\":null,\"PhotoByte\":null,\"organization_id\":null,\"type_name\":null,\"region_id\":\"00000000-0000-0000-0000-000000000000\",\"ifGetPaperwork\":false,\"pageStart\":0,\"pageEnd\":0,\"page\":0}]}}";
            var jo2 = JObject.Parse(str2);

            var ls = jo2["rows"]["rows"].ToList();

            var first = ls[0];

            var start_validity = first["start_validity"].ToObject<DateTime?>();
            var end_validity = first["end_validity"].ToObject<DateTime?>();

            Console.WriteLine();
        }

        static void Test5()
        {
            DateTime dt = DateTime.Now;
            string str = string.Empty;

            if (DateTime.TryParse(str, out dt))
            {
                Console.WriteLine("日期转换成功，输出: " + dt.ToString("yyyy-MM-dd HH:mm:ss.ffff"));
            }
            else
            {
                // 如果 DateTime.TryParse(str, out dt) 返回 false，那么 dt 会被重置为 DateTime.MinValue(0001/01/01 00:00:00)
                Console.WriteLine("日期转换失败，输出: " + dt.ToString("yyyy-MM-dd HH:mm:ss.ffff"));
            }

            var orgId = Guid.Empty;
            var jsonStr = $"{{\"id\": \"{orgId}\",\"updatetime\": \"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}\"}}";

            Console.WriteLine(jsonStr);

        }
        
    }
}
