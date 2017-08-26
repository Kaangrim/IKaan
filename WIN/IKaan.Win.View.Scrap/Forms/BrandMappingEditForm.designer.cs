namespace IKaan.Win.View.Scrap.Forms
{
	partial class BrandMappingEditForm
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
			this.lcGridList = new DevExpress.XtraLayout.LayoutControlItem();
			this.gridSiteList = new IKaan.Win.Core.Controls.Grid.XGrid();
			this.gridBrandList = new IKaan.Win.Core.Controls.Grid.XGrid();
			this.splitterItem1 = new DevExpress.XtraLayout.SplitterItem();
			this.lcGroupEditBase = new DevExpress.XtraLayout.LayoutControlGroup();
			this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
			this.lcGroupEdit1 = new DevExpress.XtraLayout.LayoutControlGroup();
			this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
			((System.ComponentModel.ISupportInitialize)(this.lc)).BeginInit();
			this.lc.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupFind)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupSearch)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemFindText)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtFindText.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGridList)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupEditBase)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupEdit1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
			this.SuspendLayout();
			// 
			// lc
			// 
			this.lc.Controls.Add(this.gridBrandList);
			this.lc.Controls.Add(this.txtFindText);
			this.lc.Controls.Add(this.gridSiteList);
			this.lc.Location = new System.Drawing.Point(0, 44);
			this.lc.Margin = new System.Windows.Forms.Padding(0);
			this.lc.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(776, 304, 457, 349);
			this.lc.OptionsView.UseDefaultDragAndDropRendering = false;
			this.lc.Padding = new System.Windows.Forms.Padding(2);
			this.lc.Size = new System.Drawing.Size(990, 552);
			// 
			// lcGroupBase
			// 
			this.lcGroupBase.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcGroupFind,
            this.splitterItem1,
            this.lcGroupEditBase});
			this.lcGroupBase.Name = "Root";
			this.lcGroupBase.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
			this.lcGroupBase.Size = new System.Drawing.Size(990, 552);
			// 
			// lcGroupFind
			// 
			this.lcGroupFind.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcGroupSearch,
            this.lcGridList});
			this.lcGroupFind.Location = new System.Drawing.Point(0, 0);
			this.lcGroupFind.Name = "lcGroupFind";
			this.lcGroupFind.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
			this.lcGroupFind.Size = new System.Drawing.Size(293, 548);
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
			this.lcGroupSearch.Size = new System.Drawing.Size(279, 57);
			// 
			// lcItemFindText
			// 
			this.lcItemFindText.Control = this.txtFindText;
			this.lcItemFindText.Location = new System.Drawing.Point(0, 0);
			this.lcItemFindText.Name = "lcItemFindText";
			this.lcItemFindText.Size = new System.Drawing.Size(265, 24);
			this.lcItemFindText.TextSize = new System.Drawing.Size(82, 14);
			// 
			// txtFindText
			// 
			this.txtFindText.Location = new System.Drawing.Point(104, 37);
			this.txtFindText.Name = "txtFindText";
			this.txtFindText.Size = new System.Drawing.Size(175, 20);
			this.txtFindText.StyleController = this.lc;
			this.txtFindText.TabIndex = 41;
			// 
			// lcGridList
			// 
			this.lcGridList.Control = this.gridSiteList;
			this.lcGridList.Location = new System.Drawing.Point(0, 57);
			this.lcGridList.Name = "lcGridList";
			this.lcGridList.Size = new System.Drawing.Size(279, 477);
			this.lcGridList.TextSize = new System.Drawing.Size(0, 0);
			this.lcGridList.TextVisible = false;
			// 
			// gridSiteList
			// 
			this.gridSiteList.Compress = false;
			this.gridSiteList.DataSource = null;
			this.gridSiteList.Editable = true;
			this.gridSiteList.FocusedRowHandle = -2147483648;
			this.gridSiteList.GridViewType = IKaan.Win.Core.Controls.Grid.GridViewType.GridView;
			this.gridSiteList.Location = new System.Drawing.Point(11, 68);
			this.gridSiteList.Name = "gridSiteList";
			this.gridSiteList.PageFooterCenter = null;
			this.gridSiteList.PageFooterLeft = null;
			this.gridSiteList.PageFooterRight = null;
			this.gridSiteList.PageHeaderCenter = null;
			this.gridSiteList.PageHeaderLeft = null;
			this.gridSiteList.PageHeaderRight = null;
			this.gridSiteList.Pager = null;
			this.gridSiteList.PrintFooter = null;
			this.gridSiteList.PrintHeader = null;
			this.gridSiteList.ReadOnly = false;
			this.gridSiteList.ShowFooter = false;
			this.gridSiteList.ShowGroupPanel = false;
			this.gridSiteList.Size = new System.Drawing.Size(275, 473);
			this.gridSiteList.TabIndex = 7;
			// 
			// gridBrandList
			// 
			this.gridBrandList.Compress = false;
			this.gridBrandList.DataSource = null;
			this.gridBrandList.Editable = true;
			this.gridBrandList.FocusedRowHandle = -2147483648;
			this.gridBrandList.GridViewType = IKaan.Win.Core.Controls.Grid.GridViewType.GridView;
			this.gridBrandList.Location = new System.Drawing.Point(309, 42);
			this.gridBrandList.Name = "gridBrandList";
			this.gridBrandList.PageFooterCenter = null;
			this.gridBrandList.PageFooterLeft = null;
			this.gridBrandList.PageFooterRight = null;
			this.gridBrandList.PageHeaderCenter = null;
			this.gridBrandList.PageHeaderLeft = null;
			this.gridBrandList.PageHeaderRight = null;
			this.gridBrandList.Pager = null;
			this.gridBrandList.PrintFooter = null;
			this.gridBrandList.PrintHeader = null;
			this.gridBrandList.ReadOnly = false;
			this.gridBrandList.ShowFooter = false;
			this.gridBrandList.ShowGroupPanel = false;
			this.gridBrandList.Size = new System.Drawing.Size(677, 506);
			this.gridBrandList.TabIndex = 48;
			// 
			// splitterItem1
			// 
			this.splitterItem1.AllowHotTrack = true;
			this.splitterItem1.Location = new System.Drawing.Point(293, 0);
			this.splitterItem1.Name = "splitterItem1";
			this.splitterItem1.Size = new System.Drawing.Size(12, 548);
			// 
			// lcGroupEditBase
			// 
			this.lcGroupEditBase.GroupBordersVisible = false;
			this.lcGroupEditBase.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.lcGroupEdit1});
			this.lcGroupEditBase.Location = new System.Drawing.Point(305, 0);
			this.lcGroupEditBase.Name = "lcGroupEditBase";
			this.lcGroupEditBase.Size = new System.Drawing.Size(681, 548);
			this.lcGroupEditBase.TextVisible = false;
			// 
			// layoutControlItem2
			// 
			this.layoutControlItem2.Control = this.gridBrandList;
			this.layoutControlItem2.Location = new System.Drawing.Point(0, 38);
			this.layoutControlItem2.Name = "layoutControlItem2";
			this.layoutControlItem2.Size = new System.Drawing.Size(681, 510);
			this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem2.TextVisible = false;
			// 
			// lcGroupEdit1
			// 
			this.lcGroupEdit1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem1});
			this.lcGroupEdit1.Location = new System.Drawing.Point(0, 0);
			this.lcGroupEdit1.Name = "lcGroupEdit1";
			this.lcGroupEdit1.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
			this.lcGroupEdit1.Size = new System.Drawing.Size(681, 38);
			this.lcGroupEdit1.TextVisible = false;
			// 
			// emptySpaceItem1
			// 
			this.emptySpaceItem1.AllowHotTrack = false;
			this.emptySpaceItem1.Location = new System.Drawing.Point(0, 0);
			this.emptySpaceItem1.Name = "emptySpaceItem1";
			this.emptySpaceItem1.Size = new System.Drawing.Size(667, 24);
			this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
			// 
			// BrandMappingEditForm
			// 
			this.Appearance.BackColor = System.Drawing.Color.White;
			this.Appearance.Options.UseBackColor = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(990, 618);
			this.LookAndFeel.SkinName = "Office 2016 Dark";
			this.Name = "BrandMappingEditForm";
			this.Text = "BrandMappingEditForm";
			((System.ComponentModel.ISupportInitialize)(this.lc)).EndInit();
			this.lc.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupFind)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupSearch)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemFindText)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtFindText.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGridList)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupEditBase)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupEdit1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupFind;
		private DevExpress.XtraLayout.SplitterItem splitterItem1;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupSearch;
		private IKaan.Win.Core.Controls.Grid.XGrid gridSiteList;
		private DevExpress.XtraLayout.LayoutControlItem lcGridList;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupEditBase;
		private DevExpress.XtraEditors.TextEdit txtFindText;
		private DevExpress.XtraLayout.LayoutControlItem lcItemFindText;
		private Core.Controls.Grid.XGrid gridBrandList;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupEdit1;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
	}
}