namespace IKaan.Win.View.Biz.Sales.Order
{
	partial class OrderNoteEditForm
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
			this.lcItemID = new DevExpress.XtraLayout.LayoutControlItem();
			this.txtID = new DevExpress.XtraEditors.TextEdit();
			this.lcItemNote = new DevExpress.XtraLayout.LayoutControlItem();
			this.memNote = new DevExpress.XtraEditors.MemoEdit();
			this.lcGroupRegInfo = new DevExpress.XtraLayout.LayoutControlGroup();
			this.lcItemCreatedByName = new DevExpress.XtraLayout.LayoutControlItem();
			this.txtCreatedByName = new DevExpress.XtraEditors.TextEdit();
			this.lcItemCreatedOn = new DevExpress.XtraLayout.LayoutControlItem();
			this.txtCreatedOn = new DevExpress.XtraEditors.TextEdit();
			this.lcItemUpdatedOn = new DevExpress.XtraLayout.LayoutControlItem();
			this.txtUpdatedOn = new DevExpress.XtraEditors.TextEdit();
			this.lcItemUpdatedByName = new DevExpress.XtraLayout.LayoutControlItem();
			this.txtUpdatedByName = new DevExpress.XtraEditors.TextEdit();
			this.lcGroupEditBase = new DevExpress.XtraLayout.LayoutControlGroup();
			((System.ComponentModel.ISupportInitialize)(this.lc)).BeginInit();
			this.lc.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupEdit1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemID)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemNote)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.memNote.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupRegInfo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemCreatedByName)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtCreatedByName.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemCreatedOn)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtCreatedOn.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemUpdatedOn)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtUpdatedOn.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemUpdatedByName)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtUpdatedByName.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupEditBase)).BeginInit();
			this.SuspendLayout();
			// 
			// lc
			// 
			this.lc.Controls.Add(this.memNote);
			this.lc.Controls.Add(this.txtUpdatedByName);
			this.lc.Controls.Add(this.txtUpdatedOn);
			this.lc.Controls.Add(this.txtCreatedByName);
			this.lc.Controls.Add(this.txtCreatedOn);
			this.lc.Controls.Add(this.txtID);
			this.lc.Location = new System.Drawing.Point(0, 44);
			this.lc.Margin = new System.Windows.Forms.Padding(0);
			this.lc.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(923, 404, 457, 350);
			this.lc.OptionsView.UseDefaultDragAndDropRendering = false;
			this.lc.Padding = new System.Windows.Forms.Padding(2);
			this.lc.Size = new System.Drawing.Size(698, 402);
			// 
			// lcGroupBase
			// 
			this.lcGroupBase.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcGroupEditBase});
			this.lcGroupBase.Name = "Root";
			this.lcGroupBase.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
			this.lcGroupBase.Size = new System.Drawing.Size(698, 402);
			// 
			// lcGroupEdit1
			// 
			this.lcGroupEdit1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcItemID,
            this.lcItemNote});
			this.lcGroupEdit1.Location = new System.Drawing.Point(0, 0);
			this.lcGroupEdit1.Name = "lcGroupEdit1";
			this.lcGroupEdit1.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
			this.lcGroupEdit1.Size = new System.Drawing.Size(680, 322);
			this.lcGroupEdit1.TextVisible = false;
			// 
			// lcItemID
			// 
			this.lcItemID.AppearanceItemCaption.Font = new System.Drawing.Font("맑은 고딕", 10F);
			this.lcItemID.AppearanceItemCaption.Options.UseFont = true;
			this.lcItemID.Control = this.txtID;
			this.lcItemID.Location = new System.Drawing.Point(0, 0);
			this.lcItemID.Name = "lcItemID";
			this.lcItemID.Size = new System.Drawing.Size(666, 24);
			this.lcItemID.TextSize = new System.Drawing.Size(125, 17);
			// 
			// txtID
			// 
			this.txtID.Location = new System.Drawing.Point(147, 18);
			this.txtID.Name = "txtID";
			this.txtID.Size = new System.Drawing.Size(533, 20);
			this.txtID.StyleController = this.lc;
			this.txtID.TabIndex = 5;
			// 
			// lcItemNote
			// 
			this.lcItemNote.Control = this.memNote;
			this.lcItemNote.Location = new System.Drawing.Point(0, 24);
			this.lcItemNote.Name = "lcItemNote";
			this.lcItemNote.Size = new System.Drawing.Size(666, 284);
			this.lcItemNote.TextSize = new System.Drawing.Size(125, 14);
			// 
			// memNote
			// 
			this.memNote.Location = new System.Drawing.Point(147, 42);
			this.memNote.Name = "memNote";
			this.memNote.Size = new System.Drawing.Size(533, 280);
			this.memNote.StyleController = this.lc;
			this.memNote.TabIndex = 14;
			// 
			// lcGroupRegInfo
			// 
			this.lcGroupRegInfo.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcItemCreatedByName,
            this.lcItemCreatedOn,
            this.lcItemUpdatedOn,
            this.lcItemUpdatedByName});
			this.lcGroupRegInfo.Location = new System.Drawing.Point(0, 322);
			this.lcGroupRegInfo.Name = "lcGroupRegInfo";
			this.lcGroupRegInfo.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
			this.lcGroupRegInfo.Size = new System.Drawing.Size(680, 62);
			this.lcGroupRegInfo.TextVisible = false;
			// 
			// lcItemCreatedByName
			// 
			this.lcItemCreatedByName.Control = this.txtCreatedByName;
			this.lcItemCreatedByName.Location = new System.Drawing.Point(0, 24);
			this.lcItemCreatedByName.Name = "lcItemCreatedByName";
			this.lcItemCreatedByName.Size = new System.Drawing.Size(333, 24);
			this.lcItemCreatedByName.TextSize = new System.Drawing.Size(125, 14);
			// 
			// txtCreatedByName
			// 
			this.txtCreatedByName.Location = new System.Drawing.Point(147, 364);
			this.txtCreatedByName.Name = "txtCreatedByName";
			this.txtCreatedByName.Size = new System.Drawing.Size(200, 20);
			this.txtCreatedByName.StyleController = this.lc;
			this.txtCreatedByName.TabIndex = 11;
			// 
			// lcItemCreatedOn
			// 
			this.lcItemCreatedOn.Control = this.txtCreatedOn;
			this.lcItemCreatedOn.Location = new System.Drawing.Point(0, 0);
			this.lcItemCreatedOn.Name = "lcItemCreatedOn";
			this.lcItemCreatedOn.Size = new System.Drawing.Size(333, 24);
			this.lcItemCreatedOn.TextSize = new System.Drawing.Size(125, 14);
			// 
			// txtCreatedOn
			// 
			this.txtCreatedOn.Location = new System.Drawing.Point(147, 340);
			this.txtCreatedOn.Name = "txtCreatedOn";
			this.txtCreatedOn.Size = new System.Drawing.Size(200, 20);
			this.txtCreatedOn.StyleController = this.lc;
			this.txtCreatedOn.TabIndex = 10;
			// 
			// lcItemUpdatedOn
			// 
			this.lcItemUpdatedOn.Control = this.txtUpdatedOn;
			this.lcItemUpdatedOn.Location = new System.Drawing.Point(333, 0);
			this.lcItemUpdatedOn.Name = "lcItemUpdatedOn";
			this.lcItemUpdatedOn.Size = new System.Drawing.Size(333, 24);
			this.lcItemUpdatedOn.TextSize = new System.Drawing.Size(125, 14);
			// 
			// txtUpdatedOn
			// 
			this.txtUpdatedOn.Location = new System.Drawing.Point(480, 340);
			this.txtUpdatedOn.Name = "txtUpdatedOn";
			this.txtUpdatedOn.Size = new System.Drawing.Size(200, 20);
			this.txtUpdatedOn.StyleController = this.lc;
			this.txtUpdatedOn.TabIndex = 12;
			// 
			// lcItemUpdatedByName
			// 
			this.lcItemUpdatedByName.Control = this.txtUpdatedByName;
			this.lcItemUpdatedByName.Location = new System.Drawing.Point(333, 24);
			this.lcItemUpdatedByName.Name = "lcItemUpdatedByName";
			this.lcItemUpdatedByName.Size = new System.Drawing.Size(333, 24);
			this.lcItemUpdatedByName.TextSize = new System.Drawing.Size(125, 14);
			// 
			// txtUpdatedByName
			// 
			this.txtUpdatedByName.Location = new System.Drawing.Point(480, 364);
			this.txtUpdatedByName.Name = "txtUpdatedByName";
			this.txtUpdatedByName.Size = new System.Drawing.Size(200, 20);
			this.txtUpdatedByName.StyleController = this.lc;
			this.txtUpdatedByName.TabIndex = 13;
			// 
			// lcGroupEditBase
			// 
			this.lcGroupEditBase.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcGroupEdit1,
            this.lcGroupRegInfo});
			this.lcGroupEditBase.Location = new System.Drawing.Point(0, 0);
			this.lcGroupEditBase.Name = "lcGroupEditBase";
			this.lcGroupEditBase.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
			this.lcGroupEditBase.Size = new System.Drawing.Size(694, 398);
			this.lcGroupEditBase.TextVisible = false;
			// 
			// OrderNoteEditForm
			// 
			this.Appearance.BackColor = System.Drawing.Color.White;
			this.Appearance.Options.UseBackColor = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(698, 468);
			this.LookAndFeel.SkinName = "Office 2016 Dark";
			this.Name = "OrderNoteEditForm";
			this.Text = "OrderNoteEditForm";
			((System.ComponentModel.ISupportInitialize)(this.lc)).EndInit();
			this.lc.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupEdit1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemID)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemNote)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.memNote.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupRegInfo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemCreatedByName)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtCreatedByName.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemCreatedOn)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtCreatedOn.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemUpdatedOn)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtUpdatedOn.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemUpdatedByName)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtUpdatedByName.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupEditBase)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupEdit1;
		private DevExpress.XtraEditors.TextEdit txtID;
		private DevExpress.XtraLayout.LayoutControlItem lcItemID;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupRegInfo;
		private DevExpress.XtraEditors.TextEdit txtUpdatedByName;
		private DevExpress.XtraEditors.TextEdit txtUpdatedOn;
		private DevExpress.XtraEditors.TextEdit txtCreatedByName;
		private DevExpress.XtraEditors.TextEdit txtCreatedOn;
		private DevExpress.XtraLayout.LayoutControlItem lcItemCreatedOn;
		private DevExpress.XtraLayout.LayoutControlItem lcItemCreatedByName;
		private DevExpress.XtraLayout.LayoutControlItem lcItemUpdatedOn;
		private DevExpress.XtraLayout.LayoutControlItem lcItemUpdatedByName;
		private DevExpress.XtraEditors.MemoEdit memNote;
		private DevExpress.XtraLayout.LayoutControlItem lcItemNote;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupEditBase;
	}
}