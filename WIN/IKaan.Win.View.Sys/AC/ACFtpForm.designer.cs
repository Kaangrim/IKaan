namespace IKaan.Win.View.Sys.AC
{
	partial class ACFtpForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ACFtpForm));
			this.lcGroupSearchBase = new DevExpress.XtraLayout.LayoutControlGroup();
			this.lcGroupSearch = new DevExpress.XtraLayout.LayoutControlGroup();
			this.lcItemFindText = new DevExpress.XtraLayout.LayoutControlItem();
			this.txtFindText = new DevExpress.XtraEditors.TextEdit();
			this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
			this.treeDirectories = new IKaan.Win.Core.Controls.Common.XTree();
			this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
			this.pbarDir = new DevExpress.XtraEditors.ProgressBarControl();
			this.lcGroupEdit1 = new DevExpress.XtraLayout.LayoutControlGroup();
			this.lcGroupButtons = new DevExpress.XtraLayout.LayoutControlGroup();
			this.esPath = new DevExpress.XtraLayout.EmptySpaceItem();
			this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
			this.btnUpload = new DevExpress.XtraEditors.SimpleButton();
			this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
			this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
			this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
			this.pBarFiles = new DevExpress.XtraEditors.ProgressBarControl();
			this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
			this.treeFiles = new IKaan.Win.Core.Controls.Common.XTree();
			this.lcGroupEditBase = new DevExpress.XtraLayout.LayoutControlGroup();
			this.lcGroupInfo = new DevExpress.XtraLayout.LayoutControlGroup();
			this.lcItemImage = new DevExpress.XtraLayout.LayoutControlItem();
			this.picImage = new DevExpress.XtraEditors.PictureEdit();
			this.lcItemFileInfo = new DevExpress.XtraLayout.LayoutControlItem();
			this.memFileInfo = new DevExpress.XtraEditors.MemoEdit();
			this.splitterItem2 = new DevExpress.XtraLayout.SplitterItem();
			this.splitterItem1 = new DevExpress.XtraLayout.SplitterItem();
			((System.ComponentModel.ISupportInitialize)(this.lc)).BeginInit();
			this.lc.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupSearchBase)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupSearch)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemFindText)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtFindText.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.treeDirectories)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbarDir.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupEdit1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupButtons)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.esPath)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pBarFiles.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.treeFiles)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupEditBase)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupInfo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemImage)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picImage.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemFileInfo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.memFileInfo.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitterItem2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).BeginInit();
			this.SuspendLayout();
			// 
			// lc
			// 
			this.lc.Controls.Add(this.treeFiles);
			this.lc.Controls.Add(this.memFileInfo);
			this.lc.Controls.Add(this.picImage);
			this.lc.Controls.Add(this.pBarFiles);
			this.lc.Controls.Add(this.pbarDir);
			this.lc.Controls.Add(this.treeDirectories);
			this.lc.Controls.Add(this.btnDelete);
			this.lc.Controls.Add(this.btnUpload);
			this.lc.Controls.Add(this.txtFindText);
			this.lc.Location = new System.Drawing.Point(0, 44);
			this.lc.Margin = new System.Windows.Forms.Padding(0);
			this.lc.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(2242, 427, 591, 350);
			this.lc.OptionsView.UseDefaultDragAndDropRendering = false;
			this.lc.Padding = new System.Windows.Forms.Padding(2);
			this.lc.Size = new System.Drawing.Size(998, 602);
			// 
			// lcGroupBase
			// 
			this.lcGroupBase.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcGroupSearchBase,
            this.lcGroupEditBase,
            this.splitterItem1});
			this.lcGroupBase.Name = "Root";
			this.lcGroupBase.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
			this.lcGroupBase.Size = new System.Drawing.Size(998, 602);
			// 
			// lcGroupSearchBase
			// 
			this.lcGroupSearchBase.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcGroupSearch,
            this.layoutControlItem3,
            this.layoutControlItem7});
			this.lcGroupSearchBase.Location = new System.Drawing.Point(0, 0);
			this.lcGroupSearchBase.Name = "lcGroupSearchBase";
			this.lcGroupSearchBase.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
			this.lcGroupSearchBase.Size = new System.Drawing.Size(256, 598);
			this.lcGroupSearchBase.Text = "검색";
			this.lcGroupSearchBase.TextVisible = false;
			// 
			// lcGroupSearch
			// 
			this.lcGroupSearch.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcItemFindText});
			this.lcGroupSearch.Location = new System.Drawing.Point(0, 0);
			this.lcGroupSearch.Name = "lcGroupSearch";
			this.lcGroupSearch.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
			this.lcGroupSearch.Size = new System.Drawing.Size(242, 57);
			// 
			// lcItemFindText
			// 
			this.lcItemFindText.Control = this.txtFindText;
			this.lcItemFindText.Location = new System.Drawing.Point(0, 0);
			this.lcItemFindText.Name = "lcItemFindText";
			this.lcItemFindText.Size = new System.Drawing.Size(228, 24);
			this.lcItemFindText.TextSize = new System.Drawing.Size(82, 14);
			// 
			// txtFindText
			// 
			this.txtFindText.Location = new System.Drawing.Point(104, 37);
			this.txtFindText.Name = "txtFindText";
			this.txtFindText.Size = new System.Drawing.Size(138, 20);
			this.txtFindText.StyleController = this.lc;
			this.txtFindText.TabIndex = 4;
			// 
			// layoutControlItem3
			// 
			this.layoutControlItem3.Control = this.treeDirectories;
			this.layoutControlItem3.Location = new System.Drawing.Point(0, 57);
			this.layoutControlItem3.Name = "layoutControlItem3";
			this.layoutControlItem3.Size = new System.Drawing.Size(242, 505);
			this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem3.TextVisible = false;
			// 
			// treeDirectories
			// 
			this.treeDirectories.Location = new System.Drawing.Point(11, 68);
			this.treeDirectories.Name = "treeDirectories";
			this.treeDirectories.OptionsBehavior.AllowExpandOnDblClick = false;
			this.treeDirectories.OptionsBehavior.AutoNodeHeight = false;
			this.treeDirectories.OptionsBehavior.PopulateServiceColumns = true;
			this.treeDirectories.OptionsView.AutoWidth = false;
			this.treeDirectories.OptionsView.EnableAppearanceEvenRow = true;
			this.treeDirectories.OptionsView.EnableAppearanceOddRow = true;
			this.treeDirectories.RowHeight = 20;
			this.treeDirectories.Size = new System.Drawing.Size(238, 501);
			this.treeDirectories.TabIndex = 13;
			// 
			// layoutControlItem7
			// 
			this.layoutControlItem7.Control = this.pbarDir;
			this.layoutControlItem7.Location = new System.Drawing.Point(0, 562);
			this.layoutControlItem7.Name = "layoutControlItem7";
			this.layoutControlItem7.Size = new System.Drawing.Size(242, 22);
			this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem7.TextVisible = false;
			// 
			// pbarDir
			// 
			this.pbarDir.Location = new System.Drawing.Point(11, 573);
			this.pbarDir.Name = "pbarDir";
			this.pbarDir.Properties.ShowTitle = true;
			this.pbarDir.Properties.Step = 5;
			this.pbarDir.ShowProgressInTaskBar = true;
			this.pbarDir.Size = new System.Drawing.Size(238, 18);
			this.pbarDir.StyleController = this.lc;
			this.pbarDir.TabIndex = 14;
			// 
			// lcGroupEdit1
			// 
			this.lcGroupEdit1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcGroupButtons,
            this.layoutControlItem8,
            this.layoutControlItem1});
			this.lcGroupEdit1.Location = new System.Drawing.Point(0, 0);
			this.lcGroupEdit1.Name = "lcGroupEdit1";
			this.lcGroupEdit1.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
			this.lcGroupEdit1.Size = new System.Drawing.Size(426, 598);
			this.lcGroupEdit1.TextVisible = false;
			// 
			// lcGroupButtons
			// 
			this.lcGroupButtons.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.esPath,
            this.layoutControlItem2,
            this.layoutControlItem4});
			this.lcGroupButtons.Location = new System.Drawing.Point(0, 0);
			this.lcGroupButtons.Name = "lcGroupButtons";
			this.lcGroupButtons.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
			this.lcGroupButtons.Size = new System.Drawing.Size(412, 57);
			this.lcGroupButtons.TextVisible = false;
			// 
			// esPath
			// 
			this.esPath.AllowHotTrack = false;
			this.esPath.Location = new System.Drawing.Point(0, 26);
			this.esPath.MaxSize = new System.Drawing.Size(0, 21);
			this.esPath.MinSize = new System.Drawing.Size(10, 21);
			this.esPath.Name = "esPath";
			this.esPath.Size = new System.Drawing.Size(402, 21);
			this.esPath.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			this.esPath.Text = " ";
			this.esPath.TextSize = new System.Drawing.Size(82, 0);
			this.esPath.TextVisible = true;
			// 
			// layoutControlItem2
			// 
			this.layoutControlItem2.Control = this.btnUpload;
			this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
			this.layoutControlItem2.Name = "layoutControlItem2";
			this.layoutControlItem2.Size = new System.Drawing.Size(206, 26);
			this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem2.TextVisible = false;
			// 
			// btnUpload
			// 
			this.btnUpload.Location = new System.Drawing.Point(284, 16);
			this.btnUpload.Name = "btnUpload";
			this.btnUpload.Size = new System.Drawing.Size(202, 22);
			this.btnUpload.StyleController = this.lc;
			this.btnUpload.TabIndex = 9;
			this.btnUpload.Text = "업로드";
			// 
			// layoutControlItem4
			// 
			this.layoutControlItem4.Control = this.btnDelete;
			this.layoutControlItem4.Location = new System.Drawing.Point(206, 0);
			this.layoutControlItem4.Name = "layoutControlItem4";
			this.layoutControlItem4.Size = new System.Drawing.Size(196, 26);
			this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem4.TextVisible = false;
			// 
			// btnDelete
			// 
			this.btnDelete.Location = new System.Drawing.Point(490, 16);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(192, 22);
			this.btnDelete.StyleController = this.lc;
			this.btnDelete.TabIndex = 10;
			this.btnDelete.Text = "삭제";
			// 
			// layoutControlItem8
			// 
			this.layoutControlItem8.Control = this.pBarFiles;
			this.layoutControlItem8.Location = new System.Drawing.Point(0, 562);
			this.layoutControlItem8.Name = "layoutControlItem8";
			this.layoutControlItem8.Size = new System.Drawing.Size(412, 22);
			this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem8.TextVisible = false;
			// 
			// pBarFiles
			// 
			this.pBarFiles.Location = new System.Drawing.Point(279, 573);
			this.pBarFiles.Name = "pBarFiles";
			this.pBarFiles.Properties.ShowTitle = true;
			this.pBarFiles.Properties.Step = 5;
			this.pBarFiles.ShowProgressInTaskBar = true;
			this.pBarFiles.Size = new System.Drawing.Size(408, 18);
			this.pBarFiles.StyleController = this.lc;
			this.pBarFiles.TabIndex = 15;
			// 
			// layoutControlItem1
			// 
			this.layoutControlItem1.Control = this.treeFiles;
			this.layoutControlItem1.Location = new System.Drawing.Point(0, 57);
			this.layoutControlItem1.Name = "layoutControlItem1";
			this.layoutControlItem1.Size = new System.Drawing.Size(412, 505);
			this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem1.TextVisible = false;
			// 
			// treeFiles
			// 
			this.treeFiles.Location = new System.Drawing.Point(279, 68);
			this.treeFiles.Name = "treeFiles";
			this.treeFiles.OptionsBehavior.AllowExpandOnDblClick = false;
			this.treeFiles.OptionsBehavior.AutoNodeHeight = false;
			this.treeFiles.OptionsBehavior.PopulateServiceColumns = true;
			this.treeFiles.OptionsView.AutoWidth = false;
			this.treeFiles.OptionsView.EnableAppearanceEvenRow = true;
			this.treeFiles.OptionsView.EnableAppearanceOddRow = true;
			this.treeFiles.RowHeight = 20;
			this.treeFiles.Size = new System.Drawing.Size(408, 501);
			this.treeFiles.TabIndex = 18;
			// 
			// lcGroupEditBase
			// 
			this.lcGroupEditBase.GroupBordersVisible = false;
			this.lcGroupEditBase.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcGroupEdit1,
            this.lcGroupInfo,
            this.splitterItem2});
			this.lcGroupEditBase.Location = new System.Drawing.Point(268, 0);
			this.lcGroupEditBase.Name = "lcGroupEditBase";
			this.lcGroupEditBase.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
			this.lcGroupEditBase.Size = new System.Drawing.Size(726, 598);
			this.lcGroupEditBase.TextVisible = false;
			// 
			// lcGroupInfo
			// 
			this.lcGroupInfo.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcItemImage,
            this.lcItemFileInfo});
			this.lcGroupInfo.Location = new System.Drawing.Point(438, 0);
			this.lcGroupInfo.Name = "lcGroupInfo";
			this.lcGroupInfo.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
			this.lcGroupInfo.Size = new System.Drawing.Size(288, 598);
			this.lcGroupInfo.TextVisible = false;
			// 
			// lcItemImage
			// 
			this.lcItemImage.Control = this.picImage;
			this.lcItemImage.Location = new System.Drawing.Point(0, 0);
			this.lcItemImage.Name = "lcItemImage";
			this.lcItemImage.Size = new System.Drawing.Size(274, 526);
			this.lcItemImage.TextSize = new System.Drawing.Size(0, 0);
			this.lcItemImage.TextVisible = false;
			// 
			// picImage
			// 
			this.picImage.Cursor = System.Windows.Forms.Cursors.Default;
			this.picImage.Location = new System.Drawing.Point(717, 11);
			this.picImage.Name = "picImage";
			this.picImage.Properties.PictureAlignment = System.Drawing.ContentAlignment.TopCenter;
			this.picImage.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
			this.picImage.Properties.ShowScrollBars = true;
			this.picImage.Properties.ZoomAccelerationFactor = 1D;
			this.picImage.Size = new System.Drawing.Size(270, 522);
			this.picImage.StyleController = this.lc;
			this.picImage.TabIndex = 16;
			// 
			// lcItemFileInfo
			// 
			this.lcItemFileInfo.Control = this.memFileInfo;
			this.lcItemFileInfo.Location = new System.Drawing.Point(0, 526);
			this.lcItemFileInfo.Name = "lcItemFileInfo";
			this.lcItemFileInfo.Size = new System.Drawing.Size(274, 58);
			this.lcItemFileInfo.TextSize = new System.Drawing.Size(0, 0);
			this.lcItemFileInfo.TextVisible = false;
			// 
			// memFileInfo
			// 
			this.memFileInfo.Location = new System.Drawing.Point(717, 537);
			this.memFileInfo.Name = "memFileInfo";
			this.memFileInfo.Size = new System.Drawing.Size(270, 54);
			this.memFileInfo.StyleController = this.lc;
			this.memFileInfo.TabIndex = 17;
			// 
			// splitterItem2
			// 
			this.splitterItem2.AllowHotTrack = true;
			this.splitterItem2.Location = new System.Drawing.Point(426, 0);
			this.splitterItem2.Name = "splitterItem2";
			this.splitterItem2.Size = new System.Drawing.Size(12, 598);
			// 
			// splitterItem1
			// 
			this.splitterItem1.AllowHotTrack = true;
			this.splitterItem1.Location = new System.Drawing.Point(256, 0);
			this.splitterItem1.Name = "splitterItem1";
			this.splitterItem1.Size = new System.Drawing.Size(12, 598);
			// 
			// ACFtpForm
			// 
			this.Appearance.BackColor = System.Drawing.Color.White;
			this.Appearance.Options.UseBackColor = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(998, 668);
			this.LookAndFeel.SkinName = "Office 2016 Dark";
			this.Name = "ACFtpForm";
			this.Text = "ACFtpForm";
			((System.ComponentModel.ISupportInitialize)(this.lc)).EndInit();
			this.lc.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupSearchBase)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupSearch)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemFindText)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtFindText.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.treeDirectories)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbarDir.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupEdit1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupButtons)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.esPath)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pBarFiles.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.treeFiles)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupEditBase)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupInfo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemImage)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picImage.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemFileInfo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.memFileInfo.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.splitterItem2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupSearchBase;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupEdit1;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupSearch;
		private DevExpress.XtraEditors.TextEdit txtFindText;
		private DevExpress.XtraLayout.LayoutControlItem lcItemFindText;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupEditBase;
		private DevExpress.XtraLayout.SplitterItem splitterItem1;
		private DevExpress.XtraLayout.EmptySpaceItem esPath;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupButtons;
		private DevExpress.XtraEditors.SimpleButton btnDelete;
		private DevExpress.XtraEditors.SimpleButton btnUpload;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
		private Core.Controls.Common.XTree treeDirectories;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
		private DevExpress.XtraEditors.ProgressBarControl pbarDir;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
		private DevExpress.XtraEditors.ProgressBarControl pBarFiles;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupInfo;
		private DevExpress.XtraEditors.PictureEdit picImage;
		private DevExpress.XtraLayout.LayoutControlItem lcItemImage;
		private DevExpress.XtraEditors.MemoEdit memFileInfo;
		private DevExpress.XtraLayout.LayoutControlItem lcItemFileInfo;
		private Core.Controls.Common.XTree treeFiles;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
		private DevExpress.XtraLayout.SplitterItem splitterItem2;
	}
}