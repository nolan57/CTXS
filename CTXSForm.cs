using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
//using Application = System.Windows.Forms.Application;
using Excel = Microsoft.Office.Interop.Excel;
using VB = Microsoft.VisualBasic.Interaction;

namespace CTXS
{
    public partial class CTXSForm : Form
    {
        public bool Go = false;

        public Excel.Workbook Workbook = null;
        public Excel.Worksheet Worksheet = null;

        private long PartNumColumn;
        private long PartNameColumn;
        private long PSStartColumn;

        //private long LastRow;
        private long LastColumn;
        public CTXSForm()
        {
            InitializeComponent();
        }

        public CTXSForm(Excel.Workbook workbook,long LastCol)
        {
            InitializeComponent();
            this.Workbook = workbook;
            this.Worksheet = this.Workbook.Worksheets[1];
            this.PartNumColumn = 4;
            this.PartNameColumn = 6;
            this.PSStartColumn = 24;

            this.PartNumColTextBox.TextChanged -= this.PartNumColTextBox_TextChanged;
            this.PartNameColTextBox.TextChanged -= this.PartNameColTextBox_TextChanged;
            this.PSStartColTextBox.TextChanged -= this.PSStartColTextBox_TextChanged;
            this.PartNumColTextBox.Text = "4";
            this.PartNameColTextBox.Text = "6";
            this.PSStartColTextBox.Text = "24";
            this.PartNumColTextBox.ReadOnly = true;
            this.PartNameColTextBox.ReadOnly = true;
            this.PSStartColTextBox.ReadOnly = true;

            this.PartNumColTextBox.TextChanged += this.PartNumColTextBox_TextChanged;
            this.PartNameColTextBox.TextChanged += this.PartNameColTextBox_TextChanged;
            this.PSStartColTextBox.TextChanged += this.PSStartColTextBox_TextChanged;

            this.LastColumn = LastCol;
            //this.LastRow = LastRow;

            this.PartNumColHin.Visible = false;
            this.PartNameColHin.Visible = false;
            this.PSStartColHin.Visible = false;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.PartNumColTextBox.Text.ToString()))
            {
                this.Close();
                return;
            }
            if (string.IsNullOrEmpty(this.PartNameColTextBox.Text.ToString()))
            {
                this.Close();
                return;
            }
            if (string.IsNullOrEmpty(this.PSStartColTextBox.Text.ToString()))
            {
                this.Close();
                return;
            }



            this.PartNumColumn = Convert.ToInt64(this.PartNumColTextBox.Text);
            this.PartNameColumn = Convert.ToInt64(this.PartNameColTextBox.Text);
            this.PSStartColumn = Convert.ToInt64(this.PSStartColTextBox.Text);
            Go = true;
            this.Close();
        }

        private void NGButton_Click(object sender, EventArgs e)
        {
            this.Go = true;
            this.Close();
        }

        private void SelectPartNumColButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            MessageBox.Show("选取零件号所在列任意单元格即可");
            try
            {
                Excel.Range TC = (Excel.Range)Globals.ThisAddIn.Application.InputBox("To Select",
                    Type.Missing,
                    Type.Missing,
                    Type.Missing,
                    Type.Missing,
                    Type.Missing,
                    Type.Missing,
                    8);
                this.PartNumColTextBox.Text = TC.Column.ToString();
                this.Visible = true;
            }
            catch
            {
                //this.PartNumColTextBox.Text = "4";
                this.Visible = true;
            }
            this.PartNumColTextBox_Leave(sender, e);
        }

        private void SelectPartNameColButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            MessageBox.Show("选取零件名所在列任意单元格即可");
            try
            {
                Excel.Range TC = (Excel.Range)Globals.ThisAddIn.Application.InputBox("To Select",
                    Type.Missing,
                    Type.Missing,
                    Type.Missing,
                    Type.Missing,
                    Type.Missing,
                    Type.Missing,
                    8);
                this.PartNameColTextBox.Text = TC.Column.ToString();
                this.Visible = true;
            }
            catch
            {
                //this.PartNameColTextBox.Text = "6";
                this.Visible = true;
            }
            
            this.PartNameColTextBox_Leave(sender, e);
        }

        private void SelectPSStartColButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            MessageBox.Show("选取派生系数起始列任意单元格即可");
            try {
                Excel.Range TC = (Excel.Range)Globals.ThisAddIn.Application.InputBox("To Select",
                    Type.Missing,
                    Type.Missing,
                    Type.Missing,
                    Type.Missing,
                    Type.Missing,
                    Type.Missing,
                    8);
                this.PSStartColTextBox.Text = TC.Column.ToString();
                this.Visible = true;
            }
            catch
            {
                //this.PSStartColTextBox.Text = "24";
                this.Visible= true;
            }
            
            this.PSStartColTextBox_Leave(sender, e);
        }

        public long getPartNumCol()
        {
            return this.PartNumColumn;
        }

        public long getPartNameCol()
        {
            return this.PartNameColumn;
        }

        public long getPSStartCol()
        {
            return this.PSStartColumn;
        }

        private void PartNumColTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.PartNumColHin.Visible = false;
            if (!(e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == '.' || e.KeyChar == 8))
            {
                this.PartNumColHin.Text = "请输入数字";
                this.PartNumColHin.Visible = true;
                e.Handled = true;
            }
        }

        private void PartNameColTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.PartNameColHin.Visible = false;
            if (!(e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == '.' || e.KeyChar == 8))
            {
                this.PartNameColHin.Text = "请输入数字";
                this.PartNameColHin.Visible = true;
                e.Handled = true;
            }

        }

        private void PSStartColTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.PSStartColHin.Visible = false;
            if (!(e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == '.' || e.KeyChar == 8))
            {
                this.PSStartColHin.Text = "请输入数字";
                this.PSStartColHin.Visible = true;
                e.Handled = true;
            }
        }

        private void PartNumColTextBox_TextChanged(object sender, EventArgs e)
        {
            PartNumColHin.Visible = false;
            if (string.IsNullOrEmpty(this.PartNumColTextBox.Text))
            {
                this.PartNumColHin.Text = $"不能为空否则恢复默认值4";
                this.PartNumColHin.Visible = true;
                this.OKButton.Enabled = false;
                return;
            }
            long Inputed;
            Inputed = Convert.ToInt64(this.PartNumColTextBox.Text);
            if (Inputed == 0)
            {
                this.PartNumColHin.Text = $"不能等于0";
                this.PartNumColHin.Visible = true;
                this.OKButton.Enabled = false;
                return;
            }
            
            if (Inputed > LastColumn)
            {
                this.PartNumColHin.Text = "超出范围、恢复默认值4";
                this.PartNumColHin.Visible = true ;
                this.OKButton.Enabled = false;
                //this.OKButtonEnabledByPartNumColTextBoxChanged = false;
                return;
            }
            //else
            //{
            //    //this.OKButtonEnabledByPartNumColTextBoxChanged = true;
            //    this.PartNumColHin.Visible = false;
            //}
        }

        private void PartNameColTextBox_TextChanged(object sender, EventArgs e)
        {
            PartNameColHin.Visible = false;
            if (string.IsNullOrEmpty(this.PartNameColTextBox.Text))
            {
                this.PartNameColHin.Text = $"不能为空否则恢复默认值6";
                this.PartNameColHin.Visible = true;
                this.OKButton.Enabled = false;
                return;
            }
            long Inputed;
            Inputed= Convert.ToInt64(this.PartNameColTextBox.Text);
            if (Inputed == 0)
            {
                this.PartNameColHin.Text = $"不能等于0";
                this.PartNameColHin.Visible = true;
                this.OKButton.Enabled = false;
                return;
            }
            
            if (Inputed > LastColumn)
            {
                this.PartNameColHin.Text = "超出范围、恢复默认值6";
                this.PartNameColHin.Visible = true;
                this.OKButton.Enabled = false;
                //this.OKButtonEnabledByPartNameColTextBoxChanged = false;
                return;
            }
            //else
            //{
            //    //this.OKButtonEnabledByPartNameColTextBoxChanged = true;
            //    this.PartNameColHin.Visible = false;
            //}
        }

        private void PSStartColTextBox_TextChanged(object sender, EventArgs e)
        {
            PSStartColHin.Visible = false;
            if (string.IsNullOrEmpty(this.PSStartColTextBox.Text))
            {
                this.PSStartColHin.Text = $"不能为空否则恢复默认值24";
                this.PSStartColHin.Visible = true;
                this.OKButton.Enabled = false;
                return;
            }
            long Inputed;
            Inputed = Convert.ToInt64(this.PSStartColTextBox.Text);
            if (Inputed == 0)
            {
                this.PSStartColHin.Text = $"不能等于0";
                this.PSStartColHin.Visible = true;
                this.OKButton.Enabled = false;
                return;
            }
            if (Inputed > LastColumn)
            {
                this.PSStartColHin.Text = "超出范围、恢复默认值24";
                this.PSStartColHin.Visible = true;
                this.OKButton.Enabled = false;
                //this.OKButtonEnabledByPSStartColTextBoxChanged = false;
                return;
            }
            //else
            //{
            //    //this.OKButtonEnabledByPSStartColTextBoxChanged = true;
            //    this.PSStartColHin.Visible = false;
            //}          
        }

        private void PartNumColTextBox_Click(object sender, EventArgs e)
        {
            this.PartNumColTextBox.ReadOnly = false;
        }
        private void PartNameColTextBox_Click(object sender, EventArgs e)
        {
            this.PartNameColTextBox.ReadOnly = false;
        }
        private void PSStartColTextBox_Click(object sender, EventArgs e)
        {
            this.PSStartColTextBox.ReadOnly = false;
        }

        private void PSStartColTextBox_Leave(object sender, EventArgs e)
        {


            long PSStartColInputed;
            if (!(string.IsNullOrEmpty(this.PSStartColTextBox.Text)))
            {
                PSStartColInputed = Convert.ToInt64(this.PSStartColTextBox.Text);
                if(PSStartColInputed > LastColumn)
                {
                    PSStartColInputed = 24;
                    this.PSStartColTextBox.Text = "24";
                }
            }
            else
            {
                PSStartColInputed = 24;
                this.PSStartColTextBox.Text ="24";
            }

            long PartNameColInputed = Convert.ToInt64(this.PartNameColTextBox.Text);
            long PartNumColInputed = Convert.ToInt64(this.PartNumColTextBox.Text);

            this.PSStartColTextBox.ReadOnly=true;
            Check(PartNumColInputed, PartNameColInputed, PSStartColInputed);
        }

        private void PartNumColTextBox_Leave(object sender, EventArgs e)
        {
            long PartNumColInputed;
            if (!(string.IsNullOrEmpty(this.PartNumColTextBox.Text)))
            {
                PartNumColInputed = Convert.ToInt64(this.PartNumColTextBox.Text);
                if(PartNumColInputed > LastColumn)
                {
                    PartNumColInputed= 4;
                    this.PartNumColTextBox.Text = "4";
                }
            }
            else
            {
                PartNumColInputed = 4;
                this.PartNumColTextBox.Text = "4";
            }

            long PartNameColInputed = Convert.ToInt64(this.PartNameColTextBox.Text);
            long PSStartColInputed = Convert.ToInt64(this.PSStartColTextBox.Text);

            this.PartNumColTextBox.ReadOnly = true;
            Check(PartNumColInputed, PartNameColInputed, PSStartColInputed);
        }

        private void PartNameColTextBox_Leave(object sender, EventArgs e)
        {
            long PartNameColInputed;
            if (!(string.IsNullOrEmpty(this.PartNameColTextBox.Text)))
            {
                PartNameColInputed = Convert.ToInt64(this.PartNameColTextBox.Text);
                if(PartNameColInputed > LastColumn)
                {
                    PartNameColInputed = 6;
                    this.PartNameColTextBox.Text = "6";
                }

            }
            else
            {
                PartNameColInputed = 6;
                this.PartNameColTextBox.Text = "6";
            }

            long PSStartColInputed = Convert.ToInt64(this.PSStartColTextBox.Text);
            long PartNumColInputed = Convert.ToInt64(this.PartNumColTextBox.Text);

            this.PartNameColTextBox.ReadOnly = true;
            Check(PartNumColInputed, PartNameColInputed, PSStartColInputed);
        }

        private void AbortButton_Click(object sender, EventArgs e)
        {
            this.Go = false;
            this.Close();
        }
        private void Check(
            long PartNumColInputed,
            long PartNameColInputed, 
            long PSStartColInputed)
        {
            //if (this.OKButtonEnabledByPartNameColTextBoxChanged &&
            //    this.OKButtonEnabledByPartNumColTextBoxChanged &&
            //    this.OKButtonEnabledByPSStartColTextBoxChanged)
            //{
                if ((PartNumColInputed < PSStartColInputed) &&
                    (PartNameColInputed < PSStartColInputed) &&
                    !(PartNumColInputed == PartNameColInputed))
                {
                    this.PartNumColHin.Visible = false;
                    this.PartNameColHin.Visible = false;
                    this.PSStartColHin.Visible = false;
                    this.OKButton.Enabled = true;
                }
                else
                {
                    if(PartNumColInputed == PartNameColInputed)
                    {
                        if(PartNumColInputed >= PSStartColInputed)
                        {
                            this.PartNumColHin.Text = "零件号和零件名同列&不小于派生系数起始列";
                            this.PSStartColHin.Text = "不大于零件号/零件名列";
                            this.PartNumColHin.Visible = true;
                            this.PSStartColHin.Visible = true;
                        }
                        else
                        {
                            this.PartNumColHin.Text = "零件号和零件名同列";
                            this.PartNumColHin.Visible = true;
                            this.PSStartColHin.Visible = false;
                        }

                        if(PartNameColInputed >= PSStartColInputed)
                        {
                            this.PartNameColHin.Text= "零件号和零件名同列&不小于派生系数起始列";
                            this.PSStartColHin.Text = "不大于零件号/零件名列";
                            this.PartNameColHin.Visible= true;
                            this.PSStartColHin.Visible = true;
                        }
                        else
                        {
                            this.PartNameColHin.Text = "零件号和零件名同列";
                            this.PartNameColHin.Visible = true;
                            this.PSStartColHin.Visible = false;
                        }
                    }
                    else
                    {
                        if (PartNumColInputed >= PSStartColInputed)
                        {
                            this.PartNumColHin.Text = "不小于派生系数起始列";
                            this.PSStartColHin.Text = "不大于零件号/零件名列";
                            this.PartNumColHin.Visible = true;
                            this.PSStartColHin.Visible = true;
                        }
                        if (PartNameColInputed >= PSStartColInputed)
                        {
                            this.PartNameColHin.Text = "不小于派生系数起始列";
                            this.PSStartColHin.Text = "不大于零件号/零件名列";
                            this.PartNameColHin.Visible = true;
                            this.PSStartColHin.Visible = true;
                        }
                    }
                    this.OKButton.Enabled = false;
                }
            //}
            //else
            //{
            //    this.OKButton.Enabled = false;
            //}
        }
    }
}
