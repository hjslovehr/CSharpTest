using System;

namespace FastExportRecordToExcel
{
    public class ExportResult
    {
        /// <summary>
        /// 导出结果状态
        ///     true：成功
        ///     false：失败
        /// </summary>
        public bool Status { get; set; }

        /// <summary>
        /// 导出后提示信息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 导出中途出现异常
        /// </summary>
        public Exception Error { get; set; }
    }
}