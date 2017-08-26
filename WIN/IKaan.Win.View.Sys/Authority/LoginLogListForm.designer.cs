namespace IKaan.Win.View.Base.Authority
{
	partial class LoginLogListForm
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
			this.lcGroupFind = new DevExpress.XtraLayout.LayoutControlGroup();
			this.lcGroupSearch = new DevExpress.XtraLayout.LayoutControlGroup();
			this.lcItemFindText = new DevExpress.XtraLayout.LayoutControlItem();
			this.txtFindText = new DevExpress.XtraEditors.TextEdit();
			this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
			this.gridList = new IKaan.Win.Core.Controls.Grid.XGrid();
			this.splitterItem1 = new DevExpress.XtraLayout.SplitterItem();
			this.lcGroupEdit = new DevExpress.XtraLayout.LayoutControlGroup();
			this.lcGroupEditBase = new DevExpress.XtraLayout.LayoutControlGroup();
			this.datStartDate = new DevExpress.XtraEditors.DateEdit();
			this.lcItemStartDate = new DevExpress.XtraLayout.LayoutControlItem();
			this.datEndDate = new DevExpress.XtraEditors.DateEdit();
			this.lcItemEndDate = new DevExpress.XtraLayout.LayoutControlItem();
			this.gridLogList = new IKaan.Win.Core.Controls.Grid.XGrid();
			this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
			((System.ComponentModel.ISupportInitialize)(this.lc)).BeginInit();
			this.lc.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupFind)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupSearch)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemFindText)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtFindText.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupEditBase)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.datStartDate.Properties.CalendarTimeProperties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.datStartDate.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemStartDate)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.datEndDate.Properties.CalendarTimeProperties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.datEndDate.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemEndDate)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
			this.SuspendLayout();
			// 
			// lc
			// 
			this.lc.Controls.Add(this.gridLogList);
			this.lc.Controls.Add(this.datEndDate);
			this.lc.Controls.Add(this.datStartDate);
			this.lc.Controls.Add(this.gridList);
			this.lc.Controls.Add(this.txtFindText);
			this.lc.Location = new System.Drawing.Point(0, 44);
			this.lc.Margin = new System.Windows.Forms.Padding(0);
			this.lc.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(2597, 402, 457, 350);
			this.lc.Padding = new System.Windows.Forms.Padding(2);
			this.lc.Size = new System.Drawing.Size(990, 499);
			// 
			// lcGroupBase
			// 
			this.lcGroupBase.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcGroupFind,
            this.splitterItem1,
            this.lcGroupEditBase});
			this.lcGroupBase.Name = "Root";
			this.lcGroupBase.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
			this.lcGroupBase.Size = new System.Drawing.Size(990, 499);
			// 
			// lcGroupFind
			// 
			this.lcGroupFind.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcGroupSearch,
            this.layoutControlItem3});
			this.lcGroupFind.Location = new System.Drawing.Point(0, 0);
			this.lcGroupFind.Name = "lcGroupFind";
			this.lcGroupFind.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
			this.lcGroupFind.Size = new System.Drawing.Size(457, 495);
			this.lcGroupFind.Text = "검색";
			this.lcGroupFind.TextVisible = false;
			// 
			// lcGroupSearch
			// 
			this.lcGroupSearch.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcItemFindText,
            this.lcItemStartDate,
            this.lcItemEndDate});
			this.lcGroupSearch.Location = new System.Drawing.Point(0, 0);
			this.lcGroupSearch.Name = "lcGroupSearch";
			this.lcGroupSearch.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
			this.lcGroupSearch.Size = new System.Drawing.Size(443, 105);
			// 
			// lcItemFindText
			// 
			this.lcItemFindText.Control = this.txtFindText;
			this.lcItemFindText.Location = new System.Drawing.Point(0, 0);
			this.lcItemFindText.Name = "lcItemFindText";
			this.lcItemFindText.Size = new System.Drawing.Size(429, 24);
			this.lcItemFindText.TextSize = new System.Drawing.Size(87, 14);
			// 
			// txtFindText
			// 
			this.txtFindText.Location = new System.Drawing.Point(109, 37);
			this.txtFindText.Name = "txtFindText";
			this.txtFindText.Size = new System.Drawing.Size(334, 20);
			this.txtFindText.StyleController = this.lc;
			this.txtFindText.TabIndex = 4;
			// 
			// layoutControlItem3
			// 
			this.layoutControlItem3.Control = this.gridList;
			this.layoutControlItem3.Location = new System.Drawing.Point(0, 105);
			this.layoutControlItem3.Name = "layoutControlItem3";
			this.layoutControlItem3.Size = new System.Drawing.Size(443, 376);
			this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem3.TextVisible = false;
			// 
			// gridList
			// 
			this.gridList.Compress = false;
			this.gridList.DataSource = null;
			this.gridList.Editable = true;
			this.gridList.FocusedRowHandle = -2147483648;
			this.gridList.GridViewType = IKaan.Win.Core.Controls.Grid.GridViewType.GridView;
			this.gridList.Location = new System.Drawing.Point(11, 116);
			this.gridList.Name = "gridList";
			this.gridList.PageFooterCenter = null;
			this.gridList.PageFooterLeft = null;
			this.gridList.PageFooterRight = null;
			this.gridList.PageHeaderCenter = null;
			this.gridList.PageHeaderLeft = null;
			this.gridList.PageHeaderRight = null;
			this.gridList.Pager = null;
			this.gridList.PrintFooter = null;
			this.gridList.PrintHeader = null;
			this.gridList.ReadOnly = false;
			this.gridList.ShowFooter = false;
			this.gridList.ShowGroupPanel = false;
			this.gridList.Size = new System.Drawing.Size(439, 372);
			this.gridList.TabIndex = 7;
			// 
			// splitterItem1
			// 
			this.splitterItem1.AllowHotTrack = true;
			this.splitterItem1.Location = new System.Drawing.Point(457, 0);
			this.splitterItem1.Name = "splitterItem1";
			this.splitterItem1.Size = new System.Drawing.Size(12, 495);
			// 
			// lcGroupEdit
			// 
			this.lcGroupEdit.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
			this.lcGroupEdit.Location = new System.Drawing.Point(0, 0);
			this.lcGroupEdit.Name = "lcGroupEdit";
			this.lcGroupEdit.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
			this.lcGroupEdit.Size = new System.Drawing.Size(517, 495);
			this.lcGroupEdit.TextVisible = false;
			// 
			// lcGroupEditBase
			// 
			this.lcGroupEditBase.GroupBordersVisible = false;
			this.lcGroupEditBase.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcGroupEdit});
			this.lcGroupEditBase.Location = new System.Drawing.Point(469, 0);
			this.lcGroupEditBase.Name = "lcGroupEditBase";
			this.lcGroupEditBase.Size = new System.Drawing.Size(517, 495);
			this.lcGroupEditBase.TextVisible = false;
			// 
			// datStartDate
			// 
			this.datStartDate.EditValue = null;
			this.datStartDate.Location = new System.Drawing.Point(109, 61);
			this.datStartDate.Name = "datStartDate";
			this.datStartDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.datStartDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.datStartDate.Size = new System.Drawing.Size(334, 20);
			this.datStartDate.StyleController = this.lc;
			this.datStartDate.TabIndex = 24;
			// 
			// lcItemStartDate
			// 
			this.lcItemStartDate.Control = this.datStartDate;
			this.lcItemStartDate.Location = new System.Drawing.Point(0, 24);
			this.lcItemStartDate.Name = "lcItemStartDate";
			this.lcItemStartDate.Size = new System.Drawing.Size(429, 24);
			this.lcItemStartDate.TextSize = new System.Drawing.Size(87, 14);
			// 
			// datEndDate
			// 
			this.datEndDate.EditValue = null;
			this.datEndDate.Location = new System.Drawing.Point(109, 85);
			this.datEndDate.Name = "datEndDate";
			this.datEndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.datEndDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.datEndDate.Size = new System.Drawing.Size(334, 20);
			this.datEndDate.StyleController = this.lc;
			this.datEndDate.TabIndex = 25;
			// 
			// lcItemEndDate
			// 
			this.lcItemEndDate.Control = this.datEndDate;
			this.lcItemEndDate.Location = new System.Drawing.Point(0, 48);
			this.lcItemEndDate.Name = "lcItemEndDate";
			this.lcItemEndDate.Size = new System.Drawing.Size(429, 24);
			this.lcItemEndDate.TextSize = new System.Drawing.Size(87, 14);
			// 
			// gridLogList
			// 
			this.gridLogList.Compress = false;
			this.gridLogList.DataSource = null;
			this.gridLogList.Editable = true;
			this.gridLogList.FocusedRowHandle = -2147483648;
			this.gridLogList.GridViewType = IKaan.Win.Core.Controls.Grid.GridViewType.GridView;
			this.gridLogList.Location = new System.Drawing.Point(480, 11);
			this.gridLogList.Name = "gridLogList";
			this.gridLogList.PageFooterCenter = null;
			this.gridLogList.PageFooterLeft = null;
			this.gridLogList.PageFooterRight = null;
			this.gridLogList.PageHeaderCenter = null;
			this.gridLogList.PageHeaderLeft = null;
			this.gridLogList.PageHeaderRight = null;
			this.gridLogList.Pager = null;
			this.gridLogList.PrintFooter = null;
			this.gridLogList.PrintHeader = null;
			this.gridLogList.ReadOnly = false;
			this.gridLogList.ShowFooter = false;
			this.gridLogList.ShowGroupPanel = false;
			this.gridLogList.Size = new System.Drawing.Size(499, 477);
			this.gridLogList.TabIndex = 26;
			// 
			// layoutControlItem1
			// 
			this.layoutControlItem1.Control = this.gridLogList;
			this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
			this.layoutControlItem1.Name = "layoutControlItem1";
			this.layoutControlItem1.Size = new System.Drawing.Size(503, 481);
			this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem1.TextVisible = false;
			// 
			// LoginLogListForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(990, 565);
			this.Name = "LoginLogListForm";
			this.Text = "LoginLogListForm";
			((System.ComponentModel.ISupportInitialize)(this.lc)).EndInit();
			this.lc.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupFind)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupSearch)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemFindText)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtFindText.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupEditBase)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.datStartDate.Properties.CalendarTimeProperties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.datStartDate.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemStartDate)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.datEndDate.Properties.CalendarTimeProperties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.datEndDate.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemEndDate)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupFind;
		private DevExpress.XtraLayout.SplitterItem splitterItem1;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupSearch;
		private DevExpress.XtraEditors.TextEdit txtFindText;
		private DevExpress.XtraLayout.LayoutControlItem lcItemFindText;
		private IKaan.Win.Core.Controls.Grid.XGrid gridList;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupEdit;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupEditBase;
		private DevExpress.XtraEditors.DateEdit datEndDate;
		private DevExpress.XtraEditors.DateEdit datStartDate;
		private DevExpress.XtraLayout.LayoutControlItem lcItemStartDate;
		private DevExpress.XtraLayout.LayoutControlItem lcItemEndDate;
		private Core.Controls.Grid.XGrid gridLogList;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
	}
}