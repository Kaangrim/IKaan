namespace IKaan.Win.View.Biz.Catalog.Category
{
	partial class CategoryListForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CategoryListForm));
			DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions2 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
			DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
			this.lcGroupSearch = new DevExpress.XtraLayout.LayoutControlGroup();
			this.lcItemCategory1 = new DevExpress.XtraLayout.LayoutControlItem();
			this.lupCategory1 = new IKaan.Win.Core.Controls.Common.XLookup();
			this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.esSearchTitle = new DevExpress.XtraLayout.EmptySpaceItem();
			this.lcItemFindText = new DevExpress.XtraLayout.LayoutControlItem();
			this.txtFindText = new DevExpress.XtraEditors.TextEdit();
			this.gridList = new IKaan.Win.Core.Controls.Grid.XGrid();
			this.lcTabList = new DevExpress.XtraLayout.TabbedControlGroup();
			this.lcGroupList = new DevExpress.XtraLayout.LayoutControlGroup();
			this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
			this.lupCategory2 = new IKaan.Win.Core.Controls.Common.XLookup();
			this.lcItemCategory2 = new DevExpress.XtraLayout.LayoutControlItem();
			this.lupCategory3 = new IKaan.Win.Core.Controls.Common.XLookup();
			this.lcItemCategory3 = new DevExpress.XtraLayout.LayoutControlItem();
			((System.ComponentModel.ISupportInitialize)(this.lc)).BeginInit();
			this.lc.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupSearch)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemCategory1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lupCategory1.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.esSearchTitle)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemFindText)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtFindText.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcTabList)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupList)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lupCategory2.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemCategory2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lupCategory3.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemCategory3)).BeginInit();
			this.SuspendLayout();
			// 
			// lc
			// 
			this.lc.Controls.Add(this.lupCategory3);
			this.lc.Controls.Add(this.lupCategory2);
			this.lc.Controls.Add(this.lupCategory1);
			this.lc.Controls.Add(this.gridList);
			this.lc.Controls.Add(this.txtFindText);
			this.lc.Location = new System.Drawing.Point(0, 44);
			this.lc.Margin = new System.Windows.Forms.Padding(0);
			this.lc.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(930, 470, 457, 350);
			this.lc.OptionsView.UseDefaultDragAndDropRendering = false;
			this.lc.Padding = new System.Windows.Forms.Padding(2);
			this.lc.Size = new System.Drawing.Size(990, 499);
			// 
			// lcGroupBase
			// 
			this.lcGroupBase.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcGroupSearch,
            this.lcTabList});
			this.lcGroupBase.Name = "Root";
			this.lcGroupBase.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
			this.lcGroupBase.Size = new System.Drawing.Size(990, 499);
			// 
			// lcGroupSearch
			// 
			this.lcGroupSearch.ExpandButtonVisible = true;
			this.lcGroupSearch.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcItemCategory1,
            this.emptySpaceItem1,
            this.esSearchTitle,
            this.lcItemFindText,
            this.lcItemCategory2,
            this.lcItemCategory3});
			this.lcGroupSearch.Location = new System.Drawing.Point(0, 0);
			this.lcGroupSearch.Name = "lcGroupSearch";
			this.lcGroupSearch.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
			this.lcGroupSearch.Size = new System.Drawing.Size(250, 495);
			this.lcGroupSearch.TextLocation = DevExpress.Utils.Locations.Left;
			this.lcGroupSearch.TextVisible = false;
			// 
			// lcItemCategory1
			// 
			this.lcItemCategory1.Control = this.lupCategory1;
			this.lcItemCategory1.Location = new System.Drawing.Point(0, 81);
			this.lcItemCategory1.Name = "lcItemCategory1";
			this.lcItemCategory1.Size = new System.Drawing.Size(216, 41);
			this.lcItemCategory1.TextLocation = DevExpress.Utils.Locations.Top;
			this.lcItemCategory1.TextSize = new System.Drawing.Size(90, 14);
			// 
			// lupCategory1
			// 
			this.lupCategory1.DisplayMember = "";
			this.lupCategory1.GroupCode = null;
			this.lupCategory1.ListMember = "ListName";
			this.lupCategory1.Location = new System.Drawing.Point(31, 108);
			this.lupCategory1.Name = "lupCategory1";
			this.lupCategory1.NullText = "[EditValue is null]";
			this.lupCategory1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Redo, "", -1, true, true, false, editorButtonImageOptions3, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), "재구성")});
			this.lupCategory1.SelectedIndex = -1;
			this.lupCategory1.Size = new System.Drawing.Size(212, 20);
			this.lupCategory1.StyleController = this.lc;
			this.lupCategory1.TabIndex = 43;
			this.lupCategory1.ValueMember = "";
			// 
			// emptySpaceItem1
			// 
			this.emptySpaceItem1.AllowHotTrack = false;
			this.emptySpaceItem1.Location = new System.Drawing.Point(0, 204);
			this.emptySpaceItem1.Name = "emptySpaceItem1";
			this.emptySpaceItem1.Size = new System.Drawing.Size(216, 278);
			this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
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
			this.esSearchTitle.TextSize = new System.Drawing.Size(90, 0);
			this.esSearchTitle.TextVisible = true;
			// 
			// lcItemFindText
			// 
			this.lcItemFindText.Control = this.txtFindText;
			this.lcItemFindText.Location = new System.Drawing.Point(0, 40);
			this.lcItemFindText.Name = "lcItemFindText";
			this.lcItemFindText.Size = new System.Drawing.Size(216, 41);
			this.lcItemFindText.TextLocation = DevExpress.Utils.Locations.Top;
			this.lcItemFindText.TextSize = new System.Drawing.Size(90, 14);
			// 
			// txtFindText
			// 
			this.txtFindText.Location = new System.Drawing.Point(31, 67);
			this.txtFindText.Name = "txtFindText";
			this.txtFindText.Size = new System.Drawing.Size(212, 20);
			this.txtFindText.StyleController = this.lc;
			this.txtFindText.TabIndex = 4;
			// 
			// gridList
			// 
			this.gridList.Compress = false;
			this.gridList.DataSource = null;
			this.gridList.Editable = true;
			this.gridList.FocusedRowHandle = -2147483648;
			this.gridList.GridViewType = IKaan.Win.Core.Controls.Grid.GridViewType.GridView;
			this.gridList.Location = new System.Drawing.Point(259, 35);
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
			this.gridList.Size = new System.Drawing.Size(722, 455);
			this.gridList.TabIndex = 7;
			// 
			// lcTabList
			// 
			this.lcTabList.Location = new System.Drawing.Point(250, 0);
			this.lcTabList.Name = "lcTabList";
			this.lcTabList.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
			this.lcTabList.SelectedTabPage = this.lcGroupList;
			this.lcTabList.SelectedTabPageIndex = 0;
			this.lcTabList.Size = new System.Drawing.Size(736, 495);
			this.lcTabList.TabPages.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcGroupList});
			// 
			// lcGroupList
			// 
			this.lcGroupList.CaptionImage = ((System.Drawing.Image)(resources.GetObject("lcGroupList.CaptionImage")));
			this.lcGroupList.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3});
			this.lcGroupList.Location = new System.Drawing.Point(0, 0);
			this.lcGroupList.Name = "lcGroupList";
			this.lcGroupList.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
			this.lcGroupList.Size = new System.Drawing.Size(726, 459);
			this.lcGroupList.Text = "조회결과";
			// 
			// layoutControlItem3
			// 
			this.layoutControlItem3.Control = this.gridList;
			this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
			this.layoutControlItem3.Name = "layoutControlItem3";
			this.layoutControlItem3.Size = new System.Drawing.Size(726, 459);
			this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem3.TextVisible = false;
			// 
			// lupCategory2
			// 
			this.lupCategory2.DisplayMember = "";
			this.lupCategory2.GroupCode = null;
			this.lupCategory2.ListMember = "ListName";
			this.lupCategory2.Location = new System.Drawing.Point(31, 149);
			this.lupCategory2.Name = "lupCategory2";
			this.lupCategory2.NullText = "[EditValue is null]";
			this.lupCategory2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Redo, "", -1, true, true, false, editorButtonImageOptions2, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), "재구성")});
			this.lupCategory2.SelectedIndex = -1;
			this.lupCategory2.Size = new System.Drawing.Size(212, 20);
			this.lupCategory2.StyleController = this.lc;
			this.lupCategory2.TabIndex = 44;
			this.lupCategory2.ValueMember = "";
			// 
			// lcItemCategory2
			// 
			this.lcItemCategory2.Control = this.lupCategory2;
			this.lcItemCategory2.Location = new System.Drawing.Point(0, 122);
			this.lcItemCategory2.Name = "lcItemCategory2";
			this.lcItemCategory2.Size = new System.Drawing.Size(216, 41);
			this.lcItemCategory2.TextLocation = DevExpress.Utils.Locations.Top;
			this.lcItemCategory2.TextSize = new System.Drawing.Size(90, 14);
			// 
			// lupCategory3
			// 
			this.lupCategory3.DisplayMember = "";
			this.lupCategory3.GroupCode = null;
			this.lupCategory3.ListMember = "ListName";
			this.lupCategory3.Location = new System.Drawing.Point(31, 190);
			this.lupCategory3.Name = "lupCategory3";
			this.lupCategory3.NullText = "[EditValue is null]";
			this.lupCategory3.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Redo, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), "재구성")});
			this.lupCategory3.SelectedIndex = -1;
			this.lupCategory3.Size = new System.Drawing.Size(212, 20);
			this.lupCategory3.StyleController = this.lc;
			this.lupCategory3.TabIndex = 45;
			this.lupCategory3.ValueMember = "";
			// 
			// lcItemCategory3
			// 
			this.lcItemCategory3.Control = this.lupCategory3;
			this.lcItemCategory3.Location = new System.Drawing.Point(0, 163);
			this.lcItemCategory3.Name = "lcItemCategory3";
			this.lcItemCategory3.Size = new System.Drawing.Size(216, 41);
			this.lcItemCategory3.TextLocation = DevExpress.Utils.Locations.Top;
			this.lcItemCategory3.TextSize = new System.Drawing.Size(90, 14);
			// 
			// CategoryListForm
			// 
			this.Appearance.BackColor = System.Drawing.Color.White;
			this.Appearance.Options.UseBackColor = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(990, 565);
			this.LookAndFeel.SkinName = "Office 2016 Dark";
			this.Name = "CategoryListForm";
			this.Text = "CategoryListForm";
			((System.ComponentModel.ISupportInitialize)(this.lc)).EndInit();
			this.lc.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupSearch)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemCategory1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lupCategory1.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.esSearchTitle)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemFindText)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtFindText.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcTabList)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupList)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lupCategory2.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemCategory2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lupCategory3.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemCategory3)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupSearch;
		private DevExpress.XtraEditors.TextEdit txtFindText;
		private DevExpress.XtraLayout.LayoutControlItem lcItemFindText;
		private IKaan.Win.Core.Controls.Grid.XGrid gridList;
		private Core.Controls.Common.XLookup lupCategory1;
		private DevExpress.XtraLayout.LayoutControlItem lcItemCategory1;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
		private DevExpress.XtraLayout.EmptySpaceItem esSearchTitle;
		private DevExpress.XtraLayout.TabbedControlGroup lcTabList;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupList;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
		private Core.Controls.Common.XLookup lupCategory3;
		private Core.Controls.Common.XLookup lupCategory2;
		private DevExpress.XtraLayout.LayoutControlItem lcItemCategory2;
		private DevExpress.XtraLayout.LayoutControlItem lcItemCategory3;
	}
}