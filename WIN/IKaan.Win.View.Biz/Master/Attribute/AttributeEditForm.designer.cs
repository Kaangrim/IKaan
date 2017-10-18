namespace IKaan.Win.View.Biz.Master.Attribute
{
	partial class AttributeEditForm
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
			this.lcGroupEdit1 = new DevExpress.XtraLayout.LayoutControlGroup();
			this.lcItemID = new DevExpress.XtraLayout.LayoutControlItem();
			this.txtID = new DevExpress.XtraEditors.TextEdit();
			this.lcItemName = new DevExpress.XtraLayout.LayoutControlItem();
			this.txtName = new DevExpress.XtraEditors.TextEdit();
			this.lcItemDescription = new DevExpress.XtraLayout.LayoutControlItem();
			this.memDescription = new DevExpress.XtraEditors.MemoEdit();
			this.lcItemUseYn = new DevExpress.XtraLayout.LayoutControlItem();
			this.chkUseYn = new DevExpress.XtraEditors.CheckEdit();
			this.lcItemCode = new DevExpress.XtraLayout.LayoutControlItem();
			this.txtCode = new DevExpress.XtraEditors.TextEdit();
			this.lcItemAttributeType = new DevExpress.XtraLayout.LayoutControlItem();
			this.lupAttributeTypeID = new IKaan.Win.Core.Controls.Common.XLookup();
			this.lcGroupRegInfo = new DevExpress.XtraLayout.LayoutControlGroup();
			this.lcItemCreatedOn = new DevExpress.XtraLayout.LayoutControlItem();
			this.txtCreatedOn = new DevExpress.XtraEditors.TextEdit();
			this.lcItemCreatedByName = new DevExpress.XtraLayout.LayoutControlItem();
			this.txtCreatedByName = new DevExpress.XtraEditors.TextEdit();
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
			((System.ComponentModel.ISupportInitialize)(this.lcItemName)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemDescription)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.memDescription.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemUseYn)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.chkUseYn.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemCode)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemAttributeType)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lupAttributeTypeID.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupRegInfo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemCreatedOn)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtCreatedOn.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemCreatedByName)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtCreatedByName.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemUpdatedOn)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtUpdatedOn.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemUpdatedByName)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtUpdatedByName.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupEditBase)).BeginInit();
			this.SuspendLayout();
			// 
			// lc
			// 
			this.lc.Controls.Add(this.lupAttributeTypeID);
			this.lc.Controls.Add(this.txtCode);
			this.lc.Controls.Add(this.chkUseYn);
			this.lc.Controls.Add(this.memDescription);
			this.lc.Controls.Add(this.txtName);
			this.lc.Controls.Add(this.txtID);
			this.lc.Controls.Add(this.txtUpdatedByName);
			this.lc.Controls.Add(this.txtUpdatedOn);
			this.lc.Controls.Add(this.txtCreatedByName);
			this.lc.Controls.Add(this.txtCreatedOn);
			this.lc.Location = new System.Drawing.Point(0, 44);
			this.lc.Margin = new System.Windows.Forms.Padding(0);
			this.lc.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(930, 470, 457, 350);
			this.lc.OptionsView.UseDefaultDragAndDropRendering = false;
			this.lc.Padding = new System.Windows.Forms.Padding(2);
			this.lc.Size = new System.Drawing.Size(498, 302);
			// 
			// lcGroupBase
			// 
			this.lcGroupBase.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcGroupEditBase});
			this.lcGroupBase.Name = "Root";
			this.lcGroupBase.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
			this.lcGroupBase.Size = new System.Drawing.Size(498, 302);
			// 
			// lcGroupEdit1
			// 
			this.lcGroupEdit1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcItemID,
            this.lcItemName,
            this.lcItemDescription,
            this.lcItemUseYn,
            this.lcItemCode,
            this.lcItemAttributeType});
			this.lcGroupEdit1.Location = new System.Drawing.Point(0, 0);
			this.lcGroupEdit1.Name = "lcGroupEdit1";
			this.lcGroupEdit1.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
			this.lcGroupEdit1.Size = new System.Drawing.Size(494, 236);
			this.lcGroupEdit1.TextVisible = false;
			// 
			// lcItemID
			// 
			this.lcItemID.Control = this.txtID;
			this.lcItemID.Location = new System.Drawing.Point(0, 0);
			this.lcItemID.Name = "lcItemID";
			this.lcItemID.Size = new System.Drawing.Size(480, 24);
			this.lcItemID.TextSize = new System.Drawing.Size(125, 14);
			// 
			// txtID
			// 
			this.txtID.Location = new System.Drawing.Point(140, 11);
			this.txtID.Name = "txtID";
			this.txtID.Size = new System.Drawing.Size(347, 20);
			this.txtID.StyleController = this.lc;
			this.txtID.TabIndex = 39;
			// 
			// lcItemName
			// 
			this.lcItemName.Control = this.txtName;
			this.lcItemName.Location = new System.Drawing.Point(0, 48);
			this.lcItemName.Name = "lcItemName";
			this.lcItemName.Size = new System.Drawing.Size(480, 24);
			this.lcItemName.TextSize = new System.Drawing.Size(125, 14);
			// 
			// txtName
			// 
			this.txtName.Location = new System.Drawing.Point(140, 59);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(347, 20);
			this.txtName.StyleController = this.lc;
			this.txtName.TabIndex = 40;
			// 
			// lcItemDescription
			// 
			this.lcItemDescription.Control = this.memDescription;
			this.lcItemDescription.Location = new System.Drawing.Point(0, 119);
			this.lcItemDescription.Name = "lcItemDescription";
			this.lcItemDescription.Size = new System.Drawing.Size(480, 103);
			this.lcItemDescription.TextSize = new System.Drawing.Size(125, 14);
			// 
			// memDescription
			// 
			this.memDescription.Location = new System.Drawing.Point(140, 130);
			this.memDescription.Name = "memDescription";
			this.memDescription.Size = new System.Drawing.Size(347, 99);
			this.memDescription.StyleController = this.lc;
			this.memDescription.TabIndex = 43;
			// 
			// lcItemUseYn
			// 
			this.lcItemUseYn.Control = this.chkUseYn;
			this.lcItemUseYn.Location = new System.Drawing.Point(0, 96);
			this.lcItemUseYn.Name = "lcItemUseYn";
			this.lcItemUseYn.Size = new System.Drawing.Size(480, 23);
			this.lcItemUseYn.TextSize = new System.Drawing.Size(125, 14);
			// 
			// chkUseYn
			// 
			this.chkUseYn.Location = new System.Drawing.Point(140, 107);
			this.chkUseYn.Name = "chkUseYn";
			this.chkUseYn.Properties.Caption = "";
			this.chkUseYn.Size = new System.Drawing.Size(347, 19);
			this.chkUseYn.StyleController = this.lc;
			this.chkUseYn.TabIndex = 44;
			// 
			// lcItemCode
			// 
			this.lcItemCode.Control = this.txtCode;
			this.lcItemCode.Location = new System.Drawing.Point(0, 72);
			this.lcItemCode.Name = "lcItemCode";
			this.lcItemCode.Size = new System.Drawing.Size(480, 24);
			this.lcItemCode.TextSize = new System.Drawing.Size(125, 14);
			// 
			// txtCode
			// 
			this.txtCode.Location = new System.Drawing.Point(140, 83);
			this.txtCode.Name = "txtCode";
			this.txtCode.Size = new System.Drawing.Size(347, 20);
			this.txtCode.StyleController = this.lc;
			this.txtCode.TabIndex = 45;
			// 
			// lcItemAttributeType
			// 
			this.lcItemAttributeType.Control = this.lupAttributeTypeID;
			this.lcItemAttributeType.Location = new System.Drawing.Point(0, 24);
			this.lcItemAttributeType.Name = "lcItemAttributeType";
			this.lcItemAttributeType.Size = new System.Drawing.Size(480, 24);
			this.lcItemAttributeType.TextSize = new System.Drawing.Size(125, 14);
			// 
			// lupAttributeTypeID
			// 
			this.lupAttributeTypeID.DisplayMember = "";
			this.lupAttributeTypeID.GroupCode = null;
			this.lupAttributeTypeID.ListMember = "ListName";
			this.lupAttributeTypeID.Location = new System.Drawing.Point(140, 35);
			this.lupAttributeTypeID.Name = "lupAttributeTypeID";
			this.lupAttributeTypeID.NullText = "[EditValue is null]";
			this.lupAttributeTypeID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Redo, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), "재구성")});
			this.lupAttributeTypeID.SelectedIndex = -1;
			this.lupAttributeTypeID.Size = new System.Drawing.Size(347, 20);
			this.lupAttributeTypeID.StyleController = this.lc;
			this.lupAttributeTypeID.TabIndex = 46;
			this.lupAttributeTypeID.ValueMember = "";
			// 
			// lcGroupRegInfo
			// 
			this.lcGroupRegInfo.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcItemCreatedOn,
            this.lcItemCreatedByName,
            this.lcItemUpdatedOn,
            this.lcItemUpdatedByName});
			this.lcGroupRegInfo.Location = new System.Drawing.Point(0, 236);
			this.lcGroupRegInfo.Name = "lcGroupRegInfo";
			this.lcGroupRegInfo.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
			this.lcGroupRegInfo.Size = new System.Drawing.Size(494, 62);
			this.lcGroupRegInfo.TextVisible = false;
			// 
			// lcItemCreatedOn
			// 
			this.lcItemCreatedOn.Control = this.txtCreatedOn;
			this.lcItemCreatedOn.Location = new System.Drawing.Point(0, 0);
			this.lcItemCreatedOn.Name = "lcItemCreatedOn";
			this.lcItemCreatedOn.Size = new System.Drawing.Size(239, 24);
			this.lcItemCreatedOn.TextSize = new System.Drawing.Size(125, 14);
			// 
			// txtCreatedOn
			// 
			this.txtCreatedOn.Location = new System.Drawing.Point(140, 247);
			this.txtCreatedOn.Name = "txtCreatedOn";
			this.txtCreatedOn.Size = new System.Drawing.Size(106, 20);
			this.txtCreatedOn.StyleController = this.lc;
			this.txtCreatedOn.TabIndex = 10;
			// 
			// lcItemCreatedByName
			// 
			this.lcItemCreatedByName.Control = this.txtCreatedByName;
			this.lcItemCreatedByName.Location = new System.Drawing.Point(0, 24);
			this.lcItemCreatedByName.Name = "lcItemCreatedByName";
			this.lcItemCreatedByName.Size = new System.Drawing.Size(239, 24);
			this.lcItemCreatedByName.TextSize = new System.Drawing.Size(125, 14);
			// 
			// txtCreatedByName
			// 
			this.txtCreatedByName.Location = new System.Drawing.Point(140, 271);
			this.txtCreatedByName.Name = "txtCreatedByName";
			this.txtCreatedByName.Size = new System.Drawing.Size(106, 20);
			this.txtCreatedByName.StyleController = this.lc;
			this.txtCreatedByName.TabIndex = 11;
			// 
			// lcItemUpdatedOn
			// 
			this.lcItemUpdatedOn.Control = this.txtUpdatedOn;
			this.lcItemUpdatedOn.Location = new System.Drawing.Point(239, 0);
			this.lcItemUpdatedOn.Name = "lcItemUpdatedOn";
			this.lcItemUpdatedOn.Size = new System.Drawing.Size(241, 24);
			this.lcItemUpdatedOn.TextSize = new System.Drawing.Size(125, 14);
			// 
			// txtUpdatedOn
			// 
			this.txtUpdatedOn.Location = new System.Drawing.Point(379, 247);
			this.txtUpdatedOn.Name = "txtUpdatedOn";
			this.txtUpdatedOn.Size = new System.Drawing.Size(108, 20);
			this.txtUpdatedOn.StyleController = this.lc;
			this.txtUpdatedOn.TabIndex = 12;
			// 
			// lcItemUpdatedByName
			// 
			this.lcItemUpdatedByName.Control = this.txtUpdatedByName;
			this.lcItemUpdatedByName.Location = new System.Drawing.Point(239, 24);
			this.lcItemUpdatedByName.Name = "lcItemUpdatedByName";
			this.lcItemUpdatedByName.Size = new System.Drawing.Size(241, 24);
			this.lcItemUpdatedByName.TextSize = new System.Drawing.Size(125, 14);
			// 
			// txtUpdatedByName
			// 
			this.txtUpdatedByName.Location = new System.Drawing.Point(379, 271);
			this.txtUpdatedByName.Name = "txtUpdatedByName";
			this.txtUpdatedByName.Size = new System.Drawing.Size(108, 20);
			this.txtUpdatedByName.StyleController = this.lc;
			this.txtUpdatedByName.TabIndex = 13;
			// 
			// lcGroupEditBase
			// 
			this.lcGroupEditBase.GroupBordersVisible = false;
			this.lcGroupEditBase.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcGroupEdit1,
            this.lcGroupRegInfo});
			this.lcGroupEditBase.Location = new System.Drawing.Point(0, 0);
			this.lcGroupEditBase.Name = "lcGroupEditBase";
			this.lcGroupEditBase.Size = new System.Drawing.Size(494, 298);
			this.lcGroupEditBase.TextVisible = false;
			// 
			// AttributeEditForm
			// 
			this.Appearance.BackColor = System.Drawing.Color.White;
			this.Appearance.Options.UseBackColor = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(498, 368);
			this.LookAndFeel.SkinName = "Office 2016 Dark";
			this.Name = "AttributeEditForm";
			this.Text = "AttributeEditForm";
			((System.ComponentModel.ISupportInitialize)(this.lc)).EndInit();
			this.lc.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupEdit1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemID)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemName)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemDescription)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.memDescription.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemUseYn)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.chkUseYn.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemCode)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemAttributeType)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lupAttributeTypeID.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupRegInfo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemCreatedOn)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtCreatedOn.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemCreatedByName)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtCreatedByName.Properties)).EndInit();
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
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupRegInfo;
		private DevExpress.XtraEditors.TextEdit txtUpdatedByName;
		private DevExpress.XtraEditors.TextEdit txtUpdatedOn;
		private DevExpress.XtraEditors.TextEdit txtCreatedByName;
		private DevExpress.XtraEditors.TextEdit txtCreatedOn;
		private DevExpress.XtraLayout.LayoutControlItem lcItemCreatedOn;
		private DevExpress.XtraLayout.LayoutControlItem lcItemCreatedByName;
		private DevExpress.XtraLayout.LayoutControlItem lcItemUpdatedOn;
		private DevExpress.XtraLayout.LayoutControlItem lcItemUpdatedByName;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupEditBase;
		private DevExpress.XtraEditors.TextEdit txtName;
		private DevExpress.XtraEditors.TextEdit txtID;
		private DevExpress.XtraLayout.LayoutControlItem lcItemID;
		private DevExpress.XtraLayout.LayoutControlItem lcItemName;
		private DevExpress.XtraEditors.CheckEdit chkUseYn;
		private DevExpress.XtraEditors.MemoEdit memDescription;
		private DevExpress.XtraLayout.LayoutControlItem lcItemDescription;
		private DevExpress.XtraLayout.LayoutControlItem lcItemUseYn;
		private DevExpress.XtraEditors.TextEdit txtCode;
		private DevExpress.XtraLayout.LayoutControlItem lcItemCode;
		private Core.Controls.Common.XLookup lupAttributeTypeID;
		private DevExpress.XtraLayout.LayoutControlItem lcItemAttributeType;
	}
}