using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastExportRecordToExcel
{
    public class NPOIExcel
    {
        public virtual void ExportExcelByTemplate(DataTable dtSource,
                                                  int iStartRow,
                                                  int iStartColumn,
                                                  string strFilePath,
                                                  string sheetName,
                                                  string strTemplatePath,
                                                  ref ExportResult result)
        {
            if (!CheckParameters(dtSource, iStartRow, iStartColumn, strFilePath, strTemplatePath, ref result))
            {
                return;
            }

            try
            {
                File.Copy(strTemplatePath, strFilePath, true);

                // 获取 Workbook 对象
                IWorkbook workbook = GetWorkbook(strFilePath);

                // 获取 Sheet 对象
                ISheet sheet = GetSheet(workbook, sheetName);

                // 数据
                CreateRows(iStartRow, iStartColumn, workbook, sheet, dtSource);

                // 保存
                SaveExcel(workbook, strFilePath);

                result.Status = true;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Error = ex;
            }

        }

        protected virtual bool CheckParameters(DataTable dtSource,
                                                int iStartRow,
                                                int iStartColumn,
                                                string strFilePath,
                                                string strTemplatePath,
                                                ref ExportResult result)
        {
            if (null == dtSource)
            {
                result.Message = "数据源为空引用！";
                result.Status = false;
                return false;
            }

            if (iStartRow < 0 || iStartRow > 65535)
            {
                result.Message = "起始行不满足条件（0~65535）！";
                result.Status = false;
                return false;
            }

            if (iStartColumn < 0 || iStartColumn > 256)
            {
                result.Message = "起始列不满足条件（0~256）！";
                result.Status = false;
                return false;
            }

            if (string.IsNullOrWhiteSpace(strFilePath))
            {
                result.Message = "请输入导出文件名称！";
                result.Status = false;
                return false;
            }

            if (string.IsNullOrWhiteSpace(strTemplatePath))
            {
                result.Message = "请输入模板文件名称！";
                result.Status = false;
                return false;
            }

            if (!File.Exists(strTemplatePath))
            {
                result.Message = "模板文件不存在！";
                result.Status = false;
                return false;
            }

            return true;
        }

        /// <summary>
        /// 创建 Workbook 
        /// </summary>
        /// <param name="strFilePath"></param>
        /// <returns></returns>
        protected virtual IWorkbook CreateWorkbook(string strFilePath)
        {
            return CreateWorkbook(strFilePath, null);
        }

        /// <summary>
        /// 创建 Workbook 
        /// </summary>
        /// <param name="strFilePath"></param>
        /// <param name="stream"></param>
        /// <returns></returns>
        protected virtual IWorkbook CreateWorkbook(string strFilePath, Stream stream)
        {
            IWorkbook workbook = null;  // 新建IWorkbook对象  
            if (strFilePath.EndsWith(".xlsx", StringComparison.OrdinalIgnoreCase))  // 2007版本  
            {
                // xlsx数据读入workbook
                workbook = ((null == stream) ? new XSSFWorkbook() : new XSSFWorkbook(stream));
            }
            else if (strFilePath.EndsWith(".xls", StringComparison.OrdinalIgnoreCase))  // 2003版本  
            {
                // xls数据读入workbook
                workbook = ((null == stream) ? new HSSFWorkbook() : new HSSFWorkbook(stream));
            }
            else
            {
                return null;
            }

            return workbook;
        }

        /// <summary>
        /// 获取 Workbook 
        /// </summary>
        /// <param name="strFilePath"></param>
        /// <returns></returns>
        protected virtual IWorkbook GetWorkbook(string strFilePath)
        {
            string strExtension = Path.GetExtension(strFilePath);
            IWorkbook workbook = null;                  // 新建IWorkbook对象
            using (FileStream fs = new FileStream(strFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                if (strExtension.Equals(".xlsx"))       // 2007版本  
                {
                    workbook = new XSSFWorkbook(fs);    // xlsx数据读入workbook  
                }
                else if (strExtension.Equals(".xls"))   // 2003版本  
                {
                    workbook = new HSSFWorkbook(fs);    // xls数据读入workbook  
                }
                else
                {
                    // no todo
                }

                return workbook;
            }
        }

        /// <summary>
        /// 创建 Sheet 
        /// </summary>
        /// <param name="workbook"></param>
        /// <param name="strSheetName"></param>
        /// <returns></returns>
        protected virtual ISheet CreateSheet(IWorkbook workbook, string strSheetName = "Sheet1")
        {
            return workbook.CreateSheet(strSheetName);
        }

        /// <summary>
        /// 获取已有的 Sheet 
        /// </summary>
        /// <param name="workbook"></param>
        /// <param name="strSheetName"></param>
        /// <returns></returns>
        protected virtual ISheet GetSheet(IWorkbook workbook, string strSheetName = "Sheet1")
        {
            return workbook.GetSheet(strSheetName);
        }

        protected virtual ICellStyle CreateCellStyle(IWorkbook workbook)
        {
            ICellStyle style = workbook.CreateCellStyle();

            // 字体
            IFont font = workbook.CreateFont();
            font.FontHeightInPoints = 20;
            style.SetFont(font);

            // 居中（水平、垂直）
            style.Alignment = HorizontalAlignment.Center;
            style.VerticalAlignment = VerticalAlignment.Center;

            // 边框
            // 上、右、下、左边框
            style.BorderTop = BorderStyle.Thin;
            style.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
            style.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
            style.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;

            return style;
        }

        /// <summary>
        /// 创建数据单元格
        /// </summary>
        /// <param name="iStartRow"></param>
        /// <param name="iStartColumn"></param>
        /// <param name="workbook"></param>
        /// <param name="sheet"></param>
        /// <param name="dt"></param>
        /// <param name="cellStyle"></param>
        protected virtual void CreateRows(int iStartRow, int iStartColumn, IWorkbook workbook, ISheet sheet, DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                IRow cells = sheet.CreateRow(i + iStartRow);
                for (int j = 0; j < dt.Columns.Count; ++j)
                {
                    ICell cell = cells.CreateCell(j + iStartColumn);

                    // 设置单元格内容
                    SetCellValue(workbook, cell, dt.Rows[i], dt.Columns[j]);
                }
            }
        }

        protected virtual void SetCellValue(IWorkbook workbook, ICell cell, DataRow row, DataColumn column)
        {
            string strValue = ((DBNull.Value == row[column] || null == row[column]) ? string.Empty : row[column].ToString());

            switch (column.DataType.ToString())
            {
                case "System.String"://字符串类型
                    cell.SetCellValue(strValue);
                    break;
                case "System.DateTime"://日期类型
                    DateTime dateV;
                    DateTime.TryParse(strValue, out dateV);
                    cell.SetCellValue(dateV);
                    cell.CellStyle.DataFormat = ((HSSFDataFormat)workbook.CreateDataFormat()).GetFormat("yyyy-mm-dd");
                    break;
                case "System.Boolean"://布尔型
                    bool boolV = false;
                    bool.TryParse(strValue, out boolV);
                    cell.SetCellValue(boolV);
                    break;
                case "System.Int16"://整型
                case "System.Int32":
                case "System.Int64":
                case "System.Byte":
                    int intV = 0;
                    int.TryParse(strValue, out intV);
                    cell.SetCellValue(intV);
                    break;
                case "System.Decimal"://浮点型
                case "System.Double":
                    double doubV = 0;
                    double.TryParse(strValue, out doubV);
                    cell.SetCellValue(doubV);
                    break;
                case "System.DBNull"://空值处理
                    cell.SetCellValue("");
                    break;
                default:
                    cell.SetCellValue("");
                    break;
            }
        }

        /// <summary>
        /// 保存 Excel 
        /// </summary>
        /// <param name="workbook"></param>
        /// <param name="strExcelName"></param>
        protected virtual void SaveExcel(IWorkbook workbook, string strExcelName)
        {
            using (FileStream fs = new FileStream(strExcelName, FileMode.Create, FileAccess.Write))
            {
                workbook.Write(fs);
                fs.Flush();
            }
        }
    }
}
