using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastExportRecordToExcel
{
    public class ExportExtend : NPOIExcel
    {
        protected override void CreateRows(int iStartRow, int iStartColumn, IWorkbook workbook, ISheet sheet, DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                IRow cells = sheet.CreateRow(i + iStartRow);
                int j = 0;
                for (; j < dt.Columns.Count - 2; ++j)
                {
                    ICell cell = cells.CreateCell(j + iStartColumn);

                    // 设置单元格内容
                    SetCellValue(workbook, cell, dt.Rows[i], dt.Columns[j]);
                }

                ICell cellTemp = cells.CreateCell(j + iStartColumn);
                // 设置单元格内容
                //SetCellValue(workbook, cellTemp, dt.Rows[i], dt.Columns[j]);
                cellTemp.SetCellValue("file link");

                IHyperlink link = new NPOI.XSSF.UserModel.XSSFHyperlink(HyperlinkType.File);
                link.Address = "pics/image.jpg";
                cellTemp.Hyperlink = link;

                ++j;
                ICell cellTemp2 = cells.CreateCell(j + iStartColumn);
                // 设置单元格内容
                //SetCellValue(workbook, cellTemp2, dt.Rows[i], dt.Columns[j]);
                cellTemp2.SetCellValue("URL link");

                IHyperlink link2 = new NPOI.XSSF.UserModel.XSSFHyperlink(HyperlinkType.Url);
                link2.Address = "http://pic.lvmama.com/uploads/pc/place2/2017-05-25/f722ecdd-48f6-4aa8-a935-77e64b756743.jpg";
                cellTemp2.Hyperlink = link2;
            }
        }
    }
}
