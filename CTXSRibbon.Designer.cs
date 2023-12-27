namespace CTXS
{
    partial class CTXSRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public CTXSRibbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tab1 = this.Factory.CreateRibbonTab();
            this.MyMGroup = this.Factory.CreateRibbonGroup();
            this.CTXSButton = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.MyMGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.MyMGroup);
            this.tab1.Label = "TabAddIns";
            this.tab1.Name = "tab1";
            // 
            // MyMGroup
            // 
            this.MyMGroup.Items.Add(this.CTXSButton);
            this.MyMGroup.Label = "MyM";
            this.MyMGroup.Name = "MyMGroup";
            // 
            // CTXSButton
            // 
            this.CTXSButton.Label = "修正轮胎系数";
            this.CTXSButton.Name = "CTXSButton";
            this.CTXSButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.CTXSButton_Click);
            // 
            // CTXSRibbon
            // 
            this.Name = "CTXSRibbon";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.CTXSRibbon_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.MyMGroup.ResumeLayout(false);
            this.MyMGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup MyMGroup;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton CTXSButton;
    }

    partial class ThisRibbonCollection
    {
        internal CTXSRibbon CTXSRibbon
        {
            get { return this.GetRibbon<CTXSRibbon>(); }
        }
    }
}
