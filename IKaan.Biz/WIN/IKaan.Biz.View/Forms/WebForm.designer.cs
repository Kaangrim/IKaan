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
			this.wb = new System.Windows.Forms.WebBrowser();
			this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
			this.txtUrl = new DevExpress.XtraEditors.TextEdit();
			this.lupWebUrl = new IKaan.Biz.Core.Controls.Common.XLookup();
			((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
			this.panelControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtUrl.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lupWebUrl.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// wb
			// 
			this.wb.Dock = System.Windows.Forms.DockStyle.Fill;
			this.wb.Location = new System.Drawing.Point(4, 54);
			this.wb.MinimumSize = new System.Drawing.Size(20, 20);
			this.wb.Name = "wb";
			this.wb.Size = new System.Drawing.Size(990, 510);
			this.wb.TabIndex = 0;
			// 
			// panelControl1
			// 
			this.panelControl1.Appearance.BackColor = System.Drawing.Color.Gray;
			this.panelControl1.Appearance.Options.UseBackColor = true;
			this.panelControl1.Controls.Add(this.lupWebUrl);
			this.panelControl1.Controls.Add(this.txtUrl);
			this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelControl1.Location = new System.Drawing.Point(4, 4);
			this.panelControl1.LookAndFeel.SkinName = "Office 2016 Dark";
			this.panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
			this.panelControl1.Name = "panelControl1";
			this.panelControl1.Size = new System.Drawing.Size(990, 50);
			this.panelControl1.TabIndex = 1;
			// 
			// txtUrl
			// 
			this.txtUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtUrl.Location = new System.Drawing.Point(242, 13);
			this.txtUrl.Name = "txtUrl";
			this.txtUrl.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
			this.txtUrl.Properties.Appearance.Options.UseFont = true;
			this.txtUrl.Size = new System.Drawing.Size(743, 24);
			this.txtUrl.TabIndex = 0;
			// 
			// lupWebUrl
			// 
			this.lupWebUrl.DisplayMember = "";
			this.lupWebUrl.GroupCode = null;
			this.lupWebUrl.ListMember = "ListName";
			this.lupWebUrl.Location = new System.Drawing.Point(5, 13);
			this.lupWebUrl.Name = "lupWebUrl";
			this.lupWebUrl.NullText = "[EditValue is null]";
			this.lupWebUrl.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
			this.lupWebUrl.Properties.Appearance.Options.UseFont = true;
			this.lupWebUrl.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Redo, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), "재구성")});
			this.lupWebUrl.Properties.LookAndFeel.SkinName = "Office 2016 Dark";
			this.lupWebUrl.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.lupWebUrl.SelectedIndex = -1;
			this.lupWebUrl.Size = new System.Drawing.Size(231, 24);
			this.lupWebUrl.TabIndex = 1;
			this.lupWebUrl.ValueMember = "";
			// 
			// WebForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(998, 568);
			this.Controls.Add(this.wb);
			this.Controls.Add(this.panelControl1);
			this.LookAndFeel.SkinMaskColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.Name = "WebForm";
			this.Padding = new System.Windows.Forms.Padding(4);
			this.Text = "WebForm";
			((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
			this.panelControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.txtUrl.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lupWebUrl.Properties)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.WebBrowser wb;
		private DevExpress.XtraEditors.PanelControl panelControl1;
		private DevExpress.XtraEditors.TextEdit txtUrl;
		private Core.Controls.Common.XLookup lupWebUrl;
	}
}