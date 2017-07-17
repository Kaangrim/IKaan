namespace IKaan.Biz.View.Sys.Forms
{
	partial class ADTableStatisticsForm
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
			this.lcItemServerID = new DevExpress.XtraLayout.LayoutControlItem();
			this.lupServerID = new IKaan.Biz.Core.Controls.Common.XLookup();
			this.lcItemDatabaseID = new DevExpress.XtraLayout.LayoutControlItem();
			this.lupDatabaseID = new IKaan.Biz.Core.Controls.Common.XLookup();
			this.lcItemSchemaID = new DevExpress.XtraLayout.LayoutControlItem();
			this.lupSchemaID = new IKaan.Biz.Core.Controls.Common.XLookup();
			this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
			this.gridList = new IKaan.Biz.Core.Controls.Grid.XGrid();
			this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
			((System.ComponentModel.ISupportInitialize)(this.lc)).BeginInit();
			this.lc.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupFind)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupSearch)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemFindText)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtFindText.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemServerID)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lupServerID.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemDatabaseID)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lupDatabaseID.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemSchemaID)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lupSchemaID.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
			this.SuspendLayout();
			// 
			// lc
			// 
			this.lc.Controls.Add(this.lupSchemaID);
			this.lc.Controls.Add(this.lupDatabaseID);
			this.lc.Controls.Add(this.lupServerID);
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
            this.lcGroupFind});
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
			this.lcGroupFind.Size = new System.Drawing.Size(986, 495);
			this.lcGroupFind.Text = "검색";
			this.lcGroupFind.TextVisible = false;
			// 
			// lcGroupSearch
			// 
			this.lcGroupSearch.ExpandButtonVisible = true;
			this.lcGroupSearch.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcItemFindText,
            this.lcItemServerID,
            this.lcItemDatabaseID,
            this.lcItemSchemaID,
            this.emptySpaceItem1,
            this.emptySpaceItem2,
            this.emptySpaceItem3,
            this.emptySpaceItem4});
			this.lcGroupSearch.Location = new System.Drawing.Point(0, 0);
			this.lcGroupSearch.Name = "lcGroupSearch";
			this.lcGroupSearch.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
			this.lcGroupSearch.Size = new System.Drawing.Size(972, 129);
			// 
			// lcItemFindText
			// 
			this.lcItemFindText.Control = this.txtFindText;
			this.lcItemFindText.Location = new System.Drawing.Point(0, 72);
			this.lcItemFindText.Name = "lcItemFindText";
			this.lcItemFindText.Size = new System.Drawing.Size(479, 24);
			this.lcItemFindText.TextSize = new System.Drawing.Size(96, 14);
			// 
			// txtFindText
			// 
			this.txtFindText.Location = new System.Drawing.Point(118, 109);
			this.txtFindText.Name = "txtFindText";
			this.txtFindText.Size = new System.Drawing.Size(375, 20);
			this.txtFindText.StyleController = this.lc;
			this.txtFindText.TabIndex = 4;
			// 
			// lcItemServerID
			// 
			this.lcItemServerID.Control = this.lupServerID;
			this.lcItemServerID.Location = new System.Drawing.Point(0, 0);
			this.lcItemServerID.Name = "lcItemServerID";
			this.lcItemServerID.Size = new System.Drawing.Size(479, 24);
			this.lcItemServerID.TextSize = new System.Drawing.Size(96, 14);
			// 
			// lupServerID
			// 
			this.lupServerID.DisplayMember = "";
			this.lupServerID.GroupCode = null;
			this.lupServerID.ListMember = "ListName";
			this.lupServerID.Location = new System.Drawing.Point(118, 37);
			this.lupServerID.Name = "lupServerID";
			this.lupServerID.NullText = "[EditValue is null]";
			this.lupServerID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Redo)});
			this.lupServerID.SelectedIndex = -1;
			this.lupServerID.Size = new System.Drawing.Size(375, 20);
			this.lupServerID.StyleController = this.lc;
			this.lupServerID.TabIndex = 26;
			this.lupServerID.ValueMember = "";
			// 
			// lcItemDatabaseID
			// 
			this.lcItemDatabaseID.Control = this.lupDatabaseID;
			this.lcItemDatabaseID.Location = new System.Drawing.Point(0, 24);
			this.lcItemDatabaseID.Name = "lcItemDatabaseID";
			this.lcItemDatabaseID.Size = new System.Drawing.Size(479, 24);
			this.lcItemDatabaseID.TextSize = new System.Drawing.Size(96, 14);
			// 
			// lupDatabaseID
			// 
			this.lupDatabaseID.DisplayMember = "";
			this.lupDatabaseID.GroupCode = null;
			this.lupDatabaseID.ListMember = "ListName";
			this.lupDatabaseID.Location = new System.Drawing.Point(118, 61);
			this.lupDatabaseID.Name = "lupDatabaseID";
			this.lupDatabaseID.NullText = "[EditValue is null]";
			this.lupDatabaseID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Redo)});
			this.lupDatabaseID.SelectedIndex = -1;
			this.lupDatabaseID.Size = new System.Drawing.Size(375, 20);
			this.lupDatabaseID.StyleController = this.lc;
			this.lupDatabaseID.TabIndex = 27;
			this.lupDatabaseID.ValueMember = "";
			// 
			// lcItemSchemaID
			// 
			this.lcItemSchemaID.Control = this.lupSchemaID;
			this.lcItemSchemaID.Location = new System.Drawing.Point(0, 48);
			this.lcItemSchemaID.Name = "lcItemSchemaID";
			this.lcItemSchemaID.Size = new System.Drawing.Size(479, 24);
			this.lcItemSchemaID.TextSize = new System.Drawing.Size(96, 14);
			// 
			// lupSchemaID
			// 
			this.lupSchemaID.DisplayMember = "";
			this.lupSchemaID.GroupCode = null;
			this.lupSchemaID.ListMember = "ListName";
			this.lupSchemaID.Location = new System.Drawing.Point(118, 85);
			this.lupSchemaID.Name = "lupSchemaID";
			this.lupSchemaID.NullText = "[EditValue is null]";
			this.lupSchemaID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Redo)});
			this.lupSchemaID.SelectedIndex = -1;
			this.lupSchemaID.Size = new System.Drawing.Size(375, 20);
			this.lupSchemaID.StyleController = this.lc;
			this.lupSchemaID.TabIndex = 28;
			this.lupSchemaID.ValueMember = "";
			// 
			// layoutControlItem3
			// 
			this.layoutControlItem3.Control = this.gridList;
			this.layoutControlItem3.Location = new System.Drawing.Point(0, 129);
			this.layoutControlItem3.Name = "layoutControlItem3";
			this.layoutControlItem3.Size = new System.Drawing.Size(972, 352);
			this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem3.TextVisible = false;
			// 
			// gridList
			// 
			this.gridList.Compress = false;
			this.gridList.DataSource = null;
			this.gridList.Editable = true;
			this.gridList.FocusedRowHandle = -2147483648;
			this.gridList.GridViewType = IKaan.Biz.Core.Controls.Grid.GridViewType.GridView;
			this.gridList.Location = new System.Drawing.Point(11, 140);
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
			this.gridList.Size = new System.Drawing.Size(968, 348);
			this.gridList.TabIndex = 7;
			// 
			// emptySpaceItem1
			// 
			this.emptySpaceItem1.AllowHotTrack = false;
			this.emptySpaceItem1.Location = new System.Drawing.Point(479, 0);
			this.emptySpaceItem1.Name = "emptySpaceItem1";
			this.emptySpaceItem1.Size = new System.Drawing.Size(479, 24);
			this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
			// 
			// emptySpaceItem2
			// 
			this.emptySpaceItem2.AllowHotTrack = false;
			this.emptySpaceItem2.Location = new System.Drawing.Point(479, 24);
			this.emptySpaceItem2.Name = "emptySpaceItem2";
			this.emptySpaceItem2.Size = new System.Drawing.Size(479, 24);
			this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
			// 
			// emptySpaceItem3
			// 
			this.emptySpaceItem3.AllowHotTrack = false;
			this.emptySpaceItem3.Location = new System.Drawing.Point(479, 48);
			this.emptySpaceItem3.Name = "emptySpaceItem3";
			this.emptySpaceItem3.Size = new System.Drawing.Size(479, 24);
			this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
			// 
			// emptySpaceItem4
			// 
			this.emptySpaceItem4.AllowHotTrack = false;
			this.emptySpaceItem4.Location = new System.Drawing.Point(479, 72);
			this.emptySpaceItem4.Name = "emptySpaceItem4";
			this.emptySpaceItem4.Size = new System.Drawing.Size(479, 24);
			this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
			// 
			// ADTableStatisticForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(990, 565);
			this.Name = "ADTableStatisticsForm";
			this.Text = "ADTableStatisticsForm";
			((System.ComponentModel.ISupportInitialize)(this.lc)).EndInit();
			this.lc.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupFind)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupSearch)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemFindText)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtFindText.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemServerID)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lupServerID.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemDatabaseID)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lupDatabaseID.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemSchemaID)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lupSchemaID.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupFind;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupSearch;
		private DevExpress.XtraEditors.TextEdit txtFindText;
		private DevExpress.XtraLayout.LayoutControlItem lcItemFindText;
		private IKaan.Biz.Core.Controls.Grid.XGrid gridList;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
		private Core.Controls.Common.XLookup lupSchemaID;
		private Core.Controls.Common.XLookup lupDatabaseID;
		private Core.Controls.Common.XLookup lupServerID;
		private DevExpress.XtraLayout.LayoutControlItem lcItemServerID;
		private DevExpress.XtraLayout.LayoutControlItem lcItemDatabaseID;
		private DevExpress.XtraLayout.LayoutControlItem lcItemSchemaID;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
	}
}