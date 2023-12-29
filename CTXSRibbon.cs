using Microsoft.Office.Tools.Ribbon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using System.IO;
using System.Collections;
using System.Windows.Forms;
using System.Globalization;
using System.Drawing;
using Microsoft.Office.Interop.Excel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Runtime.InteropServices;

namespace CTXS
{
    
    public partial class CTXSRibbon
    {
        private List<Excel.Range> SPTires = new List<Excel.Range>();
        private List<Excel.Range> NSPTires = new List<Excel.Range>();

        private Excel.Workbook Workbook = null;
        private Excel.Worksheet Worksheet = null;

        private long LastRow;
        private long LastColumn;

        private Excel.Range PartNuStartCell;
        private Excel.Range PartNameStartCell;
        private Excel.Range PSStartCell;

        private const string TireKeyNum = "42751";
        private const string SPTireKeyName = "D";
        

        //private DialogResult dialogResult = DialogResult.OK;

        //DialogResult ToSelectColMB(string MBMessage)
        //{
        //    string MBCaption = "ToSelect？";
        //    MessageBoxButtons MBButtons = MessageBoxButtons.YesNo;
        //    DialogResult MBResult;

        //    MBResult = MessageBox.Show(MBMessage, MBCaption,
        //        MBButtons, MessageBoxIcon.Question,
        //        MessageBoxDefaultButton.Button1,
        //        MessageBoxOptions.RightAlign);
        //    return MBResult;
        //}
        
        private CTXSForm CTXSForm = null;
        private ProcessingForm ProcessingForm = null;
        private void CTXSRibbon_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void CTXSButton_Click(object sender, RibbonControlEventArgs e)
        {
            Workbook = Globals.ThisAddIn.Application.ActiveWorkbook;
            Worksheet = Workbook.ActiveSheet;

            LastRow = Worksheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing).Row;
            LastColumn = Worksheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing).Column;

            //LastRow = 9908;
            //LastColumn = 212;

            long PartNumColumn = 4;
            long PartNameColumn = 6;
            long PSStartColumn = 24;
            long StartRow = 1;

            //Excel.Range TC;

            //dialogResult = ToSelectColMB("默认零件号在第4列，重新选？");
            //while(dialogResult == DialogResult.Yes) {
            //    TC = (Excel.Range)Globals.ThisAddIn.Application.InputBox("To Select",
            //        Type.Missing,
            //        Type.Missing,
            //        Type.Missing,
            //        Type.Missing,
            //        Type.Missing,
            //        Type.Missing,
            //        8);
            //    dialogResult = ToSelectColMB($"零件号在第{TC.Column}列，需要重选吗？");
            //}

            CTXSForm = new CTXSForm(Workbook, LastColumn);
            CTXSForm.ShowDialog();

            if (!CTXSForm.Go)
            {
                return;
            }

            PartNumColumn = CTXSForm.getPartNumCol();
            PartNameColumn = CTXSForm.getPartNameCol();
            PSStartColumn = CTXSForm.getPSStartCol();

            MessageBox.Show($"零件号列：{PartNumColumn},零件名列{PartNameColumn},派生系数列：{PSStartColumn}");

            MessageBox.Show($"表格范围：{LastRow}行、{LastColumn}列");

            for (long R= StartRow; R <LastRow;R++)
            {
                if (Worksheet.Cells[R, PartNumColumn].Value is null)
                {
                    continue;
                }
                if (string.IsNullOrEmpty(Convert.ToString(Worksheet.Cells[R, PartNumColumn].value)))
                {
                    continue;
                }

                if (Convert.ToString(Worksheet.Cells[R, PartNumColumn].value).Substring(0, 5).Equals(TireKeyNum, StringComparison.OrdinalIgnoreCase))
                {
                    PartNuStartCell = Worksheet.Cells[R, PartNumColumn];
                    PartNameStartCell = Worksheet.Cells[R, PartNameColumn];
                    PSStartCell = Worksheet.Cells[R, PSStartColumn];
                    PartNuStartCell.BorderAround2(Excel.XlLineStyle.xlContinuous,
                        Excel.XlBorderWeight.xlThick,
                        Excel.XlColorIndex.xlColorIndexAutomatic,
                        Excel.XlColorIndex.xlColorIndexAutomatic);

                    PartNameStartCell.BorderAround2(Excel.XlLineStyle.xlContinuous,
                        Excel.XlBorderWeight.xlThick,
                        Excel.XlColorIndex.xlColorIndexAutomatic,
                        Excel.XlColorIndex.xlColorIndexAutomatic);

                    PSStartCell.BorderAround2(Excel.XlLineStyle.xlContinuous,
                        Excel.XlBorderWeight.xlThick,
                        Excel.XlColorIndex.xlColorIndexAutomatic,
                        Excel.XlColorIndex.xlColorIndexAutomatic);
                    PartNuStartCell.Activate();
                    MessageBox.Show($"轮胎总成零件号起始单元：[{PartNuStartCell.Row},{PartNuStartCell.Column}]");
                    MessageBox.Show($"轮胎总成零件名起始单元：[{PartNameStartCell.Row},{PartNameStartCell.Column}]");
                    MessageBox.Show($"派生系数起始单元：[{PSStartCell.Row},{PSStartCell.Column}]");
                    break;
                }
            }

            //PartNuStartCell = Worksheet.Cells[4, 4];
            //PartNameStartCell = Worksheet.Cells[4, 6];
            //PSStartCell = Worksheet.Cells[4, 24];

            ProcessingForm = new ProcessingForm();
            Excel.Range EndPartNumCell = PartNuStartCell;

            for(long Row = PartNuStartCell.Row;Row < LastRow; Row++)
            {
                if (Worksheet.Cells[Row, PartNumColumn].Value is null)
                {
                    continue;
                }
                if (string.IsNullOrEmpty(Worksheet.Cells[Row, PartNumColumn].Value.ToString()))
                {
                    continue;
                }
                if (Worksheet.Cells[Row, PartNumColumn].Value.ToString().Contains(TireKeyNum))
                {
                    EndPartNumCell = Worksheet.Cells[Row, PartNumColumn];
                }

            }

            MessageBox.Show($"修正起始行：{PartNuStartCell.Row} 、修正结束行：{EndPartNumCell.Row}");
            long xsCount = 0;

            ProcessingForm.Show();
            Thread.Sleep(500);

            for (long Col = PSStartCell.Column; Col < LastColumn+1; Col++)
            {
                for (long Row = PSStartCell.Row; Row < EndPartNumCell.Row+1; Row++)
                {
                    if (Worksheet.Cells[Row, Col].Value is null)
                    {
                        continue;
                    }
                   if (string.IsNullOrEmpty(Worksheet.Cells[Row, Col].Value.ToString()))
                   {
                        continue;
                    }
                    if (Worksheet.Cells[Row,Col].Value == 0)
                    {
                        continue;
                    }

                    if (Worksheet.Cells[Row, PartNumColumn].Value is null)
                    {
                        continue;
                    }
                    if (string.IsNullOrEmpty(Worksheet.Cells[Row, PartNumColumn].Value.ToString()))
                    {
                        continue;
                    }

                    if (Worksheet.Cells[Row, PartNumColumn].Value.ToString().Contains(TireKeyNum))
                    {
                                     
                        if (Worksheet.Cells[Row, PartNameColumn].value.ToString().ToLower().Contains(SPTireKeyName.ToLower()))
                        {
                            //Worksheet.Cells[Row, 6].Activate();
                            Worksheet.Cells[Row, 6].Interior.Color = Color.Yellow;
                            SPTires.Add(Worksheet.Cells[Row, Col]);
                        }
                        else
                        {
                            //Worksheet.Cells[Row, 6].Activate();
                            Worksheet.Cells[Row, 6].Interior.Color = Color.Pink;
                            NSPTires.Add(Worksheet.Cells[Row, Col]);
                        }
                    }
                }
                foreach (Excel.Range c in SPTires)
                {
                    //c.Activate();
                    c.BorderAround2(Excel.XlLineStyle.xlContinuous,
                        Excel.XlBorderWeight.xlThick,
                        Excel.XlColorIndex.xlColorIndexAutomatic,
                        Excel.XlColorIndex.xlColorIndexAutomatic);
                    c.Value = 1.0 / Convert.ToDouble(SPTires.Count);
                    xsCount++;

                }

                double NSPXSSum = 0;
                foreach (Excel.Range c in NSPTires)
                {
                    NSPXSSum = NSPXSSum + Convert.ToDouble(c.Value);
                }
                long NPSTireCount = 0;
                double TempSum = 0;
                foreach (Excel.Range c in NSPTires)
                {
                    //c.Activate();
                    c.BorderAround2(Excel.XlLineStyle.xlContinuous,
                        Excel.XlBorderWeight.xlThick,
                        Excel.XlColorIndex.xlColorIndexAutomatic,
                        Excel.XlColorIndex.xlColorIndexAutomatic);
                    NPSTireCount++;
                    if(NPSTireCount <NSPTires.Count)
                    {
                        c.Value = Math.Round((Convert.ToDouble(c.Value) / NSPXSSum) * 4.0, 0);
                        TempSum += Convert.ToDouble(c.Value);
                        xsCount++;
                        continue;
                    }
                    c.Value = 4-TempSum;
                    xsCount++;
                }
                NPSTireCount = 0;
                TempSum = 0;
                SPTires.Clear();
                NSPTires.Clear();
                NSPXSSum = 0;
                ProcessingForm.ProcessingLabel.Text = $"修正第{xsCount}个系数";
                Thread.Sleep(200);
            }
            ProcessingForm.ProcessingLabel.Text = $"结束，共修正{xsCount}个系数";
            CTXSForm.Dispose();
        }
    }
}
