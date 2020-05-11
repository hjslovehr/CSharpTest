using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonDemo
{
    public class BASE_DEVICE : Base_Model
    {
        /// <summary>
        /// 设备主键ID
        /// </summary>
        public Guid DEVICEID { get; set; }
        /// <summary>
        /// 设备类型（1：摄像机，2：速通门）
        /// </summary>
        public int? DEVICETYPE { get; set; }
        /// <summary>
        /// 设备名称
        /// </summary>
        public string DEVICENAME { get; set; }
        /// <summary>
        /// 设备编码
        /// </summary>
        public string DEVICECODE { get; set; }
        /// <summary>
        /// 设备所属区域ID
        /// </summary>
        public Guid? DEVICEAREAID { get; set; }
        /// <summary>
        /// 设备拍摄方向（1：进，2：出，0未知）
        /// </summary>
        public int? INOROUT { get; set; }
        /// <summary>
        /// 设备IP地址
        /// </summary>
        public string IPADDRESS { get; set; }
        /// <summary>
        /// 设备端口号
        /// </summary>
        public int? PORT { get; set; }
        /// <summary>
        /// 设备视频播放地址（完整地址）
        /// </summary>
        public string URL { get; set; }
        /// <summary>
        /// 设备登录名
        /// </summary>
        public string LOGINNAME { get; set; }
        /// <summary>
        /// 设备登录密码
        /// </summary>
        public string LOGINPWD { get; set; }
        /// <summary>
        /// 设备是否有效（1：有效，0：无效）
        /// </summary>
        public int? ISACTIVE { get; set; }
        /// <summary>
        /// 删除标识（1:未删除，0：删除）
        /// </summary>
        public int? ISDELETED { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DATASOURCES { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CREATEDATE { get; set; }
        /// <summary>
        /// 创建用户
        /// </summary>
        public Guid? CREATEUSERID { get; set; }
        /// <summary>
        /// 创建用户名
        /// </summary>
        public string CREATEUSERNAME { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? MODIFYDATE { get; set; }
        /// <summary>
        /// 修改用户
        /// </summary>
        public Guid? MODIFYUSERID { get; set; }
        /// <summary>
        /// 修改用户名
        /// </summary>
        public string MODIFYUSERNAME { get; set; }

        /// <summary>
        /// 下发状态
        /// </summary>
        public int DOWNSTATUS { get; set; }
        /// <summary>
        /// 对应外部平台的id
        /// </summary>
        public string OUTSIDEID { get; set; }

        /// <summary>
        /// 所属服务器id
        /// </summary>
        public string SERVERID { get; set; }

        public string RegistryCode { get; set; }

        public string SessionId { get; set; }

        public string Token { get; set; }

        public DateTime LastAccessDate { get; set; }
    }
}
