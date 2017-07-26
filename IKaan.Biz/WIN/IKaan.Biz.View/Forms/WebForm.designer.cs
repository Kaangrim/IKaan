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
			this.wb = new System.Windows.Forms.WebBrowser();
			this.lcItemWebBrowser = new DevExpress.XtraLayout.LayoutControlItem();
			((System.ComponentModel.ISupportInitialize)(this.lc)).BeginInit();
			this.lc.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemWebBrowser)).BeginInit();
			this.SuspendLayout();
			// 
			// lc
			// 
			this.lc.Controls.Add(this.wb);
			this.lc.Location = new System.Drawing.Point(4, 48);
			this.lc.Margin = new System.Windows.Forms.Padding(0);
			this.lc.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(2850, 294, 450, 400);
			this.lc.Padding = new System.Windows.Forms.Padding(2);
			this.lc.Size = new System.Drawing.Size(990, 494);
			// 
			// lcGroupBase
			// 
			this.lcGroupBase.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcItemWebBrowser});
			this.lcGroupBase.Name = "Root";
			this.lcGroupBase.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
			this.lcGroupBase.Size = new System.Drawing.Size(990, 494);
			// 
			// wb
			// 
			this.wb.Location = new System.Drawing.Point(4, 4);
			this.wb.MinimumSize = new System.Drawing.Size(20, 20);
			this.wb.Name = "wb";
			this.wb.Size = new System.Drawing.Size(982, 486);
			this.wb.TabIndex = 5;
			// 
			// lcItemWebBrowser
			// 
			this.lcItemWebBrowser.Control = this.wb;
			this.lcItemWebBrowser.Location = new System.Drawing.Point(0, 0);
			this.lcItemWebBrowser.Name = "lcItemWebBrowser";
			this.lcItemWebBrowser.Size = new System.Drawing.Size(986, 490);
			this.lcItemWebBrowser.TextSize = new System.Drawing.Size(0, 0);
			this.lcItemWebBrowser.TextVisible = false;
			// 
			// WebForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(998, 568);
			this.LookAndFeel.SkinMaskColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.Name = "WebForm";
			this.Padding = new System.Windows.Forms.Padding(4);
			this.Text = "WebForm";
			((System.ComponentModel.ISupportInitialize)(this.lc)).EndInit();
			this.lc.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemWebBrowser)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.WebBrowser wb;
		private DevExpress.XtraLayout.LayoutControlItem lcItemWebBrowser;
	}
}