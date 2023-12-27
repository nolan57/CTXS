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
            this.label4 = new System.Windows.Forms.Label();
            this.SelectPartNumColButton = new System.Windows.Forms.Button();
            this.SelectPartNameColButton = new System.Windows.Forms.Button();
            this.SelectPSStartColButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PartNumColTextBox
            // 
            this.PartNumColTextBox.Font = new System.Drawing.Font("楷体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PartNumColTextBox.Location = new System.Drawing.Point(417, 73);
            this.PartNumColTextBox.Name = "PartNumColTextBox";
            this.PartNumColTextBox.Size = new System.Drawing.Size(272, 39);
            this.PartNumColTextBox.TabIndex = 0;
            this.PartNumColTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PartNumColTextBox_KeyPress);
            // 
            // PartNameColTextBox
            // 
            this.PartNameColTextBox.Font = new System.Drawing.Font("楷体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PartNameColTextBox.Location = new System.Drawing.Point(417, 163);
            this.PartNameColTextBox.Name = "PartNameColTextBox";
            this.PartNameColTextBox.Size = new System.Drawing.Size(272, 39);
            this.PartNameColTextBox.TabIndex = 1;
            this.PartNameColTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PartNameColTextBox_KeyPress);
            // 
            // PSStartColTextBox
            // 
            this.PSStartColTextBox.Font = new System.Drawing.Font("楷体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PSStartColTextBox.Location = new System.Drawing.Point(417, 259);
            this.PSStartColTextBox.Name = "PSStartColTextBox";
            this.PSStartColTextBox.Size = new System.Drawing.Size(272, 39);
            this.PSStartColTextBox.TabIndex = 2;
            this.PSStartColTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PSStartColTextBox_KeyPress);
            // 
            // OKButton
            // 
            this.OKButton.Font = new System.Drawing.Font("楷体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.OKButton.Location = new System.Drawing.Point(155, 355);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(163, 53);
            this.OKButton.TabIndex = 3;
            this.OKButton.Text = "确定";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // NGButton
            // 
            this.NGButton.Font = new System.Drawing.Font("楷体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.NGButton.Location = new System.Drawing.Point(472, 354);
            this.NGButton.Name = "NGButton";
            this.NGButton.Size = new System.Drawing.Size(163, 53);
            this.NGButton.TabIndex = 4;
            this.NGButton.Text = "放弃";
            this.NGButton.UseVisualStyleBackColor = true;
            this.NGButton.Click += new System.EventHandler(this.NGButton_Click);
            // 
            // PartNumColLabel
            // 
            this.PartNumColLabel.AutoSize = true;
            this.PartNumColLabel.Font = new System.Drawing.Font("楷体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PartNumColLabel.Location = new System.Drawing.Point(90, 84);
            this.PartNumColLabel.Name = "PartNumColLabel";
            this.PartNumColLabel.Size = new System.Drawing.Size(292, 28);
            this.PartNumColLabel.TabIndex = 5;
            this.PartNumColLabel.Text = "请输入零件号所在列数";
            // 
            // PartNameColLabel
            // 
            this.PartNameColLabel.AutoSize = true;
            this.PartNameColLabel.Font = new System.Drawing.Font("楷体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PartNameColLabel.Location = new System.Drawing.Point(90, 174);
            this.PartNameColLabel.Name = "PartNameColLabel";
            this.PartNameColLabel.Size = new System.Drawing.Size(292, 28);
            this.PartNameColLabel.TabIndex = 6;
            this.PartNameColLabel.Text = "请输入零件名所在列数";
            // 
            // PSStartColLabel
            // 
            this.PSStartColLabel.AutoSize = true;
            this.PSStartColLabel.Font = new System.Drawing.Font("楷体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PSStartColLabel.Location = new System.Drawing.Point(118, 270);
            this.PSStartColLabel.Name = "PSStartColLabel";
            this.PSStartColLabel.Size = new System.Drawing.Size(264, 28);
            this.PSStartColLabel.TabIndex = 7;
            this.PSStartColLabel.Text = "请输入派生起始列数";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("楷体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(271, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(267, 36);
            this.label4.TabIndex = 8;
            this.label4.Text = "请确定必要参数";
            // 
            // SelectPartNumColButton
            // 
            this.SelectPartNumColButton.Location = new System.Drawing.Point(713, 73);
            this.SelectPartNumColButton.Name = "SelectPartNumColButton";
            this.SelectPartNumColButton.Size = new System.Drawing.Size(75, 38);
            this.SelectPartNumColButton.TabIndex = 9;
            this.SelectPartNumColButton.Text = "选取";
            this.SelectPartNumColButton.UseVisualStyleBackColor = true;
            this.SelectPartNumColButton.Click += new System.EventHandler(this.SelectPartNumColButton_Click);
            // 
            // SelectPartNameColButton
            // 
            this.SelectPartNameColButton.Location = new System.Drawing.Point(713, 163);
            this.SelectPartNameColButton.Name = "SelectPartNameColButton";
            this.SelectPartNameColButton.Size = new System.Drawing.Size(75, 38);
            this.SelectPartNameColButton.TabIndex = 10;
            this.SelectPartNameColButton.Text = "选取";
            this.SelectPartNameColButton.UseVisualStyleBackColor = true;
            this.SelectPartNameColButton.Click += new System.EventHandler(this.SelectPartNameColButton_Click);
            // 
            // SelectPSStartColButton
            // 
            this.SelectPSStartColButton.Location = new System.Drawing.Point(713, 259);
            this.SelectPSStartColButton.Name = "SelectPSStartColButton";
            this.SelectPSStartColButton.Size = new System.Drawing.Size(75, 38);
            this.SelectPSStartColButton.TabIndex = 11;
            this.SelectPSStartColButton.Text = "选取";
            this.SelectPSStartColButton.UseVisualStyleBackColor = true;
            this.SelectPSStartColButton.Click += new System.EventHandler(this.SelectPSStartColButton_Click);
            // 
            // CTXSForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SelectPSStartColButton);
            this.Controls.Add(this.SelectPartNameColButton);
            this.Controls.Add(this.SelectPartNumColButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.PSStartColLabel);
            this.Controls.Add(this.PartNameColLabel);
            this.Controls.Add(this.PartNumColLabel);
            this.Controls.Add(this.NGButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.PSStartColTextBox);
            this.Controls.Add(this.PartNameColTextBox);
            this.Controls.Add(this.PartNumColTextBox);
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button SelectPartNumColButton;
        private System.Windows.Forms.Button SelectPartNameColButton;
        private System.Windows.Forms.Button SelectPSStartColButton;
    }
}