namespace IKaan.Win.View.Base.Common
{
	partial class DictionaryEditForm
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
			this.lcItemLanguageCode = new DevExpress.XtraLayout.LayoutControlItem();
			this.lupLanguageCode = new IKaan.Win.Core.Controls.Common.XLookup();
			this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
			this.gridList = new IKaan.Win.Core.Controls.Grid.XGrid();
			this.lcGroupEdit1 = new DevExpress.XtraLayout.LayoutControlGroup();
			this.lcItemID = new DevExpress.XtraLayout.LayoutControlItem();
			this.txtID = new DevExpress.XtraEditors.TextEdit();
			this.lcItemLogicalName = new DevExpress.XtraLayout.LayoutControlItem();
			this.txtLogicalName = new DevExpress.XtraEditors.TextEdit();
			this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.lcItemDescription = new DevExpress.XtraLayout.LayoutControlItem();
			this.memDescription = new DevExpress.XtraEditors.MemoEdit();
			this.lcItemPhysicalName = new DevExpress.XtraLayout.LayoutControlItem();
			this.txtPhysicalName = new DevExpress.XtraEditors.TextEdit();
			this.splitterItem1 = new DevExpress.XtraLayout.SplitterItem();
			this.lcGroupRegInfo = new DevExpress.XtraLayout.LayoutControlGroup();
			this.lcItemCreateDate = new DevExpress.XtraLayout.LayoutControlItem();
			this.txtCreateDate = new DevExpress.XtraEditors.TextEdit();
			this.lcItemCreateByName = new DevExpress.XtraLayout.LayoutControlItem();
			this.txtCreateByName = new DevExpress.XtraEditors.TextEdit();
			this.lcItemUpdateDate = new DevExpress.XtraLayout.LayoutControlItem();
			this.txtUpdateDate = new DevExpress.XtraEditors.TextEdit();
			this.lcItemUpdateByName = new DevExpress.XtraLayout.LayoutControlItem();
			this.txtUpdateByName = new DevExpress.XtraEditors.TextEdit();
			this.lcGroupEditBase = new DevExpress.XtraLayout.LayoutControlGroup();
			this.gridLangList = new IKaan.Win.Core.Controls.Grid.XGrid();
			this.lcTab = new DevExpress.XtraLayout.TabbedControlGroup();
			this.lcGroupEdit2 = new DevExpress.XtraLayout.LayoutControlGroup();
			this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
			((System.ComponentModel.ISupportInitialize)(this.lc)).BeginInit();
			this.lc.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupFind)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupSearch)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemFindText)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtFindText.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemLanguageCode)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lupLanguageCode.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupEdit1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemID)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemLogicalName)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtLogicalName.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemDescription)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.memDescription.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemPhysicalName)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtPhysicalName.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupRegInfo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemCreateDate)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtCreateDate.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemCreateByName)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtCreateByName.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemUpdateDate)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtUpdateDate.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemUpdateByName)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtUpdateByName.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupEditBase)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcTab)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupEdit2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
			this.SuspendLayout();
			// 
			// lc
			// 
			this.lc.Controls.Add(this.gridLangList);
			this.lc.Controls.Add(this.lupLanguageCode);
			this.lc.Controls.Add(this.txtPhysicalName);
			this.lc.Controls.Add(this.memDescription);
			this.lc.Controls.Add(this.txtUpdateByName);
			this.lc.Controls.Add(this.txtUpdateDate);
			this.lc.Controls.Add(this.txtCreateByName);
			this.lc.Controls.Add(this.txtCreateDate);
			this.lc.Controls.Add(this.gridList);
			this.lc.Controls.Add(this.txtLogicalName);
			this.lc.Controls.Add(this.txtID);
			this.lc.Controls.Add(this.txtFindText);
			this.lc.Location = new System.Drawing.Point(0, 47);
			this.lc.Margin = new System.Windows.Forms.Padding(0);
			this.lc.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(930, 313, 250, 350);
			this.lc.Padding = new System.Windows.Forms.Padding(2);
			this.lc.Size = new System.Drawing.Size(990, 493);
			// 
			// lcGroupBase
			// 
			this.lcGroupBase.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcGroupFind,
            this.splitterItem1,
            this.lcGroupEditBase});
			this.lcGroupBase.Name = "Root";
			this.lcGroupBase.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
			this.lcGroupBase.Size = new System.Drawing.Size(990, 493);
			// 
			// lcGroupFind
			// 
			this.lcGroupFind.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcGroupSearch,
            this.layoutControlItem3});
			this.lcGroupFind.Location = new System.Drawing.Point(0, 0);
			this.lcGroupFind.Name = "lcGroupFind";
			this.lcGroupFind.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
			this.lcGroupFind.Size = new System.Drawing.Size(411, 489);
			this.lcGroupFind.Text = "검색";
			this.lcGroupFind.TextVisible = false;
			// 
			// lcGroupSearch
			// 
			this.lcGroupSearch.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcItemFindText,
            this.lcItemLanguageCode});
			this.lcGroupSearch.Location = new System.Drawing.Point(0, 0);
			this.lcGroupSearch.Name = "lcGroupSearch";
			this.lcGroupSearch.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
			this.lcGroupSearch.Size = new System.Drawing.Size(397, 81);
			// 
			// lcItemFindText
			// 
			this.lcItemFindText.Control = this.txtFindText;
			this.lcItemFindText.Location = new System.Drawing.Point(0, 24);
			this.lcItemFindText.Name = "lcItemFindText";
			this.lcItemFindText.Size = new System.Drawing.Size(383, 24);
			this.lcItemFindText.TextSize = new System.Drawing.Size(118, 14);
			// 
			// txtFindText
			// 
			this.txtFindText.Location = new System.Drawing.Point(140, 61);
			this.txtFindText.Name = "txtFindText";
			this.txtFindText.Size = new System.Drawing.Size(257, 20);
			this.txtFindText.StyleController = this.lc;
			this.txtFindText.TabIndex = 4;
			// 
			// lcItemLanguageCode
			// 
			this.lcItemLanguageCode.Control = this.lupLanguageCode;
			this.lcItemLanguageCode.Location = new System.Drawing.Point(0, 0);
			this.lcItemLanguageCode.Name = "lcItemLanguageCode";
			this.lcItemLanguageCode.Size = new System.Drawing.Size(383, 24);
			this.lcItemLanguageCode.TextSize = new System.Drawing.Size(118, 14);
			// 
			// lupLanguageCode
			// 
			this.lupLanguageCode.DisplayMember = "";
			this.lupLanguageCode.GroupCode = null;
			this.lupLanguageCode.ListMember = "ListName";
			this.lupLanguageCode.Location = new System.Drawing.Point(140, 37);
			this.lupLanguageCode.Name = "lupLanguageCode";
			this.lupLanguageCode.NullText = "[EditValue is null]";
			this.lupLanguageCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Redo)});
			this.lupLanguageCode.SelectedIndex = -1;
			this.lupLanguageCode.Size = new System.Drawing.Size(257, 20);
			this.lupLanguageCode.StyleController = this.lc;
			this.lupLanguageCode.TabIndex = 19;
			this.lupLanguageCode.ValueMember = "";
			// 
			// layoutControlItem3
			// 
			this.layoutControlItem3.Control = this.gridList;
			this.layoutControlItem3.Location = new System.Drawing.Point(0, 81);
			this.layoutControlItem3.Name = "layoutControlItem3";
			this.layoutControlItem3.Size = new System.Drawing.Size(397, 394);
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
			this.gridList.Location = new System.Drawing.Point(11, 92);
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
			this.gridList.Size = new System.Drawing.Size(393, 390);
			this.gridList.TabIndex = 7;
			// 
			// lcGroupEdit1
			// 
			this.lcGroupEdit1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcItemID,
            this.lcItemLogicalName,
            this.emptySpaceItem1,
            this.lcItemDescription,
            this.lcItemPhysicalName});
			this.lcGroupEdit1.Location = new System.Drawing.Point(0, 0);
			this.lcGroupEdit1.Name = "lcGroupEdit1";
			this.lcGroupEdit1.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
			this.lcGroupEdit1.Size = new System.Drawing.Size(570, 186);
			this.lcGroupEdit1.TextVisible = false;
			// 
			// lcItemID
			// 
			this.lcItemID.AppearanceItemCaption.Font = new System.Drawing.Font("맑은 고딕", 10F);
			this.lcItemID.AppearanceItemCaption.Options.UseFont = true;
			this.lcItemID.Control = this.txtID;
			this.lcItemID.Location = new System.Drawing.Point(0, 0);
			this.lcItemID.Name = "lcItemID";
			this.lcItemID.Size = new System.Drawing.Size(278, 24);
			this.lcItemID.TextSize = new System.Drawing.Size(118, 17);
			// 
			// txtID
			// 
			this.txtID.Location = new System.Drawing.Point(549, 11);
			this.txtID.Name = "txtID";
			this.txtID.Size = new System.Drawing.Size(152, 20);
			this.txtID.StyleController = this.lc;
			this.txtID.TabIndex = 5;
			// 
			// lcItemLogicalName
			// 
			this.lcItemLogicalName.Control = this.txtLogicalName;
			this.lcItemLogicalName.Location = new System.Drawing.Point(0, 48);
			this.lcItemLogicalName.Name = "lcItemLogicalName";
			this.lcItemLogicalName.Size = new System.Drawing.Size(556, 24);
			this.lcItemLogicalName.TextSize = new System.Drawing.Size(118, 14);
			// 
			// txtLogicalName
			// 
			this.txtLogicalName.Location = new System.Drawing.Point(549, 59);
			this.txtLogicalName.Name = "txtLogicalName";
			this.txtLogicalName.Size = new System.Drawing.Size(430, 20);
			this.txtLogicalName.StyleController = this.lc;
			this.txtLogicalName.TabIndex = 6;
			// 
			// emptySpaceItem1
			// 
			this.emptySpaceItem1.AllowHotTrack = false;
			this.emptySpaceItem1.Location = new System.Drawing.Point(278, 0);
			this.emptySpaceItem1.Name = "emptySpaceItem1";
			this.emptySpaceItem1.Size = new System.Drawing.Size(278, 24);
			this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
			// 
			// lcItemDescription
			// 
			this.lcItemDescription.Control = this.memDescription;
			this.lcItemDescription.Location = new System.Drawing.Point(0, 72);
			this.lcItemDescription.MaxSize = new System.Drawing.Size(0, 100);
			this.lcItemDescription.MinSize = new System.Drawing.Size(129, 100);
			this.lcItemDescription.Name = "lcItemDescription";
			this.lcItemDescription.Size = new System.Drawing.Size(556, 100);
			this.lcItemDescription.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			this.lcItemDescription.TextSize = new System.Drawing.Size(118, 14);
			// 
			// memDescription
			// 
			this.memDescription.Location = new System.Drawing.Point(549, 83);
			this.memDescription.Name = "memDescription";
			this.memDescription.Size = new System.Drawing.Size(430, 96);
			this.memDescription.StyleController = this.lc;
			this.memDescription.TabIndex = 14;
			// 
			// lcItemPhysicalName
			// 
			this.lcItemPhysicalName.Control = this.txtPhysicalName;
			this.lcItemPhysicalName.Location = new System.Drawing.Point(0, 24);
			this.lcItemPhysicalName.Name = "lcItemPhysicalName";
			this.lcItemPhysicalName.Size = new System.Drawing.Size(556, 24);
			this.lcItemPhysicalName.TextSize = new System.Drawing.Size(118, 14);
			// 
			// txtPhysicalName
			// 
			this.txtPhysicalName.Location = new System.Drawing.Point(549, 35);
			this.txtPhysicalName.Name = "txtPhysicalName";
			this.txtPhysicalName.Size = new System.Drawing.Size(430, 20);
			this.txtPhysicalName.StyleController = this.lc;
			this.txtPhysicalName.TabIndex = 17;
			// 
			// splitterItem1
			// 
			this.splitterItem1.AllowHotTrack = true;
			this.splitterItem1.Location = new System.Drawing.Point(411, 0);
			this.splitterItem1.Name = "splitterItem1";
			this.splitterItem1.Size = new System.Drawing.Size(5, 489);
			// 
			// lcGroupRegInfo
			// 
			this.lcGroupRegInfo.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcItemCreateDate,
            this.lcItemCreateByName,
            this.lcItemUpdateDate,
            this.lcItemUpdateByName});
			this.lcGroupRegInfo.Location = new System.Drawing.Point(0, 186);
			this.lcGroupRegInfo.Name = "lcGroupRegInfo";
			this.lcGroupRegInfo.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
			this.lcGroupRegInfo.Size = new System.Drawing.Size(570, 62);
			this.lcGroupRegInfo.TextVisible = false;
			// 
			// lcItemCreateDate
			// 
			this.lcItemCreateDate.Control = this.txtCreateDate;
			this.lcItemCreateDate.Location = new System.Drawing.Point(0, 0);
			this.lcItemCreateDate.Name = "lcItemCreateDate";
			this.lcItemCreateDate.Size = new System.Drawing.Size(276, 24);
			this.lcItemCreateDate.TextSize = new System.Drawing.Size(118, 14);
			// 
			// txtCreateDate
			// 
			this.txtCreateDate.Location = new System.Drawing.Point(549, 197);
			this.txtCreateDate.Name = "txtCreateDate";
			this.txtCreateDate.Size = new System.Drawing.Size(150, 20);
			this.txtCreateDate.StyleController = this.lc;
			this.txtCreateDate.TabIndex = 10;
			// 
			// lcItemCreateByName
			// 
			this.lcItemCreateByName.Control = this.txtCreateByName;
			this.lcItemCreateByName.Location = new System.Drawing.Point(0, 24);
			this.lcItemCreateByName.Name = "lcItemCreateByName";
			this.lcItemCreateByName.Size = new System.Drawing.Size(276, 24);
			this.lcItemCreateByName.TextSize = new System.Drawing.Size(118, 14);
			// 
			// txtCreateByName
			// 
			this.txtCreateByName.Location = new System.Drawing.Point(549, 221);
			this.txtCreateByName.Name = "txtCreateByName";
			this.txtCreateByName.Size = new System.Drawing.Size(150, 20);
			this.txtCreateByName.StyleController = this.lc;
			this.txtCreateByName.TabIndex = 11;
			// 
			// lcItemUpdateDate
			// 
			this.lcItemUpdateDate.Control = this.txtUpdateDate;
			this.lcItemUpdateDate.Location = new System.Drawing.Point(276, 0);
			this.lcItemUpdateDate.Name = "lcItemUpdateDate";
			this.lcItemUpdateDate.Size = new System.Drawing.Size(280, 24);
			this.lcItemUpdateDate.TextSize = new System.Drawing.Size(118, 14);
			// 
			// txtUpdateDate
			// 
			this.txtUpdateDate.Location = new System.Drawing.Point(825, 197);
			this.txtUpdateDate.Name = "txtUpdateDate";
			this.txtUpdateDate.Size = new System.Drawing.Size(154, 20);
			this.txtUpdateDate.StyleController = this.lc;
			this.txtUpdateDate.TabIndex = 12;
			// 
			// lcItemUpdateByName
			// 
			this.lcItemUpdateByName.Control = this.txtUpdateByName;
			this.lcItemUpdateByName.Location = new System.Drawing.Point(276, 24);
			this.lcItemUpdateByName.Name = "lcItemUpdateByName";
			this.lcItemUpdateByName.Size = new System.Drawing.Size(280, 24);
			this.lcItemUpdateByName.TextSize = new System.Drawing.Size(118, 14);
			// 
			// txtUpdateByName
			// 
			this.txtUpdateByName.Location = new System.Drawing.Point(825, 221);
			this.txtUpdateByName.Name = "txtUpdateByName";
			this.txtUpdateByName.Size = new System.Drawing.Size(154, 20);
			this.txtUpdateByName.StyleController = this.lc;
			this.txtUpdateByName.TabIndex = 13;
			// 
			// lcGroupEditBase
			// 
			this.lcGroupEditBase.GroupBordersVisible = false;
			this.lcGroupEditBase.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcGroupEdit1,
            this.lcGroupRegInfo,
            this.lcTab});
			this.lcGroupEditBase.Location = new System.Drawing.Point(416, 0);
			this.lcGroupEditBase.Name = "lcGroupEditBase";
			this.lcGroupEditBase.Size = new System.Drawing.Size(570, 489);
			this.lcGroupEditBase.TextVisible = false;
			// 
			// gridLangList
			// 
			this.gridLangList.Compress = false;
			this.gridLangList.DataSource = null;
			this.gridLangList.Editable = true;
			this.gridLangList.FocusedRowHandle = -2147483648;
			this.gridLangList.GridViewType = IKaan.Win.Core.Controls.Grid.GridViewType.GridView;
			this.gridLangList.Location = new System.Drawing.Point(425, 280);
			this.gridLangList.Name = "gridLangList";
			this.gridLangList.PageFooterCenter = null;
			this.gridLangList.PageFooterLeft = null;
			this.gridLangList.PageFooterRight = null;
			this.gridLangList.PageHeaderCenter = null;
			this.gridLangList.PageHeaderLeft = null;
			this.gridLangList.PageHeaderRight = null;
			this.gridLangList.Pager = null;
			this.gridLangList.PrintFooter = null;
			this.gridLangList.PrintHeader = null;
			this.gridLangList.ReadOnly = false;
			this.gridLangList.ShowFooter = false;
			this.gridLangList.ShowGroupPanel = false;
			this.gridLangList.Size = new System.Drawing.Size(556, 204);
			this.gridLangList.TabIndex = 20;
			// 
			// lcTab
			// 
			this.lcTab.Location = new System.Drawing.Point(0, 248);
			this.lcTab.Name = "lcTab";
			this.lcTab.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
			this.lcTab.SelectedTabPage = this.lcGroupEdit2;
			this.lcTab.SelectedTabPageIndex = 0;
			this.lcTab.Size = new System.Drawing.Size(570, 241);
			this.lcTab.TabPages.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcGroupEdit2});
			// 
			// lcGroupEdit2
			// 
			this.lcGroupEdit2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
			this.lcGroupEdit2.Location = new System.Drawing.Point(0, 0);
			this.lcGroupEdit2.Name = "lcGroupEdit2";
			this.lcGroupEdit2.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
			this.lcGroupEdit2.Size = new System.Drawing.Size(560, 208);
			this.lcGroupEdit2.Text = "언어별 설정";
			// 
			// layoutControlItem1
			// 
			this.layoutControlItem1.Control = this.gridLangList;
			this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
			this.layoutControlItem1.Name = "layoutControlItem1";
			this.layoutControlItem1.Size = new System.Drawing.Size(560, 208);
			this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem1.TextVisible = false;
			// 
			// DictionaryEditForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(990, 565);
			this.Name = "DictionaryEditForm";
			this.Text = "DictionaryEditForm";
			((System.ComponentModel.ISupportInitialize)(this.lc)).EndInit();
			this.lc.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupFind)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupSearch)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemFindText)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtFindText.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemLanguageCode)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lupLanguageCode.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupEdit1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemID)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemLogicalName)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtLogicalName.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemDescription)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.memDescription.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemPhysicalName)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtPhysicalName.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupRegInfo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemCreateDate)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtCreateDate.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemCreateByName)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtCreateByName.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemUpdateDate)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtUpdateDate.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemUpdateByName)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtUpdateByName.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupEditBase)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcTab)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupEdit2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
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
		private DevExpress.XtraEditors.TextEdit txtLogicalName;
		private DevExpress.XtraEditors.TextEdit txtID;
		private DevExpress.XtraLayout.LayoutControlItem lcItemID;
		private DevExpress.XtraLayout.LayoutControlItem lcItemLogicalName;
		private IKaan.Win.Core.Controls.Grid.XGrid gridList;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupRegInfo;
		private DevExpress.XtraEditors.TextEdit txtUpdateByName;
		private DevExpress.XtraEditors.TextEdit txtUpdateDate;
		private DevExpress.XtraEditors.TextEdit txtCreateByName;
		private DevExpress.XtraEditors.TextEdit txtCreateDate;
		private DevExpress.XtraLayout.LayoutControlItem lcItemCreateDate;
		private DevExpress.XtraLayout.LayoutControlItem lcItemCreateByName;
		private DevExpress.XtraLayout.LayoutControlItem lcItemUpdateDate;
		private DevExpress.XtraLayout.LayoutControlItem lcItemUpdateByName;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
		private DevExpress.XtraEditors.MemoEdit memDescription;
		private DevExpress.XtraLayout.LayoutControlItem lcItemDescription;
		private DevExpress.XtraEditors.TextEdit txtPhysicalName;
		private DevExpress.XtraLayout.LayoutControlItem lcItemPhysicalName;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupEditBase;
		private Core.Controls.Common.XLookup lupLanguageCode;
		private DevExpress.XtraLayout.LayoutControlItem lcItemLanguageCode;
		private Core.Controls.Grid.XGrid gridLangList;
		private DevExpress.XtraLayout.TabbedControlGroup lcTab;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupEdit2;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
	}
}