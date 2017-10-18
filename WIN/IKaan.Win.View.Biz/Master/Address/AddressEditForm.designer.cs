namespace IKaan.Win.View.Biz.Master.Address
{
	partial class AddressEditForm
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
			DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions2 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
			this.lcGroupEdit1 = new DevExpress.XtraLayout.LayoutControlGroup();
			this.lcItemStateProvince = new DevExpress.XtraLayout.LayoutControlItem();
			this.txtStateProvince = new DevExpress.XtraEditors.TextEdit();
			this.lcItemAddressLine1 = new DevExpress.XtraLayout.LayoutControlItem();
			this.txtAddressLine1 = new DevExpress.XtraEditors.TextEdit();
			this.lcItemAddressLine2 = new DevExpress.XtraLayout.LayoutControlItem();
			this.txtAddressLine2 = new DevExpress.XtraEditors.TextEdit();
			this.lcItemCountry = new DevExpress.XtraLayout.LayoutControlItem();
			this.lupCountry = new IKaan.Win.Core.Controls.Common.XLookup();
			this.lcItemCity = new DevExpress.XtraLayout.LayoutControlItem();
			this.txtCity = new DevExpress.XtraEditors.TextEdit();
			this.lcItemPostalCode = new DevExpress.XtraLayout.LayoutControlItem();
			this.txtPostalCode = new DevExpress.XtraEditors.ButtonEdit();
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
			this.lcGroupEdit2 = new DevExpress.XtraLayout.LayoutControlGroup();
			((System.ComponentModel.ISupportInitialize)(this.lc)).BeginInit();
			this.lc.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupEdit1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemStateProvince)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtStateProvince.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemAddressLine1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtAddressLine1.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemAddressLine2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtAddressLine2.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemCountry)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lupCountry.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemCity)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtCity.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemPostalCode)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtPostalCode.Properties)).BeginInit();
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
			((System.ComponentModel.ISupportInitialize)(this.lcGroupEdit2)).BeginInit();
			this.SuspendLayout();
			// 
			// lc
			// 
			this.lc.Controls.Add(this.txtPostalCode);
			this.lc.Controls.Add(this.lupCountry);
			this.lc.Controls.Add(this.txtAddressLine2);
			this.lc.Controls.Add(this.txtAddressLine1);
			this.lc.Controls.Add(this.txtStateProvince);
			this.lc.Controls.Add(this.txtCity);
			this.lc.Controls.Add(this.txtUpdatedByName);
			this.lc.Controls.Add(this.txtUpdatedOn);
			this.lc.Controls.Add(this.txtCreatedByName);
			this.lc.Controls.Add(this.txtCreatedOn);
			this.lc.Location = new System.Drawing.Point(0, 44);
			this.lc.Margin = new System.Windows.Forms.Padding(0);
			this.lc.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(930, 470, 457, 350);
			this.lc.OptionsView.UseDefaultDragAndDropRendering = false;
			this.lc.Padding = new System.Windows.Forms.Padding(2);
			this.lc.Size = new System.Drawing.Size(598, 202);
			// 
			// lcGroupBase
			// 
			this.lcGroupBase.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcGroupEditBase});
			this.lcGroupBase.Name = "Root";
			this.lcGroupBase.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
			this.lcGroupBase.Size = new System.Drawing.Size(598, 202);
			// 
			// lcGroupEdit1
			// 
			this.lcGroupEdit1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcItemAddressLine1,
            this.lcItemAddressLine2,
            this.lcItemCity,
            this.lcItemPostalCode,
            this.lcItemCountry,
            this.lcItemStateProvince});
			this.lcGroupEdit1.Location = new System.Drawing.Point(0, 0);
			this.lcGroupEdit1.Name = "lcGroupEdit1";
			this.lcGroupEdit1.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
			this.lcGroupEdit1.Size = new System.Drawing.Size(594, 110);
			this.lcGroupEdit1.TextVisible = false;
			// 
			// lcItemStateProvince
			// 
			this.lcItemStateProvince.Control = this.txtStateProvince;
			this.lcItemStateProvince.Location = new System.Drawing.Point(290, 24);
			this.lcItemStateProvince.Name = "lcItemStateProvince";
			this.lcItemStateProvince.Size = new System.Drawing.Size(290, 24);
			this.lcItemStateProvince.TextSize = new System.Drawing.Size(125, 14);
			// 
			// txtStateProvince
			// 
			this.txtStateProvince.Location = new System.Drawing.Point(430, 35);
			this.txtStateProvince.Name = "txtStateProvince";
			this.txtStateProvince.Size = new System.Drawing.Size(157, 20);
			this.txtStateProvince.StyleController = this.lc;
			this.txtStateProvince.TabIndex = 37;
			// 
			// lcItemAddressLine1
			// 
			this.lcItemAddressLine1.Control = this.txtAddressLine1;
			this.lcItemAddressLine1.Location = new System.Drawing.Point(0, 48);
			this.lcItemAddressLine1.Name = "lcItemAddressLine1";
			this.lcItemAddressLine1.Size = new System.Drawing.Size(580, 24);
			this.lcItemAddressLine1.TextSize = new System.Drawing.Size(125, 14);
			// 
			// txtAddressLine1
			// 
			this.txtAddressLine1.Location = new System.Drawing.Point(140, 59);
			this.txtAddressLine1.Name = "txtAddressLine1";
			this.txtAddressLine1.Size = new System.Drawing.Size(447, 20);
			this.txtAddressLine1.StyleController = this.lc;
			this.txtAddressLine1.TabIndex = 39;
			// 
			// lcItemAddressLine2
			// 
			this.lcItemAddressLine2.Control = this.txtAddressLine2;
			this.lcItemAddressLine2.Location = new System.Drawing.Point(0, 72);
			this.lcItemAddressLine2.Name = "lcItemAddressLine2";
			this.lcItemAddressLine2.Size = new System.Drawing.Size(580, 24);
			this.lcItemAddressLine2.TextSize = new System.Drawing.Size(125, 14);
			// 
			// txtAddressLine2
			// 
			this.txtAddressLine2.Location = new System.Drawing.Point(140, 83);
			this.txtAddressLine2.Name = "txtAddressLine2";
			this.txtAddressLine2.Size = new System.Drawing.Size(447, 20);
			this.txtAddressLine2.StyleController = this.lc;
			this.txtAddressLine2.TabIndex = 40;
			// 
			// lcItemCountry
			// 
			this.lcItemCountry.Control = this.lupCountry;
			this.lcItemCountry.Location = new System.Drawing.Point(290, 0);
			this.lcItemCountry.Name = "lcItemCountry";
			this.lcItemCountry.Size = new System.Drawing.Size(290, 24);
			this.lcItemCountry.TextSize = new System.Drawing.Size(125, 14);
			// 
			// lupCountry
			// 
			this.lupCountry.DisplayMember = "";
			this.lupCountry.GroupCode = null;
			this.lupCountry.ListMember = "ListName";
			this.lupCountry.Location = new System.Drawing.Point(430, 11);
			this.lupCountry.Name = "lupCountry";
			this.lupCountry.NullText = "[EditValue is null]";
			this.lupCountry.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Redo, "", -1, true, true, false, editorButtonImageOptions2, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), "재구성")});
			this.lupCountry.SelectedIndex = -1;
			this.lupCountry.Size = new System.Drawing.Size(157, 20);
			this.lupCountry.StyleController = this.lc;
			this.lupCountry.TabIndex = 41;
			this.lupCountry.ValueMember = "";
			// 
			// lcItemCity
			// 
			this.lcItemCity.Control = this.txtCity;
			this.lcItemCity.Location = new System.Drawing.Point(0, 24);
			this.lcItemCity.Name = "lcItemCity";
			this.lcItemCity.Size = new System.Drawing.Size(290, 24);
			this.lcItemCity.TextSize = new System.Drawing.Size(125, 14);
			// 
			// txtCity
			// 
			this.txtCity.Location = new System.Drawing.Point(140, 35);
			this.txtCity.Name = "txtCity";
			this.txtCity.Size = new System.Drawing.Size(157, 20);
			this.txtCity.StyleController = this.lc;
			this.txtCity.TabIndex = 35;
			// 
			// lcItemPostalCode
			// 
			this.lcItemPostalCode.Control = this.txtPostalCode;
			this.lcItemPostalCode.Location = new System.Drawing.Point(0, 0);
			this.lcItemPostalCode.Name = "lcItemPostalCode";
			this.lcItemPostalCode.Size = new System.Drawing.Size(290, 24);
			this.lcItemPostalCode.TextSize = new System.Drawing.Size(125, 14);
			// 
			// txtPostalCode
			// 
			this.txtPostalCode.Location = new System.Drawing.Point(140, 11);
			this.txtPostalCode.Name = "txtPostalCode";
			this.txtPostalCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
			this.txtPostalCode.Size = new System.Drawing.Size(157, 20);
			this.txtPostalCode.StyleController = this.lc;
			this.txtPostalCode.TabIndex = 42;
			// 
			// lcGroupRegInfo
			// 
			this.lcGroupRegInfo.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcItemCreatedOn,
            this.lcItemCreatedByName,
            this.lcItemUpdatedOn,
            this.lcItemUpdatedByName});
			this.lcGroupRegInfo.Location = new System.Drawing.Point(0, 110);
			this.lcGroupRegInfo.Name = "lcGroupRegInfo";
			this.lcGroupRegInfo.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
			this.lcGroupRegInfo.Size = new System.Drawing.Size(594, 62);
			this.lcGroupRegInfo.TextVisible = false;
			// 
			// lcItemCreatedOn
			// 
			this.lcItemCreatedOn.Control = this.txtCreatedOn;
			this.lcItemCreatedOn.Location = new System.Drawing.Point(0, 0);
			this.lcItemCreatedOn.Name = "lcItemCreatedOn";
			this.lcItemCreatedOn.Size = new System.Drawing.Size(289, 24);
			this.lcItemCreatedOn.TextSize = new System.Drawing.Size(125, 14);
			// 
			// txtCreatedOn
			// 
			this.txtCreatedOn.Location = new System.Drawing.Point(140, 121);
			this.txtCreatedOn.Name = "txtCreatedOn";
			this.txtCreatedOn.Size = new System.Drawing.Size(156, 20);
			this.txtCreatedOn.StyleController = this.lc;
			this.txtCreatedOn.TabIndex = 10;
			// 
			// lcItemCreatedByName
			// 
			this.lcItemCreatedByName.Control = this.txtCreatedByName;
			this.lcItemCreatedByName.Location = new System.Drawing.Point(0, 24);
			this.lcItemCreatedByName.Name = "lcItemCreatedByName";
			this.lcItemCreatedByName.Size = new System.Drawing.Size(289, 24);
			this.lcItemCreatedByName.TextSize = new System.Drawing.Size(125, 14);
			// 
			// txtCreatedByName
			// 
			this.txtCreatedByName.Location = new System.Drawing.Point(140, 145);
			this.txtCreatedByName.Name = "txtCreatedByName";
			this.txtCreatedByName.Size = new System.Drawing.Size(156, 20);
			this.txtCreatedByName.StyleController = this.lc;
			this.txtCreatedByName.TabIndex = 11;
			// 
			// lcItemUpdatedOn
			// 
			this.lcItemUpdatedOn.Control = this.txtUpdatedOn;
			this.lcItemUpdatedOn.Location = new System.Drawing.Point(289, 0);
			this.lcItemUpdatedOn.Name = "lcItemUpdatedOn";
			this.lcItemUpdatedOn.Size = new System.Drawing.Size(291, 24);
			this.lcItemUpdatedOn.TextSize = new System.Drawing.Size(125, 14);
			// 
			// txtUpdatedOn
			// 
			this.txtUpdatedOn.Location = new System.Drawing.Point(429, 121);
			this.txtUpdatedOn.Name = "txtUpdatedOn";
			this.txtUpdatedOn.Size = new System.Drawing.Size(158, 20);
			this.txtUpdatedOn.StyleController = this.lc;
			this.txtUpdatedOn.TabIndex = 12;
			// 
			// lcItemUpdatedByName
			// 
			this.lcItemUpdatedByName.Control = this.txtUpdatedByName;
			this.lcItemUpdatedByName.Location = new System.Drawing.Point(289, 24);
			this.lcItemUpdatedByName.Name = "lcItemUpdatedByName";
			this.lcItemUpdatedByName.Size = new System.Drawing.Size(291, 24);
			this.lcItemUpdatedByName.TextSize = new System.Drawing.Size(125, 14);
			// 
			// txtUpdatedByName
			// 
			this.txtUpdatedByName.Location = new System.Drawing.Point(429, 145);
			this.txtUpdatedByName.Name = "txtUpdatedByName";
			this.txtUpdatedByName.Size = new System.Drawing.Size(158, 20);
			this.txtUpdatedByName.StyleController = this.lc;
			this.txtUpdatedByName.TabIndex = 13;
			// 
			// lcGroupEditBase
			// 
			this.lcGroupEditBase.GroupBordersVisible = false;
			this.lcGroupEditBase.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcGroupEdit1,
            this.lcGroupRegInfo,
            this.lcGroupEdit2});
			this.lcGroupEditBase.Location = new System.Drawing.Point(0, 0);
			this.lcGroupEditBase.Name = "lcGroupEditBase";
			this.lcGroupEditBase.Size = new System.Drawing.Size(594, 198);
			this.lcGroupEditBase.TextVisible = false;
			// 
			// lcGroupEdit2
			// 
			this.lcGroupEdit2.Location = new System.Drawing.Point(0, 172);
			this.lcGroupEdit2.Name = "lcGroupEdit2";
			this.lcGroupEdit2.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
			this.lcGroupEdit2.Size = new System.Drawing.Size(594, 26);
			this.lcGroupEdit2.Text = "거래처매핑";
			this.lcGroupEdit2.TextVisible = false;
			// 
			// AddressEditForm
			// 
			this.Appearance.BackColor = System.Drawing.Color.White;
			this.Appearance.Options.UseBackColor = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(598, 268);
			this.LookAndFeel.SkinName = "Office 2016 Dark";
			this.Name = "AddressEditForm";
			this.Text = "AddressEditForm";
			((System.ComponentModel.ISupportInitialize)(this.lc)).EndInit();
			this.lc.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupEdit1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemStateProvince)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtStateProvince.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemAddressLine1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtAddressLine1.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemAddressLine2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtAddressLine2.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemCountry)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lupCountry.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemCity)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtCity.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemPostalCode)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtPostalCode.Properties)).EndInit();
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
			((System.ComponentModel.ISupportInitialize)(this.lcGroupEdit2)).EndInit();
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
		private Core.Controls.Common.XLookup lupCountry;
		private DevExpress.XtraEditors.TextEdit txtAddressLine2;
		private DevExpress.XtraEditors.TextEdit txtAddressLine1;
		private DevExpress.XtraEditors.TextEdit txtStateProvince;
		private DevExpress.XtraEditors.TextEdit txtCity;
		private DevExpress.XtraLayout.LayoutControlItem lcItemStateProvince;
		private DevExpress.XtraLayout.LayoutControlItem lcItemAddressLine1;
		private DevExpress.XtraLayout.LayoutControlItem lcItemAddressLine2;
		private DevExpress.XtraLayout.LayoutControlItem lcItemCountry;
		private DevExpress.XtraLayout.LayoutControlItem lcItemCity;
		private DevExpress.XtraEditors.ButtonEdit txtPostalCode;
		private DevExpress.XtraLayout.LayoutControlItem lcItemPostalCode;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupEdit2;
	}
}