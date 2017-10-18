namespace IKaan.Win.View.Scrap.Common
{
	partial class ScrapProductViewForm
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
			this.lcGroupEdit1 = new DevExpress.XtraLayout.LayoutControlGroup();
			this.lcItemUrl = new DevExpress.XtraLayout.LayoutControlItem();
			this.txtUrl = new DevExpress.XtraEditors.TextEdit();
			this.lcGroupEditBase = new DevExpress.XtraLayout.LayoutControlGroup();
			this.wb = new System.Windows.Forms.WebBrowser();
			this.lcItemWebPage = new DevExpress.XtraLayout.LayoutControlItem();
			((System.ComponentModel.ISupportInitialize)(this.lc)).BeginInit();
			this.lc.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupEdit1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemUrl)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtUrl.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupEditBase)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemWebPage)).BeginInit();
			this.SuspendLayout();
			// 
			// lc
			// 
			this.lc.Controls.Add(this.wb);
			this.lc.Controls.Add(this.txtUrl);
			this.lc.Location = new System.Drawing.Point(0, 44);
			this.lc.Margin = new System.Windows.Forms.Padding(0);
			this.lc.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(862, 85, 457, 350);
			this.lc.OptionsView.UseDefaultDragAndDropRendering = false;
			this.lc.Padding = new System.Windows.Forms.Padding(2);
			this.lc.Size = new System.Drawing.Size(798, 602);
			// 
			// lcGroupBase
			// 
			this.lcGroupBase.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcGroupEditBase});
			this.lcGroupBase.Name = "Root";
			this.lcGroupBase.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
			this.lcGroupBase.Size = new System.Drawing.Size(798, 602);
			// 
			// lcGroupEdit1
			// 
			this.lcGroupEdit1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcItemUrl,
            this.lcItemWebPage});
			this.lcGroupEdit1.Location = new System.Drawing.Point(0, 0);
			this.lcGroupEdit1.Name = "lcGroupEdit1";
			this.lcGroupEdit1.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
			this.lcGroupEdit1.Size = new System.Drawing.Size(794, 598);
			this.lcGroupEdit1.TextVisible = false;
			// 
			// lcItemUrl
			// 
			this.lcItemUrl.Control = this.txtUrl;
			this.lcItemUrl.Location = new System.Drawing.Point(0, 0);
			this.lcItemUrl.Name = "lcItemUrl";
			this.lcItemUrl.Size = new System.Drawing.Size(780, 24);
			this.lcItemUrl.TextSize = new System.Drawing.Size(48, 14);
			// 
			// txtUrl
			// 
			this.txtUrl.Location = new System.Drawing.Point(63, 11);
			this.txtUrl.Name = "txtUrl";
			this.txtUrl.Size = new System.Drawing.Size(724, 20);
			this.txtUrl.StyleController = this.lc;
			this.txtUrl.TabIndex = 62;
			// 
			// lcGroupEditBase
			// 
			this.lcGroupEditBase.GroupBordersVisible = false;
			this.lcGroupEditBase.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcGroupEdit1});
			this.lcGroupEditBase.Location = new System.Drawing.Point(0, 0);
			this.lcGroupEditBase.Name = "lcGroupEditBase";
			this.lcGroupEditBase.Size = new System.Drawing.Size(794, 598);
			this.lcGroupEditBase.TextVisible = false;
			// 
			// wb
			// 
			this.wb.Location = new System.Drawing.Point(11, 35);
			this.wb.MinimumSize = new System.Drawing.Size(20, 20);
			this.wb.Name = "wb";
			this.wb.Size = new System.Drawing.Size(776, 556);
			this.wb.TabIndex = 63;
			// 
			// lcItemWebPage
			// 
			this.lcItemWebPage.Control = this.wb;
			this.lcItemWebPage.Location = new System.Drawing.Point(0, 24);
			this.lcItemWebPage.Name = "lcItemWebPage";
			this.lcItemWebPage.Size = new System.Drawing.Size(780, 560);
			this.lcItemWebPage.TextSize = new System.Drawing.Size(0, 0);
			this.lcItemWebPage.TextVisible = false;
			// 
			// ScrapProductViewForm
			// 
			this.Appearance.BackColor = System.Drawing.Color.White;
			this.Appearance.Options.UseBackColor = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(798, 668);
			this.LookAndFeel.SkinName = "Office 2016 Dark";
			this.Name = "ScrapProductViewForm";
			this.Text = "ScrapProductViewForm";
			((System.ComponentModel.ISupportInitialize)(this.lc)).EndInit();
			this.lc.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupEdit1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemUrl)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtUrl.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupEditBase)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemWebPage)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupEdit1;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupEditBase;
		private DevExpress.XtraEditors.TextEdit txtUrl;
		private DevExpress.XtraLayout.LayoutControlItem lcItemUrl;
		private System.Windows.Forms.WebBrowser wb;
		private DevExpress.XtraLayout.LayoutControlItem lcItemWebPage;
	}
}