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

        private CTXSForm CTXSForm = null;
        private void CTXSRibbon_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void CTXSButton_Click(object sender, RibbonControlEventArgs e)
        {
            Workbook = Globals.ThisAddIn.Application.ActiveWorkbook;
            Worksheet = Workbook.Worksheets[1];

            LastRow = Worksheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing).Row;
            LastColumn = Worksheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing).Column;

            //LastRow = 9908;
            //LastColumn = 212;

            long PartNumColumn;
            long PartNameColumn;
            long PSStartColumn;

            CTXSForm = new CTXSForm(Worksheet,LastColumn);
            //CTXSForm.Show();
            CTXSForm.ShowDialog();
            PartNumColumn = CTXSForm.getPartNumCol();
            PartNameColumn = CTXSForm.getPartNameCol();
            PSStartColumn = CTXSForm.getPSStartCol();

            //if (PSStartColumn > LastColumn)
            //{
            //    MessageBox.Show("无合适数据处理");
            //    return;
            //}

            for (long R= 1; R<LastRow;R++)
            {
                if(string.IsNullOrEmpty(Convert.ToString(Worksheet.Cells[R, PartNumColumn].value)))
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
                    break;
                }
            }

            //PartNuStartCell = Worksheet.Cells[4, 4];
            //PartNameStartCell = Worksheet.Cells[4, 6];
            //PSStartCell = Worksheet.Cells[4, 24];

            MessageBox.Show($"待处理的最后一行是 {LastRow} 、最后一列是 {LastColumn}");

            long Col = 1;
            long Row = 1;
            long xsCount = 0;

            for (Col = PSStartCell.Column; Col < LastColumn + 1; Col++)
            {
                for (Row = PSStartCell.Row; Row < LastRow + 1; Row++)
                {
                    if (Convert.ToDouble(Worksheet.Cells[Row, Col].Value) == 0.0)
                    {
                        continue;
                    }
                    if (!Convert.ToString(Worksheet.Cells[Row, 4].value).Substring(0,5).Equals(TireKeyNum, StringComparison.OrdinalIgnoreCase))
                    {
                        continue;
                    }
                    else
                    {
                        if (Convert.ToString(Worksheet.Cells[Row, 6].value).ToLower().Contains(SPTireKeyName.ToLower()))
                        {
                            Worksheet.Cells[Row, 6].Activate();
                            Worksheet.Cells[Row, 6].Interior.Color = Color.Yellow;
                            SPTires.Add(Worksheet.Cells[Row, Col]);
                        }
                        else
                        {
                            Worksheet.Cells[Row, 6].Activate();
                            Worksheet.Cells[Row, 6].Interior.Color = Color.Pink;
                            NSPTires.Add(Worksheet.Cells[Row, Col]);
                        }
                    }
                }
                foreach (Excel.Range c in SPTires)
                {
                    c.Value = 1.0 / Convert.ToDouble(SPTires.Count);
                    xsCount++;

                }
                double NSPXSSum = 0;
                foreach (Excel.Range c in NSPTires)
                {
                    NSPXSSum = NSPXSSum + Convert.ToDouble(c.Value);
                }
                foreach (Excel.Range c in NSPTires)
                {
                    c.Activate();
                    c.BorderAround2(Excel.XlLineStyle.xlContinuous,
                        Excel.XlBorderWeight.xlThick,
                        Excel.XlColorIndex.xlColorIndexAutomatic,
                        Excel.XlColorIndex.xlColorIndexAutomatic);
                    c.Value = Math.Round((Convert.ToDouble(c.Value) / NSPXSSum) * 4.0,2);
                    xsCount++;
                }
                SPTires.Clear();
                NSPTires.Clear();
            }
            MessageBox.Show($"共修正 {xsCount} 个轮胎总成的系数");
        }
    }
}
