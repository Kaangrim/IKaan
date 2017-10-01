namespace IKaan.Win.Core.Controls.Common
{
	partial class XPicture
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.picture = new DevExpress.XtraEditors.PictureEdit();
			this.edit = new DevExpress.XtraEditors.ButtonEdit();
			((System.ComponentModel.ISupportInitialize)(this.picture.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.edit.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// picture
			// 
			this.picture.Cursor = System.Windows.Forms.Cursors.Default;
			this.picture.Dock = System.Windows.Forms.DockStyle.Fill;
			this.picture.Location = new System.Drawing.Point(0, 0);
			this.picture.Name = "picture";
			this.picture.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
			this.picture.Properties.ZoomAccelerationFactor = 1D;
			this.picture.Size = new System.Drawing.Size(200, 180);
			this.picture.TabIndex = 0;
			// 
			// edit
			// 
			this.edit.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.edit.Location = new System.Drawing.Point(0, 180);
			this.edit.Name = "edit";
			this.edit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
			this.edit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.edit.Size = new System.Drawing.Size(200, 20);
			this.edit.TabIndex = 1;
			// 
			// XPicture
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.picture);
			this.Controls.Add(this.edit);
			this.Name = "XPicture";
			this.Size = new System.Drawing.Size(200, 200);
			((System.ComponentModel.ISupportInitialize)(this.picture.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.edit.Properties)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraEditors.PictureEdit picture;
		private DevExpress.XtraEditors.ButtonEdit edit;
	}
}
