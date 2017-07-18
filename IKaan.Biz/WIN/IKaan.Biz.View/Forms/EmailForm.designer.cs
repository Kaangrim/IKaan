namespace IKaan.Biz.View.Forms
{
	partial class EmailForm
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
			this.lcGroupContent = new DevExpress.XtraLayout.LayoutControlGroup();
			this.lcGroupSearch = new DevExpress.XtraLayout.LayoutControlGroup();
			this.txtURL = new DevExpress.XtraEditors.TextEdit();
			this.lcItemURL = new DevExpress.XtraLayout.LayoutControlItem();
			this.wb = new System.Windows.Forms.WebBrowser();
			this.lcItemWebBrowser = new DevExpress.XtraLayout.LayoutControlItem();
			((System.ComponentModel.ISupportInitialize)(this.lc)).BeginInit();
			this.lc.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupContent)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupSearch)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtURL.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemURL)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemWebBrowser)).BeginInit();
			this.SuspendLayout();
			// 
			// lc
			// 
			this.lc.Controls.Add(this.wb);
			this.lc.Controls.Add(this.txtURL);
			this.lc.Location = new System.Drawing.Point(4, 48);
			this.lc.Margin = new System.Windows.Forms.Padding(0);
			this.lc.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(2850, 294, 450, 400);
			this.lc.Padding = new System.Windows.Forms.Padding(2);
			this.lc.Size = new System.Drawing.Size(990, 494);
			// 
			// lcGroupBase
			// 
			this.lcGroupBase.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcGroupContent,
            this.lcGroupSearch});
			this.lcGroupBase.Name = "Root";
			this.lcGroupBase.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
			this.lcGroupBase.Size = new System.Drawing.Size(990, 494);
			// 
			// lcGroupContent
			// 
			this.lcGroupContent.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcItemWebBrowser});
			this.lcGroupContent.Location = new System.Drawing.Point(0, 34);
			this.lcGroupContent.Name = "lcGroupContent";
			this.lcGroupContent.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
			this.lcGroupContent.Size = new System.Drawing.Size(986, 456);
			this.lcGroupContent.TextVisible = false;
			// 
			// lcGroupSearch
			// 
			this.lcGroupSearch.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcItemURL});
			this.lcGroupSearch.Location = new System.Drawing.Point(0, 0);
			this.lcGroupSearch.Name = "lcGroupSearch";
			this.lcGroupSearch.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
			this.lcGroupSearch.Size = new System.Drawing.Size(986, 34);
			this.lcGroupSearch.TextVisible = false;
			// 
			// txtURL
			// 
			this.txtURL.Location = new System.Drawing.Point(68, 9);
			this.txtURL.Name = "txtURL";
			this.txtURL.Size = new System.Drawing.Size(913, 20);
			this.txtURL.StyleController = this.lc;
			this.txtURL.TabIndex = 4;
			// 
			// lcItemURL
			// 
			this.lcItemURL.Control = this.txtURL;
			this.lcItemURL.Location = new System.Drawing.Point(0, 0);
			this.lcItemURL.Name = "lcItemURL";
			this.lcItemURL.Size = new System.Drawing.Size(976, 24);
			this.lcItemURL.TextSize = new System.Drawing.Size(55, 14);
			// 
			// wb
			// 
			this.wb.Location = new System.Drawing.Point(9, 43);
			this.wb.MinimumSize = new System.Drawing.Size(20, 20);
			this.wb.Name = "wb";
			this.wb.Size = new System.Drawing.Size(972, 442);
			this.wb.TabIndex = 5;
			// 
			// lcItemWebBrowser
			// 
			this.lcItemWebBrowser.Control = this.wb;
			this.lcItemWebBrowser.Location = new System.Drawing.Point(0, 0);
			this.lcItemWebBrowser.Name = "lcItemWebBrowser";
			this.lcItemWebBrowser.Size = new System.Drawing.Size(976, 446);
			this.lcItemWebBrowser.TextSize = new System.Drawing.Size(0, 0);
			this.lcItemWebBrowser.TextVisible = false;
			// 
			// EmailForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(998, 568);
			this.LookAndFeel.SkinMaskColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.Name = "EmailForm";
			this.Padding = new System.Windows.Forms.Padding(4);
			this.Text = "EmailForm";
			((System.ComponentModel.ISupportInitialize)(this.lc)).EndInit();
			this.lc.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupContent)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupSearch)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtURL.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemURL)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemWebBrowser)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private DevExpress.XtraLayout.LayoutControlGroup lcGroupContent;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupSearch;
		private DevExpress.XtraEditors.TextEdit txtURL;
		private DevExpress.XtraLayout.LayoutControlItem lcItemURL;
		private System.Windows.Forms.WebBrowser wb;
		private DevExpress.XtraLayout.LayoutControlItem lcItemWebBrowser;
	}
}