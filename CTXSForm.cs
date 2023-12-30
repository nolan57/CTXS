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
        private bool OKButtonEnabledByPartNumColTextBoxChanged = true;
        private bool OKButtonEnabledByPartNameColTextBoxChanged = true;
        private bool OKButtonEnabledByPSStartColTextBoxChanged = true;

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

            //this.PartNumColTextBox.Enabled = false;
            //this.PartNameColTextBox.Enabled = false;
            //this.PSStartColTextBox.Enabled = false;
            this.PartNumColTextBox.TextChanged -= this.PartNumColTextBox_TextChanged;
            this.PartNameColTextBox.TextChanged -= this.PartNameColTextBox_TextChanged;
            this.PSStartColTextBox.TextChanged -= this.PSStartColTextBox_TextChanged;
            this.PartNumColTextBox.Text = "4";
            this.PartNameColTextBox.Text = "6";
            this.PSStartColTextBox.Text = "24";
            this.PartNumColTextBox.ReadOnly = true;
            this.PartNameColTextBox.ReadOnly = true;
            this.PSStartColTextBox.ReadOnly = true;

            //this.PartNumColTextBox.Enabled = true;
            //this.PartNameColTextBox.Enabled = true;
            //this.PSStartColTextBox.Enabled = true;
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

        private void SelectPartNameColButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;
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

        private void SelectPSStartColButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;
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
                //MessageBox.Show("请输入整数");
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
                //MessageBox.Show("请输入整数");
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
                //MessageBox.Show("请输入整数");
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
                //this.OKButton.Enabled = false;
                return;
            }
            long Inputed;
            Inputed = Convert.ToInt64(this.PartNumColTextBox.Text);
            if (Inputed == 0)
            {
                this.PartNumColHin.Text = $"不能等于0";
                this.PartNumColHin.Visible = true;
                //this.OKButton.Enabled = false;
                return;
            }
            if (Inputed == Convert.ToInt64(this.PartNameColTextBox.Text))
            {
                this.PartNumColHin.Text = $"不能和零件名同列";
                this.PartNumColHin.Visible = true;
                //this.OKButton.Enabled = false;
                return;
            }
            if (Inputed > LastColumn)
            {
                this.PartNumColHin.Text = $"不能超出最边列：{LastColumn}";
                this.PartNumColHin.Visible = true ;
                this.OKButton.Enabled = false;
                this.OKButtonEnabledByPartNumColTextBoxChanged = false;
            }
            else
            {
                this.OKButtonEnabledByPartNumColTextBoxChanged = true;
                this.PartNameColHin.Visible = false;
            }
            long PSStarColInputed;
            PSStarColInputed = Convert.ToInt64(this.PSStartColTextBox.Text);
            if (Inputed >= PSStarColInputed)
            {
                this.PartNumColHin.Text = $"不能大于等于派生系数起始列：{PSStarColInputed}";
                this.PartNumColHin.Visible = true;
                //this.OKButton.Enabled = false;
                return;
            }
        }

        private void PartNameColTextBox_TextChanged(object sender, EventArgs e)
        {
            PartNameColHin.Visible = false;
            if (string.IsNullOrEmpty(this.PartNameColTextBox.Text))
            {
                this.PartNameColHin.Text = $"不能为空否则恢复默认值6";
                this.PartNameColHin.Visible = true;
                //this.OKButton.Enabled = false;
                return;
            }
            long Inputed;
            Inputed= Convert.ToInt64(this.PartNameColTextBox.Text);
            if (Inputed == 0)
            {
                this.PartNameColHin.Text = $"不能等于0";
                this.PartNameColHin.Visible = true;
                //this.OKButton.Enabled = false;
                return;
            }
            if (Inputed == Convert.ToInt64(this.PartNumColTextBox.Text))
            {
                this.PartNameColHin.Text = $"不能和零件号同列";
                this.PartNameColHin.Visible = true;
                //this.OKButton.Enabled = false;
                return;
            }
            if (Inputed > LastColumn)
            {
                this.PartNameColHin.Text = $"不能超出最边列：{LastColumn}";
                this.PartNameColHin.Visible = true;
                //this.OKButton.Enabled = false;
                this.OKButtonEnabledByPartNameColTextBoxChanged = false;
            }
            else
            {
                this.OKButtonEnabledByPartNameColTextBoxChanged = true;
                this.PartNameColHin.Visible = false;
            }

            long PSStarColInputed;
            PSStarColInputed = Convert.ToInt64(this.PSStartColTextBox.Text);
            if (Inputed >= PSStarColInputed)
            {
                this.PartNameColHin.Text = $"不能大于等于派生系数起始列：{PSStarColInputed}";
                this.PartNameColHin.Visible = true;
                //this.OKButton.Enabled = false;
                return;
            }
        }

        private void PSStartColTextBox_TextChanged(object sender, EventArgs e)
        {
            PSStartColHin.Visible = false;
            if (string.IsNullOrEmpty(this.PSStartColTextBox.Text))
            {
                this.PSStartColHin.Text = $"不能为空否则恢复默认值24";
                this.PSStartColHin.Visible = true;
                //this.OKButton.Enabled = false;
                return;
            }
            long Inputed;
            Inputed = Convert.ToInt64(this.PSStartColTextBox.Text);
            if (Inputed == 0)
            {
                this.PSStartColHin.Text = $"不能等于0";
                this.PSStartColHin.Visible = true;
                //this.OKButton.Enabled = false;
                return;
            }
            if (Inputed > LastColumn)
            {
                this.PSStartColHin.Text = $"不能超出最边列：{LastColumn}";
                this.PSStartColHin.Visible = true;
                //this.OKButton.Enabled = false;
                this.OKButtonEnabledByPSStartColTextBoxChanged = false;
            }
            else
            {
                this.OKButtonEnabledByPSStartColTextBoxChanged = true;
                this.PSStartColHin.Visible = false;
            }
            long PartNumColInputed = Convert.ToInt64(this.PartNumColTextBox.Text);
            long PartNameColInputed = Convert.ToInt64(this.PartNameColTextBox.Text);
            if (Inputed <= PartNumColInputed )
            {
                this.PSStartColHin.Text = $"不能小于等于零件号所在列：{PartNumColInputed}";
                this.PSStartColHin.Visible = true;
                //this.OKButton.Enabled = false;
                return;
            }
            if (Inputed <= PartNameColInputed)
            {
                this.PSStartColHin.Text = $"不能小于等于零件名所在列：{PartNameColInputed}";
                this.PSStartColHin.Visible = true;
                //this.OKButton.Enabled = false;
                return;
            }
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


            long PSStartColInputed = 24;
            if (!(string.IsNullOrEmpty(this.PSStartColTextBox.Text)))
            {
                PSStartColInputed = Convert.ToInt64(this.PSStartColTextBox.Text);
            }
            else
            {
                this.PSStartColTextBox.Text =$"{PSStartColInputed}";
            }

            long PartNameColInputed = Convert.ToInt64(this.PartNameColTextBox.Text);
            long PartNumColInputed = Convert.ToInt64(this.PartNumColTextBox.Text);

            this.PSStartColTextBox.ReadOnly=true;
            if (this.OKButtonEnabledByPartNameColTextBoxChanged &&
                this.OKButtonEnabledByPartNumColTextBoxChanged &&
                this.OKButtonEnabledByPSStartColTextBoxChanged)
            {
                if((PartNumColInputed < PSStartColInputed) && 
                    (PartNameColInputed < PSStartColInputed))
                {
                    this.OKButton.Enabled = true;
                }
                else
                {
                    if (!(PartNumColInputed < PSStartColInputed))
                    {
                        this.PartNumColHin.Text = $"不能大于派生系数起始列：{Convert.ToInt64(this.PSStartColTextBox.Text)}";
                        this.PartNumColHin.Visible = true;
                    }
                    if (!(PartNameColInputed < PSStartColInputed))
                    {
                        this.PartNameColHin.Text = $"不能大于派生系数起始列：{Convert.ToInt64(this.PSStartColTextBox.Text)}";
                        this.PartNameColHin.Visible = true;
                    }
                    this.OKButton.Enabled = false;
                }
            }
            else
            {
                this.OKButton.Enabled = false;
            }
        }

        private void PartNumColTextBox_Leave(object sender, EventArgs e)
        {
            long PartNumColInputed = 4;
            if (!(string.IsNullOrEmpty(this.PartNumColTextBox.Text)))
            {
                PartNumColInputed = Convert.ToInt64(this.PartNumColTextBox.Text);
            }
            else
            {
                this.PartNumColTextBox.Text = $"{PartNumColInputed}";
            }

            long PartNameColInputed = Convert.ToInt64(this.PartNameColTextBox.Text);
            long PSStartColInputed = Convert.ToInt64(this.PSStartColTextBox.Text);

            this.PartNumColTextBox.ReadOnly = true;
            if (this.OKButtonEnabledByPartNameColTextBoxChanged &&
                this.OKButtonEnabledByPartNumColTextBoxChanged &&
                this.OKButtonEnabledByPSStartColTextBoxChanged)
            {
                if ((PartNumColInputed < PSStartColInputed) && (PartNameColInputed < PSStartColInputed))
                {
                    this.OKButton.Enabled = true;
                }
                else
                {
                    if(!(PartNumColInputed < PSStartColInputed))
                    {
                        this.PartNumColHin.Text = $"不能大于等于派生系数起始列：{Convert.ToInt64(this.PSStartColTextBox.Text)}";
                        this.PartNumColHin.Visible = true;
                    }
                    if (!(PartNameColInputed < PSStartColInputed))
                    {
                        this.PartNameColHin.Text = $"不能大于等于派生系数起始列：{Convert.ToInt64(this.PSStartColTextBox.Text)}";
                        this.PartNameColHin.Visible = true;
                    }
                    this.OKButton.Enabled = false;
                }
            }
            else
            {
                this.OKButton.Enabled = false;
            }
        }

        private void PartNameColTextBox_Leave(object sender, EventArgs e)
        {
            long PartNameColInputed = 6;
            if (!(string.IsNullOrEmpty(this.PartNameColTextBox.Text)))
            {
                PartNameColInputed = Convert.ToInt64(this.PartNameColTextBox.Text);
            }
            else
            {
                this.PartNameColTextBox.Text = $"{PartNameColInputed}";
            }

            long PSStartColInputed = Convert.ToInt64(this.PSStartColTextBox.Text);
            long PartNumColInputed = Convert.ToInt64(this.PartNumColTextBox.Text);

            this.PartNameColTextBox.ReadOnly = true;
            if (this.OKButtonEnabledByPartNameColTextBoxChanged &&
                this.OKButtonEnabledByPartNumColTextBoxChanged &&
                this.OKButtonEnabledByPSStartColTextBoxChanged)
            {
                if ((PartNumColInputed < PSStartColInputed) && (PartNameColInputed < PSStartColInputed))
                {
                    this.OKButton.Enabled = true;
                }
                else
                {
                    if (!(PartNumColInputed < PSStartColInputed))
                    {
                        this.PartNumColHin.Text = $"不能大于等于派生系数起始列：{Convert.ToInt64(this.PSStartColTextBox.Text)}";
                        this.PartNumColHin.Visible = true;
                    }
                    if (!(PartNameColInputed < PSStartColInputed))
                    {
                        this.PartNameColHin.Text = $"不能大于等于派生系数起始列：{Convert.ToInt64(this.PSStartColTextBox.Text)}";
                        this.PartNameColHin.Visible = true;
                    }
                    this.OKButton.Enabled = false;
                }
            }
            else
            {
                this.OKButton.Enabled = false;
            }
        }

        private void AbortButton_Click(object sender, EventArgs e)
        {
            this.Go = false;
            this.Close();
        }
    }
}
