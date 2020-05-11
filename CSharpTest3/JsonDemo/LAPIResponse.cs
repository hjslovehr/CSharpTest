/*
 * 由SharpDevelop创建。
 * 用户： DLAX
 * 日期: 2020/2/13
 * 时间: 18:13
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Text;

namespace JsonDemo
{
	/// <summary>
	/// Description of LAPIResponse.
	/// </summary>
	public class LAPIResponse
    {
        /// <summary>
        /// 
        /// </summary>
        public Response Response { get; set; }

		public override string ToString()
		{
			return ToJson();
		}

        public string ToJson()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("{");

            sb.AppendLine(" \"Response\": { ");
            sb.AppendLine(" " + Response.ToJson());
            sb.AppendLine(" } ");

            sb.AppendLine("}");

            return sb.ToString();
        }
    }

    public class Response
    {
        /// <summary>
        /// 
        /// </summary>
        public string ResponseURL { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ResponseCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ResponseString { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int StatusCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public object Data { get; set; }

        public string ToJson()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("     \"ResponseURL\": " + ResponseURL);
            sb.AppendLine("     \"ResponseCode\": " + ResponseCode);
            sb.AppendLine("     \"ResponseString\": " + ResponseString);
            sb.AppendLine("     \"ResponseString\": " + StatusCode);
            sb.AppendLine("     \"Data\": {" + Data);
            sb.AppendLine("     }");

            return sb.ToString();
        }
    }
}
