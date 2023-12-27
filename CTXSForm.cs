using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;

namespace CTXS
{
    public partial class CTXSForm : Form
    {
        //public Excel.Workbook Workbook = null;
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

        public CTXSForm(Excel.Worksheet worksheet,long LastCol)
        {
            InitializeComponent();
            this.Worksheet = worksheet;
            this.PartNumColumn = 4;
            this.PartNameColumn = 6;
            this.PSStartColumn = 24;

            this.PartNumColTextBox.Text = "4";
            this.PartNameColTextBox.Text = "6";
            this.PSStartColTextBox.Text = "24";

            this.LastColumn = LastCol;
            //this.LastRow = LastRow;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            long pnuc = Convert.ToInt64(this.PartNumColTextBox.Text); ;
            long pnac = Convert.ToInt64(this.PartNameColTextBox.Text);
            long pssc = Convert.ToInt64(this.PSStartColTextBox.Text);

            if(pnuc > pssc || pnac > pssc)
            {
                MessageBox.Show($"错误,零件号/零件名起始列号不应该大于{PSStartColumn}，请重新输入！");
                return;
            }

            if (pnuc > LastColumn || pnac > LastColumn || pssc > LastColumn)
            {
                MessageBox.Show($"错误,零件号/零件名/派生起始列号不应该大于{LastColumn}，请重新输入！");
                return;
            }

            this.PartNumColumn = Convert.ToInt64(this.PartNumColTextBox.Text);
            this.PartNameColumn = Convert.ToInt64(this.PartNameColTextBox.Text);
            this.PSStartColumn = Convert.ToInt64(this.PSStartColTextBox.Text);
            this.Close();
        }

        private void NGButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SelectPartNumColButton_Click(object sender, EventArgs e)
        {

        }

        private void SelectPartNameColButton_Click(object sender, EventArgs e)
        {

        }

        private void SelectPSStartColButton_Click(object sender, EventArgs e)
        {

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
            if (!(e.KeyChar > '0' && e.KeyChar < '9' || e.KeyChar == '.' || e.KeyChar == 8))
            {
                MessageBox.Show("请输入整数");
                e.Handled = true;
            }
        }

        private void PartNameColTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar > '0' && e.KeyChar < '9' || e.KeyChar == '.' || e.KeyChar == 8))
            {
                MessageBox.Show("请输入整数");
                e.Handled = true;
            }

        }

        private void PSStartColTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar > '0' && e.KeyChar < '9' || e.KeyChar == '.' || e.KeyChar == 8))
            {
                MessageBox.Show("请输入整数");
                e.Handled = true;
            }
        }

    }
}
