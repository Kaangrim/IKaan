namespace IKaan.Win.View.Biz.Master.Brand
{
	partial class BrandFromScrapForm
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
			this.lcItemFindText = new DevExpress.XtraLayout.LayoutControlItem();
			this.txtFindText = new DevExpress.XtraEditors.TextEdit();
			this.lcItemSite = new DevExpress.XtraLayout.LayoutControlItem();
			this.lupSiteID = new IKaan.Win.Core.Controls.Common.XLookup();
			this.lcItemUseYn = new DevExpress.XtraLayout.LayoutControlItem();
			this.lupUseYn = new IKaan.Win.Core.Controls.Common.XLookup();
			this.lcGroupSearch = new DevExpress.XtraLayout.LayoutControlGroup();
			this.gridResult = new IKaan.Win.Core.Controls.Grid.XGrid();
			this.lcGroupResult = new DevExpress.XtraLayout.LayoutControlGroup();
			this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
			this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.lcGroupButtons = new DevExpress.XtraLayout.LayoutControlGroup();
			this.lcButtonAccept = new DevExpress.XtraLayout.LayoutControlItem();
			this.btnAccept = new DevExpress.XtraEditors.SimpleButton();
			this.lcButtonSearch = new DevExpress.XtraLayout.LayoutControlItem();
			this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.lc)).BeginInit();
			this.lc.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemFindText)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtFindText.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemSite)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lupSiteID.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemUseYn)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lupUseYn.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupSearch)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupResult)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupButtons)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcButtonAccept)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcButtonSearch)).BeginInit();
			this.SuspendLayout();
			// 
			// lc
			// 
			this.lc.Controls.Add(this.btnSearch);
			this.lc.Controls.Add(this.btnAccept);
			this.lc.Controls.Add(this.lupUseYn);
			this.lc.Controls.Add(this.lupSiteID);
			this.lc.Controls.Add(this.gridResult);
			this.lc.Controls.Add(this.txtFindText);
			this.lc.Margin = new System.Windows.Forms.Padding(0);
			this.lc.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1344, 329, 457, 350);
			this.lc.OptionsView.UseDefaultDragAndDropRendering = false;
			this.lc.Padding = new System.Windows.Forms.Padding(2);
			this.lc.Size = new System.Drawing.Size(798, 568);
			// 
			// lcGroupBase
			// 
			this.lcGroupBase.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcGroupSearch,
            this.lcGroupResult,
            this.lcGroupButtons});
			this.lcGroupBase.Name = "Root";
			this.lcGroupBase.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
			this.lcGroupBase.Size = new System.Drawing.Size(798, 568);
			// 
			// lcItemFindText
			// 
			this.lcItemFindText.Control = this.txtFindText;
			this.lcItemFindText.Location = new System.Drawing.Point(0, 24);
			this.lcItemFindText.Name = "lcItemFindText";
			this.lcItemFindText.Size = new System.Drawing.Size(780, 24);
			this.lcItemFindText.TextSize = new System.Drawing.Size(82, 14);
			// 
			// txtFindText
			// 
			this.txtFindText.Location = new System.Drawing.Point(97, 35);
			this.txtFindText.Name = "txtFindText";
			this.txtFindText.Size = new System.Drawing.Size(690, 20);
			this.txtFindText.StyleController = this.lc;
			this.txtFindText.TabIndex = 23;
			// 
			// lcItemSite
			// 
			this.lcItemSite.Control = this.lupSiteID;
			this.lcItemSite.Location = new System.Drawing.Point(0, 0);
			this.lcItemSite.Name = "lcItemSite";
			this.lcItemSite.Size = new System.Drawing.Size(390, 24);
			this.lcItemSite.TextSize = new System.Drawing.Size(82, 14);
			// 
			// lupSiteID
			// 
			this.lupSiteID.DisplayMember = "";
			this.lupSiteID.GroupCode = null;
			this.lupSiteID.ListMember = "ListName";
			this.lupSiteID.Location = new System.Drawing.Point(97, 11);
			this.lupSiteID.Name = "lupSiteID";
			this.lupSiteID.NullText = "[EditValue is null]";
			this.lupSiteID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Redo, "", -1, true, true, false, editorButtonImageOptions2, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), "재구성")});
			this.lupSiteID.SelectedIndex = -1;
			this.lupSiteID.Size = new System.Drawing.Size(300, 20);
			this.lupSiteID.StyleController = this.lc;
			this.lupSiteID.TabIndex = 34;
			this.lupSiteID.ValueMember = "";
			// 
			// lcItemUseYn
			// 
			this.lcItemUseYn.Control = this.lupUseYn;
			this.lcItemUseYn.Location = new System.Drawing.Point(390, 0);
			this.lcItemUseYn.Name = "lcItemUseYn";
			this.lcItemUseYn.Size = new System.Drawing.Size(390, 24);
			this.lcItemUseYn.TextSize = new System.Drawing.Size(82, 14);
			// 
			// lupUseYn
			// 
			this.lupUseYn.DisplayMember = "";
			this.lupUseYn.GroupCode = null;
			this.lupUseYn.ListMember = "ListName";
			this.lupUseYn.Location = new System.Drawing.Point(487, 11);
			this.lupUseYn.Name = "lupUseYn";
			this.lupUseYn.NullText = "[EditValue is null]";
			this.lupUseYn.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Redo, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), "재구성")});
			this.lupUseYn.SelectedIndex = -1;
			this.lupUseYn.Size = new System.Drawing.Size(300, 20);
			this.lupUseYn.StyleController = this.lc;
			this.lupUseYn.TabIndex = 35;
			this.lupUseYn.ValueMember = "";
			// 
			// lcGroupSearch
			// 
			this.lcGroupSearch.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcItemSite,
            this.lcItemFindText,
            this.lcItemUseYn});
			this.lcGroupSearch.Location = new System.Drawing.Point(0, 0);
			this.lcGroupSearch.Name = "lcGroupSearch";
			this.lcGroupSearch.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
			this.lcGroupSearch.Size = new System.Drawing.Size(794, 62);
			this.lcGroupSearch.TextVisible = false;
			// 
			// gridResult
			// 
			this.gridResult.Compress = false;
			this.gridResult.DataSource = null;
			this.gridResult.Editable = true;
			this.gridResult.FocusedRowHandle = -2147483648;
			this.gridResult.GridViewType = IKaan.Win.Core.Controls.Grid.GridViewType.GridView;
			this.gridResult.Location = new System.Drawing.Point(11, 113);
			this.gridResult.Name = "gridResult";
			this.gridResult.PageFooterCenter = null;
			this.gridResult.PageFooterLeft = null;
			this.gridResult.PageFooterRight = null;
			this.gridResult.PageHeaderCenter = null;
			this.gridResult.PageHeaderLeft = null;
			this.gridResult.PageHeaderRight = null;
			this.gridResult.Pager = null;
			this.gridResult.PrintFooter = null;
			this.gridResult.PrintHeader = null;
			this.gridResult.ReadOnly = false;
			this.gridResult.ShowFooter = false;
			this.gridResult.ShowGroupPanel = false;
			this.gridResult.Size = new System.Drawing.Size(776, 444);
			this.gridResult.TabIndex = 26;
			// 
			// lcGroupResult
			// 
			this.lcGroupResult.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
			this.lcGroupResult.Location = new System.Drawing.Point(0, 102);
			this.lcGroupResult.Name = "lcGroupResult";
			this.lcGroupResult.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
			this.lcGroupResult.Size = new System.Drawing.Size(794, 462);
			this.lcGroupResult.Text = "Result";
			this.lcGroupResult.TextVisible = false;
			// 
			// layoutControlItem1
			// 
			this.layoutControlItem1.Control = this.gridResult;
			this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
			this.layoutControlItem1.Name = "layoutControlItem1";
			this.layoutControlItem1.Size = new System.Drawing.Size(780, 448);
			this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem1.TextVisible = false;
			// 
			// emptySpaceItem1
			// 
			this.emptySpaceItem1.AllowHotTrack = false;
			this.emptySpaceItem1.Location = new System.Drawing.Point(0, 0);
			this.emptySpaceItem1.Name = "emptySpaceItem1";
			this.emptySpaceItem1.Size = new System.Drawing.Size(580, 26);
			this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
			// 
			// lcGroupButtons
			// 
			this.lcGroupButtons.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem1,
            this.lcButtonAccept,
            this.lcButtonSearch});
			this.lcGroupButtons.Location = new System.Drawing.Point(0, 62);
			this.lcGroupButtons.Name = "lcGroupButtons";
			this.lcGroupButtons.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
			this.lcGroupButtons.Size = new System.Drawing.Size(794, 40);
			this.lcGroupButtons.TextVisible = false;
			// 
			// lcButtonAccept
			// 
			this.lcButtonAccept.Control = this.btnAccept;
			this.lcButtonAccept.Location = new System.Drawing.Point(680, 0);
			this.lcButtonAccept.MaxSize = new System.Drawing.Size(100, 26);
			this.lcButtonAccept.MinSize = new System.Drawing.Size(100, 26);
			this.lcButtonAccept.Name = "lcButtonAccept";
			this.lcButtonAccept.Size = new System.Drawing.Size(100, 26);
			this.lcButtonAccept.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			this.lcButtonAccept.TextSize = new System.Drawing.Size(0, 0);
			this.lcButtonAccept.TextVisible = false;
			// 
			// btnAccept
			// 
			this.btnAccept.Location = new System.Drawing.Point(691, 73);
			this.btnAccept.Name = "btnAccept";
			this.btnAccept.Size = new System.Drawing.Size(96, 22);
			this.btnAccept.StyleController = this.lc;
			this.btnAccept.TabIndex = 36;
			this.btnAccept.Text = "적용";
			// 
			// lcButtonSearch
			// 
			this.lcButtonSearch.Control = this.btnSearch;
			this.lcButtonSearch.Location = new System.Drawing.Point(580, 0);
			this.lcButtonSearch.MaxSize = new System.Drawing.Size(100, 26);
			this.lcButtonSearch.MinSize = new System.Drawing.Size(100, 26);
			this.lcButtonSearch.Name = "lcButtonSearch";
			this.lcButtonSearch.Size = new System.Drawing.Size(100, 26);
			this.lcButtonSearch.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			this.lcButtonSearch.TextSize = new System.Drawing.Size(0, 0);
			this.lcButtonSearch.TextVisible = false;
			// 
			// btnSearch
			// 
			this.btnSearch.Location = new System.Drawing.Point(591, 73);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(96, 22);
			this.btnSearch.StyleController = this.lc;
			this.btnSearch.TabIndex = 37;
			this.btnSearch.Text = "검색";
			// 
			// BrandFromScrapForm
			// 
			this.Appearance.BackColor = System.Drawing.Color.White;
			this.Appearance.Options.UseBackColor = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(798, 568);
			this.LookAndFeel.SkinName = "Office 2016 Dark";
			this.Name = "BrandFromScrapForm";
			this.Text = "BrandFromScrapForm";
			this.VisibleStatusbar = false;
			this.VisibleToolbar = false;
			((System.ComponentModel.ISupportInitialize)(this.lc)).EndInit();
			this.lc.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemFindText)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtFindText.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemSite)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lupSiteID.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemUseYn)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lupUseYn.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupSearch)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupResult)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupButtons)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcButtonAccept)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcButtonSearch)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupSearch;
		private DevExpress.XtraEditors.TextEdit txtFindText;
		private DevExpress.XtraLayout.LayoutControlItem lcItemFindText;
		private Core.Controls.Grid.XGrid gridResult;
		private Core.Controls.Common.XLookup lupUseYn;
		private Core.Controls.Common.XLookup lupSiteID;
		private DevExpress.XtraLayout.LayoutControlItem lcItemSite;
		private DevExpress.XtraLayout.LayoutControlItem lcItemUseYn;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupResult;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupButtons;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
		private DevExpress.XtraEditors.SimpleButton btnSearch;
		private DevExpress.XtraEditors.SimpleButton btnAccept;
		private DevExpress.XtraLayout.LayoutControlItem lcButtonAccept;
		private DevExpress.XtraLayout.LayoutControlItem lcButtonSearch;
	}
}