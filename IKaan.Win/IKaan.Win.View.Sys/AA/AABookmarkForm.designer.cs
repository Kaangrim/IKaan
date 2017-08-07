namespace IKaan.Win.View.Sys.AA
{
	partial class AABookmarkForm
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
			this.lcGroupEdit1 = new DevExpress.XtraLayout.LayoutControlGroup();
			this.splitterItem1 = new DevExpress.XtraLayout.SplitterItem();
			this.lcGroupEditBase = new DevExpress.XtraLayout.LayoutControlGroup();
			this.gridBookmark = new IKaan.Win.Core.Controls.Grid.XGrid();
			this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
			this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.lcGroupButtons = new DevExpress.XtraLayout.LayoutControlGroup();
			this.btnDown = new DevExpress.XtraEditors.SimpleButton();
			this.lcButtonDown = new DevExpress.XtraLayout.LayoutControlItem();
			this.btnUp = new DevExpress.XtraEditors.SimpleButton();
			this.lcButtonUp = new DevExpress.XtraLayout.LayoutControlItem();
			((System.ComponentModel.ISupportInitialize)(this.lc)).BeginInit();
			this.lc.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupFind)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupSearch)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemFindText)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtFindText.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupEdit1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupEditBase)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupButtons)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcButtonDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcButtonUp)).BeginInit();
			this.SuspendLayout();
			// 
			// lc
			// 
			this.lc.Controls.Add(this.btnUp);
			this.lc.Controls.Add(this.btnDown);
			this.lc.Controls.Add(this.gridBookmark);
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
			this.lcGroupFind.Size = new System.Drawing.Size(365, 495);
			this.lcGroupFind.Text = "검색";
			this.lcGroupFind.TextVisible = false;
			// 
			// lcGroupSearch
			// 
			this.lcGroupSearch.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcItemFindText});
			this.lcGroupSearch.Location = new System.Drawing.Point(0, 0);
			this.lcGroupSearch.Name = "lcGroupSearch";
			this.lcGroupSearch.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
			this.lcGroupSearch.Size = new System.Drawing.Size(351, 57);
			// 
			// lcItemFindText
			// 
			this.lcItemFindText.Control = this.txtFindText;
			this.lcItemFindText.Location = new System.Drawing.Point(0, 0);
			this.lcItemFindText.Name = "lcItemFindText";
			this.lcItemFindText.Size = new System.Drawing.Size(337, 24);
			this.lcItemFindText.TextSize = new System.Drawing.Size(82, 14);
			// 
			// txtFindText
			// 
			this.txtFindText.Location = new System.Drawing.Point(104, 37);
			this.txtFindText.Name = "txtFindText";
			this.txtFindText.Size = new System.Drawing.Size(247, 20);
			this.txtFindText.StyleController = this.lc;
			this.txtFindText.TabIndex = 4;
			// 
			// layoutControlItem3
			// 
			this.layoutControlItem3.Control = this.gridList;
			this.layoutControlItem3.Location = new System.Drawing.Point(0, 57);
			this.layoutControlItem3.Name = "layoutControlItem3";
			this.layoutControlItem3.Size = new System.Drawing.Size(351, 424);
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
			this.gridList.Location = new System.Drawing.Point(11, 68);
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
			this.gridList.Size = new System.Drawing.Size(347, 420);
			this.gridList.TabIndex = 7;
			// 
			// lcGroupEdit1
			// 
			this.lcGroupEdit1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.lcGroupButtons});
			this.lcGroupEdit1.Location = new System.Drawing.Point(0, 0);
			this.lcGroupEdit1.Name = "lcGroupEdit1";
			this.lcGroupEdit1.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
			this.lcGroupEdit1.Size = new System.Drawing.Size(609, 495);
			this.lcGroupEdit1.TextVisible = false;
			// 
			// splitterItem1
			// 
			this.splitterItem1.AllowHotTrack = true;
			this.splitterItem1.Location = new System.Drawing.Point(365, 0);
			this.splitterItem1.Name = "splitterItem1";
			this.splitterItem1.Size = new System.Drawing.Size(12, 495);
			// 
			// lcGroupEditBase
			// 
			this.lcGroupEditBase.GroupBordersVisible = false;
			this.lcGroupEditBase.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcGroupEdit1});
			this.lcGroupEditBase.Location = new System.Drawing.Point(377, 0);
			this.lcGroupEditBase.Name = "lcGroupEditBase";
			this.lcGroupEditBase.Size = new System.Drawing.Size(609, 495);
			this.lcGroupEditBase.TextVisible = false;
			// 
			// gridBookmark
			// 
			this.gridBookmark.Compress = false;
			this.gridBookmark.DataSource = null;
			this.gridBookmark.Editable = true;
			this.gridBookmark.FocusedRowHandle = -2147483648;
			this.gridBookmark.GridViewType = IKaan.Win.Core.Controls.Grid.GridViewType.GridView;
			this.gridBookmark.Location = new System.Drawing.Point(388, 47);
			this.gridBookmark.Name = "gridBookmark";
			this.gridBookmark.PageFooterCenter = null;
			this.gridBookmark.PageFooterLeft = null;
			this.gridBookmark.PageFooterRight = null;
			this.gridBookmark.PageHeaderCenter = null;
			this.gridBookmark.PageHeaderLeft = null;
			this.gridBookmark.PageHeaderRight = null;
			this.gridBookmark.Pager = null;
			this.gridBookmark.PrintFooter = null;
			this.gridBookmark.PrintHeader = null;
			this.gridBookmark.ReadOnly = false;
			this.gridBookmark.ShowFooter = false;
			this.gridBookmark.ShowGroupPanel = false;
			this.gridBookmark.Size = new System.Drawing.Size(591, 441);
			this.gridBookmark.TabIndex = 8;
			// 
			// layoutControlItem1
			// 
			this.layoutControlItem1.Control = this.gridBookmark;
			this.layoutControlItem1.Location = new System.Drawing.Point(0, 36);
			this.layoutControlItem1.Name = "layoutControlItem1";
			this.layoutControlItem1.Size = new System.Drawing.Size(595, 445);
			this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem1.TextVisible = false;
			// 
			// emptySpaceItem1
			// 
			this.emptySpaceItem1.AllowHotTrack = false;
			this.emptySpaceItem1.Location = new System.Drawing.Point(120, 0);
			this.emptySpaceItem1.Name = "emptySpaceItem1";
			this.emptySpaceItem1.Size = new System.Drawing.Size(465, 26);
			this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
			// 
			// lcGroupButtons
			// 
			this.lcGroupButtons.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem1,
            this.lcButtonUp,
            this.lcButtonDown});
			this.lcGroupButtons.Location = new System.Drawing.Point(0, 0);
			this.lcGroupButtons.Name = "lcGroupButtons";
			this.lcGroupButtons.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
			this.lcGroupButtons.Size = new System.Drawing.Size(595, 36);
			this.lcGroupButtons.TextVisible = false;
			// 
			// btnDown
			// 
			this.btnDown.Location = new System.Drawing.Point(453, 16);
			this.btnDown.Name = "btnDown";
			this.btnDown.Size = new System.Drawing.Size(56, 22);
			this.btnDown.StyleController = this.lc;
			this.btnDown.TabIndex = 9;
			this.btnDown.Text = "아래로";
			// 
			// lcButtonDown
			// 
			this.lcButtonDown.Control = this.btnDown;
			this.lcButtonDown.Location = new System.Drawing.Point(60, 0);
			this.lcButtonDown.MaxSize = new System.Drawing.Size(60, 26);
			this.lcButtonDown.MinSize = new System.Drawing.Size(60, 26);
			this.lcButtonDown.Name = "lcButtonDown";
			this.lcButtonDown.Size = new System.Drawing.Size(60, 26);
			this.lcButtonDown.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			this.lcButtonDown.TextSize = new System.Drawing.Size(0, 0);
			this.lcButtonDown.TextVisible = false;
			// 
			// btnUp
			// 
			this.btnUp.Location = new System.Drawing.Point(393, 16);
			this.btnUp.Name = "btnUp";
			this.btnUp.Size = new System.Drawing.Size(56, 22);
			this.btnUp.StyleController = this.lc;
			this.btnUp.TabIndex = 10;
			this.btnUp.Text = "위로";
			// 
			// lcButtonUp
			// 
			this.lcButtonUp.Control = this.btnUp;
			this.lcButtonUp.Location = new System.Drawing.Point(0, 0);
			this.lcButtonUp.MaxSize = new System.Drawing.Size(60, 26);
			this.lcButtonUp.MinSize = new System.Drawing.Size(60, 26);
			this.lcButtonUp.Name = "lcButtonUp";
			this.lcButtonUp.Size = new System.Drawing.Size(60, 26);
			this.lcButtonUp.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			this.lcButtonUp.TextSize = new System.Drawing.Size(0, 0);
			this.lcButtonUp.TextVisible = false;
			// 
			// AABookmarkForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(990, 565);
			this.Name = "AABookmarkForm";
			this.Text = "AABookmarkForm";
			((System.ComponentModel.ISupportInitialize)(this.lc)).EndInit();
			this.lc.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupFind)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupSearch)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemFindText)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtFindText.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupEdit1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupEditBase)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupButtons)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcButtonDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcButtonUp)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupFind;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupEdit1;
		private DevExpress.XtraLayout.SplitterItem splitterItem1;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupSearch;
		private DevExpress.XtraEditors.TextEdit txtFindText;
		private DevExpress.XtraLayout.LayoutControlItem lcItemFindText;
		private IKaan.Win.Core.Controls.Grid.XGrid gridList;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupEditBase;
		private Core.Controls.Grid.XGrid gridBookmark;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupButtons;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
		private DevExpress.XtraEditors.SimpleButton btnUp;
		private DevExpress.XtraEditors.SimpleButton btnDown;
		private DevExpress.XtraLayout.LayoutControlItem lcButtonDown;
		private DevExpress.XtraLayout.LayoutControlItem lcButtonUp;
	}
}