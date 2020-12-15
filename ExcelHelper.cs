using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Rename_File_Or_Foder
{
    class ExcelHelper
    {
        public static void GenerateExcel(DataTable dataTable, string path)
        {
            DataSet dataSet = new DataSet();
            dataSet.Tables.Add(dataTable);

            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook excelWorkBook = excelApp.Workbooks.Add();
            Excel._Worksheet xlWorksheet = excelWorkBook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;
            foreach (DataTable table in dataSet.Tables)
            {
                //Add a new worksheet to workbook with the Datatable name
                Excel.Worksheet excelWorkSheet = excelWorkBook.Sheets.Add();
                excelWorkSheet.Name = table.TableName;

                // add all the columns
                for (int i = 1; i < table.Columns.Count + 1; i++)
                {
                    excelWorkSheet.Cells[1, i] = table.Columns[i - 1].ColumnName;
                }

                // add all the rows
                for (int j = 0; j < table.Rows.Count; j++)
                {
                    for (int k = 0; k < table.Columns.Count; k++)
                    {
                        excelWorkSheet.Cells[j + 2, k + 1] = table.Rows[j].ItemArray[k].ToString();
                    }
                }
            }
            excelWorkBook.SaveAs(path);
            excelWorkBook.Close();
            excelApp.Quit();
        }
        public static List<ListLoad> RedingExcel(string path)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            Excel.Range range;

            string str;
            int rw = 0;
            int cl = 0;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(path, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            range = xlWorkSheet.UsedRange;
            rw = range.Rows.Count;
            cl = range.Columns.Count;

            string[] header = new string[range.Columns.Count];
            for (int cot = 1; cot <= range.Columns.Count; cot++)
            {
                str = (string)(range.Cells[1, cot] as Excel.Range).Value2;
                header[cot-1] = str;
            }
            //ListLoad listLoad = new ListLoad();
            //listLoad.SetValueByName("Path", "dsvcsvdgcsd");
            //Console.WriteLine(listLoad);
            List<ListLoad> list = new List<ListLoad>();
            for (int rCnt = 2; rCnt <= rw; rCnt++)
            {
                ListLoad listLoad = new ListLoad();
                for (int cCnt = 1; cCnt <= cl; cCnt++)
                {
                    try
                    {
                        str = Convert.ToString((range.Cells[rCnt, cCnt] as Excel.Range).Value2);
                    }
                    catch
                    {
                        str = null;
                    }
                    listLoad.SetValueByName(header[cCnt - 1], str);
                }
                list.Add(listLoad);
            }

            xlWorkBook.Close(true, null, null);
            xlApp.Quit();

            Marshal.ReleaseComObject(xlWorkSheet);
            Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(xlApp);

            return list;
        }
    }
}
