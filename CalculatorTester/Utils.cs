using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace CalculatorTester
{
    class Utils
    {
        public static bool writeToExcel(string[] headers = null, string[][] data = null)
        {
            Excel.Application excelApp = new Excel.Application();
            if (excelApp != null)
            {
                Excel.Workbook excelWorkbook = excelApp.Workbooks.Add();
                Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelWorkbook.Sheets.Add();

                // Make headers
                for (int i = 0; i < headers.Length; i++)
                {
                    excelWorksheet.Cells[1, i+1] = headers[i];
                }

                // Make records
                for (int i = 0; i < data.Length; i++)
                {
                    for (int j = 0; j < data[0].Length; j++)
                    {
                        if (i == 0)
                        {
                            excelWorksheet.Cells[i+2, j+1] = data[i][j];
                        } 
                        else
                        {
                            excelWorksheet.Cells[i, j + 1] = data[i][j];
                        }
                    }
                }

                excelApp.ActiveWorkbook.SaveAs(@"abc.xls", Excel.XlFileFormat.xlWorkbookNormal);

                excelWorkbook.Close();
                excelApp.Quit();

                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(excelWorksheet);
                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(excelWorkbook);
                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(excelApp);
                GC.Collect();
                GC.WaitForPendingFinalizers();

                return true;
            }
            return false;
        }
    }
}
