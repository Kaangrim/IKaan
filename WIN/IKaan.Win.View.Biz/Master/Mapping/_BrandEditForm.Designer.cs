namespace IKaan.Win.View.Biz.Master.Mapping
{
	partial class _BrandEditForm
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
			DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions3 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
			this.lcGroupEdit1 = new DevExpress.XtraLayout.LayoutControlGroup();
			this.lcGroupRegInfo = new DevExpress.XtraLayout.LayoutControlGroup();
			this.lcItemCreatedOn = new DevExpress.XtraLayout.LayoutControlItem();
			this.txtCreatedOn = new DevExpress.XtraEditors.TextEdit();
			this.lcItemCreatedByName = new DevExpress.XtraLayout.LayoutControlItem();
			this.txtCreatedByName = new DevExpress.XtraEditors.TextEdit();
			this.lcItemUpdatedOn = new DevExpress.XtraLayout.LayoutControlItem();
			this.txtUpdatedOn = new DevExpress.XtraEditors.TextEdit();
			this.lcItemUpdatedByName = new DevExpress.XtraLayout.LayoutControlItem();
			this.txtUpdatedByName = new DevExpress.XtraEditors.TextEdit();
			this.lcGroupEdit2 = new DevExpress.XtraLayout.LayoutControlGroup();
			this.lcItemStartDate = new DevExpress.XtraLayout.LayoutControlItem();
			this.datStartDate = new DevExpress.XtraEditors.DateEdit();
			this.memDescription = new DevExpress.XtraEditors.MemoEdit();
			this.lcItemDescription = new DevExpress.XtraLayout.LayoutControlItem();
			this.lcGroupEdit3 = new DevExpress.XtraLayout.LayoutControlGroup();
			this.lupCustomerID = new IKaan.Win.Core.Controls.Common.XLookup();
			this.lcItemCustomer = new DevExpress.XtraLayout.LayoutControlItem();
			this.lupBrandID = new IKaan.Win.Core.Controls.Common.XLookup();
			this.lcItemBrand = new DevExpress.XtraLayout.LayoutControlItem();
			this.datEndDate = new DevExpress.XtraEditors.DateEdit();
			this.lcItemEndDate = new DevExpress.XtraLayout.LayoutControlItem();
			((System.ComponentModel.ISupportInitialize)(this.lc)).BeginInit();
			this.lc.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupEdit1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupRegInfo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemCreatedOn)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtCreatedOn.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemCreatedByName)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtCreatedByName.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemUpdatedOn)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtUpdatedOn.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemUpdatedByName)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtUpdatedByName.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupEdit2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemStartDate)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.datStartDate.Properties.CalendarTimeProperties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.datStartDate.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.memDescription.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemDescription)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupEdit3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lupCustomerID.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemCustomer)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lupBrandID.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemBrand)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.datEndDate.Properties.CalendarTimeProperties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.datEndDate.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemEndDate)).BeginInit();
			this.SuspendLayout();
			// 
			// lc
			// 
			this.lc.Controls.Add(this.datEndDate);
			this.lc.Controls.Add(this.lupBrandID);
			this.lc.Controls.Add(this.lupCustomerID);
			this.lc.Controls.Add(this.datStartDate);
			this.lc.Controls.Add(this.memDescription);
			this.lc.Controls.Add(this.txtUpdatedByName);
			this.lc.Controls.Add(this.txtUpdatedOn);
			this.lc.Controls.Add(this.txtCreatedByName);
			this.lc.Controls.Add(this.txtCreatedOn);
			this.lc.Location = new System.Drawing.Point(0, 44);
			this.lc.Margin = new System.Windows.Forms.Padding(0);
			this.lc.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1074, 289, 450, 400);
			this.lc.OptionsView.UseDefaultDragAndDropRendering = false;
			this.lc.Padding = new System.Windows.Forms.Padding(2);
			this.lc.Size = new System.Drawing.Size(498, 252);
			// 
			// lcGroupBase
			// 
			this.lcGroupBase.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcGroupEdit1,
            this.lcGroupRegInfo,
            this.lcGroupEdit2,
            this.lcGroupEdit3});
			this.lcGroupBase.Name = "Root";
			this.lcGroupBase.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
			this.lcGroupBase.Size = new System.Drawing.Size(498, 252);
			// 
			// lcGroupEdit1
			// 
			this.lcGroupEdit1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcItemCustomer});
			this.lcGroupEdit1.Location = new System.Drawing.Point(0, 0);
			this.lcGroupEdit1.Name = "lcGroupEdit1";
			this.lcGroupEdit1.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
			this.lcGroupEdit1.Size = new System.Drawing.Size(494, 38);
			this.lcGroupEdit1.TextVisible = false;
			// 
			// lcGroupRegInfo
			// 
			this.lcGroupRegInfo.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcItemCreatedOn,
            this.lcItemCreatedByName,
            this.lcItemUpdatedOn,
            this.lcItemUpdatedByName});
			this.lcGroupRegInfo.Location = new System.Drawing.Point(0, 186);
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
			this.lcItemCreatedOn.Size = new System.Drawing.Size(240, 24);
			this.lcItemCreatedOn.TextSize = new System.Drawing.Size(125, 14);
			// 
			// txtCreatedOn
			// 
			this.txtCreatedOn.Location = new System.Drawing.Point(140, 197);
			this.txtCreatedOn.Name = "txtCreatedOn";
			this.txtCreatedOn.Size = new System.Drawing.Size(107, 20);
			this.txtCreatedOn.StyleController = this.lc;
			this.txtCreatedOn.TabIndex = 4;
			// 
			// lcItemCreatedByName
			// 
			this.lcItemCreatedByName.Control = this.txtCreatedByName;
			this.lcItemCreatedByName.Location = new System.Drawing.Point(0, 24);
			this.lcItemCreatedByName.Name = "lcItemCreatedByName";
			this.lcItemCreatedByName.Size = new System.Drawing.Size(240, 24);
			this.lcItemCreatedByName.TextSize = new System.Drawing.Size(125, 14);
			// 
			// txtCreatedByName
			// 
			this.txtCreatedByName.Location = new System.Drawing.Point(140, 221);
			this.txtCreatedByName.Name = "txtCreatedByName";
			this.txtCreatedByName.Size = new System.Drawing.Size(107, 20);
			this.txtCreatedByName.StyleController = this.lc;
			this.txtCreatedByName.TabIndex = 5;
			// 
			// lcItemUpdatedOn
			// 
			this.lcItemUpdatedOn.Control = this.txtUpdatedOn;
			this.lcItemUpdatedOn.Location = new System.Drawing.Point(240, 0);
			this.lcItemUpdatedOn.Name = "lcItemUpdatedOn";
			this.lcItemUpdatedOn.Size = new System.Drawing.Size(240, 24);
			this.lcItemUpdatedOn.TextSize = new System.Drawing.Size(125, 14);
			// 
			// txtUpdatedOn
			// 
			this.txtUpdatedOn.Location = new System.Drawing.Point(380, 197);
			this.txtUpdatedOn.Name = "txtUpdatedOn";
			this.txtUpdatedOn.Size = new System.Drawing.Size(107, 20);
			this.txtUpdatedOn.StyleController = this.lc;
			this.txtUpdatedOn.TabIndex = 6;
			// 
			// lcItemUpdatedByName
			// 
			this.lcItemUpdatedByName.Control = this.txtUpdatedByName;
			this.lcItemUpdatedByName.Location = new System.Drawing.Point(240, 24);
			this.lcItemUpdatedByName.Name = "lcItemUpdatedByName";
			this.lcItemUpdatedByName.Size = new System.Drawing.Size(240, 24);
			this.lcItemUpdatedByName.TextSize = new System.Drawing.Size(125, 14);
			// 
			// txtUpdatedByName
			// 
			this.txtUpdatedByName.Location = new System.Drawing.Point(380, 221);
			this.txtUpdatedByName.Name = "txtUpdatedByName";
			this.txtUpdatedByName.Size = new System.Drawing.Size(107, 20);
			this.txtUpdatedByName.StyleController = this.lc;
			this.txtUpdatedByName.TabIndex = 7;
			// 
			// lcGroupEdit2
			// 
			this.lcGroupEdit2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcItemStartDate,
            this.lcItemBrand,
            this.lcItemEndDate});
			this.lcGroupEdit2.Location = new System.Drawing.Point(0, 38);
			this.lcGroupEdit2.Name = "lcGroupEdit2";
			this.lcGroupEdit2.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
			this.lcGroupEdit2.Size = new System.Drawing.Size(494, 62);
			this.lcGroupEdit2.TextVisible = false;
			// 
			// lcItemStartDate
			// 
			this.lcItemStartDate.Control = this.datStartDate;
			this.lcItemStartDate.Location = new System.Drawing.Point(0, 24);
			this.lcItemStartDate.Name = "lcItemStartDate";
			this.lcItemStartDate.Size = new System.Drawing.Size(240, 24);
			this.lcItemStartDate.TextSize = new System.Drawing.Size(125, 14);
			// 
			// datStartDate
			// 
			this.datStartDate.EditValue = null;
			this.datStartDate.Location = new System.Drawing.Point(140, 73);
			this.datStartDate.Name = "datStartDate";
			this.datStartDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.datStartDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.datStartDate.Size = new System.Drawing.Size(107, 20);
			this.datStartDate.StyleController = this.lc;
			this.datStartDate.TabIndex = 29;
			// 
			// memDescription
			// 
			this.memDescription.Location = new System.Drawing.Point(140, 111);
			this.memDescription.Name = "memDescription";
			this.memDescription.Size = new System.Drawing.Size(347, 68);
			this.memDescription.StyleController = this.lc;
			this.memDescription.TabIndex = 28;
			// 
			// lcItemDescription
			// 
			this.lcItemDescription.Control = this.memDescription;
			this.lcItemDescription.Location = new System.Drawing.Point(0, 0);
			this.lcItemDescription.Name = "lcItemDescription";
			this.lcItemDescription.Size = new System.Drawing.Size(480, 72);
			this.lcItemDescription.TextSize = new System.Drawing.Size(125, 14);
			// 
			// lcGroupEdit3
			// 
			this.lcGroupEdit3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcItemDescription});
			this.lcGroupEdit3.Location = new System.Drawing.Point(0, 100);
			this.lcGroupEdit3.Name = "lcGroupEdit3";
			this.lcGroupEdit3.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
			this.lcGroupEdit3.Size = new System.Drawing.Size(494, 86);
			this.lcGroupEdit3.TextVisible = false;
			// 
			// lupCustomerID
			// 
			this.lupCustomerID.DisplayMember = "";
			this.lupCustomerID.GroupCode = null;
			this.lupCustomerID.ListMember = "ListName";
			this.lupCustomerID.Location = new System.Drawing.Point(140, 11);
			this.lupCustomerID.Name = "lupCustomerID";
			this.lupCustomerID.NullText = "[EditValue is null]";
			this.lupCustomerID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Redo, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), "재구성")});
			this.lupCustomerID.SelectedIndex = -1;
			this.lupCustomerID.Size = new System.Drawing.Size(347, 20);
			this.lupCustomerID.StyleController = this.lc;
			this.lupCustomerID.TabIndex = 31;
			this.lupCustomerID.ValueMember = "";
			// 
			// lcItemCustomer
			// 
			this.lcItemCustomer.Control = this.lupCustomerID;
			this.lcItemCustomer.Location = new System.Drawing.Point(0, 0);
			this.lcItemCustomer.Name = "lcItemCustomer";
			this.lcItemCustomer.Size = new System.Drawing.Size(480, 24);
			this.lcItemCustomer.TextSize = new System.Drawing.Size(125, 14);
			// 
			// lupBrandID
			// 
			this.lupBrandID.DisplayMember = "";
			this.lupBrandID.GroupCode = null;
			this.lupBrandID.ListMember = "ListName";
			this.lupBrandID.Location = new System.Drawing.Point(140, 49);
			this.lupBrandID.Name = "lupBrandID";
			this.lupBrandID.NullText = "[EditValue is null]";
			this.lupBrandID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Redo, "", -1, true, true, false, editorButtonImageOptions3, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), "재구성")});
			this.lupBrandID.SelectedIndex = -1;
			this.lupBrandID.Size = new System.Drawing.Size(347, 20);
			this.lupBrandID.StyleController = this.lc;
			this.lupBrandID.TabIndex = 32;
			this.lupBrandID.ValueMember = "";
			// 
			// lcItemBrand
			// 
			this.lcItemBrand.Control = this.lupBrandID;
			this.lcItemBrand.Location = new System.Drawing.Point(0, 0);
			this.lcItemBrand.Name = "lcItemBrand";
			this.lcItemBrand.Size = new System.Drawing.Size(480, 24);
			this.lcItemBrand.TextSize = new System.Drawing.Size(125, 14);
			// 
			// datEndDate
			// 
			this.datEndDate.EditValue = null;
			this.datEndDate.Location = new System.Drawing.Point(380, 73);
			this.datEndDate.Name = "datEndDate";
			this.datEndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.datEndDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.datEndDate.Size = new System.Drawing.Size(107, 20);
			this.datEndDate.StyleController = this.lc;
			this.datEndDate.TabIndex = 33;
			// 
			// lcItemEndDate
			// 
			this.lcItemEndDate.Control = this.datEndDate;
			this.lcItemEndDate.Location = new System.Drawing.Point(240, 24);
			this.lcItemEndDate.Name = "lcItemEndDate";
			this.lcItemEndDate.Size = new System.Drawing.Size(240, 24);
			this.lcItemEndDate.TextSize = new System.Drawing.Size(125, 14);
			// 
			// _BrandEditForm
			// 
			this.Appearance.BackColor = System.Drawing.Color.White;
			this.Appearance.Options.UseBackColor = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(498, 318);
			this.LookAndFeel.SkinName = "Office 2016 Dark";
			this.Name = "_BrandEditForm";
			this.Text = "_BrandEditForm";
			((System.ComponentModel.ISupportInitialize)(this.lc)).EndInit();
			this.lc.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupEdit1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupRegInfo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemCreatedOn)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtCreatedOn.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemCreatedByName)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtCreatedByName.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemUpdatedOn)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtUpdatedOn.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemUpdatedByName)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtUpdatedByName.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupEdit2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemStartDate)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.datStartDate.Properties.CalendarTimeProperties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.datStartDate.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.memDescription.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemDescription)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupEdit3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lupCustomerID.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemCustomer)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lupBrandID.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemBrand)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.datEndDate.Properties.CalendarTimeProperties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.datEndDate.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemEndDate)).EndInit();
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
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupEdit2;
		private DevExpress.XtraEditors.MemoEdit memDescription;
		private DevExpress.XtraLayout.LayoutControlItem lcItemDescription;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupEdit3;
		private DevExpress.XtraEditors.DateEdit datStartDate;
		private DevExpress.XtraLayout.LayoutControlItem lcItemStartDate;
		private DevExpress.XtraEditors.DateEdit datEndDate;
		private Core.Controls.Common.XLookup lupBrandID;
		private Core.Controls.Common.XLookup lupCustomerID;
		private DevExpress.XtraLayout.LayoutControlItem lcItemCustomer;
		private DevExpress.XtraLayout.LayoutControlItem lcItemBrand;
		private DevExpress.XtraLayout.LayoutControlItem lcItemEndDate;
	}
}