namespace IKaan.Win.View.Scrap.Common
{
	partial class ScrapListForm
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
			DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions3 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
			DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions2 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
			DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
			this.lcGroupSearch = new DevExpress.XtraLayout.LayoutControlGroup();
			this.esSearchTitle = new DevExpress.XtraLayout.EmptySpaceItem();
			this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.lcItemFindText = new DevExpress.XtraLayout.LayoutControlItem();
			this.txtFindText = new DevExpress.XtraEditors.TextEdit();
			this.lcItemBrand = new DevExpress.XtraLayout.LayoutControlItem();
			this.lupBrand = new IKaan.Win.Core.Controls.Common.XLookup();
			this.lcItemSite = new DevExpress.XtraLayout.LayoutControlItem();
			this.lupSite = new IKaan.Win.Core.Controls.Common.XLookup();
			this.lcItemCategory = new DevExpress.XtraLayout.LayoutControlItem();
			this.lupCategory = new IKaan.Win.Core.Controls.Common.XLookup();
			this.lcTabList = new DevExpress.XtraLayout.TabbedControlGroup();
			this.lcGroupBrand = new DevExpress.XtraLayout.LayoutControlGroup();
			this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
			this.gridBrandList = new IKaan.Win.Core.Controls.Grid.XGrid();
			this.lcGroupCategory = new DevExpress.XtraLayout.LayoutControlGroup();
			this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
			this.gridCategoryList = new IKaan.Win.Core.Controls.Grid.XGrid();
			this.lcGroupColor = new DevExpress.XtraLayout.LayoutControlGroup();
			this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
			this.gridColorList = new IKaan.Win.Core.Controls.Grid.XGrid();
			this.lcGroupSize = new DevExpress.XtraLayout.LayoutControlGroup();
			this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
			this.gridSizeList = new IKaan.Win.Core.Controls.Grid.XGrid();
			this.lcGroupProduct = new DevExpress.XtraLayout.LayoutControlGroup();
			this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
			this.gridProductList = new IKaan.Win.Core.Controls.Grid.XGrid();
			this.lcGroupEditBase = new DevExpress.XtraLayout.LayoutControlGroup();
			((System.ComponentModel.ISupportInitialize)(this.lc)).BeginInit();
			this.lc.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupSearch)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.esSearchTitle)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemFindText)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtFindText.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemBrand)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lupBrand.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemSite)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lupSite.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemCategory)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lupCategory.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcTabList)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBrand)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupCategory)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupColor)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupSize)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupProduct)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupEditBase)).BeginInit();
			this.SuspendLayout();
			// 
			// lc
			// 
			this.lc.Controls.Add(this.gridProductList);
			this.lc.Controls.Add(this.gridSizeList);
			this.lc.Controls.Add(this.gridColorList);
			this.lc.Controls.Add(this.gridCategoryList);
			this.lc.Controls.Add(this.gridBrandList);
			this.lc.Controls.Add(this.lupCategory);
			this.lc.Controls.Add(this.lupSite);
			this.lc.Controls.Add(this.lupBrand);
			this.lc.Controls.Add(this.txtFindText);
			this.lc.Location = new System.Drawing.Point(0, 44);
			this.lc.Margin = new System.Windows.Forms.Padding(0);
			this.lc.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(795, 511, 457, 350);
			this.lc.OptionsView.UseDefaultDragAndDropRendering = false;
			this.lc.Padding = new System.Windows.Forms.Padding(2);
			this.lc.Size = new System.Drawing.Size(990, 552);
			// 
			// lcGroupBase
			// 
			this.lcGroupBase.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcGroupSearch,
            this.lcGroupEditBase});
			this.lcGroupBase.Name = "Root";
			this.lcGroupBase.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
			this.lcGroupBase.Size = new System.Drawing.Size(990, 552);
			// 
			// lcGroupSearch
			// 
			this.lcGroupSearch.ExpandButtonVisible = true;
			this.lcGroupSearch.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.esSearchTitle,
            this.emptySpaceItem2,
            this.lcItemBrand,
            this.lcItemCategory,
            this.lcItemSite,
            this.lcItemFindText});
			this.lcGroupSearch.Location = new System.Drawing.Point(0, 0);
			this.lcGroupSearch.Name = "lcGroupSearch";
			this.lcGroupSearch.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
			this.lcGroupSearch.Size = new System.Drawing.Size(250, 548);
			this.lcGroupSearch.TextLocation = DevExpress.Utils.Locations.Left;
			this.lcGroupSearch.TextVisible = false;
			// 
			// esSearchTitle
			// 
			this.esSearchTitle.AllowHotTrack = false;
			this.esSearchTitle.AppearanceItemCaption.BackColor = System.Drawing.Color.Black;
			this.esSearchTitle.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
			this.esSearchTitle.AppearanceItemCaption.ForeColor = System.Drawing.Color.White;
			this.esSearchTitle.AppearanceItemCaption.Options.UseBackColor = true;
			this.esSearchTitle.AppearanceItemCaption.Options.UseFont = true;
			this.esSearchTitle.AppearanceItemCaption.Options.UseForeColor = true;
			this.esSearchTitle.AppearanceItemCaption.Options.UseTextOptions = true;
			this.esSearchTitle.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.esSearchTitle.Location = new System.Drawing.Point(0, 0);
			this.esSearchTitle.MaxSize = new System.Drawing.Size(216, 40);
			this.esSearchTitle.MinSize = new System.Drawing.Size(216, 40);
			this.esSearchTitle.Name = "esSearchTitle";
			this.esSearchTitle.Size = new System.Drawing.Size(216, 40);
			this.esSearchTitle.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			this.esSearchTitle.Text = "검색조건";
			this.esSearchTitle.TextSize = new System.Drawing.Size(83, 0);
			this.esSearchTitle.TextVisible = true;
			// 
			// emptySpaceItem2
			// 
			this.emptySpaceItem2.AllowHotTrack = false;
			this.emptySpaceItem2.Location = new System.Drawing.Point(0, 204);
			this.emptySpaceItem2.Name = "emptySpaceItem2";
			this.emptySpaceItem2.Size = new System.Drawing.Size(216, 331);
			this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
			// 
			// lcItemFindText
			// 
			this.lcItemFindText.Control = this.txtFindText;
			this.lcItemFindText.Location = new System.Drawing.Point(0, 163);
			this.lcItemFindText.Name = "lcItemFindText";
			this.lcItemFindText.Size = new System.Drawing.Size(216, 41);
			this.lcItemFindText.TextLocation = DevExpress.Utils.Locations.Top;
			this.lcItemFindText.TextSize = new System.Drawing.Size(83, 14);
			// 
			// txtFindText
			// 
			this.txtFindText.Location = new System.Drawing.Point(31, 190);
			this.txtFindText.Name = "txtFindText";
			this.txtFindText.Size = new System.Drawing.Size(212, 20);
			this.txtFindText.StyleController = this.lc;
			this.txtFindText.TabIndex = 4;
			// 
			// lcItemBrand
			// 
			this.lcItemBrand.Control = this.lupBrand;
			this.lcItemBrand.Location = new System.Drawing.Point(0, 81);
			this.lcItemBrand.Name = "lcItemBrand";
			this.lcItemBrand.Size = new System.Drawing.Size(216, 41);
			this.lcItemBrand.TextLocation = DevExpress.Utils.Locations.Top;
			this.lcItemBrand.TextSize = new System.Drawing.Size(83, 14);
			// 
			// lupBrand
			// 
			this.lupBrand.DisplayMember = "";
			this.lupBrand.GroupCode = null;
			this.lupBrand.ListMember = "ListName";
			this.lupBrand.Location = new System.Drawing.Point(31, 108);
			this.lupBrand.Name = "lupBrand";
			this.lupBrand.NullText = "[EditValue is null]";
			this.lupBrand.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Redo, "", -1, true, true, false, editorButtonImageOptions3, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), "재구성")});
			this.lupBrand.SelectedIndex = -1;
			this.lupBrand.Size = new System.Drawing.Size(212, 20);
			this.lupBrand.StyleController = this.lc;
			this.lupBrand.TabIndex = 32;
			this.lupBrand.ValueMember = "";
			// 
			// lcItemSite
			// 
			this.lcItemSite.Control = this.lupSite;
			this.lcItemSite.Location = new System.Drawing.Point(0, 40);
			this.lcItemSite.Name = "lcItemSite";
			this.lcItemSite.Size = new System.Drawing.Size(216, 41);
			this.lcItemSite.TextLocation = DevExpress.Utils.Locations.Top;
			this.lcItemSite.TextSize = new System.Drawing.Size(83, 14);
			// 
			// lupSite
			// 
			this.lupSite.DisplayMember = "";
			this.lupSite.GroupCode = null;
			this.lupSite.ListMember = "ListName";
			this.lupSite.Location = new System.Drawing.Point(31, 67);
			this.lupSite.Name = "lupSite";
			this.lupSite.NullText = "[EditValue is null]";
			this.lupSite.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Redo, "", -1, true, true, false, editorButtonImageOptions2, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), "재구성")});
			this.lupSite.SelectedIndex = -1;
			this.lupSite.Size = new System.Drawing.Size(212, 20);
			this.lupSite.StyleController = this.lc;
			this.lupSite.TabIndex = 33;
			this.lupSite.ValueMember = "";
			// 
			// lcItemCategory
			// 
			this.lcItemCategory.Control = this.lupCategory;
			this.lcItemCategory.Location = new System.Drawing.Point(0, 122);
			this.lcItemCategory.Name = "lcItemCategory";
			this.lcItemCategory.Size = new System.Drawing.Size(216, 41);
			this.lcItemCategory.TextLocation = DevExpress.Utils.Locations.Top;
			this.lcItemCategory.TextSize = new System.Drawing.Size(83, 14);
			// 
			// lupCategory
			// 
			this.lupCategory.DisplayMember = "";
			this.lupCategory.GroupCode = null;
			this.lupCategory.ListMember = "ListName";
			this.lupCategory.Location = new System.Drawing.Point(31, 149);
			this.lupCategory.Name = "lupCategory";
			this.lupCategory.NullText = "[EditValue is null]";
			this.lupCategory.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Redo, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), "재구성")});
			this.lupCategory.SelectedIndex = -1;
			this.lupCategory.Size = new System.Drawing.Size(212, 20);
			this.lupCategory.StyleController = this.lc;
			this.lupCategory.TabIndex = 34;
			this.lupCategory.ValueMember = "";
			// 
			// lcTabList
			// 
			this.lcTabList.Location = new System.Drawing.Point(0, 0);
			this.lcTabList.Name = "lcTabList";
			this.lcTabList.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
			this.lcTabList.SelectedTabPage = this.lcGroupProduct;
			this.lcTabList.SelectedTabPageIndex = 4;
			this.lcTabList.Size = new System.Drawing.Size(736, 548);
			this.lcTabList.TabPages.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcGroupBrand,
            this.lcGroupCategory,
            this.lcGroupColor,
            this.lcGroupSize,
            this.lcGroupProduct});
			// 
			// lcGroupBrand
			// 
			this.lcGroupBrand.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
			this.lcGroupBrand.Location = new System.Drawing.Point(0, 0);
			this.lcGroupBrand.Name = "lcGroupBrand";
			this.lcGroupBrand.Size = new System.Drawing.Size(726, 514);
			this.lcGroupBrand.Text = "Brand";
			// 
			// layoutControlItem1
			// 
			this.layoutControlItem1.Control = this.gridBrandList;
			this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
			this.layoutControlItem1.Name = "layoutControlItem1";
			this.layoutControlItem1.Size = new System.Drawing.Size(726, 514);
			this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem1.TextVisible = false;
			// 
			// gridBrandList
			// 
			this.gridBrandList.Compress = false;
			this.gridBrandList.DataSource = null;
			this.gridBrandList.Editable = true;
			this.gridBrandList.FocusedRowHandle = -2147483648;
			this.gridBrandList.GridViewType = IKaan.Win.Core.Controls.Grid.GridViewType.GridView;
			this.gridBrandList.Location = new System.Drawing.Point(259, 33);
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
			this.gridBrandList.Size = new System.Drawing.Size(722, 510);
			this.gridBrandList.TabIndex = 37;
			// 
			// lcGroupCategory
			// 
			this.lcGroupCategory.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem4});
			this.lcGroupCategory.Location = new System.Drawing.Point(0, 0);
			this.lcGroupCategory.Name = "lcGroupCategory";
			this.lcGroupCategory.Size = new System.Drawing.Size(726, 514);
			this.lcGroupCategory.Text = "Category";
			// 
			// layoutControlItem4
			// 
			this.layoutControlItem4.Control = this.gridCategoryList;
			this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
			this.layoutControlItem4.Name = "layoutControlItem4";
			this.layoutControlItem4.Size = new System.Drawing.Size(726, 514);
			this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem4.TextVisible = false;
			// 
			// gridCategoryList
			// 
			this.gridCategoryList.Compress = false;
			this.gridCategoryList.DataSource = null;
			this.gridCategoryList.Editable = true;
			this.gridCategoryList.FocusedRowHandle = -2147483648;
			this.gridCategoryList.GridViewType = IKaan.Win.Core.Controls.Grid.GridViewType.GridView;
			this.gridCategoryList.Location = new System.Drawing.Point(259, 33);
			this.gridCategoryList.Name = "gridCategoryList";
			this.gridCategoryList.PageFooterCenter = null;
			this.gridCategoryList.PageFooterLeft = null;
			this.gridCategoryList.PageFooterRight = null;
			this.gridCategoryList.PageHeaderCenter = null;
			this.gridCategoryList.PageHeaderLeft = null;
			this.gridCategoryList.PageHeaderRight = null;
			this.gridCategoryList.Pager = null;
			this.gridCategoryList.PrintFooter = null;
			this.gridCategoryList.PrintHeader = null;
			this.gridCategoryList.ReadOnly = false;
			this.gridCategoryList.ShowFooter = false;
			this.gridCategoryList.ShowGroupPanel = false;
			this.gridCategoryList.Size = new System.Drawing.Size(722, 510);
			this.gridCategoryList.TabIndex = 39;
			// 
			// lcGroupColor
			// 
			this.lcGroupColor.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem5});
			this.lcGroupColor.Location = new System.Drawing.Point(0, 0);
			this.lcGroupColor.Name = "lcGroupColor";
			this.lcGroupColor.Size = new System.Drawing.Size(726, 514);
			this.lcGroupColor.Text = "Color";
			// 
			// layoutControlItem5
			// 
			this.layoutControlItem5.Control = this.gridColorList;
			this.layoutControlItem5.Location = new System.Drawing.Point(0, 0);
			this.layoutControlItem5.Name = "layoutControlItem5";
			this.layoutControlItem5.Size = new System.Drawing.Size(726, 514);
			this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem5.TextVisible = false;
			// 
			// gridColorList
			// 
			this.gridColorList.Compress = false;
			this.gridColorList.DataSource = null;
			this.gridColorList.Editable = true;
			this.gridColorList.FocusedRowHandle = -2147483648;
			this.gridColorList.GridViewType = IKaan.Win.Core.Controls.Grid.GridViewType.GridView;
			this.gridColorList.Location = new System.Drawing.Point(259, 33);
			this.gridColorList.Name = "gridColorList";
			this.gridColorList.PageFooterCenter = null;
			this.gridColorList.PageFooterLeft = null;
			this.gridColorList.PageFooterRight = null;
			this.gridColorList.PageHeaderCenter = null;
			this.gridColorList.PageHeaderLeft = null;
			this.gridColorList.PageHeaderRight = null;
			this.gridColorList.Pager = null;
			this.gridColorList.PrintFooter = null;
			this.gridColorList.PrintHeader = null;
			this.gridColorList.ReadOnly = false;
			this.gridColorList.ShowFooter = false;
			this.gridColorList.ShowGroupPanel = false;
			this.gridColorList.Size = new System.Drawing.Size(722, 510);
			this.gridColorList.TabIndex = 40;
			// 
			// lcGroupSize
			// 
			this.lcGroupSize.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem6});
			this.lcGroupSize.Location = new System.Drawing.Point(0, 0);
			this.lcGroupSize.Name = "lcGroupSize";
			this.lcGroupSize.Size = new System.Drawing.Size(726, 514);
			this.lcGroupSize.Text = "Size";
			// 
			// layoutControlItem6
			// 
			this.layoutControlItem6.Control = this.gridSizeList;
			this.layoutControlItem6.Location = new System.Drawing.Point(0, 0);
			this.layoutControlItem6.Name = "layoutControlItem6";
			this.layoutControlItem6.Size = new System.Drawing.Size(726, 514);
			this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem6.TextVisible = false;
			// 
			// gridSizeList
			// 
			this.gridSizeList.Compress = false;
			this.gridSizeList.DataSource = null;
			this.gridSizeList.Editable = true;
			this.gridSizeList.FocusedRowHandle = -2147483648;
			this.gridSizeList.GridViewType = IKaan.Win.Core.Controls.Grid.GridViewType.GridView;
			this.gridSizeList.Location = new System.Drawing.Point(259, 33);
			this.gridSizeList.Name = "gridSizeList";
			this.gridSizeList.PageFooterCenter = null;
			this.gridSizeList.PageFooterLeft = null;
			this.gridSizeList.PageFooterRight = null;
			this.gridSizeList.PageHeaderCenter = null;
			this.gridSizeList.PageHeaderLeft = null;
			this.gridSizeList.PageHeaderRight = null;
			this.gridSizeList.Pager = null;
			this.gridSizeList.PrintFooter = null;
			this.gridSizeList.PrintHeader = null;
			this.gridSizeList.ReadOnly = false;
			this.gridSizeList.ShowFooter = false;
			this.gridSizeList.ShowGroupPanel = false;
			this.gridSizeList.Size = new System.Drawing.Size(722, 510);
			this.gridSizeList.TabIndex = 41;
			// 
			// lcGroupProduct
			// 
			this.lcGroupProduct.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem7});
			this.lcGroupProduct.Location = new System.Drawing.Point(0, 0);
			this.lcGroupProduct.Name = "lcGroupProduct";
			this.lcGroupProduct.Size = new System.Drawing.Size(726, 514);
			this.lcGroupProduct.Text = "Product";
			// 
			// layoutControlItem7
			// 
			this.layoutControlItem7.Control = this.gridProductList;
			this.layoutControlItem7.Location = new System.Drawing.Point(0, 0);
			this.layoutControlItem7.Name = "layoutControlItem7";
			this.layoutControlItem7.Size = new System.Drawing.Size(726, 514);
			this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem7.TextVisible = false;
			// 
			// gridProductList
			// 
			this.gridProductList.Compress = false;
			this.gridProductList.DataSource = null;
			this.gridProductList.Editable = true;
			this.gridProductList.FocusedRowHandle = -2147483648;
			this.gridProductList.GridViewType = IKaan.Win.Core.Controls.Grid.GridViewType.GridView;
			this.gridProductList.Location = new System.Drawing.Point(259, 33);
			this.gridProductList.Name = "gridProductList";
			this.gridProductList.PageFooterCenter = null;
			this.gridProductList.PageFooterLeft = null;
			this.gridProductList.PageFooterRight = null;
			this.gridProductList.PageHeaderCenter = null;
			this.gridProductList.PageHeaderLeft = null;
			this.gridProductList.PageHeaderRight = null;
			this.gridProductList.Pager = null;
			this.gridProductList.PrintFooter = null;
			this.gridProductList.PrintHeader = null;
			this.gridProductList.ReadOnly = false;
			this.gridProductList.ShowFooter = false;
			this.gridProductList.ShowGroupPanel = false;
			this.gridProductList.Size = new System.Drawing.Size(722, 510);
			this.gridProductList.TabIndex = 42;
			// 
			// lcGroupEditBase
			// 
			this.lcGroupEditBase.GroupBordersVisible = false;
			this.lcGroupEditBase.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcTabList});
			this.lcGroupEditBase.Location = new System.Drawing.Point(250, 0);
			this.lcGroupEditBase.Name = "lcGroupEditBase";
			this.lcGroupEditBase.Size = new System.Drawing.Size(736, 548);
			this.lcGroupEditBase.TextVisible = false;
			// 
			// ScrapListForm
			// 
			this.Appearance.BackColor = System.Drawing.Color.White;
			this.Appearance.Options.UseBackColor = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(990, 618);
			this.LookAndFeel.SkinName = "Office 2016 Dark";
			this.Name = "ScrapListForm";
			this.Text = "ScrapListForm";
			((System.ComponentModel.ISupportInitialize)(this.lc)).EndInit();
			this.lc.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupSearch)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.esSearchTitle)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemFindText)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtFindText.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemBrand)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lupBrand.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemSite)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lupSite.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemCategory)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lupCategory.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcTabList)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBrand)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupCategory)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupColor)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupSize)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupProduct)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupEditBase)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupSearch;
		private DevExpress.XtraEditors.TextEdit txtFindText;
		private DevExpress.XtraLayout.LayoutControlItem lcItemFindText;
		private DevExpress.XtraLayout.EmptySpaceItem esSearchTitle;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
		private DevExpress.XtraLayout.TabbedControlGroup lcTabList;
		private Core.Controls.Common.XLookup lupBrand;
		private DevExpress.XtraLayout.LayoutControlItem lcItemBrand;
		private Core.Controls.Common.XLookup lupSite;
		private DevExpress.XtraLayout.LayoutControlItem lcItemSite;
		private Core.Controls.Common.XLookup lupCategory;
		private DevExpress.XtraLayout.LayoutControlItem lcItemCategory;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupEditBase;
		private Core.Controls.Grid.XGrid gridBrandList;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupBrand;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
		private Core.Controls.Grid.XGrid gridCategoryList;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupCategory;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
		private Core.Controls.Grid.XGrid gridSizeList;
		private Core.Controls.Grid.XGrid gridColorList;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupSize;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupColor;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupProduct;
		private Core.Controls.Grid.XGrid gridProductList;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
	}
}