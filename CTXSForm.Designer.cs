using System;
using System.Windows.Forms;

namespace CTXS
{
    partial class CTXSForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PartNumColTextBox = new System.Windows.Forms.TextBox();
            this.PartNameColTextBox = new System.Windows.Forms.TextBox();
            this.PSStartColTextBox = new System.Windows.Forms.TextBox();
            this.OKButton = new System.Windows.Forms.Button();
            this.NGButton = new System.Windows.Forms.Button();
            this.PartNumColLabel = new System.Windows.Forms.Label();
            this.PartNameColLabel = new System.Windows.Forms.Label();
            this.PSStartColLabel = new System.Windows.Forms.Label();
            this.CaptionLabel = new System.Windows.Forms.Label();
            this.PartNumColHin = new System.Windows.Forms.Label();
            this.PartNameColHin = new System.Windows.Forms.Label();
            this.PSStartColHin = new System.Windows.Forms.Label();
            this.AbortButton = new System.Windows.Forms.Button();
            this.SelectPartNumColButton = new System.Windows.Forms.Button();
            this.SelectPartNameColButton = new System.Windows.Forms.Button();
            this.SelectPSStartColButton = new System.Windows.Forms.Button();
            this.PartNumColDefaultValueLabel = new System.Windows.Forms.Label();
            this.PartNameColDefaultValueLabel = new System.Windows.Forms.Label();
            this.PSStartColDefaultValueLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PartNumColTextBox
            // 
            this.PartNumColTextBox.Font = new System.Drawing.Font("楷体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PartNumColTextBox.Location = new System.Drawing.Point(556, 97);
            this.PartNumColTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.PartNumColTextBox.Name = "PartNumColTextBox";
            this.PartNumColTextBox.Size = new System.Drawing.Size(361, 50);
            this.PartNumColTextBox.TabIndex = 0;
            this.PartNumColTextBox.Click += new System.EventHandler(this.PartNumColTextBox_Click);
            this.PartNumColTextBox.TextChanged += new System.EventHandler(this.PartNumColTextBox_TextChanged);
            this.PartNumColTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PartNumColTextBox_KeyPress);
            this.PartNumColTextBox.Leave += new System.EventHandler(this.PartNumColTextBox_Leave);
            // 
            // PartNameColTextBox
            // 
            this.PartNameColTextBox.Font = new System.Drawing.Font("楷体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PartNameColTextBox.Location = new System.Drawing.Point(556, 217);
            this.PartNameColTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.PartNameColTextBox.Name = "PartNameColTextBox";
            this.PartNameColTextBox.Size = new System.Drawing.Size(361, 50);
            this.PartNameColTextBox.TabIndex = 1;
            this.PartNameColTextBox.Click += new System.EventHandler(this.PartNameColTextBox_Click);
            this.PartNameColTextBox.TextChanged += new System.EventHandler(this.PartNameColTextBox_TextChanged);
            this.PartNameColTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PartNameColTextBox_KeyPress);
            this.PartNameColTextBox.Leave += new System.EventHandler(this.PartNameColTextBox_Leave);
            // 
            // PSStartColTextBox
            // 
            this.PSStartColTextBox.Font = new System.Drawing.Font("楷体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PSStartColTextBox.Location = new System.Drawing.Point(556, 345);
            this.PSStartColTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.PSStartColTextBox.Name = "PSStartColTextBox";
            this.PSStartColTextBox.Size = new System.Drawing.Size(361, 50);
            this.PSStartColTextBox.TabIndex = 2;
            this.PSStartColTextBox.Click += new System.EventHandler(this.PSStartColTextBox_Click);
            this.PSStartColTextBox.TextChanged += new System.EventHandler(this.PSStartColTextBox_TextChanged);
            this.PSStartColTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PSStartColTextBox_KeyPress);
            this.PSStartColTextBox.Leave += new System.EventHandler(this.PSStartColTextBox_Leave);
            // 
            // OKButton
            // 
            this.OKButton.Font = new System.Drawing.Font("楷体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.OKButton.Location = new System.Drawing.Point(164, 471);
            this.OKButton.Margin = new System.Windows.Forms.Padding(4);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(217, 71);
            this.OKButton.TabIndex = 3;
            this.OKButton.Text = "确定";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // NGButton
            // 
            this.NGButton.Font = new System.Drawing.Font("楷体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.NGButton.Location = new System.Drawing.Point(417, 471);
            this.NGButton.Margin = new System.Windows.Forms.Padding(4);
            this.NGButton.Name = "NGButton";
            this.NGButton.Size = new System.Drawing.Size(217, 71);
            this.NGButton.TabIndex = 4;
            this.NGButton.Text = "保持默认值";
            this.NGButton.UseVisualStyleBackColor = true;
            this.NGButton.Click += new System.EventHandler(this.NGButton_Click);
            // 
            // PartNumColLabel
            // 
            this.PartNumColLabel.AutoSize = true;
            this.PartNumColLabel.Font = new System.Drawing.Font("楷体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PartNumColLabel.Location = new System.Drawing.Point(81, 109);
            this.PartNumColLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PartNumColLabel.Name = "PartNumColLabel";
            this.PartNumColLabel.Size = new System.Drawing.Size(397, 38);
            this.PartNumColLabel.TabIndex = 5;
            this.PartNumColLabel.Text = "请输入零件号所在列数";
            // 
            // PartNameColLabel
            // 
            this.PartNameColLabel.AutoSize = true;
            this.PartNameColLabel.Font = new System.Drawing.Font("楷体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PartNameColLabel.Location = new System.Drawing.Point(81, 229);
            this.PartNameColLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PartNameColLabel.Name = "PartNameColLabel";
            this.PartNameColLabel.Size = new System.Drawing.Size(397, 38);
            this.PartNameColLabel.TabIndex = 6;
            this.PartNameColLabel.Text = "请输入零件名所在列数";
            // 
            // PSStartColLabel
            // 
            this.PSStartColLabel.AutoSize = true;
            this.PSStartColLabel.Font = new System.Drawing.Font("楷体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PSStartColLabel.Location = new System.Drawing.Point(81, 354);
            this.PSStartColLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PSStartColLabel.Name = "PSStartColLabel";
            this.PSStartColLabel.Size = new System.Drawing.Size(435, 38);
            this.PSStartColLabel.TabIndex = 7;
            this.PSStartColLabel.Text = "请输入派生系数起始列数";
            // 
            // CaptionLabel
            // 
            this.CaptionLabel.AutoSize = true;
            this.CaptionLabel.Font = new System.Drawing.Font("楷体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CaptionLabel.Location = new System.Drawing.Point(361, 12);
            this.CaptionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CaptionLabel.Name = "CaptionLabel";
            this.CaptionLabel.Size = new System.Drawing.Size(356, 48);
            this.CaptionLabel.TabIndex = 8;
            this.CaptionLabel.Text = "请确定必要参数";
            // 
            // PartNumColHin
            // 
            this.PartNumColHin.AutoSize = true;
            this.PartNumColHin.ForeColor = System.Drawing.Color.Red;
            this.PartNumColHin.Location = new System.Drawing.Point(556, 159);
            this.PartNumColHin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PartNumColHin.Name = "PartNumColHin";
            this.PartNumColHin.Size = new System.Drawing.Size(0, 24);
            this.PartNumColHin.TabIndex = 12;
            // 
            // PartNameColHin
            // 
            this.PartNameColHin.AutoSize = true;
            this.PartNameColHin.ForeColor = System.Drawing.Color.Red;
            this.PartNameColHin.Location = new System.Drawing.Point(556, 273);
            this.PartNameColHin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PartNameColHin.Name = "PartNameColHin";
            this.PartNameColHin.Size = new System.Drawing.Size(0, 24);
            this.PartNameColHin.TabIndex = 13;
            // 
            // PSStartColHin
            // 
            this.PSStartColHin.AutoSize = true;
            this.PSStartColHin.ForeColor = System.Drawing.Color.Red;
            this.PSStartColHin.Location = new System.Drawing.Point(556, 401);
            this.PSStartColHin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PSStartColHin.Name = "PSStartColHin";
            this.PSStartColHin.Size = new System.Drawing.Size(0, 24);
            this.PSStartColHin.TabIndex = 14;
            // 
            // AbortButton
            // 
            this.AbortButton.Font = new System.Drawing.Font("楷体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AbortButton.Location = new System.Drawing.Point(670, 471);
            this.AbortButton.Margin = new System.Windows.Forms.Padding(4);
            this.AbortButton.Name = "AbortButton";
            this.AbortButton.Size = new System.Drawing.Size(217, 71);
            this.AbortButton.TabIndex = 15;
            this.AbortButton.Text = "终止";
            this.AbortButton.UseVisualStyleBackColor = true;
            this.AbortButton.Click += new System.EventHandler(this.AbortButton_Click);
            // 
            // SelectPartNumColButton
            // 
            this.SelectPartNumColButton.Font = new System.Drawing.Font("宋体", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SelectPartNumColButton.Location = new System.Drawing.Point(940, 97);
            this.SelectPartNumColButton.Name = "SelectPartNumColButton";
            this.SelectPartNumColButton.Size = new System.Drawing.Size(101, 49);
            this.SelectPartNumColButton.TabIndex = 16;
            this.SelectPartNumColButton.Text = "选取";
            this.SelectPartNumColButton.UseVisualStyleBackColor = true;
            this.SelectPartNumColButton.Click += new System.EventHandler(this.SelectPartNumColButton_Click);
            // 
            // SelectPartNameColButton
            // 
            this.SelectPartNameColButton.Font = new System.Drawing.Font("宋体", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SelectPartNameColButton.Location = new System.Drawing.Point(940, 217);
            this.SelectPartNameColButton.Name = "SelectPartNameColButton";
            this.SelectPartNameColButton.Size = new System.Drawing.Size(101, 50);
            this.SelectPartNameColButton.TabIndex = 17;
            this.SelectPartNameColButton.Text = "选取";
            this.SelectPartNameColButton.UseVisualStyleBackColor = true;
            this.SelectPartNameColButton.Click += new System.EventHandler(this.SelectPartNameColButton_Click);
            // 
            // SelectPSStartColButton
            // 
            this.SelectPSStartColButton.Font = new System.Drawing.Font("宋体", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SelectPSStartColButton.Location = new System.Drawing.Point(940, 345);
            this.SelectPSStartColButton.Name = "SelectPSStartColButton";
            this.SelectPSStartColButton.Size = new System.Drawing.Size(101, 50);
            this.SelectPSStartColButton.TabIndex = 18;
            this.SelectPSStartColButton.Text = "选取";
            this.SelectPSStartColButton.UseVisualStyleBackColor = true;
            this.SelectPSStartColButton.Click += new System.EventHandler(this.SelectPSStartColButton_Click);
            // 
            // PartNumColDefaultValueLabel
            // 
            this.PartNumColDefaultValueLabel.AutoSize = true;
            this.PartNumColDefaultValueLabel.Location = new System.Drawing.Point(81, 159);
            this.PartNumColDefaultValueLabel.Name = "PartNumColDefaultValueLabel";
            this.PartNumColDefaultValueLabel.Size = new System.Drawing.Size(118, 24);
            this.PartNumColDefaultValueLabel.TabIndex = 19;
            this.PartNumColDefaultValueLabel.Text = "默认值：4";
            // 
            // PartNameColDefaultValueLabel
            // 
            this.PartNameColDefaultValueLabel.AutoSize = true;
            this.PartNameColDefaultValueLabel.Location = new System.Drawing.Point(81, 288);
            this.PartNameColDefaultValueLabel.Name = "PartNameColDefaultValueLabel";
            this.PartNameColDefaultValueLabel.Size = new System.Drawing.Size(118, 24);
            this.PartNameColDefaultValueLabel.TabIndex = 20;
            this.PartNameColDefaultValueLabel.Text = "默认值：6";
            // 
            // PSStartColDefaultValueLabel
            // 
            this.PSStartColDefaultValueLabel.AutoSize = true;
            this.PSStartColDefaultValueLabel.Location = new System.Drawing.Point(81, 417);
            this.PSStartColDefaultValueLabel.Name = "PSStartColDefaultValueLabel";
            this.PSStartColDefaultValueLabel.Size = new System.Drawing.Size(130, 24);
            this.PSStartColDefaultValueLabel.TabIndex = 21;
            this.PSStartColDefaultValueLabel.Text = "默认值：24";
            // 
            // CTXSForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 600);
            this.Controls.Add(this.PSStartColDefaultValueLabel);
            this.Controls.Add(this.PartNameColDefaultValueLabel);
            this.Controls.Add(this.PartNumColDefaultValueLabel);
            this.Controls.Add(this.SelectPSStartColButton);
            this.Controls.Add(this.SelectPartNameColButton);
            this.Controls.Add(this.SelectPartNumColButton);
            this.Controls.Add(this.AbortButton);
            this.Controls.Add(this.PSStartColHin);
            this.Controls.Add(this.PartNameColHin);
            this.Controls.Add(this.PartNumColHin);
            this.Controls.Add(this.CaptionLabel);
            this.Controls.Add(this.PSStartColLabel);
            this.Controls.Add(this.PartNameColLabel);
            this.Controls.Add(this.PartNumColLabel);
            this.Controls.Add(this.NGButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.PSStartColTextBox);
            this.Controls.Add(this.PartNameColTextBox);
            this.Controls.Add(this.PartNumColTextBox);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CTXSForm";
            this.Text = "CTXSForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        


        #endregion

        private System.Windows.Forms.TextBox PartNumColTextBox;
        private System.Windows.Forms.TextBox PartNameColTextBox;
        private System.Windows.Forms.TextBox PSStartColTextBox;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button NGButton;
        private System.Windows.Forms.Label PartNumColLabel;
        private System.Windows.Forms.Label PartNameColLabel;
        private System.Windows.Forms.Label PSStartColLabel;
        private System.Windows.Forms.Label CaptionLabel;
        private System.Windows.Forms.Label PartNumColHin;
        private System.Windows.Forms.Label PartNameColHin;
        private System.Windows.Forms.Label PSStartColHin;
        private System.Windows.Forms.Button AbortButton;
        private System.Windows.Forms.Button SelectPartNumColButton;
        private System.Windows.Forms.Button SelectPartNameColButton;
        private System.Windows.Forms.Button SelectPSStartColButton;
        private Label PartNumColDefaultValueLabel;
        private Label PartNameColDefaultValueLabel;
        private Label PSStartColDefaultValueLabel;
    }
}