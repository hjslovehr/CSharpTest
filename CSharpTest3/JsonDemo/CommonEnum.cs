using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonDemo
{
    /// <summary>
    /// 下发状态
    /// </summary>
    public enum DownStatus
    {
        /// <summary>
        /// 未下发
        /// </summary>
        None = 0,
        /// <summary>
        /// 下发成功
        /// </summary>
        Down = 1,
    }

    public enum StatusCodeEnum
    {

        [Description("新增成功")]
        AddSuccess = 10000, //新增请求(或处理)成功

        [Description("新增失败")]
        AddError = 10001, //新增请求(或处理)失败

        [Description("删除成功")]
        DeleteSuccess = 20000, //删除请求(或处理)成功

        [Description("删除失败")]
        DeleteError = 20001, //删除请求(或处理)失败

        [Description("查询成功")]
        GetSuccess = 30000, //获取请求(或处理)成功

        [Description("查询失败")]
        GetError = 30001, //获取请求(或处理)失败

        [Description("修改成功")]
        SetSuccess = 40000, //修改请求(或处理)成功

        [Description("修改失败")]
        SetError = 40001, //修改请求(或处理)失败


        [Description("内部请求处理出错")]
        Error = 50001, //内部请求出错

        [Description("未授权标识")]
        Unauthorized = 60001,//请求未授权标识

        [Description("请求参数不完整或不正确")]
        ParameterError = 60002,//请求参数不完整或不正确

        [Description("请求TOKEN失效")]
        TokenInvalid = 60003,//请求TOKEN失效

        [Description("HTTP请求类型不合法")]
        HttpMehtodError = 60004,//HTTP请求类型不合法

        [Description("HTTP请求不合法,请求参数可能被篡改")]
        HttpRequestError = 60005,//HTTP请求不合法

        [Description("该URL请求地址已经失效")]
        URLExpireError = 60006,//HTTP请求不合法
    }
}
