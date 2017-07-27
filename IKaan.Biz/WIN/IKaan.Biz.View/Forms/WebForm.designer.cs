namespace IKaan.Biz.View.Forms
{
	partial class WebForm
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
			DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
			this.lcGroupBrowser = new DevExpress.XtraLayout.LayoutControlGroup();
			this.lcGroupSearch = new DevExpress.XtraLayout.LayoutControlGroup();
			this.wb = new System.Windows.Forms.WebBrowser();
			this.lcItemWebBrowser = new DevExpress.XtraLayout.LayoutControlItem();
			this.lupWebUrl = new IKaan.Biz.Core.Controls.Common.XLookup();
			this.lcItemWebUrl = new DevExpress.XtraLayout.LayoutControlItem();
			this.txtUrl = new DevExpress.XtraEditors.TextEdit();
			this.lcItemUrl = new DevExpress.XtraLayout.LayoutControlItem();
			((System.ComponentModel.ISupportInitialize)(this.lc)).BeginInit();
			this.lc.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBrowser)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupSearch)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemWebBrowser)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lupWebUrl.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemWebUrl)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtUrl.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemUrl)).BeginInit();
			this.SuspendLayout();
			// 
			// lc
			// 
			this.lc.Controls.Add(this.txtUrl);
			this.lc.Controls.Add(this.lupWebUrl);
			this.lc.Controls.Add(this.wb);
			this.lc.Location = new System.Drawing.Point(4, 48);
			this.lc.Margin = new System.Windows.Forms.Padding(0);
			this.lc.Padding = new System.Windows.Forms.Padding(2);
			this.lc.Size = new System.Drawing.Size(990, 494);
			// 
			// lcGroupBase
			// 
			this.lcGroupBase.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcGroupBrowser,
            this.lcGroupSearch});
			this.lcGroupBase.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
			this.lcGroupBase.Size = new System.Drawing.Size(990, 494);
			// 
			// lcGroupBrowser
			// 
			this.lcGroupBrowser.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcItemWebBrowser});
			this.lcGroupBrowser.Location = new System.Drawing.Point(0, 38);
			this.lcGroupBrowser.Name = "lcGroupBrowser";
			this.lcGroupBrowser.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
			this.lcGroupBrowser.Size = new System.Drawing.Size(990, 456);
			this.lcGroupBrowser.TextVisible = false;
			// 
			// lcGroupSearch
			// 
			this.lcGroupSearch.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcItemWebUrl,
            this.lcItemUrl});
			this.lcGroupSearch.Location = new System.Drawing.Point(0, 0);
			this.lcGroupSearch.Name = "lcGroupSearch";
			this.lcGroupSearch.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
			this.lcGroupSearch.Size = new System.Drawing.Size(990, 38);
			this.lcGroupSearch.TextVisible = false;
			// 
			// wb
			// 
			this.wb.Location = new System.Drawing.Point(7, 45);
			this.wb.MinimumSize = new System.Drawing.Size(20, 20);
			this.wb.Name = "wb";
			this.wb.Size = new System.Drawing.Size(976, 442);
			this.wb.TabIndex = 4;
			// 
			// lcItemWebBrowser
			// 
			this.lcItemWebBrowser.Control = this.wb;
			this.lcItemWebBrowser.Location = new System.Drawing.Point(0, 0);
			this.lcItemWebBrowser.Name = "lcItemWebBrowser";
			this.lcItemWebBrowser.Size = new System.Drawing.Size(980, 446);
			this.lcItemWebBrowser.TextSize = new System.Drawing.Size(0, 0);
			this.lcItemWebBrowser.TextVisible = false;
			// 
			// lupWebUrl
			// 
			this.lupWebUrl.DisplayMember = "";
			this.lupWebUrl.GroupCode = null;
			this.lupWebUrl.ListMember = "ListName";
			this.lupWebUrl.Location = new System.Drawing.Point(87, 9);
			this.lupWebUrl.Name = "lupWebUrl";
			this.lupWebUrl.NullText = "[EditValue is null]";
			this.lupWebUrl.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Redo, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), "재구성")});
			this.lupWebUrl.SelectedIndex = -1;
			this.lupWebUrl.Size = new System.Drawing.Size(213, 20);
			this.lupWebUrl.StyleController = this.lc;
			this.lupWebUrl.TabIndex = 5;
			this.lupWebUrl.ValueMember = "";
			// 
			// lcItemWebUrl
			// 
			this.lcItemWebUrl.Control = this.lupWebUrl;
			this.lcItemWebUrl.Location = new System.Drawing.Point(0, 0);
			this.lcItemWebUrl.Name = "lcItemWebUrl";
			this.lcItemWebUrl.Size = new System.Drawing.Size(295, 24);
			this.lcItemWebUrl.TextSize = new System.Drawing.Size(74, 14);
			// 
			// txtUrl
			// 
			this.txtUrl.Location = new System.Drawing.Point(382, 9);
			this.txtUrl.Name = "txtUrl";
			this.txtUrl.Size = new System.Drawing.Size(599, 20);
			this.txtUrl.StyleController = this.lc;
			this.txtUrl.TabIndex = 6;
			// 
			// lcItemUrl
			// 
			this.lcItemUrl.Control = this.txtUrl;
			this.lcItemUrl.Location = new System.Drawing.Point(295, 0);
			this.lcItemUrl.Name = "lcItemUrl";
			this.lcItemUrl.Size = new System.Drawing.Size(681, 24);
			this.lcItemUrl.TextSize = new System.Drawing.Size(74, 14);
			// 
			// WebForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(998, 568);
			this.Name = "WebForm";
			this.Padding = new System.Windows.Forms.Padding(4);
			this.Text = "WebForm";
			((System.ComponentModel.ISupportInitialize)(this.lc)).EndInit();
			this.lc.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBrowser)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupSearch)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemWebBrowser)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lupWebUrl.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemWebUrl)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtUrl.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemUrl)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private DevExpress.XtraLayout.LayoutControlGroup lcGroupBrowser;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupSearch;
		private System.Windows.Forms.WebBrowser wb;
		private DevExpress.XtraLayout.LayoutControlItem lcItemWebBrowser;
		private DevExpress.XtraEditors.TextEdit txtUrl;
		private Core.Controls.Common.XLookup lupWebUrl;
		private DevExpress.XtraLayout.LayoutControlItem lcItemWebUrl;
		private DevExpress.XtraLayout.LayoutControlItem lcItemUrl;
	}
}