namespace IKaan.Biz.View.Sys.AA
{
	partial class AAHelpForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AAHelpForm));
			this.lcGroupFind = new DevExpress.XtraLayout.LayoutControlGroup();
			this.lcGroupSearch = new DevExpress.XtraLayout.LayoutControlGroup();
			this.lcItemFindText = new DevExpress.XtraLayout.LayoutControlItem();
			this.txtFindText = new DevExpress.XtraEditors.TextEdit();
			this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
			this.gridList = new IKaan.Biz.Core.Controls.Grid.XGrid();
			this.lcGroupEdit1 = new DevExpress.XtraLayout.LayoutControlGroup();
			this.lcItemID = new DevExpress.XtraLayout.LayoutControlItem();
			this.txtID = new DevExpress.XtraEditors.TextEdit();
			this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.lcItemHelpType = new DevExpress.XtraLayout.LayoutControlItem();
			this.lupHelpType = new IKaan.Biz.Core.Controls.Common.XLookup();
			this.lcItemHelpName = new DevExpress.XtraLayout.LayoutControlItem();
			this.txtHelpName = new DevExpress.XtraEditors.TextEdit();
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
			this.richEditor = new IKaan.Biz.Core.Controls.Common.XRichEditor();
			this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
			this.simpleSeparator1 = new DevExpress.XtraLayout.SimpleSeparator();
			((System.ComponentModel.ISupportInitialize)(this.lc)).BeginInit();
			this.lc.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupFind)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupSearch)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemFindText)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtFindText.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupEdit1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemID)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemHelpType)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lupHelpType.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemHelpName)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtHelpName.Properties)).BeginInit();
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
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.simpleSeparator1)).BeginInit();
			this.SuspendLayout();
			// 
			// lc
			// 
			this.lc.Controls.Add(this.richEditor);
			this.lc.Controls.Add(this.txtHelpName);
			this.lc.Controls.Add(this.lupHelpType);
			this.lc.Controls.Add(this.txtUpdateByName);
			this.lc.Controls.Add(this.txtUpdateDate);
			this.lc.Controls.Add(this.txtCreateByName);
			this.lc.Controls.Add(this.txtCreateDate);
			this.lc.Controls.Add(this.gridList);
			this.lc.Controls.Add(this.txtID);
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
			this.lcGroupFind.Size = new System.Drawing.Size(369, 495);
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
			this.lcGroupSearch.Size = new System.Drawing.Size(355, 57);
			// 
			// lcItemFindText
			// 
			this.lcItemFindText.Control = this.txtFindText;
			this.lcItemFindText.Location = new System.Drawing.Point(0, 0);
			this.lcItemFindText.Name = "lcItemFindText";
			this.lcItemFindText.Size = new System.Drawing.Size(341, 24);
			this.lcItemFindText.TextSize = new System.Drawing.Size(118, 14);
			// 
			// txtFindText
			// 
			this.txtFindText.Location = new System.Drawing.Point(140, 37);
			this.txtFindText.Name = "txtFindText";
			this.txtFindText.Size = new System.Drawing.Size(215, 20);
			this.txtFindText.StyleController = this.lc;
			this.txtFindText.TabIndex = 4;
			// 
			// layoutControlItem3
			// 
			this.layoutControlItem3.Control = this.gridList;
			this.layoutControlItem3.Location = new System.Drawing.Point(0, 57);
			this.layoutControlItem3.Name = "layoutControlItem3";
			this.layoutControlItem3.Size = new System.Drawing.Size(355, 424);
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
			this.gridList.Size = new System.Drawing.Size(351, 420);
			this.gridList.TabIndex = 7;
			// 
			// lcGroupEdit1
			// 
			this.lcGroupEdit1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcItemID,
            this.emptySpaceItem1,
            this.lcItemHelpType,
            this.lcItemHelpName,
            this.layoutControlItem1,
            this.simpleSeparator1});
			this.lcGroupEdit1.Location = new System.Drawing.Point(0, 0);
			this.lcGroupEdit1.Name = "lcGroupEdit1";
			this.lcGroupEdit1.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
			this.lcGroupEdit1.Size = new System.Drawing.Size(605, 433);
			this.lcGroupEdit1.TextVisible = false;
			// 
			// lcItemID
			// 
			this.lcItemID.AppearanceItemCaption.Font = new System.Drawing.Font("맑은 고딕", 10F);
			this.lcItemID.AppearanceItemCaption.Options.UseFont = true;
			this.lcItemID.Control = this.txtID;
			this.lcItemID.Location = new System.Drawing.Point(0, 0);
			this.lcItemID.Name = "lcItemID";
			this.lcItemID.Size = new System.Drawing.Size(314, 24);
			this.lcItemID.TextSize = new System.Drawing.Size(118, 17);
			// 
			// txtID
			// 
			this.txtID.Location = new System.Drawing.Point(514, 11);
			this.txtID.Name = "txtID";
			this.txtID.Size = new System.Drawing.Size(188, 20);
			this.txtID.StyleController = this.lc;
			this.txtID.TabIndex = 5;
			// 
			// emptySpaceItem1
			// 
			this.emptySpaceItem1.AllowHotTrack = false;
			this.emptySpaceItem1.Location = new System.Drawing.Point(314, 0);
			this.emptySpaceItem1.Name = "emptySpaceItem1";
			this.emptySpaceItem1.Size = new System.Drawing.Size(277, 24);
			this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
			// 
			// lcItemHelpType
			// 
			this.lcItemHelpType.Control = this.lupHelpType;
			this.lcItemHelpType.Location = new System.Drawing.Point(0, 48);
			this.lcItemHelpType.Name = "lcItemHelpType";
			this.lcItemHelpType.Size = new System.Drawing.Size(591, 24);
			this.lcItemHelpType.TextSize = new System.Drawing.Size(118, 14);
			// 
			// lupHelpType
			// 
			this.lupHelpType.DisplayMember = "";
			this.lupHelpType.GroupCode = null;
			this.lupHelpType.ListMember = "ListName";
			this.lupHelpType.Location = new System.Drawing.Point(514, 59);
			this.lupHelpType.Name = "lupHelpType";
			this.lupHelpType.NullText = "[EditValue is null]";
			this.lupHelpType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Redo)});
			this.lupHelpType.SelectedIndex = -1;
			this.lupHelpType.Size = new System.Drawing.Size(465, 20);
			this.lupHelpType.StyleController = this.lc;
			this.lupHelpType.TabIndex = 22;
			this.lupHelpType.ValueMember = "";
			// 
			// lcItemHelpName
			// 
			this.lcItemHelpName.Control = this.txtHelpName;
			this.lcItemHelpName.Location = new System.Drawing.Point(0, 24);
			this.lcItemHelpName.Name = "lcItemHelpName";
			this.lcItemHelpName.Size = new System.Drawing.Size(591, 24);
			this.lcItemHelpName.TextSize = new System.Drawing.Size(118, 14);
			// 
			// txtHelpName
			// 
			this.txtHelpName.Location = new System.Drawing.Point(514, 35);
			this.txtHelpName.Name = "txtHelpName";
			this.txtHelpName.Size = new System.Drawing.Size(465, 20);
			this.txtHelpName.StyleController = this.lc;
			this.txtHelpName.TabIndex = 23;
			// 
			// splitterItem1
			// 
			this.splitterItem1.AllowHotTrack = true;
			this.splitterItem1.Location = new System.Drawing.Point(369, 0);
			this.splitterItem1.Name = "splitterItem1";
			this.splitterItem1.Size = new System.Drawing.Size(12, 495);
			// 
			// lcGroupRegInfo
			// 
			this.lcGroupRegInfo.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcItemCreateDate,
            this.lcItemCreateByName,
            this.lcItemUpdateDate,
            this.lcItemUpdateByName});
			this.lcGroupRegInfo.Location = new System.Drawing.Point(0, 433);
			this.lcGroupRegInfo.Name = "lcGroupRegInfo";
			this.lcGroupRegInfo.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
			this.lcGroupRegInfo.Size = new System.Drawing.Size(605, 62);
			this.lcGroupRegInfo.TextVisible = false;
			// 
			// lcItemCreateDate
			// 
			this.lcItemCreateDate.Control = this.txtCreateDate;
			this.lcItemCreateDate.Location = new System.Drawing.Point(0, 0);
			this.lcItemCreateDate.Name = "lcItemCreateDate";
			this.lcItemCreateDate.Size = new System.Drawing.Size(296, 24);
			this.lcItemCreateDate.TextSize = new System.Drawing.Size(118, 14);
			// 
			// txtCreateDate
			// 
			this.txtCreateDate.Location = new System.Drawing.Point(514, 444);
			this.txtCreateDate.Name = "txtCreateDate";
			this.txtCreateDate.Size = new System.Drawing.Size(170, 20);
			this.txtCreateDate.StyleController = this.lc;
			this.txtCreateDate.TabIndex = 10;
			// 
			// lcItemCreateByName
			// 
			this.lcItemCreateByName.Control = this.txtCreateByName;
			this.lcItemCreateByName.Location = new System.Drawing.Point(0, 24);
			this.lcItemCreateByName.Name = "lcItemCreateByName";
			this.lcItemCreateByName.Size = new System.Drawing.Size(296, 24);
			this.lcItemCreateByName.TextSize = new System.Drawing.Size(118, 14);
			// 
			// txtCreateByName
			// 
			this.txtCreateByName.Location = new System.Drawing.Point(514, 468);
			this.txtCreateByName.Name = "txtCreateByName";
			this.txtCreateByName.Size = new System.Drawing.Size(170, 20);
			this.txtCreateByName.StyleController = this.lc;
			this.txtCreateByName.TabIndex = 11;
			// 
			// lcItemUpdateDate
			// 
			this.lcItemUpdateDate.Control = this.txtUpdateDate;
			this.lcItemUpdateDate.Location = new System.Drawing.Point(296, 0);
			this.lcItemUpdateDate.Name = "lcItemUpdateDate";
			this.lcItemUpdateDate.Size = new System.Drawing.Size(295, 24);
			this.lcItemUpdateDate.TextSize = new System.Drawing.Size(118, 14);
			// 
			// txtUpdateDate
			// 
			this.txtUpdateDate.Location = new System.Drawing.Point(810, 444);
			this.txtUpdateDate.Name = "txtUpdateDate";
			this.txtUpdateDate.Size = new System.Drawing.Size(169, 20);
			this.txtUpdateDate.StyleController = this.lc;
			this.txtUpdateDate.TabIndex = 12;
			// 
			// lcItemUpdateByName
			// 
			this.lcItemUpdateByName.Control = this.txtUpdateByName;
			this.lcItemUpdateByName.Location = new System.Drawing.Point(296, 24);
			this.lcItemUpdateByName.Name = "lcItemUpdateByName";
			this.lcItemUpdateByName.Size = new System.Drawing.Size(295, 24);
			this.lcItemUpdateByName.TextSize = new System.Drawing.Size(118, 14);
			// 
			// txtUpdateByName
			// 
			this.txtUpdateByName.Location = new System.Drawing.Point(810, 468);
			this.txtUpdateByName.Name = "txtUpdateByName";
			this.txtUpdateByName.Size = new System.Drawing.Size(169, 20);
			this.txtUpdateByName.StyleController = this.lc;
			this.txtUpdateByName.TabIndex = 13;
			// 
			// lcGroupEditBase
			// 
			this.lcGroupEditBase.GroupBordersVisible = false;
			this.lcGroupEditBase.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcGroupEdit1,
            this.lcGroupRegInfo});
			this.lcGroupEditBase.Location = new System.Drawing.Point(381, 0);
			this.lcGroupEditBase.Name = "lcGroupEditBase";
			this.lcGroupEditBase.Size = new System.Drawing.Size(605, 495);
			this.lcGroupEditBase.TextVisible = false;
			// 
			// richEditor
			// 
			this.richEditor.EditValue = resources.GetString("richEditor.EditValue");
			this.richEditor.Location = new System.Drawing.Point(392, 84);
			this.richEditor.LookAndFeel.SkinName = "Office 2013 Dark Gray";
			this.richEditor.Name = "richEditor";
			this.richEditor.ReadOnly = false;
			this.richEditor.Size = new System.Drawing.Size(587, 342);
			this.richEditor.TabIndex = 24;
			this.richEditor.ToolbarVisible = true;
			// 
			// layoutControlItem1
			// 
			this.layoutControlItem1.Control = this.richEditor;
			this.layoutControlItem1.Location = new System.Drawing.Point(0, 73);
			this.layoutControlItem1.Name = "layoutControlItem1";
			this.layoutControlItem1.Size = new System.Drawing.Size(591, 346);
			this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem1.TextVisible = false;
			// 
			// simpleSeparator1
			// 
			this.simpleSeparator1.AllowHotTrack = false;
			this.simpleSeparator1.Location = new System.Drawing.Point(0, 72);
			this.simpleSeparator1.Name = "simpleSeparator1";
			this.simpleSeparator1.Size = new System.Drawing.Size(591, 1);
			// 
			// AAHelpForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(990, 565);
			this.Name = "AAHelpForm";
			this.Text = "AAHelpForm";
			((System.ComponentModel.ISupportInitialize)(this.lc)).EndInit();
			this.lc.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupFind)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupSearch)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemFindText)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtFindText.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupEdit1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemID)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemHelpType)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lupHelpType.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemHelpName)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtHelpName.Properties)).EndInit();
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
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.simpleSeparator1)).EndInit();
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
		private DevExpress.XtraEditors.TextEdit txtID;
		private DevExpress.XtraLayout.LayoutControlItem lcItemID;
		private IKaan.Biz.Core.Controls.Grid.XGrid gridList;
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
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupEditBase;
		private Core.Controls.Common.XLookup lupHelpType;
		private DevExpress.XtraLayout.LayoutControlItem lcItemHelpType;
		private DevExpress.XtraEditors.TextEdit txtHelpName;
		private DevExpress.XtraLayout.LayoutControlItem lcItemHelpName;
		private Core.Controls.Common.XRichEditor richEditor;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
		private DevExpress.XtraLayout.SimpleSeparator simpleSeparator1;
	}
}