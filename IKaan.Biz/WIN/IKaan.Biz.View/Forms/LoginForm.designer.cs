namespace IKaan.Biz.View.Forms
{
    partial class LoginForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
			this.chkRemember = new DevExpress.XtraEditors.CheckEdit();
			this.styleController1 = new DevExpress.XtraEditors.StyleController();
			this.lblForgot = new DevExpress.XtraEditors.HyperlinkLabelControl();
			this.picBanner = new DevExpress.XtraEditors.PictureEdit();
			this.barManager = new DevExpress.XtraBars.BarManager();
			this.barStatus = new DevExpress.XtraBars.Bar();
			this.barMessage = new DevExpress.XtraBars.BarStaticItem();
			this.barAndDockingController1 = new DevExpress.XtraBars.BarAndDockingController();
			this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
			this.txtLoginId = new DevExpress.XtraEditors.TextEdit();
			this.btnOk = new DevExpress.XtraEditors.SimpleButton();
			this.txtPassword = new DevExpress.XtraEditors.TextEdit();
			this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
			this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
			((System.ComponentModel.ISupportInitialize)(this.chkRemember.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.styleController1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picBanner.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtLoginId.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// chkRemember
			// 
			this.chkRemember.EditValue = "N";
			this.chkRemember.Location = new System.Drawing.Point(50, 246);
			this.chkRemember.Name = "chkRemember";
			this.chkRemember.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.chkRemember.Properties.Appearance.Options.UseForeColor = true;
			this.chkRemember.Properties.AutoWidth = true;
			this.chkRemember.Properties.Caption = "Remember";
			this.chkRemember.Properties.ValueChecked = "Y";
			this.chkRemember.Properties.ValueUnchecked = "N";
			this.chkRemember.Size = new System.Drawing.Size(81, 19);
			this.chkRemember.StyleController = this.styleController1;
			this.chkRemember.TabIndex = 11;
			// 
			// styleController1
			// 
			this.styleController1.LookAndFeel.SkinName = "Office 2016 Colorful";
			this.styleController1.LookAndFeel.UseDefaultLookAndFeel = false;
			// 
			// lblForgot
			// 
			this.lblForgot.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblForgot.Location = new System.Drawing.Point(253, 369);
			this.lblForgot.Name = "lblForgot";
			this.lblForgot.Size = new System.Drawing.Size(97, 14);
			this.lblForgot.StyleController = this.styleController1;
			this.lblForgot.TabIndex = 13;
			this.lblForgot.Text = "Forgot Password?\r\n";
			// 
			// picBanner
			// 
			this.picBanner.Cursor = System.Windows.Forms.Cursors.Default;
			this.picBanner.EditValue = ((object)(resources.GetObject("picBanner.EditValue")));
			this.picBanner.Location = new System.Drawing.Point(12, 12);
			this.picBanner.MenuManager = this.barManager;
			this.picBanner.Name = "picBanner";
			this.picBanner.Properties.AllowFocused = false;
			this.picBanner.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.picBanner.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
			this.picBanner.Properties.ShowMenu = false;
			this.picBanner.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
			this.picBanner.Properties.ZoomAccelerationFactor = 1D;
			this.picBanner.Size = new System.Drawing.Size(374, 115);
			this.picBanner.TabIndex = 12;
			// 
			// barManager
			// 
			this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barStatus});
			this.barManager.Controller = this.barAndDockingController1;
			this.barManager.DockControls.Add(this.barDockControlTop);
			this.barManager.DockControls.Add(this.barDockControlBottom);
			this.barManager.DockControls.Add(this.barDockControlLeft);
			this.barManager.DockControls.Add(this.barDockControlRight);
			this.barManager.Form = this;
			this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barMessage});
			this.barManager.MaxItemId = 1;
			this.barManager.StatusBar = this.barStatus;
			// 
			// barStatus
			// 
			this.barStatus.BarName = "Status bar";
			this.barStatus.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
			this.barStatus.DockCol = 0;
			this.barStatus.DockRow = 0;
			this.barStatus.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
			this.barStatus.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barMessage, true)});
			this.barStatus.OptionsBar.AllowQuickCustomization = false;
			this.barStatus.OptionsBar.DrawDragBorder = false;
			this.barStatus.OptionsBar.UseWholeRow = true;
			this.barStatus.Text = "Status bar";
			// 
			// barMessage
			// 
			this.barMessage.AutoSize = DevExpress.XtraBars.BarStaticItemSize.Spring;
			this.barMessage.Caption = " ";
			this.barMessage.Id = 0;
			this.barMessage.Name = "barMessage";
			this.barMessage.Size = new System.Drawing.Size(32, 0);
			this.barMessage.Width = 32;
			// 
			// barAndDockingController1
			// 
			this.barAndDockingController1.LookAndFeel.SkinName = "Office 2016 Dark";
			this.barAndDockingController1.LookAndFeel.UseDefaultLookAndFeel = false;
			this.barAndDockingController1.PropertiesBar.AllowLinkLighting = false;
			this.barAndDockingController1.PropertiesBar.DefaultGlyphSize = new System.Drawing.Size(16, 16);
			this.barAndDockingController1.PropertiesBar.DefaultLargeGlyphSize = new System.Drawing.Size(32, 32);
			// 
			// barDockControlTop
			// 
			this.barDockControlTop.CausesValidation = false;
			this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
			this.barDockControlTop.Manager = this.barManager;
			this.barDockControlTop.Size = new System.Drawing.Size(398, 0);
			// 
			// barDockControlBottom
			// 
			this.barDockControlBottom.CausesValidation = false;
			this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.barDockControlBottom.Location = new System.Drawing.Point(0, 396);
			this.barDockControlBottom.Manager = this.barManager;
			this.barDockControlBottom.Size = new System.Drawing.Size(398, 22);
			// 
			// barDockControlLeft
			// 
			this.barDockControlLeft.CausesValidation = false;
			this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
			this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
			this.barDockControlLeft.Manager = this.barManager;
			this.barDockControlLeft.Size = new System.Drawing.Size(0, 396);
			// 
			// barDockControlRight
			// 
			this.barDockControlRight.CausesValidation = false;
			this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
			this.barDockControlRight.Location = new System.Drawing.Point(398, 0);
			this.barDockControlRight.Manager = this.barManager;
			this.barDockControlRight.Size = new System.Drawing.Size(0, 396);
			// 
			// txtLoginId
			// 
			this.txtLoginId.Location = new System.Drawing.Point(50, 163);
			this.txtLoginId.Name = "txtLoginId";
			this.txtLoginId.Properties.Appearance.BackColor = System.Drawing.Color.White;
			this.txtLoginId.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
			this.txtLoginId.Properties.Appearance.Options.UseBackColor = true;
			this.txtLoginId.Properties.Appearance.Options.UseFont = true;
			this.txtLoginId.Size = new System.Drawing.Size(300, 26);
			this.txtLoginId.StyleController = this.styleController1;
			this.txtLoginId.TabIndex = 6;
			// 
			// btnOk
			// 
			this.btnOk.Appearance.BackColor = System.Drawing.Color.Black;
			this.btnOk.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
			this.btnOk.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnOk.Appearance.Options.UseBackColor = true;
			this.btnOk.Appearance.Options.UseFont = true;
			this.btnOk.Appearance.Options.UseForeColor = true;
			this.btnOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.btnOk.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.ImageOptions.Image")));
			this.btnOk.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
			this.btnOk.Location = new System.Drawing.Point(50, 285);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(300, 60);
			this.btnOk.StyleController = this.styleController1;
			this.btnOk.TabIndex = 8;
			// 
			// txtPassword
			// 
			this.txtPassword.Location = new System.Drawing.Point(50, 214);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
			this.txtPassword.Properties.Appearance.Options.UseFont = true;
			this.txtPassword.Properties.PasswordChar = '*';
			this.txtPassword.Properties.UseSystemPasswordChar = true;
			this.txtPassword.Size = new System.Drawing.Size(300, 26);
			this.txtPassword.StyleController = this.styleController1;
			this.txtPassword.TabIndex = 7;
			// 
			// labelControl1
			// 
			this.labelControl1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.labelControl1.Appearance.Options.UseForeColor = true;
			this.labelControl1.Location = new System.Drawing.Point(50, 143);
			this.labelControl1.Name = "labelControl1";
			this.labelControl1.Size = new System.Drawing.Size(147, 14);
			this.labelControl1.StyleController = this.styleController1;
			this.labelControl1.TabIndex = 27;
			this.labelControl1.Text = "Username or Email Address";
			// 
			// labelControl2
			// 
			this.labelControl2.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.labelControl2.Appearance.Options.UseForeColor = true;
			this.labelControl2.Location = new System.Drawing.Point(50, 194);
			this.labelControl2.Name = "labelControl2";
			this.labelControl2.Size = new System.Drawing.Size(51, 14);
			this.labelControl2.StyleController = this.styleController1;
			this.labelControl2.TabIndex = 28;
			this.labelControl2.Text = "Password";
			// 
			// LoginForm
			// 
			this.Appearance.BackColor = System.Drawing.Color.White;
			this.Appearance.Options.UseBackColor = true;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(398, 418);
			this.Controls.Add(this.labelControl2);
			this.Controls.Add(this.labelControl1);
			this.Controls.Add(this.picBanner);
			this.Controls.Add(this.txtLoginId);
			this.Controls.Add(this.txtPassword);
			this.Controls.Add(this.lblForgot);
			this.Controls.Add(this.chkRemember);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.barDockControlLeft);
			this.Controls.Add(this.barDockControlRight);
			this.Controls.Add(this.barDockControlBottom);
			this.Controls.Add(this.barDockControlTop);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.LookAndFeel.SkinName = "Office 2016 Dark";
			this.LookAndFeel.UseDefaultLookAndFeel = false;
			this.MaximizeBox = false;
			this.Name = "LoginForm";
			this.Text = "LoginForm";
			((System.ComponentModel.ISupportInitialize)(this.chkRemember.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.styleController1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picBanner.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtLoginId.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.TextEdit txtLoginId;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.CheckEdit chkRemember;
		private DevExpress.XtraBars.BarStaticItem barMessage;
		private DevExpress.XtraBars.Bar barStatus;
		private DevExpress.XtraBars.BarDockControl barDockControlTop;
		private DevExpress.XtraBars.BarDockControl barDockControlBottom;
		private DevExpress.XtraBars.BarDockControl barDockControlLeft;
		private DevExpress.XtraBars.BarDockControl barDockControlRight;
		private DevExpress.XtraBars.BarManager barManager;
		private DevExpress.XtraBars.BarAndDockingController barAndDockingController1;
		private DevExpress.XtraEditors.PictureEdit picBanner;
		private DevExpress.XtraEditors.HyperlinkLabelControl lblForgot;
		private DevExpress.XtraEditors.LabelControl labelControl2;
		private DevExpress.XtraEditors.LabelControl labelControl1;
		private DevExpress.XtraEditors.StyleController styleController1;
	}
}