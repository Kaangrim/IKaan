namespace IKaan.Win.View.Biz.Activity
{
	partial class SearchBrandActivityEditForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchBrandActivityEditForm));
			this.lcGroupEdit = new DevExpress.XtraLayout.LayoutControlGroup();
			this.lcItemID = new DevExpress.XtraLayout.LayoutControlItem();
			this.txtID = new DevExpress.XtraEditors.TextEdit();
			this.lcItemActivityDate = new DevExpress.XtraLayout.LayoutControlItem();
			this.datActivityDate = new DevExpress.XtraEditors.DateEdit();
			this.lcGroupRegInfo = new DevExpress.XtraLayout.LayoutControlGroup();
			this.lcItemCreateDate = new DevExpress.XtraLayout.LayoutControlItem();
			this.txtCreateDate = new DevExpress.XtraEditors.TextEdit();
			this.lcItemCreateByName = new DevExpress.XtraLayout.LayoutControlItem();
			this.txtCreateByName = new DevExpress.XtraEditors.TextEdit();
			this.lcItemUpdateDate = new DevExpress.XtraLayout.LayoutControlItem();
			this.txtUpdateDate = new DevExpress.XtraEditors.TextEdit();
			this.lcItemUpdateByName = new DevExpress.XtraLayout.LayoutControlItem();
			this.txtUpdateByName = new DevExpress.XtraEditors.TextEdit();
			this.txtSearchBrandID = new DevExpress.XtraEditors.TextEdit();
			this.lcItemSearchBrandID = new DevExpress.XtraLayout.LayoutControlItem();
			this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.rteDescription = new IKaan.Win.Core.Controls.Common.XRichEditor();
			this.lcItemDescription = new DevExpress.XtraLayout.LayoutControlItem();
			this.simpleSeparator1 = new DevExpress.XtraLayout.SimpleSeparator();
			this.lcGroupEdit2 = new DevExpress.XtraLayout.LayoutControlGroup();
			((System.ComponentModel.ISupportInitialize)(this.lc)).BeginInit();
			this.lc.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemID)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemActivityDate)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.datActivityDate.Properties.CalendarTimeProperties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.datActivityDate.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupRegInfo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemCreateDate)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtCreateDate.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemCreateByName)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtCreateByName.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemUpdateDate)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtUpdateDate.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemUpdateByName)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtUpdateByName.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtSearchBrandID.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemSearchBrandID)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemDescription)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.simpleSeparator1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupEdit2)).BeginInit();
			this.SuspendLayout();
			// 
			// lc
			// 
			this.lc.Controls.Add(this.rteDescription);
			this.lc.Controls.Add(this.txtSearchBrandID);
			this.lc.Controls.Add(this.datActivityDate);
			this.lc.Controls.Add(this.txtID);
			this.lc.Controls.Add(this.txtUpdateByName);
			this.lc.Controls.Add(this.txtUpdateDate);
			this.lc.Controls.Add(this.txtCreateByName);
			this.lc.Controls.Add(this.txtCreateDate);
			this.lc.Location = new System.Drawing.Point(0, 44);
			this.lc.Margin = new System.Windows.Forms.Padding(0);
			this.lc.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1128, 219, 450, 400);
			this.lc.Padding = new System.Windows.Forms.Padding(2);
			this.lc.Size = new System.Drawing.Size(698, 502);
			// 
			// lcGroupBase
			// 
			this.lcGroupBase.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcGroupEdit,
            this.lcGroupRegInfo,
            this.lcGroupEdit2});
			this.lcGroupBase.Name = "Root";
			this.lcGroupBase.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
			this.lcGroupBase.Size = new System.Drawing.Size(698, 502);
			// 
			// lcGroupEdit
			// 
			this.lcGroupEdit.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcItemID,
            this.lcItemActivityDate,
            this.lcItemSearchBrandID,
            this.emptySpaceItem1,
            this.simpleSeparator1});
			this.lcGroupEdit.Location = new System.Drawing.Point(0, 0);
			this.lcGroupEdit.Name = "lcGroupEdit";
			this.lcGroupEdit.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
			this.lcGroupEdit.Size = new System.Drawing.Size(694, 63);
			this.lcGroupEdit.TextVisible = false;
			// 
			// lcItemID
			// 
			this.lcItemID.Control = this.txtID;
			this.lcItemID.Location = new System.Drawing.Point(0, 0);
			this.lcItemID.Name = "lcItemID";
			this.lcItemID.Size = new System.Drawing.Size(340, 24);
			this.lcItemID.TextSize = new System.Drawing.Size(118, 14);
			// 
			// txtID
			// 
			this.txtID.Location = new System.Drawing.Point(133, 11);
			this.txtID.Name = "txtID";
			this.txtID.Size = new System.Drawing.Size(214, 20);
			this.txtID.StyleController = this.lc;
			this.txtID.TabIndex = 8;
			// 
			// lcItemActivityDate
			// 
			this.lcItemActivityDate.Control = this.datActivityDate;
			this.lcItemActivityDate.Location = new System.Drawing.Point(0, 25);
			this.lcItemActivityDate.Name = "lcItemActivityDate";
			this.lcItemActivityDate.Size = new System.Drawing.Size(340, 24);
			this.lcItemActivityDate.TextSize = new System.Drawing.Size(118, 14);
			// 
			// datActivityDate
			// 
			this.datActivityDate.EditValue = null;
			this.datActivityDate.Location = new System.Drawing.Point(133, 36);
			this.datActivityDate.Name = "datActivityDate";
			this.datActivityDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.datActivityDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.datActivityDate.Size = new System.Drawing.Size(214, 20);
			this.datActivityDate.StyleController = this.lc;
			this.datActivityDate.TabIndex = 20;
			// 
			// lcGroupRegInfo
			// 
			this.lcGroupRegInfo.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcItemCreateDate,
            this.lcItemCreateByName,
            this.lcItemUpdateDate,
            this.lcItemUpdateByName});
			this.lcGroupRegInfo.Location = new System.Drawing.Point(0, 436);
			this.lcGroupRegInfo.Name = "lcGroupRegInfo";
			this.lcGroupRegInfo.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
			this.lcGroupRegInfo.Size = new System.Drawing.Size(694, 62);
			this.lcGroupRegInfo.TextVisible = false;
			// 
			// lcItemCreateDate
			// 
			this.lcItemCreateDate.Control = this.txtCreateDate;
			this.lcItemCreateDate.Location = new System.Drawing.Point(0, 0);
			this.lcItemCreateDate.Name = "lcItemCreateDate";
			this.lcItemCreateDate.Size = new System.Drawing.Size(340, 24);
			this.lcItemCreateDate.TextSize = new System.Drawing.Size(118, 14);
			// 
			// txtCreateDate
			// 
			this.txtCreateDate.Location = new System.Drawing.Point(133, 447);
			this.txtCreateDate.Name = "txtCreateDate";
			this.txtCreateDate.Size = new System.Drawing.Size(214, 20);
			this.txtCreateDate.StyleController = this.lc;
			this.txtCreateDate.TabIndex = 4;
			// 
			// lcItemCreateByName
			// 
			this.lcItemCreateByName.Control = this.txtCreateByName;
			this.lcItemCreateByName.Location = new System.Drawing.Point(0, 24);
			this.lcItemCreateByName.Name = "lcItemCreateByName";
			this.lcItemCreateByName.Size = new System.Drawing.Size(340, 24);
			this.lcItemCreateByName.TextSize = new System.Drawing.Size(118, 14);
			// 
			// txtCreateByName
			// 
			this.txtCreateByName.Location = new System.Drawing.Point(133, 471);
			this.txtCreateByName.Name = "txtCreateByName";
			this.txtCreateByName.Size = new System.Drawing.Size(214, 20);
			this.txtCreateByName.StyleController = this.lc;
			this.txtCreateByName.TabIndex = 5;
			// 
			// lcItemUpdateDate
			// 
			this.lcItemUpdateDate.Control = this.txtUpdateDate;
			this.lcItemUpdateDate.Location = new System.Drawing.Point(340, 0);
			this.lcItemUpdateDate.Name = "lcItemUpdateDate";
			this.lcItemUpdateDate.Size = new System.Drawing.Size(340, 24);
			this.lcItemUpdateDate.TextSize = new System.Drawing.Size(118, 14);
			// 
			// txtUpdateDate
			// 
			this.txtUpdateDate.Location = new System.Drawing.Point(473, 447);
			this.txtUpdateDate.Name = "txtUpdateDate";
			this.txtUpdateDate.Size = new System.Drawing.Size(214, 20);
			this.txtUpdateDate.StyleController = this.lc;
			this.txtUpdateDate.TabIndex = 6;
			// 
			// lcItemUpdateByName
			// 
			this.lcItemUpdateByName.Control = this.txtUpdateByName;
			this.lcItemUpdateByName.Location = new System.Drawing.Point(340, 24);
			this.lcItemUpdateByName.Name = "lcItemUpdateByName";
			this.lcItemUpdateByName.Size = new System.Drawing.Size(340, 24);
			this.lcItemUpdateByName.TextSize = new System.Drawing.Size(118, 14);
			// 
			// txtUpdateByName
			// 
			this.txtUpdateByName.Location = new System.Drawing.Point(473, 471);
			this.txtUpdateByName.Name = "txtUpdateByName";
			this.txtUpdateByName.Size = new System.Drawing.Size(214, 20);
			this.txtUpdateByName.StyleController = this.lc;
			this.txtUpdateByName.TabIndex = 7;
			// 
			// txtSearchBrandID
			// 
			this.txtSearchBrandID.Location = new System.Drawing.Point(473, 11);
			this.txtSearchBrandID.Name = "txtSearchBrandID";
			this.txtSearchBrandID.Size = new System.Drawing.Size(214, 20);
			this.txtSearchBrandID.StyleController = this.lc;
			this.txtSearchBrandID.TabIndex = 23;
			// 
			// lcItemSearchBrandID
			// 
			this.lcItemSearchBrandID.Control = this.txtSearchBrandID;
			this.lcItemSearchBrandID.Location = new System.Drawing.Point(340, 0);
			this.lcItemSearchBrandID.Name = "lcItemSearchBrandID";
			this.lcItemSearchBrandID.Size = new System.Drawing.Size(340, 24);
			this.lcItemSearchBrandID.TextSize = new System.Drawing.Size(118, 14);
			// 
			// emptySpaceItem1
			// 
			this.emptySpaceItem1.AllowHotTrack = false;
			this.emptySpaceItem1.Location = new System.Drawing.Point(340, 25);
			this.emptySpaceItem1.Name = "emptySpaceItem1";
			this.emptySpaceItem1.Size = new System.Drawing.Size(340, 24);
			this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
			// 
			// rteDescription
			// 
			this.rteDescription.EditValue = resources.GetString("rteDescription.EditValue");
			this.rteDescription.Location = new System.Drawing.Point(9, 72);
			this.rteDescription.LookAndFeel.SkinName = "Office 2013 Dark Gray";
			this.rteDescription.Name = "rteDescription";
			this.rteDescription.ReadOnly = false;
			this.rteDescription.Size = new System.Drawing.Size(680, 359);
			this.rteDescription.TabIndex = 24;
			this.rteDescription.ToolbarVisible = true;
			// 
			// lcItemDescription
			// 
			this.lcItemDescription.Control = this.rteDescription;
			this.lcItemDescription.Location = new System.Drawing.Point(0, 0);
			this.lcItemDescription.Name = "lcItemDescription";
			this.lcItemDescription.Size = new System.Drawing.Size(684, 363);
			this.lcItemDescription.TextSize = new System.Drawing.Size(0, 0);
			this.lcItemDescription.TextVisible = false;
			// 
			// simpleSeparator1
			// 
			this.simpleSeparator1.AllowHotTrack = false;
			this.simpleSeparator1.Location = new System.Drawing.Point(0, 24);
			this.simpleSeparator1.Name = "simpleSeparator1";
			this.simpleSeparator1.Size = new System.Drawing.Size(680, 1);
			// 
			// lcGroupEdit2
			// 
			this.lcGroupEdit2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcItemDescription});
			this.lcGroupEdit2.Location = new System.Drawing.Point(0, 63);
			this.lcGroupEdit2.Name = "lcGroupEdit2";
			this.lcGroupEdit2.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
			this.lcGroupEdit2.Size = new System.Drawing.Size(694, 373);
			this.lcGroupEdit2.TextVisible = false;
			// 
			// SearchBrandActivityEditForm
			// 
			this.Appearance.BackColor = System.Drawing.Color.White;
			this.Appearance.Options.UseBackColor = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(698, 568);
			this.LookAndFeel.SkinName = "Office 2016 Dark";
			this.Name = "SearchBrandActivityEditForm";
			this.Text = "SearchBrandActivityEditForm";
			((System.ComponentModel.ISupportInitialize)(this.lc)).EndInit();
			this.lc.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemID)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemActivityDate)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.datActivityDate.Properties.CalendarTimeProperties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.datActivityDate.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupRegInfo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemCreateDate)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtCreateDate.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemCreateByName)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtCreateByName.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemUpdateDate)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtUpdateDate.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemUpdateByName)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtUpdateByName.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtSearchBrandID.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemSearchBrandID)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemDescription)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.simpleSeparator1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupEdit2)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private DevExpress.XtraLayout.LayoutControlGroup lcGroupEdit;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupRegInfo;
		private DevExpress.XtraEditors.TextEdit txtUpdateByName;
		private DevExpress.XtraEditors.TextEdit txtUpdateDate;
		private DevExpress.XtraEditors.TextEdit txtCreateByName;
		private DevExpress.XtraEditors.TextEdit txtCreateDate;
		private DevExpress.XtraLayout.LayoutControlItem lcItemCreateDate;
		private DevExpress.XtraLayout.LayoutControlItem lcItemCreateByName;
		private DevExpress.XtraLayout.LayoutControlItem lcItemUpdateDate;
		private DevExpress.XtraLayout.LayoutControlItem lcItemUpdateByName;
		private DevExpress.XtraEditors.TextEdit txtID;
		private DevExpress.XtraLayout.LayoutControlItem lcItemID;
		private DevExpress.XtraEditors.DateEdit datActivityDate;
		private DevExpress.XtraLayout.LayoutControlItem lcItemActivityDate;
		private Core.Controls.Common.XRichEditor rteDescription;
		private DevExpress.XtraEditors.TextEdit txtSearchBrandID;
		private DevExpress.XtraLayout.LayoutControlItem lcItemSearchBrandID;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
		private DevExpress.XtraLayout.LayoutControlItem lcItemDescription;
		private DevExpress.XtraLayout.SimpleSeparator simpleSeparator1;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupEdit2;
	}
}