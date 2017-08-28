namespace IKaan.Win.View.Biz.Sales
{
	partial class OrderSumListForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderSumListForm));
			this.lcGroupSearch = new DevExpress.XtraLayout.LayoutControlGroup();
			this.lcItemBrand = new DevExpress.XtraLayout.LayoutControlItem();
			this.lupBrandID = new IKaan.Win.Core.Controls.Common.XLookup();
			this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.lcItemChannel = new DevExpress.XtraLayout.LayoutControlItem();
			this.lupChannelID = new IKaan.Win.Core.Controls.Common.XLookup();
			this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
			this.btnShowChannelEdit = new DevExpress.XtraEditors.SimpleButton();
			this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
			this.btnShowBrandEdit = new DevExpress.XtraEditors.SimpleButton();
			this.esSearchTitle = new DevExpress.XtraLayout.EmptySpaceItem();
			this.lcItemPeriod = new DevExpress.XtraLayout.LayoutControlItem();
			this.datPeriod = new IKaan.Win.Core.Controls.Common.XPeriod();
			this.gridOrder = new DevExpress.XtraPivotGrid.PivotGridControl();
			this.lcTab = new DevExpress.XtraLayout.TabbedControlGroup();
			this.lcGroupList1 = new DevExpress.XtraLayout.LayoutControlGroup();
			this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
			this.lcGroupList2 = new DevExpress.XtraLayout.LayoutControlGroup();
			this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
			this.gridSales = new IKaan.Win.Core.Controls.Grid.XGrid();
			((System.ComponentModel.ISupportInitialize)(this.lc)).BeginInit();
			this.lc.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupSearch)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemBrand)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lupBrandID.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemChannel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lupChannelID.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.esSearchTitle)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemPeriod)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridOrder)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcTab)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupList1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupList2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
			this.SuspendLayout();
			// 
			// lc
			// 
			this.lc.Controls.Add(this.datPeriod);
			this.lc.Controls.Add(this.gridSales);
			this.lc.Controls.Add(this.gridOrder);
			this.lc.Controls.Add(this.btnShowBrandEdit);
			this.lc.Controls.Add(this.btnShowChannelEdit);
			this.lc.Controls.Add(this.lupChannelID);
			this.lc.Controls.Add(this.lupBrandID);
			this.lc.Location = new System.Drawing.Point(0, 44);
			this.lc.Margin = new System.Windows.Forms.Padding(0);
			this.lc.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(930, 373, 457, 350);
			this.lc.OptionsView.UseDefaultDragAndDropRendering = false;
			this.lc.Padding = new System.Windows.Forms.Padding(2);
			this.lc.Size = new System.Drawing.Size(990, 552);
			// 
			// lcGroupBase
			// 
			this.lcGroupBase.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcGroupSearch,
            this.lcTab});
			this.lcGroupBase.Name = "Root";
			this.lcGroupBase.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
			this.lcGroupBase.Size = new System.Drawing.Size(990, 552);
			// 
			// lcGroupSearch
			// 
			this.lcGroupSearch.ExpandButtonVisible = true;
			this.lcGroupSearch.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcItemBrand,
            this.emptySpaceItem2,
            this.lcItemChannel,
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.esSearchTitle,
            this.lcItemPeriod});
			this.lcGroupSearch.Location = new System.Drawing.Point(0, 0);
			this.lcGroupSearch.Name = "lcGroupSearch";
			this.lcGroupSearch.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
			this.lcGroupSearch.Size = new System.Drawing.Size(260, 548);
			this.lcGroupSearch.TextLocation = DevExpress.Utils.Locations.Left;
			this.lcGroupSearch.TextVisible = false;
			// 
			// lcItemBrand
			// 
			this.lcItemBrand.Control = this.lupBrandID;
			this.lcItemBrand.Location = new System.Drawing.Point(0, 81);
			this.lcItemBrand.Name = "lcItemBrand";
			this.lcItemBrand.Size = new System.Drawing.Size(226, 41);
			this.lcItemBrand.TextLocation = DevExpress.Utils.Locations.Top;
			this.lcItemBrand.TextSize = new System.Drawing.Size(77, 14);
			// 
			// lupBrandID
			// 
			this.lupBrandID.DisplayMember = "";
			this.lupBrandID.GroupCode = null;
			this.lupBrandID.ListMember = "ListName";
			this.lupBrandID.Location = new System.Drawing.Point(31, 108);
			this.lupBrandID.Name = "lupBrandID";
			this.lupBrandID.NullText = "[EditValue is null]";
			this.lupBrandID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Redo, "", -1, true, true, false, editorButtonImageOptions2, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), "재구성")});
			this.lupBrandID.SelectedIndex = -1;
			this.lupBrandID.Size = new System.Drawing.Size(222, 20);
			this.lupBrandID.StyleController = this.lc;
			this.lupBrandID.TabIndex = 9;
			this.lupBrandID.ValueMember = "";
			// 
			// emptySpaceItem2
			// 
			this.emptySpaceItem2.AllowHotTrack = false;
			this.emptySpaceItem2.Location = new System.Drawing.Point(0, 163);
			this.emptySpaceItem2.MaxSize = new System.Drawing.Size(226, 0);
			this.emptySpaceItem2.MinSize = new System.Drawing.Size(226, 10);
			this.emptySpaceItem2.Name = "emptySpaceItem2";
			this.emptySpaceItem2.Size = new System.Drawing.Size(226, 320);
			this.emptySpaceItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
			// 
			// lcItemChannel
			// 
			this.lcItemChannel.Control = this.lupChannelID;
			this.lcItemChannel.Location = new System.Drawing.Point(0, 122);
			this.lcItemChannel.Name = "lcItemChannel";
			this.lcItemChannel.Size = new System.Drawing.Size(226, 41);
			this.lcItemChannel.TextLocation = DevExpress.Utils.Locations.Top;
			this.lcItemChannel.TextSize = new System.Drawing.Size(77, 14);
			// 
			// lupChannelID
			// 
			this.lupChannelID.DisplayMember = "";
			this.lupChannelID.GroupCode = null;
			this.lupChannelID.ListMember = "ListName";
			this.lupChannelID.Location = new System.Drawing.Point(31, 149);
			this.lupChannelID.Name = "lupChannelID";
			this.lupChannelID.NullText = "[EditValue is null]";
			this.lupChannelID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Redo, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), "재구성")});
			this.lupChannelID.SelectedIndex = -1;
			this.lupChannelID.Size = new System.Drawing.Size(222, 20);
			this.lupChannelID.StyleController = this.lc;
			this.lupChannelID.TabIndex = 12;
			this.lupChannelID.ValueMember = "";
			// 
			// layoutControlItem1
			// 
			this.layoutControlItem1.Control = this.btnShowChannelEdit;
			this.layoutControlItem1.Location = new System.Drawing.Point(0, 509);
			this.layoutControlItem1.Name = "layoutControlItem1";
			this.layoutControlItem1.Size = new System.Drawing.Size(226, 26);
			this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem1.TextVisible = false;
			// 
			// btnShowChannelEdit
			// 
			this.btnShowChannelEdit.Location = new System.Drawing.Point(31, 519);
			this.btnShowChannelEdit.Name = "btnShowChannelEdit";
			this.btnShowChannelEdit.Size = new System.Drawing.Size(222, 22);
			this.btnShowChannelEdit.StyleController = this.lc;
			this.btnShowChannelEdit.TabIndex = 21;
			this.btnShowChannelEdit.Text = "채널별 매출등록";
			// 
			// layoutControlItem2
			// 
			this.layoutControlItem2.Control = this.btnShowBrandEdit;
			this.layoutControlItem2.Location = new System.Drawing.Point(0, 483);
			this.layoutControlItem2.Name = "layoutControlItem2";
			this.layoutControlItem2.Size = new System.Drawing.Size(226, 26);
			this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem2.TextVisible = false;
			// 
			// btnShowBrandEdit
			// 
			this.btnShowBrandEdit.Location = new System.Drawing.Point(31, 493);
			this.btnShowBrandEdit.Name = "btnShowBrandEdit";
			this.btnShowBrandEdit.Size = new System.Drawing.Size(222, 22);
			this.btnShowBrandEdit.StyleController = this.lc;
			this.btnShowBrandEdit.TabIndex = 22;
			this.btnShowBrandEdit.Text = "브랜드별 매출등록";
			// 
			// esSearchTitle
			// 
			this.esSearchTitle.AllowHotTrack = false;
			this.esSearchTitle.Location = new System.Drawing.Point(0, 0);
			this.esSearchTitle.MaxSize = new System.Drawing.Size(226, 40);
			this.esSearchTitle.MinSize = new System.Drawing.Size(226, 40);
			this.esSearchTitle.Name = "esSearchTitle";
			this.esSearchTitle.Size = new System.Drawing.Size(226, 40);
			this.esSearchTitle.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			this.esSearchTitle.Text = "검색조건";
			this.esSearchTitle.TextSize = new System.Drawing.Size(77, 0);
			this.esSearchTitle.TextVisible = true;
			// 
			// lcItemPeriod
			// 
			this.lcItemPeriod.Control = this.datPeriod;
			this.lcItemPeriod.Location = new System.Drawing.Point(0, 40);
			this.lcItemPeriod.Name = "lcItemPeriod";
			this.lcItemPeriod.Size = new System.Drawing.Size(226, 41);
			this.lcItemPeriod.TextLocation = DevExpress.Utils.Locations.Top;
			this.lcItemPeriod.TextSize = new System.Drawing.Size(77, 14);
			// 
			// datPeriod
			// 
			this.datPeriod.FromEditValue = new System.DateTime(2017, 8, 28, 18, 35, 23, 975);
			this.datPeriod.Location = new System.Drawing.Point(31, 67);
			this.datPeriod.MaximumSize = new System.Drawing.Size(0, 20);
			this.datPeriod.MinimumSize = new System.Drawing.Size(215, 20);
			this.datPeriod.Name = "datPeriod";
			this.datPeriod.Size = new System.Drawing.Size(222, 20);
			this.datPeriod.TabIndex = 25;
			this.datPeriod.ToEditValue = new System.DateTime(2017, 8, 28, 18, 35, 23, 975);
			// 
			// gridOrder
			// 
			this.gridOrder.Location = new System.Drawing.Point(269, 35);
			this.gridOrder.Name = "gridOrder";
			this.gridOrder.OptionsData.DataProcessingEngine = DevExpress.XtraPivotGrid.PivotDataProcessingEngine.LegacyOptimized;
			this.gridOrder.OptionsView.ShowFilterHeaders = false;
			this.gridOrder.Size = new System.Drawing.Size(712, 508);
			this.gridOrder.TabIndex = 23;
			// 
			// lcTab
			// 
			this.lcTab.Location = new System.Drawing.Point(260, 0);
			this.lcTab.Name = "lcTab";
			this.lcTab.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
			this.lcTab.SelectedTabPage = this.lcGroupList1;
			this.lcTab.SelectedTabPageIndex = 0;
			this.lcTab.Size = new System.Drawing.Size(726, 548);
			this.lcTab.TabPages.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcGroupList1,
            this.lcGroupList2});
			// 
			// lcGroupList1
			// 
			this.lcGroupList1.CaptionImage = ((System.Drawing.Image)(resources.GetObject("lcGroupList1.CaptionImage")));
			this.lcGroupList1.GroupBordersVisible = false;
			this.lcGroupList1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3});
			this.lcGroupList1.Location = new System.Drawing.Point(0, 0);
			this.lcGroupList1.Name = "lcGroupList1";
			this.lcGroupList1.Size = new System.Drawing.Size(716, 512);
			this.lcGroupList1.Text = "전체주문현황";
			// 
			// layoutControlItem3
			// 
			this.layoutControlItem3.Control = this.gridOrder;
			this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
			this.layoutControlItem3.Name = "layoutControlItem3";
			this.layoutControlItem3.Size = new System.Drawing.Size(716, 512);
			this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem3.TextVisible = false;
			// 
			// lcGroupList2
			// 
			this.lcGroupList2.CaptionImage = ((System.Drawing.Image)(resources.GetObject("lcGroupList2.CaptionImage")));
			this.lcGroupList2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem4});
			this.lcGroupList2.Location = new System.Drawing.Point(0, 0);
			this.lcGroupList2.Name = "lcGroupList2";
			this.lcGroupList2.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
			this.lcGroupList2.Size = new System.Drawing.Size(716, 512);
			this.lcGroupList2.Text = "예상매출현황";
			// 
			// layoutControlItem4
			// 
			this.layoutControlItem4.Control = this.gridSales;
			this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
			this.layoutControlItem4.Name = "layoutControlItem4";
			this.layoutControlItem4.Size = new System.Drawing.Size(716, 512);
			this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem4.TextVisible = false;
			// 
			// gridSales
			// 
			this.gridSales.Compress = false;
			this.gridSales.DataSource = null;
			this.gridSales.Editable = true;
			this.gridSales.FocusedRowHandle = -2147483648;
			this.gridSales.GridViewType = IKaan.Win.Core.Controls.Grid.GridViewType.GridView;
			this.gridSales.Location = new System.Drawing.Point(269, 35);
			this.gridSales.Name = "gridSales";
			this.gridSales.PageFooterCenter = null;
			this.gridSales.PageFooterLeft = null;
			this.gridSales.PageFooterRight = null;
			this.gridSales.PageHeaderCenter = null;
			this.gridSales.PageHeaderLeft = null;
			this.gridSales.PageHeaderRight = null;
			this.gridSales.Pager = null;
			this.gridSales.PrintFooter = null;
			this.gridSales.PrintHeader = null;
			this.gridSales.ReadOnly = false;
			this.gridSales.ShowFooter = false;
			this.gridSales.ShowGroupPanel = false;
			this.gridSales.Size = new System.Drawing.Size(712, 508);
			this.gridSales.TabIndex = 24;
			// 
			// OrderSumListForm
			// 
			this.Appearance.BackColor = System.Drawing.Color.White;
			this.Appearance.Options.UseBackColor = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(990, 618);
			this.LookAndFeel.SkinName = "Office 2016 Dark";
			this.Name = "OrderSumListForm";
			this.Text = "OrderSumListForm";
			((System.ComponentModel.ISupportInitialize)(this.lc)).EndInit();
			this.lc.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupSearch)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemBrand)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lupBrandID.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemChannel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lupChannelID.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.esSearchTitle)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemPeriod)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridOrder)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcTab)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupList1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupList2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupSearch;
		private Core.Controls.Common.XLookup lupChannelID;
		private Core.Controls.Common.XLookup lupBrandID;
		private DevExpress.XtraLayout.LayoutControlItem lcItemBrand;
		private DevExpress.XtraLayout.LayoutControlItem lcItemChannel;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
		private DevExpress.XtraEditors.SimpleButton btnShowBrandEdit;
		private DevExpress.XtraEditors.SimpleButton btnShowChannelEdit;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
		private DevExpress.XtraPivotGrid.PivotGridControl gridOrder;
		private DevExpress.XtraLayout.TabbedControlGroup lcTab;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupList1;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupList2;
		private Core.Controls.Grid.XGrid gridSales;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
		private DevExpress.XtraLayout.EmptySpaceItem esSearchTitle;
		private Core.Controls.Common.XPeriod datPeriod;
		private DevExpress.XtraLayout.LayoutControlItem lcItemPeriod;
	}
}