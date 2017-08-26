namespace IKaan.Win.View.Biz.Catalog
{
	partial class TGoodsChannelEditForm
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
			this.lcTabInfo = new DevExpress.XtraLayout.TabbedControlGroup();
			this.lcGroupGoodsInfo = new DevExpress.XtraLayout.LayoutControlGroup();
			this.splitterItem2 = new DevExpress.XtraLayout.SplitterItem();
			this.wbPage = new System.Windows.Forms.WebBrowser();
			this.lcTab = new DevExpress.XtraLayout.TabbedControlGroup();
			this.lcGroupWebBrowser = new DevExpress.XtraLayout.LayoutControlGroup();
			this.lcItemWebBrowser = new DevExpress.XtraLayout.LayoutControlItem();
			this.lupChannelAdmin = new IKaan.Win.Core.Controls.Common.XLookup();
			this.lcItemChannelAdmin = new DevExpress.XtraLayout.LayoutControlItem();
			this.picGoodsImage = new DevExpress.XtraEditors.PictureEdit();
			this.lcItemGoodsImage = new DevExpress.XtraLayout.LayoutControlItem();
			this.btnGetInfo = new DevExpress.XtraEditors.SimpleButton();
			this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
			this.simpleSeparator1 = new DevExpress.XtraLayout.SimpleSeparator();
			this.memInfoText = new DevExpress.XtraEditors.MemoEdit();
			this.lcItemInfoText = new DevExpress.XtraLayout.LayoutControlItem();
			this.lcGroupWebBrowserUrl = new DevExpress.XtraLayout.LayoutControlGroup();
			this.txtURL = new DevExpress.XtraEditors.TextEdit();
			this.lcItemURL = new DevExpress.XtraLayout.LayoutControlItem();
			this.txtLoginId = new DevExpress.XtraEditors.TextEdit();
			this.lcItemLoginId = new DevExpress.XtraLayout.LayoutControlItem();
			this.txtLoginPw = new DevExpress.XtraEditors.TextEdit();
			this.lcItemLoginPw = new DevExpress.XtraLayout.LayoutControlItem();
			((System.ComponentModel.ISupportInitialize)(this.lc)).BeginInit();
			this.lc.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupFind)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupSearch)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemFindText)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtFindText.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcTabInfo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupGoodsInfo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitterItem2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcTab)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupWebBrowser)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemWebBrowser)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lupChannelAdmin.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemChannelAdmin)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picGoodsImage.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemGoodsImage)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.simpleSeparator1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.memInfoText.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemInfoText)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupWebBrowserUrl)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtURL.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemURL)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtLoginId.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemLoginId)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtLoginPw.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemLoginPw)).BeginInit();
			this.SuspendLayout();
			// 
			// lc
			// 
			this.lc.Controls.Add(this.txtLoginPw);
			this.lc.Controls.Add(this.txtLoginId);
			this.lc.Controls.Add(this.txtURL);
			this.lc.Controls.Add(this.memInfoText);
			this.lc.Controls.Add(this.btnGetInfo);
			this.lc.Controls.Add(this.picGoodsImage);
			this.lc.Controls.Add(this.lupChannelAdmin);
			this.lc.Controls.Add(this.wbPage);
			this.lc.Controls.Add(this.txtFindText);
			this.lc.Location = new System.Drawing.Point(0, 44);
			this.lc.Margin = new System.Windows.Forms.Padding(0);
			this.lc.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(2850, 354, 457, 350);
			this.lc.Padding = new System.Windows.Forms.Padding(2);
			this.lc.Size = new System.Drawing.Size(990, 499);
			// 
			// lcGroupBase
			// 
			this.lcGroupBase.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcGroupFind,
            this.lcTabInfo,
            this.splitterItem2});
			this.lcGroupBase.Name = "Root";
			this.lcGroupBase.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
			this.lcGroupBase.Size = new System.Drawing.Size(990, 499);
			// 
			// lcGroupFind
			// 
			this.lcGroupFind.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcGroupSearch,
            this.lcTab});
			this.lcGroupFind.Location = new System.Drawing.Point(0, 0);
			this.lcGroupFind.Name = "lcGroupFind";
			this.lcGroupFind.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
			this.lcGroupFind.Size = new System.Drawing.Size(705, 495);
			this.lcGroupFind.Text = "검색";
			this.lcGroupFind.TextVisible = false;
			// 
			// lcGroupSearch
			// 
			this.lcGroupSearch.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcItemFindText,
            this.lcItemChannelAdmin});
			this.lcGroupSearch.Location = new System.Drawing.Point(0, 0);
			this.lcGroupSearch.Name = "lcGroupSearch";
			this.lcGroupSearch.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
			this.lcGroupSearch.Size = new System.Drawing.Size(691, 57);
			// 
			// lcItemFindText
			// 
			this.lcItemFindText.Control = this.txtFindText;
			this.lcItemFindText.Location = new System.Drawing.Point(338, 0);
			this.lcItemFindText.Name = "lcItemFindText";
			this.lcItemFindText.Size = new System.Drawing.Size(339, 24);
			this.lcItemFindText.TextSize = new System.Drawing.Size(111, 14);
			// 
			// txtFindText
			// 
			this.txtFindText.Location = new System.Drawing.Point(471, 37);
			this.txtFindText.Name = "txtFindText";
			this.txtFindText.Size = new System.Drawing.Size(220, 20);
			this.txtFindText.StyleController = this.lc;
			this.txtFindText.TabIndex = 4;
			// 
			// lcTabInfo
			// 
			this.lcTabInfo.Location = new System.Drawing.Point(717, 0);
			this.lcTabInfo.Name = "lcTabInfo";
			this.lcTabInfo.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
			this.lcTabInfo.SelectedTabPage = this.lcGroupGoodsInfo;
			this.lcTabInfo.SelectedTabPageIndex = 0;
			this.lcTabInfo.Size = new System.Drawing.Size(269, 495);
			this.lcTabInfo.TabPages.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcGroupGoodsInfo});
			// 
			// lcGroupGoodsInfo
			// 
			this.lcGroupGoodsInfo.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcItemGoodsImage,
            this.layoutControlItem1,
            this.simpleSeparator1,
            this.lcItemInfoText});
			this.lcGroupGoodsInfo.Location = new System.Drawing.Point(0, 0);
			this.lcGroupGoodsInfo.Name = "lcGroupGoodsInfo";
			this.lcGroupGoodsInfo.Size = new System.Drawing.Size(255, 457);
			this.lcGroupGoodsInfo.Text = "상품정보";
			// 
			// splitterItem2
			// 
			this.splitterItem2.AllowHotTrack = true;
			this.splitterItem2.Location = new System.Drawing.Point(705, 0);
			this.splitterItem2.Name = "splitterItem2";
			this.splitterItem2.Size = new System.Drawing.Size(12, 495);
			// 
			// wbPage
			// 
			this.wbPage.Location = new System.Drawing.Point(16, 155);
			this.wbPage.MinimumSize = new System.Drawing.Size(20, 20);
			this.wbPage.Name = "wbPage";
			this.wbPage.Size = new System.Drawing.Size(677, 328);
			this.wbPage.TabIndex = 5;
			// 
			// lcTab
			// 
			this.lcTab.Location = new System.Drawing.Point(0, 57);
			this.lcTab.Name = "lcTab";
			this.lcTab.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
			this.lcTab.SelectedTabPage = this.lcGroupWebBrowser;
			this.lcTab.SelectedTabPageIndex = 0;
			this.lcTab.Size = new System.Drawing.Size(691, 424);
			this.lcTab.TabPages.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcGroupWebBrowser});
			// 
			// lcGroupWebBrowser
			// 
			this.lcGroupWebBrowser.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcItemWebBrowser,
            this.lcGroupWebBrowserUrl});
			this.lcGroupWebBrowser.Location = new System.Drawing.Point(0, 0);
			this.lcGroupWebBrowser.Name = "lcGroupWebBrowser";
			this.lcGroupWebBrowser.Size = new System.Drawing.Size(681, 390);
			this.lcGroupWebBrowser.Text = "웹브라우저";
			// 
			// lcItemWebBrowser
			// 
			this.lcItemWebBrowser.Control = this.wbPage;
			this.lcItemWebBrowser.Location = new System.Drawing.Point(0, 58);
			this.lcItemWebBrowser.Name = "lcItemWebBrowser";
			this.lcItemWebBrowser.Size = new System.Drawing.Size(681, 332);
			this.lcItemWebBrowser.TextSize = new System.Drawing.Size(0, 0);
			this.lcItemWebBrowser.TextVisible = false;
			// 
			// lupChannelAdmin
			// 
			this.lupChannelAdmin.DisplayMember = "";
			this.lupChannelAdmin.GroupCode = null;
			this.lupChannelAdmin.ListMember = "ListName";
			this.lupChannelAdmin.Location = new System.Drawing.Point(133, 37);
			this.lupChannelAdmin.Name = "lupChannelAdmin";
			this.lupChannelAdmin.NullText = "[EditValue is null]";
			this.lupChannelAdmin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Redo)});
			this.lupChannelAdmin.SelectedIndex = -1;
			this.lupChannelAdmin.Size = new System.Drawing.Size(219, 20);
			this.lupChannelAdmin.StyleController = this.lc;
			this.lupChannelAdmin.TabIndex = 6;
			this.lupChannelAdmin.ValueMember = "";
			// 
			// lcItemChannelAdmin
			// 
			this.lcItemChannelAdmin.Control = this.lupChannelAdmin;
			this.lcItemChannelAdmin.Location = new System.Drawing.Point(0, 0);
			this.lcItemChannelAdmin.Name = "lcItemChannelAdmin";
			this.lcItemChannelAdmin.Size = new System.Drawing.Size(338, 24);
			this.lcItemChannelAdmin.TextSize = new System.Drawing.Size(111, 14);
			// 
			// picGoodsImage
			// 
			this.picGoodsImage.Cursor = System.Windows.Forms.Cursors.Default;
			this.picGoodsImage.Location = new System.Drawing.Point(728, 62);
			this.picGoodsImage.Name = "picGoodsImage";
			this.picGoodsImage.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
			this.picGoodsImage.Properties.ZoomAccelerationFactor = 1D;
			this.picGoodsImage.Size = new System.Drawing.Size(251, 224);
			this.picGoodsImage.StyleController = this.lc;
			this.picGoodsImage.TabIndex = 7;
			// 
			// lcItemGoodsImage
			// 
			this.lcItemGoodsImage.Control = this.picGoodsImage;
			this.lcItemGoodsImage.Location = new System.Drawing.Point(0, 27);
			this.lcItemGoodsImage.MaxSize = new System.Drawing.Size(0, 228);
			this.lcItemGoodsImage.MinSize = new System.Drawing.Size(24, 228);
			this.lcItemGoodsImage.Name = "lcItemGoodsImage";
			this.lcItemGoodsImage.Size = new System.Drawing.Size(255, 228);
			this.lcItemGoodsImage.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			this.lcItemGoodsImage.TextSize = new System.Drawing.Size(0, 0);
			this.lcItemGoodsImage.TextVisible = false;
			// 
			// btnGetInfo
			// 
			this.btnGetInfo.Location = new System.Drawing.Point(728, 35);
			this.btnGetInfo.Name = "btnGetInfo";
			this.btnGetInfo.Size = new System.Drawing.Size(251, 22);
			this.btnGetInfo.StyleController = this.lc;
			this.btnGetInfo.TabIndex = 8;
			this.btnGetInfo.Text = "상품정보 가져오기";
			// 
			// layoutControlItem1
			// 
			this.layoutControlItem1.Control = this.btnGetInfo;
			this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
			this.layoutControlItem1.Name = "layoutControlItem1";
			this.layoutControlItem1.Size = new System.Drawing.Size(255, 26);
			this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem1.TextVisible = false;
			// 
			// simpleSeparator1
			// 
			this.simpleSeparator1.AllowHotTrack = false;
			this.simpleSeparator1.Location = new System.Drawing.Point(0, 26);
			this.simpleSeparator1.Name = "simpleSeparator1";
			this.simpleSeparator1.Size = new System.Drawing.Size(255, 1);
			// 
			// memInfoText
			// 
			this.memInfoText.Location = new System.Drawing.Point(728, 290);
			this.memInfoText.Name = "memInfoText";
			this.memInfoText.Size = new System.Drawing.Size(251, 198);
			this.memInfoText.StyleController = this.lc;
			this.memInfoText.TabIndex = 9;
			// 
			// lcItemInfoText
			// 
			this.lcItemInfoText.Control = this.memInfoText;
			this.lcItemInfoText.Location = new System.Drawing.Point(0, 255);
			this.lcItemInfoText.Name = "lcItemInfoText";
			this.lcItemInfoText.Size = new System.Drawing.Size(255, 202);
			this.lcItemInfoText.TextSize = new System.Drawing.Size(0, 0);
			this.lcItemInfoText.TextVisible = false;
			// 
			// lcGroupWebBrowserUrl
			// 
			this.lcGroupWebBrowserUrl.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcItemURL,
            this.lcItemLoginId,
            this.lcItemLoginPw});
			this.lcGroupWebBrowserUrl.Location = new System.Drawing.Point(0, 0);
			this.lcGroupWebBrowserUrl.Name = "lcGroupWebBrowserUrl";
			this.lcGroupWebBrowserUrl.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
			this.lcGroupWebBrowserUrl.Size = new System.Drawing.Size(681, 58);
			this.lcGroupWebBrowserUrl.TextVisible = false;
			// 
			// txtURL
			// 
			this.txtURL.Location = new System.Drawing.Point(136, 102);
			this.txtURL.Name = "txtURL";
			this.txtURL.Size = new System.Drawing.Size(552, 20);
			this.txtURL.StyleController = this.lc;
			this.txtURL.TabIndex = 10;
			// 
			// lcItemURL
			// 
			this.lcItemURL.Control = this.txtURL;
			this.lcItemURL.Location = new System.Drawing.Point(0, 0);
			this.lcItemURL.Name = "lcItemURL";
			this.lcItemURL.Size = new System.Drawing.Size(671, 24);
			this.lcItemURL.TextSize = new System.Drawing.Size(111, 14);
			// 
			// txtLoginId
			// 
			this.txtLoginId.Location = new System.Drawing.Point(136, 126);
			this.txtLoginId.Name = "txtLoginId";
			this.txtLoginId.Size = new System.Drawing.Size(216, 20);
			this.txtLoginId.StyleController = this.lc;
			this.txtLoginId.TabIndex = 11;
			// 
			// lcItemLoginId
			// 
			this.lcItemLoginId.Control = this.txtLoginId;
			this.lcItemLoginId.Location = new System.Drawing.Point(0, 24);
			this.lcItemLoginId.Name = "lcItemLoginId";
			this.lcItemLoginId.Size = new System.Drawing.Size(335, 24);
			this.lcItemLoginId.TextSize = new System.Drawing.Size(111, 14);
			// 
			// txtLoginPw
			// 
			this.txtLoginPw.Location = new System.Drawing.Point(471, 126);
			this.txtLoginPw.Name = "txtLoginPw";
			this.txtLoginPw.Size = new System.Drawing.Size(217, 20);
			this.txtLoginPw.StyleController = this.lc;
			this.txtLoginPw.TabIndex = 12;
			// 
			// lcItemLoginPw
			// 
			this.lcItemLoginPw.Control = this.txtLoginPw;
			this.lcItemLoginPw.Location = new System.Drawing.Point(335, 24);
			this.lcItemLoginPw.Name = "lcItemLoginPw";
			this.lcItemLoginPw.Size = new System.Drawing.Size(336, 24);
			this.lcItemLoginPw.TextSize = new System.Drawing.Size(111, 14);
			// 
			// TGoodsChannelEditForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(990, 565);
			this.Name = "TGoodsChannelEditForm";
			this.Text = "GroupModelForm";
			((System.ComponentModel.ISupportInitialize)(this.lc)).EndInit();
			this.lc.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupFind)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupSearch)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemFindText)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtFindText.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcTabInfo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupGoodsInfo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.splitterItem2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcTab)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupWebBrowser)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemWebBrowser)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lupChannelAdmin.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemChannelAdmin)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picGoodsImage.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemGoodsImage)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.simpleSeparator1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.memInfoText.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemInfoText)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupWebBrowserUrl)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtURL.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemURL)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtLoginId.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemLoginId)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtLoginPw.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemLoginPw)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupFind;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupSearch;
		private DevExpress.XtraEditors.TextEdit txtFindText;
		private DevExpress.XtraLayout.LayoutControlItem lcItemFindText;
		private DevExpress.XtraLayout.TabbedControlGroup lcTabInfo;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupGoodsInfo;
		private DevExpress.XtraLayout.SplitterItem splitterItem2;
		private System.Windows.Forms.WebBrowser wbPage;
		private DevExpress.XtraLayout.TabbedControlGroup lcTab;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupWebBrowser;
		private DevExpress.XtraLayout.LayoutControlItem lcItemWebBrowser;
		private Core.Controls.Common.XLookup lupChannelAdmin;
		private DevExpress.XtraLayout.LayoutControlItem lcItemChannelAdmin;
		private DevExpress.XtraEditors.PictureEdit picGoodsImage;
		private DevExpress.XtraLayout.LayoutControlItem lcItemGoodsImage;
		private DevExpress.XtraEditors.SimpleButton btnGetInfo;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
		private DevExpress.XtraLayout.SimpleSeparator simpleSeparator1;
		private DevExpress.XtraEditors.MemoEdit memInfoText;
		private DevExpress.XtraLayout.LayoutControlItem lcItemInfoText;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupWebBrowserUrl;
		private DevExpress.XtraEditors.TextEdit txtURL;
		private DevExpress.XtraLayout.LayoutControlItem lcItemURL;
		private DevExpress.XtraEditors.TextEdit txtLoginPw;
		private DevExpress.XtraEditors.TextEdit txtLoginId;
		private DevExpress.XtraLayout.LayoutControlItem lcItemLoginId;
		private DevExpress.XtraLayout.LayoutControlItem lcItemLoginPw;
	}
}