using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Microsoft.Office.Core;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Diagnostics;
using Microsoft.Office.Interop.Excel;

namespace TSB
{
    class ExcelOp
    {
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowThreadProcessId(IntPtr hwnd, out int ID);

        private string filePathRd;
        private string filePathWr;
        private Excel.Application xlApp;
        private Excel.Workbook xlsWorkBook;
        public Excel.Worksheet sheet;


        public ExcelOp(string fileName, int sheetID)
        {
            filePathRd = fileName;
            xlApp = new Excel.Application();
            xlApp.DisplayAlerts = false;
            xlApp.Visible = false;
            xlApp.ScreenUpdating = false;

            try
            {
                xlsWorkBook = xlApp.Workbooks.Open(filePathRd, System.Type.Missing, System.Type.Missing, System.Type.Missing,
                                                    System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing,
                                                    System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing,
                                                    System.Type.Missing, System.Type.Missing, System.Type.Missing);

                if(sheetID >= 1)
                    sheet = xlsWorkBook.Worksheets[sheetID];//工作薄从1开始，不是0
            }
            catch
            {
                //ExcelClose();
                MessageBox.Show("Excel打开失败！");
            }

        }


        public void ExcelClose()
        {
            if (xlsWorkBook != null)
                xlsWorkBook.Close(true, Type.Missing, Type.Missing);
            xlApp.Quit();

            // 安全回收进程
            //System.GC.GetGeneration(xlApp);
            IntPtr t = new IntPtr(xlApp.Hwnd);//获取句柄
            int k = 0;
            GetWindowThreadProcessId(t, out k);//获取进程唯一标志
            System.Diagnostics.Process p = System.Diagnostics.Process.GetProcessById(k);
            p.Kill();//关闭进程
        }

        public void ExcelSave(string fileName)
        {
            try
            {
                xlsWorkBook.SaveAs(fileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
                                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            }
            catch
            {
                //ExcelClose();
                MessageBox.Show("Excel保存失败！");
            }
        }

        

        public void CellWr(int row, int col, string val)
        {
            try
            {
                sheet.Cells[row, col] = val;
            }
            catch
            {
                //MessageBox.Show("Excel写入失败！");
            }

        }

        public string CellRd(int row, int col)
        {
            //return ((Excel.Range)sheet.Cells[row, col]).Text.ToString();
            if (((Excel.Range)sheet.Cells[row, col]).Value2 == null)
                return "";
            else
                return ((Excel.Range)sheet.Cells[row, col]).Value2.ToString().Trim();
        }





        public static void Kill(Microsoft.Office.Interop.Excel.Application excel)
        {
            IntPtr t = new IntPtr(excel.Hwnd);//得到这个句柄，具体作用是得到这块内存入口 

            int k = 0;
            GetWindowThreadProcessId(t, out k);//得到本进程唯一标志k

            System.Diagnostics.Process p = System.Diagnostics.Process.GetProcessById(k);//得到对进程k的引用

            p.Kill();//关闭进程k
        }
    }
}
