/*
 * 由SharpDevelop创建。
 * 用户： DLAX
 * 日期: 2020/2/13
 * 时间: 17:58
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonDemo
{
    class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                //Test();

                //Test2();

                //Test3();

                //Test4();

                Test5();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }

        public static void Test()
        {
            var json = "{\"Response\":{\"ResponseURL\":\"/LAPI/V1.0/PeopleLibraries/BasicInfo\",\"ResponseCode\":0,\"ResponseString\":\"Succeed\",\"StatusCode\":0,\"Data\":{\"ID\":3}}}";

            var resp = JsonConvert.DeserializeObject<LAPIResponse>(json);

            Console.WriteLine(resp);


            var jo = JObject.FromObject(resp.Response.Data);

            Console.WriteLine(jo["ID"]);
        }

        public static void Test2()
        {
            Console.WriteLine("请输入文件名称: ");
            var fileName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(fileName) || !File.Exists(fileName))
            {
                Console.WriteLine("请输入有效文件名称！");
            }

            var jsonStr = File.ReadAllText(fileName, Encoding.UTF8);
            //Console.WriteLine(jsonStr);

            JObject jo = JObject.Parse(jsonStr);
            var personEventInfo = jo["PersonEventInfo"];
            var faceInfoList = personEventInfo["FaceInfoList"][0];
            var compareInfo = faceInfoList["CompareInfo"];
            var personInfo = compareInfo["PersonInfo"];
            var snapshotImage = compareInfo["SnapshotImage"];

            var personEventID = personEventInfo["ID"].ToObject<ulong>();
            var timeStamp = personEventInfo["Timestamp"].ToString();
            var notificationType = personEventInfo["NotificationType"].ToObject<int>();
            var faceInfoNum = personEventInfo["FaceInfoNum"].ToObject<int>();
            var channelID = faceInfoList["ChannelID"].ToObject<int>();
            var similarity = compareInfo["Similarity"].ToObject<int>();
            var personID = personInfo["PersonID"].ToObject<ulong>();
            var personName = personInfo["PersonName"].ToString();
            var idNum = personInfo["IdentificationList"][0]["Number"].ToString();
            var faceImageBase64String = personInfo["ImageList"][0]["Data"].ToString();
            var bigImageBase64String = snapshotImage["BigImage"]["Data"].ToString();
            var smallImageBase64String = snapshotImage["SmallImage"]["Data"].ToString();

            Console.WriteLine("PersonEventID: " + personEventID);
            Console.WriteLine("TimeStamp: " + timeStamp);
            Console.WriteLine("NotificationType: " + notificationType);
            Console.WriteLine("FaceInfoNum: " + faceInfoNum);
            if (faceInfoNum <= 0)
            {
                Console.WriteLine("没有人脸数据！");
                return;
            }
            Console.WriteLine();

            Console.WriteLine("ChannelID: " + channelID);
            Console.WriteLine("Similarity: " + similarity);
            Console.WriteLine("PersonID: " + personID);
            Console.WriteLine("PersonName: " + personName);
            Console.WriteLine("IdNum: " + idNum);

            Console.WriteLine();
        }

        public static void Test3()
        {
            Console.WriteLine("请输入文件名称: ");
            var fileName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(fileName) || !File.Exists(fileName))
            {
                Console.WriteLine("请输入有效文件名称！");
            }

            var jsonStr = File.ReadAllText(fileName, Encoding.UTF8);
            //Console.WriteLine(jsonStr);

            JObject jo = JObject.Parse(jsonStr);

            var data = jo["Response"]["Data"];
            var detailsInfos = JArray.FromObject(data["DetailInfos"]);

            List<BASE_DEVICE> devices = new List<BASE_DEVICE>();

            foreach (var item in detailsInfos)
            {
                JObject info = JObject.FromObject(item);

                //Console.WriteLine("ID:" + info["ID"]);
                //Console.WriteLine("Name: " + info["Name"]);

                //if (null != info.Property("AddressInfo"))
                //{
                //    JObject address = JObject.FromObject(info["AddressInfo"]);
                //    Console.WriteLine("Address: " + address["Address"]);
                //    Console.WriteLine("Port: " + address["Port"]);
                //}
                //Console.WriteLine("----------");

                if (null != info.Property("AddressInfo"))
                {
                    JObject address = JObject.FromObject(info["AddressInfo"]);

                    BASE_DEVICE dev = new BASE_DEVICE();
                    dev.DEVICEID = Guid.NewGuid();
                    dev.DOWNSTATUS = (int)DownStatus.Down;
                    dev.DEVICETYPE = 1; // 1 为人脸摄像机
                    dev.DEVICENAME = info["Name"].ToString();
                    dev.DATASOURCES = "驱动同步";
                    var status = Convert.ToInt32(info["Status"].ToString());
                    if (1 == status)
                    {
                        dev.ISACTIVE = 1;
                    }
                    else
                    {
                        dev.ISACTIVE = 0;
                    }
                    dev.IPADDRESS = address["Address"].ToString();
                    dev.PORT = Convert.ToInt32(address["Port"].ToString());
                    dev.OUTSIDEID = dev.IPADDRESS;

                    devices.Add(dev);
                }
            }

            Console.WriteLine("Count: " + devices.Count);
            Console.WriteLine(JsonConvert.SerializeObject(devices, Formatting.Indented));

            Console.WriteLine();
        }

        public static void Test4()
        {
            //string str = "{\"data\": [1, \"int\", 2, \"float\"]}";

            //var json = JsonConvert.DeserializeObject(str);
            //JObject job = JObject.FromObject(json);

            //var data = job["data"];

            //foreach (var item in data)
            //{
            //    Console.WriteLine(item.ToString());
            //}

            string jsonstr = File.ReadAllText("tb(2020-02-17).json");
            Console.WriteLine(jsonstr);
            Console.WriteLine();
            Console.WriteLine("************************************************************");

            var obj = JsonConvert.DeserializeObject(jsonstr);
            JObject jo = JObject.FromObject(obj);

            Console.WriteLine("modbusReadPara: ");
            foreach (var item in jo["modbusReadPara"])
            {
                Console.WriteLine(item);
            }


            Console.WriteLine();
        }

        static void Test5()
        {
            DateTime time = DateTime.Parse("2019-11-01");
            var querySnapTime = new
            {
                QueryColumn = "snap_time",//列名SnapTime
                LogicFlag = 1,//大于等于
                QueryData = time.ToString("yyyy-MM-dd HH:mm:ss")//查询参数


            };
            var querySnapTime2 = new
            {
                QueryColumn = "snap_time",//列名SnapTime
                LogicFlag = 4,//小于等于
                QueryData = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")//查询参数
                                                                        //QueryData = time.AddMinutes(30).ToString("yyyy-MM-3dd HH:mm:ss")//查询参数
            };
            //按照升序查询
            var querySnapTime3 = new
            {
                QueryColumn = "snap_time",//列名SnapTime
                LogicFlag = 6,//大于等于
                QueryData = ""//查询参数
                              // QueryData = time.AddSeconds(1).ToString("yyyy-MM-dd HH:mm:ss")//查询参数
            };

            object[] query = new object[3] { querySnapTime, querySnapTime2, querySnapTime3 };

            var data = new
            {
                ItemNum = 3,
                Condition = query,
                QueryCount = 0,
                PageFirstRowNumber = 0,
                PageRowNum = 200
            };

            Console.WriteLine(JsonConvert.SerializeObject(data));
        }

    }
}