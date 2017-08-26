namespace IKaan.Win.View.Base.Database
{
	partial class TableStatisticsListForm
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
			DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions2 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
			DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
			this.txtTableName = new DevExpress.XtraEditors.TextEdit();
			this.lupServerID = new IKaan.Win.Core.Controls.Common.XLookup();
			this.lupDatabaseID = new IKaan.Win.Core.Controls.Common.XLookup();
			this.lcGridList = new DevExpress.XtraLayout.LayoutControlItem();
			this.gridList = new IKaan.Win.Core.Controls.Grid.XGrid();
			this.lcGroupSearch = new DevExpress.XtraLayout.LayoutControlGroup();
			this.lcItemTableName = new DevExpress.XtraLayout.LayoutControlItem();
			this.lcItemServerID = new DevExpress.XtraLayout.LayoutControlItem();
			this.lcItemDatabaseID = new DevExpress.XtraLayout.LayoutControlItem();
			this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.splitterItem1 = new DevExpress.XtraLayout.SplitterItem();
			this.lcGroupList = new DevExpress.XtraLayout.LayoutControlGroup();
			((System.ComponentModel.ISupportInitialize)(this.lc)).BeginInit();
			this.lc.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtTableName.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lupServerID.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lupDatabaseID.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGridList)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupSearch)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemTableName)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemServerID)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemDatabaseID)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupList)).BeginInit();
			this.SuspendLayout();
			// 
			// lc
			// 
			this.lc.Controls.Add(this.lupDatabaseID);
			this.lc.Controls.Add(this.lupServerID);
			this.lc.Controls.Add(this.gridList);
			this.lc.Controls.Add(this.txtTableName);
			this.lc.Location = new System.Drawing.Point(0, 44);
			this.lc.Margin = new System.Windows.Forms.Padding(0);
			this.lc.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1470, 270, 457, 350);
			this.lc.OptionsView.UseDefaultDragAndDropRendering = false;
			this.lc.Padding = new System.Windows.Forms.Padding(2);
			this.lc.Size = new System.Drawing.Size(990, 499);
			// 
			// lcGroupBase
			// 
			this.lcGroupBase.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcGroupSearch,
            this.splitterItem1,
            this.lcGroupList});
			this.lcGroupBase.Name = "Root";
			this.lcGroupBase.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
			this.lcGroupBase.Size = new System.Drawing.Size(990, 499);
			// 
			// txtTableName
			// 
			this.txtTableName.Location = new System.Drawing.Point(111, 78);
			this.txtTableName.Name = "txtTableName";
			this.txtTableName.Size = new System.Drawing.Size(182, 20);
			this.txtTableName.StyleController = this.lc;
			this.txtTableName.TabIndex = 4;
			// 
			// lupServerID
			// 
			this.lupServerID.DisplayMember = "";
			this.lupServerID.GroupCode = null;
			this.lupServerID.ListMember = "ListName";
			this.lupServerID.Location = new System.Drawing.Point(111, 30);
			this.lupServerID.Name = "lupServerID";
			this.lupServerID.NullText = "[EditValue is null]";
			this.lupServerID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Redo, "", -1, true, true, false, editorButtonImageOptions2, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), "재구성")});
			this.lupServerID.SelectedIndex = -1;
			this.lupServerID.Size = new System.Drawing.Size(182, 20);
			this.lupServerID.StyleController = this.lc;
			this.lupServerID.TabIndex = 26;
			this.lupServerID.ValueMember = "";
			// 
			// lupDatabaseID
			// 
			this.lupDatabaseID.DisplayMember = "";
			this.lupDatabaseID.GroupCode = null;
			this.lupDatabaseID.ListMember = "ListName";
			this.lupDatabaseID.Location = new System.Drawing.Point(111, 54);
			this.lupDatabaseID.Name = "lupDatabaseID";
			this.lupDatabaseID.NullText = "[EditValue is null]";
			this.lupDatabaseID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Redo, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), "재구성")});
			this.lupDatabaseID.SelectedIndex = -1;
			this.lupDatabaseID.Size = new System.Drawing.Size(182, 20);
			this.lupDatabaseID.StyleController = this.lc;
			this.lupDatabaseID.TabIndex = 27;
			this.lupDatabaseID.ValueMember = "";
			// 
			// lcGridList
			// 
			this.lcGridList.Control = this.gridList;
			this.lcGridList.Location = new System.Drawing.Point(0, 0);
			this.lcGridList.Name = "lcGridList";
			this.lcGridList.Size = new System.Drawing.Size(664, 485);
			this.lcGridList.TextSize = new System.Drawing.Size(0, 0);
			this.lcGridList.TextVisible = false;
			// 
			// gridList
			// 
			this.gridList.Compress = false;
			this.gridList.DataSource = null;
			this.gridList.Editable = true;
			this.gridList.FocusedRowHandle = -2147483648;
			this.gridList.GridViewType = IKaan.Win.Core.Controls.Grid.GridViewType.GridView;
			this.gridList.Location = new System.Drawing.Point(321, 9);
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
			this.gridList.Size = new System.Drawing.Size(660, 481);
			this.gridList.TabIndex = 7;
			// 
			// lcGroupSearch
			// 
			this.lcGroupSearch.ExpandButtonVisible = true;
			this.lcGroupSearch.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcItemTableName,
            this.lcItemServerID,
            this.lcItemDatabaseID,
            this.emptySpaceItem1});
			this.lcGroupSearch.Location = new System.Drawing.Point(0, 0);
			this.lcGroupSearch.Name = "lcGroupSearch";
			this.lcGroupSearch.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
			this.lcGroupSearch.Size = new System.Drawing.Size(300, 495);
			// 
			// lcItemTableName
			// 
			this.lcItemTableName.Control = this.txtTableName;
			this.lcItemTableName.Location = new System.Drawing.Point(0, 48);
			this.lcItemTableName.MaxSize = new System.Drawing.Size(286, 24);
			this.lcItemTableName.MinSize = new System.Drawing.Size(286, 24);
			this.lcItemTableName.Name = "lcItemTableName";
			this.lcItemTableName.Size = new System.Drawing.Size(286, 24);
			this.lcItemTableName.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			this.lcItemTableName.TextSize = new System.Drawing.Size(96, 14);
			// 
			// lcItemServerID
			// 
			this.lcItemServerID.Control = this.lupServerID;
			this.lcItemServerID.Location = new System.Drawing.Point(0, 0);
			this.lcItemServerID.Name = "lcItemServerID";
			this.lcItemServerID.Size = new System.Drawing.Size(286, 24);
			this.lcItemServerID.TextSize = new System.Drawing.Size(96, 14);
			// 
			// lcItemDatabaseID
			// 
			this.lcItemDatabaseID.Control = this.lupDatabaseID;
			this.lcItemDatabaseID.Location = new System.Drawing.Point(0, 24);
			this.lcItemDatabaseID.Name = "lcItemDatabaseID";
			this.lcItemDatabaseID.Size = new System.Drawing.Size(286, 24);
			this.lcItemDatabaseID.TextSize = new System.Drawing.Size(96, 14);
			// 
			// emptySpaceItem1
			// 
			this.emptySpaceItem1.AllowHotTrack = false;
			this.emptySpaceItem1.Location = new System.Drawing.Point(0, 72);
			this.emptySpaceItem1.Name = "emptySpaceItem1";
			this.emptySpaceItem1.Size = new System.Drawing.Size(286, 390);
			this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
			// 
			// splitterItem1
			// 
			this.splitterItem1.AllowHotTrack = true;
			this.splitterItem1.Location = new System.Drawing.Point(300, 0);
			this.splitterItem1.Name = "splitterItem1";
			this.splitterItem1.Size = new System.Drawing.Size(12, 495);
			// 
			// lcGroupList
			// 
			this.lcGroupList.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcGridList});
			this.lcGroupList.Location = new System.Drawing.Point(312, 0);
			this.lcGroupList.Name = "lcGroupList";
			this.lcGroupList.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
			this.lcGroupList.Size = new System.Drawing.Size(674, 495);
			this.lcGroupList.TextVisible = false;
			// 
			// TableStatisticsListForm
			// 
			this.Appearance.BackColor = System.Drawing.Color.White;
			this.Appearance.Options.UseBackColor = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(990, 565);
			this.LookAndFeel.SkinName = "Office 2016 Dark";
			this.Name = "TableStatisticsListForm";
			this.Text = "TableStatisticsListForm";
			((System.ComponentModel.ISupportInitialize)(this.lc)).EndInit();
			this.lc.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtTableName.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lupServerID.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lupDatabaseID.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGridList)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupSearch)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemTableName)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemServerID)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemDatabaseID)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupList)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private DevExpress.XtraEditors.TextEdit txtTableName;
		private IKaan.Win.Core.Controls.Grid.XGrid gridList;
		private DevExpress.XtraLayout.LayoutControlItem lcGridList;
		private Core.Controls.Common.XLookup lupDatabaseID;
		private Core.Controls.Common.XLookup lupServerID;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupSearch;
		private DevExpress.XtraLayout.LayoutControlItem lcItemTableName;
		private DevExpress.XtraLayout.LayoutControlItem lcItemServerID;
		private DevExpress.XtraLayout.LayoutControlItem lcItemDatabaseID;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
		private DevExpress.XtraLayout.SplitterItem splitterItem1;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupList;
	}
}