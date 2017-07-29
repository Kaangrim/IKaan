namespace Ikaan.Biz.View.Forms
{
	partial class DownloadCodeForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DownloadCodeForm));
			this.lcGroupEdit1 = new DevExpress.XtraLayout.LayoutControlGroup();
			this.lcItemDictionary = new DevExpress.XtraLayout.LayoutControlItem();
			this.prgDictionary = new DevExpress.XtraEditors.ProgressBarControl();
			this.lcItemMessage = new DevExpress.XtraLayout.LayoutControlItem();
			this.prgMessage = new DevExpress.XtraEditors.ProgressBarControl();
			this.lcItemCodes = new DevExpress.XtraLayout.LayoutControlItem();
			this.prgCodes = new DevExpress.XtraEditors.ProgressBarControl();
			this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.lcButtonDownload = new DevExpress.XtraLayout.LayoutControlItem();
			this.btnDownload = new DevExpress.XtraEditors.SimpleButton();
			this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.emptySpaceItem5 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.lcItemImage = new DevExpress.XtraLayout.LayoutControlItem();
			this.pnlImage = new System.Windows.Forms.Panel();
			this.picImage = new DevExpress.XtraEditors.PictureEdit();
			((System.ComponentModel.ISupportInitialize)(this.lc)).BeginInit();
			this.lc.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupEdit1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemDictionary)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.prgDictionary.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemMessage)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.prgMessage.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemCodes)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.prgCodes.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcButtonDownload)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemImage)).BeginInit();
			this.pnlImage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picImage.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// lc
			// 
			this.lc.Controls.Add(this.pnlImage);
			this.lc.Controls.Add(this.btnDownload);
			this.lc.Controls.Add(this.prgCodes);
			this.lc.Controls.Add(this.prgMessage);
			this.lc.Controls.Add(this.prgDictionary);
			this.lc.Margin = new System.Windows.Forms.Padding(0);
			this.lc.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(2916, 98, 450, 400);
			this.lc.OptionsView.UseDefaultDragAndDropRendering = false;
			this.lc.Padding = new System.Windows.Forms.Padding(2);
			this.lc.Size = new System.Drawing.Size(598, 226);
			// 
			// lcGroupBase
			// 
			this.lcGroupBase.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcGroupEdit1});
			this.lcGroupBase.Name = "Root";
			this.lcGroupBase.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
			this.lcGroupBase.Size = new System.Drawing.Size(598, 226);
			this.lcGroupBase.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
			// 
			// lcGroupEdit1
			// 
			this.lcGroupEdit1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcItemDictionary,
            this.lcItemMessage,
            this.lcItemCodes,
            this.emptySpaceItem1,
            this.emptySpaceItem2,
            this.emptySpaceItem3,
            this.lcButtonDownload,
            this.emptySpaceItem4,
            this.emptySpaceItem5,
            this.lcItemImage});
			this.lcGroupEdit1.Location = new System.Drawing.Point(0, 0);
			this.lcGroupEdit1.Name = "lcGroupEdit1";
			this.lcGroupEdit1.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
			this.lcGroupEdit1.Size = new System.Drawing.Size(586, 214);
			this.lcGroupEdit1.TextVisible = false;
			// 
			// lcItemDictionary
			// 
			this.lcItemDictionary.Control = this.prgDictionary;
			this.lcItemDictionary.Location = new System.Drawing.Point(150, 55);
			this.lcItemDictionary.Name = "lcItemDictionary";
			this.lcItemDictionary.Size = new System.Drawing.Size(422, 22);
			this.lcItemDictionary.TextSize = new System.Drawing.Size(87, 14);
			// 
			// prgDictionary
			// 
			this.prgDictionary.Location = new System.Drawing.Point(256, 70);
			this.prgDictionary.Name = "prgDictionary";
			this.prgDictionary.Size = new System.Drawing.Size(327, 18);
			this.prgDictionary.StyleController = this.lc;
			this.prgDictionary.TabIndex = 4;
			// 
			// lcItemMessage
			// 
			this.lcItemMessage.Control = this.prgMessage;
			this.lcItemMessage.Location = new System.Drawing.Point(150, 77);
			this.lcItemMessage.Name = "lcItemMessage";
			this.lcItemMessage.Size = new System.Drawing.Size(422, 22);
			this.lcItemMessage.TextSize = new System.Drawing.Size(87, 14);
			// 
			// prgMessage
			// 
			this.prgMessage.Location = new System.Drawing.Point(256, 92);
			this.prgMessage.Name = "prgMessage";
			this.prgMessage.Size = new System.Drawing.Size(327, 18);
			this.prgMessage.StyleController = this.lc;
			this.prgMessage.TabIndex = 5;
			// 
			// lcItemCodes
			// 
			this.lcItemCodes.Control = this.prgCodes;
			this.lcItemCodes.Location = new System.Drawing.Point(150, 99);
			this.lcItemCodes.Name = "lcItemCodes";
			this.lcItemCodes.Size = new System.Drawing.Size(422, 22);
			this.lcItemCodes.TextSize = new System.Drawing.Size(87, 14);
			// 
			// prgCodes
			// 
			this.prgCodes.Location = new System.Drawing.Point(256, 114);
			this.prgCodes.Name = "prgCodes";
			this.prgCodes.Size = new System.Drawing.Size(327, 18);
			this.prgCodes.StyleController = this.lc;
			this.prgCodes.TabIndex = 6;
			// 
			// emptySpaceItem1
			// 
			this.emptySpaceItem1.AllowHotTrack = false;
			this.emptySpaceItem1.Location = new System.Drawing.Point(150, 0);
			this.emptySpaceItem1.Name = "emptySpaceItem1";
			this.emptySpaceItem1.Size = new System.Drawing.Size(422, 55);
			this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
			// 
			// emptySpaceItem2
			// 
			this.emptySpaceItem2.AllowHotTrack = false;
			this.emptySpaceItem2.Location = new System.Drawing.Point(150, 121);
			this.emptySpaceItem2.Name = "emptySpaceItem2";
			this.emptySpaceItem2.Size = new System.Drawing.Size(422, 37);
			this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
			// 
			// emptySpaceItem3
			// 
			this.emptySpaceItem3.AllowHotTrack = false;
			this.emptySpaceItem3.Location = new System.Drawing.Point(150, 184);
			this.emptySpaceItem3.Name = "emptySpaceItem3";
			this.emptySpaceItem3.Size = new System.Drawing.Size(422, 16);
			this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
			// 
			// lcButtonDownload
			// 
			this.lcButtonDownload.Control = this.btnDownload;
			this.lcButtonDownload.Location = new System.Drawing.Point(311, 158);
			this.lcButtonDownload.MaxSize = new System.Drawing.Size(100, 26);
			this.lcButtonDownload.MinSize = new System.Drawing.Size(100, 26);
			this.lcButtonDownload.Name = "lcButtonDownload";
			this.lcButtonDownload.Size = new System.Drawing.Size(100, 26);
			this.lcButtonDownload.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			this.lcButtonDownload.TextSize = new System.Drawing.Size(0, 0);
			this.lcButtonDownload.TextVisible = false;
			// 
			// btnDownload
			// 
			this.btnDownload.BackgroundImage = global::Ikaan.Biz.View.Properties.Resources.back_gray;
			this.btnDownload.Location = new System.Drawing.Point(326, 173);
			this.btnDownload.Name = "btnDownload";
			this.btnDownload.Size = new System.Drawing.Size(96, 22);
			this.btnDownload.StyleController = this.lc;
			this.btnDownload.TabIndex = 7;
			this.btnDownload.Text = "다운로드";
			// 
			// emptySpaceItem4
			// 
			this.emptySpaceItem4.AllowHotTrack = false;
			this.emptySpaceItem4.Location = new System.Drawing.Point(150, 158);
			this.emptySpaceItem4.Name = "emptySpaceItem4";
			this.emptySpaceItem4.Size = new System.Drawing.Size(161, 26);
			this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
			// 
			// emptySpaceItem5
			// 
			this.emptySpaceItem5.AllowHotTrack = false;
			this.emptySpaceItem5.Location = new System.Drawing.Point(411, 158);
			this.emptySpaceItem5.Name = "emptySpaceItem5";
			this.emptySpaceItem5.Size = new System.Drawing.Size(161, 26);
			this.emptySpaceItem5.TextSize = new System.Drawing.Size(0, 0);
			// 
			// lcItemImage
			// 
			this.lcItemImage.Control = this.pnlImage;
			this.lcItemImage.Location = new System.Drawing.Point(0, 0);
			this.lcItemImage.MaxSize = new System.Drawing.Size(150, 0);
			this.lcItemImage.MinSize = new System.Drawing.Size(150, 24);
			this.lcItemImage.Name = "lcItemImage";
			this.lcItemImage.Size = new System.Drawing.Size(150, 200);
			this.lcItemImage.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			this.lcItemImage.TextSize = new System.Drawing.Size(0, 0);
			this.lcItemImage.TextVisible = false;
			// 
			// pnlImage
			// 
			this.pnlImage.BackColor = System.Drawing.Color.White;
			this.pnlImage.Controls.Add(this.picImage);
			this.pnlImage.Location = new System.Drawing.Point(15, 15);
			this.pnlImage.Name = "pnlImage";
			this.pnlImage.Size = new System.Drawing.Size(146, 196);
			this.pnlImage.TabIndex = 8;
			// 
			// picImage
			// 
			this.picImage.Cursor = System.Windows.Forms.Cursors.Default;
			this.picImage.Dock = System.Windows.Forms.DockStyle.Fill;
			this.picImage.EditValue = ((object)(resources.GetObject("picImage.EditValue")));
			this.picImage.Location = new System.Drawing.Point(0, 0);
			this.picImage.Name = "picImage";
			this.picImage.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.picImage.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
			this.picImage.Properties.ZoomAccelerationFactor = 1D;
			this.picImage.Size = new System.Drawing.Size(146, 196);
			this.picImage.TabIndex = 0;
			// 
			// DownloadCodeForm
			// 
			this.Appearance.BackColor = System.Drawing.Color.White;
			this.Appearance.Options.UseBackColor = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(598, 248);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.LookAndFeel.SkinName = "Office 2016 Dark";
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DownloadCodeForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "DownloadCodeForm";
			this.TopMost = true;
			this.VisibleToolbar = false;
			((System.ComponentModel.ISupportInitialize)(this.lc)).EndInit();
			this.lc.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupEdit1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemDictionary)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.prgDictionary.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemMessage)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.prgMessage.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemCodes)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.prgCodes.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcButtonDownload)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemImage)).EndInit();
			this.pnlImage.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.picImage.Properties)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupEdit1;
		private DevExpress.XtraEditors.SimpleButton btnDownload;
		private DevExpress.XtraEditors.ProgressBarControl prgCodes;
		private DevExpress.XtraEditors.ProgressBarControl prgMessage;
		private DevExpress.XtraEditors.ProgressBarControl prgDictionary;
		private DevExpress.XtraLayout.LayoutControlItem lcItemDictionary;
		private DevExpress.XtraLayout.LayoutControlItem lcItemMessage;
		private DevExpress.XtraLayout.LayoutControlItem lcItemCodes;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
		private DevExpress.XtraLayout.LayoutControlItem lcButtonDownload;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem5;
		private System.Windows.Forms.Panel pnlImage;
		private DevExpress.XtraLayout.LayoutControlItem lcItemImage;
		private DevExpress.XtraEditors.PictureEdit picImage;
	}
}