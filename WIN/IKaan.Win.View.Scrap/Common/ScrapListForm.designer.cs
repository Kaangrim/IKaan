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
			DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
			DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions2 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
			this.lcGroupSearch = new DevExpress.XtraLayout.LayoutControlGroup();
			this.esSearchTitle = new DevExpress.XtraLayout.EmptySpaceItem();
			this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.lcItemBrand = new DevExpress.XtraLayout.LayoutControlItem();
			this.lupBrand = new IKaan.Win.Core.Controls.Common.XLookup();
			this.lcItemCategory = new DevExpress.XtraLayout.LayoutControlItem();
			this.lupCategory = new IKaan.Win.Core.Controls.Common.XLookup();
			this.lcItemSite = new DevExpress.XtraLayout.LayoutControlItem();
			this.lupSite = new IKaan.Win.Core.Controls.Common.XLookup();
			this.lcItemFindText = new DevExpress.XtraLayout.LayoutControlItem();
			this.txtFindText = new DevExpress.XtraEditors.TextEdit();
			this.lcButtonOptionDiv = new DevExpress.XtraLayout.LayoutControlItem();
			this.btnOptionDiv = new DevExpress.XtraEditors.SimpleButton();
			this.lcButtonImageUpload = new DevExpress.XtraLayout.LayoutControlItem();
			this.btnImageUpload = new DevExpress.XtraEditors.SimpleButton();
			this.lcTabList = new DevExpress.XtraLayout.TabbedControlGroup();
			this.lcGroupBrand = new DevExpress.XtraLayout.LayoutControlGroup();
			this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
			this.gridBrands = new IKaan.Win.Core.Controls.Grid.XGrid();
			this.lcGroupCategory = new DevExpress.XtraLayout.LayoutControlGroup();
			this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
			this.gridCategories = new IKaan.Win.Core.Controls.Grid.XGrid();
			this.lcGroupOption = new DevExpress.XtraLayout.LayoutControlGroup();
			this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
			this.gridOptions = new IKaan.Win.Core.Controls.Grid.XGrid();
			this.lcGroupProduct = new DevExpress.XtraLayout.LayoutControlGroup();
			this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
			this.gridProducts = new IKaan.Win.Core.Controls.Grid.XGrid();
			this.lcGroupEditBase = new DevExpress.XtraLayout.LayoutControlGroup();
			((System.ComponentModel.ISupportInitialize)(this.lc)).BeginInit();
			this.lc.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupSearch)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.esSearchTitle)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemBrand)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lupBrand.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemCategory)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lupCategory.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemSite)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lupSite.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemFindText)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtFindText.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcButtonOptionDiv)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcButtonImageUpload)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcTabList)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBrand)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupCategory)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupOption)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupProduct)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupEditBase)).BeginInit();
			this.SuspendLayout();
			// 
			// lc
			// 
			this.lc.Controls.Add(this.btnImageUpload);
			this.lc.Controls.Add(this.btnOptionDiv);
			this.lc.Controls.Add(this.gridProducts);
			this.lc.Controls.Add(this.gridOptions);
			this.lc.Controls.Add(this.gridCategories);
			this.lc.Controls.Add(this.gridBrands);
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
            this.lcItemFindText,
            this.lcButtonOptionDiv,
            this.lcButtonImageUpload});
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
			this.emptySpaceItem2.Size = new System.Drawing.Size(216, 279);
			this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
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
			// lcButtonOptionDiv
			// 
			this.lcButtonOptionDiv.Control = this.btnOptionDiv;
			this.lcButtonOptionDiv.Location = new System.Drawing.Point(0, 483);
			this.lcButtonOptionDiv.Name = "lcButtonOptionDiv";
			this.lcButtonOptionDiv.Size = new System.Drawing.Size(216, 26);
			this.lcButtonOptionDiv.TextSize = new System.Drawing.Size(0, 0);
			this.lcButtonOptionDiv.TextVisible = false;
			// 
			// btnOptionDiv
			// 
			this.btnOptionDiv.Location = new System.Drawing.Point(31, 493);
			this.btnOptionDiv.Name = "btnOptionDiv";
			this.btnOptionDiv.Size = new System.Drawing.Size(212, 22);
			this.btnOptionDiv.StyleController = this.lc;
			this.btnOptionDiv.TabIndex = 43;
			this.btnOptionDiv.Text = "옵션수집";
			// 
			// lcButtonImageUpload
			// 
			this.lcButtonImageUpload.Control = this.btnImageUpload;
			this.lcButtonImageUpload.Location = new System.Drawing.Point(0, 509);
			this.lcButtonImageUpload.Name = "lcButtonImageUpload";
			this.lcButtonImageUpload.Size = new System.Drawing.Size(216, 26);
			this.lcButtonImageUpload.TextSize = new System.Drawing.Size(0, 0);
			this.lcButtonImageUpload.TextVisible = false;
			// 
			// btnImageUpload
			// 
			this.btnImageUpload.Location = new System.Drawing.Point(31, 519);
			this.btnImageUpload.Name = "btnImageUpload";
			this.btnImageUpload.Size = new System.Drawing.Size(212, 22);
			this.btnImageUpload.StyleController = this.lc;
			this.btnImageUpload.TabIndex = 44;
			this.btnImageUpload.Text = "이미지업로드";
			// 
			// lcTabList
			// 
			this.lcTabList.Location = new System.Drawing.Point(0, 0);
			this.lcTabList.Name = "lcTabList";
			this.lcTabList.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
			this.lcTabList.SelectedTabPage = this.lcGroupBrand;
			this.lcTabList.SelectedTabPageIndex = 0;
			this.lcTabList.Size = new System.Drawing.Size(736, 548);
			this.lcTabList.TabPages.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcGroupBrand,
            this.lcGroupCategory,
            this.lcGroupOption,
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
			this.layoutControlItem1.Control = this.gridBrands;
			this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
			this.layoutControlItem1.Name = "layoutControlItem1";
			this.layoutControlItem1.Size = new System.Drawing.Size(726, 514);
			this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem1.TextVisible = false;
			// 
			// gridBrands
			// 
			this.gridBrands.Compress = false;
			this.gridBrands.DataSource = null;
			this.gridBrands.Editable = true;
			this.gridBrands.FocusedRowHandle = -2147483648;
			this.gridBrands.GridViewType = IKaan.Win.Core.Controls.Grid.GridViewType.GridView;
			this.gridBrands.Location = new System.Drawing.Point(259, 33);
			this.gridBrands.Name = "gridBrands";
			this.gridBrands.PageFooterCenter = null;
			this.gridBrands.PageFooterLeft = null;
			this.gridBrands.PageFooterRight = null;
			this.gridBrands.PageHeaderCenter = null;
			this.gridBrands.PageHeaderLeft = null;
			this.gridBrands.PageHeaderRight = null;
			this.gridBrands.Pager = null;
			this.gridBrands.PrintFooter = null;
			this.gridBrands.PrintHeader = null;
			this.gridBrands.ReadOnly = false;
			this.gridBrands.ShowFooter = false;
			this.gridBrands.ShowGroupPanel = false;
			this.gridBrands.Size = new System.Drawing.Size(722, 510);
			this.gridBrands.TabIndex = 37;
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
			this.layoutControlItem4.Control = this.gridCategories;
			this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
			this.layoutControlItem4.Name = "layoutControlItem4";
			this.layoutControlItem4.Size = new System.Drawing.Size(726, 514);
			this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem4.TextVisible = false;
			// 
			// gridCategories
			// 
			this.gridCategories.Compress = false;
			this.gridCategories.DataSource = null;
			this.gridCategories.Editable = true;
			this.gridCategories.FocusedRowHandle = -2147483648;
			this.gridCategories.GridViewType = IKaan.Win.Core.Controls.Grid.GridViewType.GridView;
			this.gridCategories.Location = new System.Drawing.Point(259, 33);
			this.gridCategories.Name = "gridCategories";
			this.gridCategories.PageFooterCenter = null;
			this.gridCategories.PageFooterLeft = null;
			this.gridCategories.PageFooterRight = null;
			this.gridCategories.PageHeaderCenter = null;
			this.gridCategories.PageHeaderLeft = null;
			this.gridCategories.PageHeaderRight = null;
			this.gridCategories.Pager = null;
			this.gridCategories.PrintFooter = null;
			this.gridCategories.PrintHeader = null;
			this.gridCategories.ReadOnly = false;
			this.gridCategories.ShowFooter = false;
			this.gridCategories.ShowGroupPanel = false;
			this.gridCategories.Size = new System.Drawing.Size(722, 510);
			this.gridCategories.TabIndex = 39;
			// 
			// lcGroupOption
			// 
			this.lcGroupOption.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem5});
			this.lcGroupOption.Location = new System.Drawing.Point(0, 0);
			this.lcGroupOption.Name = "lcGroupOption";
			this.lcGroupOption.Size = new System.Drawing.Size(726, 514);
			this.lcGroupOption.Text = "Option";
			// 
			// layoutControlItem5
			// 
			this.layoutControlItem5.Control = this.gridOptions;
			this.layoutControlItem5.Location = new System.Drawing.Point(0, 0);
			this.layoutControlItem5.Name = "layoutControlItem5";
			this.layoutControlItem5.Size = new System.Drawing.Size(726, 514);
			this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem5.TextVisible = false;
			// 
			// gridOptions
			// 
			this.gridOptions.Compress = false;
			this.gridOptions.DataSource = null;
			this.gridOptions.Editable = true;
			this.gridOptions.FocusedRowHandle = -2147483648;
			this.gridOptions.GridViewType = IKaan.Win.Core.Controls.Grid.GridViewType.GridView;
			this.gridOptions.Location = new System.Drawing.Point(259, 33);
			this.gridOptions.Name = "gridOptions";
			this.gridOptions.PageFooterCenter = null;
			this.gridOptions.PageFooterLeft = null;
			this.gridOptions.PageFooterRight = null;
			this.gridOptions.PageHeaderCenter = null;
			this.gridOptions.PageHeaderLeft = null;
			this.gridOptions.PageHeaderRight = null;
			this.gridOptions.Pager = null;
			this.gridOptions.PrintFooter = null;
			this.gridOptions.PrintHeader = null;
			this.gridOptions.ReadOnly = false;
			this.gridOptions.ShowFooter = false;
			this.gridOptions.ShowGroupPanel = false;
			this.gridOptions.Size = new System.Drawing.Size(722, 510);
			this.gridOptions.TabIndex = 40;
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
			this.layoutControlItem7.Control = this.gridProducts;
			this.layoutControlItem7.Location = new System.Drawing.Point(0, 0);
			this.layoutControlItem7.Name = "layoutControlItem7";
			this.layoutControlItem7.Size = new System.Drawing.Size(726, 514);
			this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem7.TextVisible = false;
			// 
			// gridProducts
			// 
			this.gridProducts.Compress = false;
			this.gridProducts.DataSource = null;
			this.gridProducts.Editable = true;
			this.gridProducts.FocusedRowHandle = -2147483648;
			this.gridProducts.GridViewType = IKaan.Win.Core.Controls.Grid.GridViewType.GridView;
			this.gridProducts.Location = new System.Drawing.Point(259, 33);
			this.gridProducts.Name = "gridProducts";
			this.gridProducts.PageFooterCenter = null;
			this.gridProducts.PageFooterLeft = null;
			this.gridProducts.PageFooterRight = null;
			this.gridProducts.PageHeaderCenter = null;
			this.gridProducts.PageHeaderLeft = null;
			this.gridProducts.PageHeaderRight = null;
			this.gridProducts.Pager = null;
			this.gridProducts.PrintFooter = null;
			this.gridProducts.PrintHeader = null;
			this.gridProducts.ReadOnly = false;
			this.gridProducts.ShowFooter = false;
			this.gridProducts.ShowGroupPanel = false;
			this.gridProducts.Size = new System.Drawing.Size(722, 510);
			this.gridProducts.TabIndex = 42;
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
			((System.ComponentModel.ISupportInitialize)(this.lcItemBrand)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lupBrand.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemCategory)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lupCategory.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemSite)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lupSite.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemFindText)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtFindText.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcButtonOptionDiv)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcButtonImageUpload)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcTabList)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBrand)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupCategory)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupOption)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
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
		private Core.Controls.Grid.XGrid gridBrands;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupBrand;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
		private Core.Controls.Grid.XGrid gridCategories;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupCategory;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
		private Core.Controls.Grid.XGrid gridOptions;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupOption;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupProduct;
		private Core.Controls.Grid.XGrid gridProducts;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
		private DevExpress.XtraEditors.SimpleButton btnOptionDiv;
		private DevExpress.XtraLayout.LayoutControlItem lcButtonOptionDiv;
		private DevExpress.XtraEditors.SimpleButton btnImageUpload;
		private DevExpress.XtraLayout.LayoutControlItem lcButtonImageUpload;
	}
}