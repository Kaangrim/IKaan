namespace IKaan.Win.View.Biz.Common
{
	partial class CustomerChannelEditForm
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
			this.lcItemCustomer = new DevExpress.XtraLayout.LayoutControlItem();
			this.txtCustomerID = new IKaan.Win.Core.Controls.Common.XSearch();
			this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.lcGroupRegInfo = new DevExpress.XtraLayout.LayoutControlGroup();
			this.lcItemCreateDate = new DevExpress.XtraLayout.LayoutControlItem();
			this.txtCreateDate = new DevExpress.XtraEditors.TextEdit();
			this.lcItemCreateByName = new DevExpress.XtraLayout.LayoutControlItem();
			this.txtCreateByName = new DevExpress.XtraEditors.TextEdit();
			this.lcItemUpdateDate = new DevExpress.XtraLayout.LayoutControlItem();
			this.txtUpdateDate = new DevExpress.XtraEditors.TextEdit();
			this.lcItemUpdateByName = new DevExpress.XtraLayout.LayoutControlItem();
			this.txtUpdateByName = new DevExpress.XtraEditors.TextEdit();
			this.lcGroupEdit2 = new DevExpress.XtraLayout.LayoutControlGroup();
			this.lcItemStartDate = new DevExpress.XtraLayout.LayoutControlItem();
			this.datStartDate = new DevExpress.XtraEditors.DateEdit();
			this.lcItemChannel = new DevExpress.XtraLayout.LayoutControlItem();
			this.txtChannelID = new IKaan.Win.Core.Controls.Common.XSearch();
			this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.memDescription = new DevExpress.XtraEditors.MemoEdit();
			this.lcItemDescription = new DevExpress.XtraLayout.LayoutControlItem();
			this.lcGroupEdit3 = new DevExpress.XtraLayout.LayoutControlGroup();
			((System.ComponentModel.ISupportInitialize)(this.lc)).BeginInit();
			this.lc.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupEdit1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemID)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemCustomer)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupRegInfo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemCreateDate)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtCreateDate.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemCreateByName)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtCreateByName.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemUpdateDate)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtUpdateDate.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemUpdateByName)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtUpdateByName.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupEdit2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemStartDate)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.datStartDate.Properties.CalendarTimeProperties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.datStartDate.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemChannel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.memDescription.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemDescription)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupEdit3)).BeginInit();
			this.SuspendLayout();
			// 
			// lc
			// 
			this.lc.Controls.Add(this.txtChannelID);
			this.lc.Controls.Add(this.datStartDate);
			this.lc.Controls.Add(this.memDescription);
			this.lc.Controls.Add(this.txtCustomerID);
			this.lc.Controls.Add(this.txtID);
			this.lc.Controls.Add(this.txtUpdateByName);
			this.lc.Controls.Add(this.txtUpdateDate);
			this.lc.Controls.Add(this.txtCreateByName);
			this.lc.Controls.Add(this.txtCreateDate);
			this.lc.Location = new System.Drawing.Point(0, 44);
			this.lc.Margin = new System.Windows.Forms.Padding(0);
			this.lc.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1074, 289, 450, 400);
			this.lc.OptionsView.UseDefaultDragAndDropRendering = false;
			this.lc.Padding = new System.Windows.Forms.Padding(2);
			this.lc.Size = new System.Drawing.Size(498, 302);
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
			this.lcGroupBase.Size = new System.Drawing.Size(498, 302);
			// 
			// lcGroupEdit1
			// 
			this.lcGroupEdit1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcItemID,
            this.lcItemCustomer,
            this.emptySpaceItem2});
			this.lcGroupEdit1.Location = new System.Drawing.Point(0, 0);
			this.lcGroupEdit1.Name = "lcGroupEdit1";
			this.lcGroupEdit1.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
			this.lcGroupEdit1.Size = new System.Drawing.Size(494, 62);
			this.lcGroupEdit1.TextVisible = false;
			// 
			// lcItemID
			// 
			this.lcItemID.Control = this.txtID;
			this.lcItemID.Location = new System.Drawing.Point(0, 0);
			this.lcItemID.Name = "lcItemID";
			this.lcItemID.Size = new System.Drawing.Size(240, 24);
			this.lcItemID.TextSize = new System.Drawing.Size(118, 14);
			// 
			// txtID
			// 
			this.txtID.Location = new System.Drawing.Point(133, 11);
			this.txtID.Name = "txtID";
			this.txtID.Size = new System.Drawing.Size(114, 20);
			this.txtID.StyleController = this.lc;
			this.txtID.TabIndex = 8;
			// 
			// lcItemCustomer
			// 
			this.lcItemCustomer.Control = this.txtCustomerID;
			this.lcItemCustomer.Location = new System.Drawing.Point(0, 24);
			this.lcItemCustomer.Name = "lcItemCustomer";
			this.lcItemCustomer.Size = new System.Drawing.Size(480, 24);
			this.lcItemCustomer.TextSize = new System.Drawing.Size(118, 14);
			// 
			// txtCustomerID
			// 
			this.txtCustomerID.CodeField = "Code";
			this.txtCustomerID.CodeGroup = "Codes";
			this.txtCustomerID.CodeWidth = 100;
			this.txtCustomerID.DisplayFields = new string[] {
        "Code",
        "Name"};
			this.txtCustomerID.EditText = null;
			this.txtCustomerID.EditValue = null;
			this.txtCustomerID.Location = new System.Drawing.Point(133, 35);
			this.txtCustomerID.MaximumSize = new System.Drawing.Size(0, 20);
			this.txtCustomerID.MinimumSize = new System.Drawing.Size(0, 20);
			this.txtCustomerID.Name = "txtCustomerID";
			this.txtCustomerID.NameField = "Name";
			this.txtCustomerID.Parameters = null;
			this.txtCustomerID.Size = new System.Drawing.Size(354, 20);
			this.txtCustomerID.TabIndex = 9;
			// 
			// emptySpaceItem2
			// 
			this.emptySpaceItem2.AllowHotTrack = false;
			this.emptySpaceItem2.Location = new System.Drawing.Point(240, 0);
			this.emptySpaceItem2.Name = "emptySpaceItem2";
			this.emptySpaceItem2.Size = new System.Drawing.Size(240, 24);
			this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
			// 
			// lcGroupRegInfo
			// 
			this.lcGroupRegInfo.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcItemCreateDate,
            this.lcItemCreateByName,
            this.lcItemUpdateDate,
            this.lcItemUpdateByName});
			this.lcGroupRegInfo.Location = new System.Drawing.Point(0, 236);
			this.lcGroupRegInfo.Name = "lcGroupRegInfo";
			this.lcGroupRegInfo.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
			this.lcGroupRegInfo.Size = new System.Drawing.Size(494, 62);
			this.lcGroupRegInfo.TextVisible = false;
			// 
			// lcItemCreateDate
			// 
			this.lcItemCreateDate.Control = this.txtCreateDate;
			this.lcItemCreateDate.Location = new System.Drawing.Point(0, 0);
			this.lcItemCreateDate.Name = "lcItemCreateDate";
			this.lcItemCreateDate.Size = new System.Drawing.Size(240, 24);
			this.lcItemCreateDate.TextSize = new System.Drawing.Size(118, 14);
			// 
			// txtCreateDate
			// 
			this.txtCreateDate.Location = new System.Drawing.Point(133, 247);
			this.txtCreateDate.Name = "txtCreateDate";
			this.txtCreateDate.Size = new System.Drawing.Size(114, 20);
			this.txtCreateDate.StyleController = this.lc;
			this.txtCreateDate.TabIndex = 4;
			// 
			// lcItemCreateByName
			// 
			this.lcItemCreateByName.Control = this.txtCreateByName;
			this.lcItemCreateByName.Location = new System.Drawing.Point(0, 24);
			this.lcItemCreateByName.Name = "lcItemCreateByName";
			this.lcItemCreateByName.Size = new System.Drawing.Size(240, 24);
			this.lcItemCreateByName.TextSize = new System.Drawing.Size(118, 14);
			// 
			// txtCreateByName
			// 
			this.txtCreateByName.Location = new System.Drawing.Point(133, 271);
			this.txtCreateByName.Name = "txtCreateByName";
			this.txtCreateByName.Size = new System.Drawing.Size(114, 20);
			this.txtCreateByName.StyleController = this.lc;
			this.txtCreateByName.TabIndex = 5;
			// 
			// lcItemUpdateDate
			// 
			this.lcItemUpdateDate.Control = this.txtUpdateDate;
			this.lcItemUpdateDate.Location = new System.Drawing.Point(240, 0);
			this.lcItemUpdateDate.Name = "lcItemUpdateDate";
			this.lcItemUpdateDate.Size = new System.Drawing.Size(240, 24);
			this.lcItemUpdateDate.TextSize = new System.Drawing.Size(118, 14);
			// 
			// txtUpdateDate
			// 
			this.txtUpdateDate.Location = new System.Drawing.Point(373, 247);
			this.txtUpdateDate.Name = "txtUpdateDate";
			this.txtUpdateDate.Size = new System.Drawing.Size(114, 20);
			this.txtUpdateDate.StyleController = this.lc;
			this.txtUpdateDate.TabIndex = 6;
			// 
			// lcItemUpdateByName
			// 
			this.lcItemUpdateByName.Control = this.txtUpdateByName;
			this.lcItemUpdateByName.Location = new System.Drawing.Point(240, 24);
			this.lcItemUpdateByName.Name = "lcItemUpdateByName";
			this.lcItemUpdateByName.Size = new System.Drawing.Size(240, 24);
			this.lcItemUpdateByName.TextSize = new System.Drawing.Size(118, 14);
			// 
			// txtUpdateByName
			// 
			this.txtUpdateByName.Location = new System.Drawing.Point(373, 271);
			this.txtUpdateByName.Name = "txtUpdateByName";
			this.txtUpdateByName.Size = new System.Drawing.Size(114, 20);
			this.txtUpdateByName.StyleController = this.lc;
			this.txtUpdateByName.TabIndex = 7;
			// 
			// lcGroupEdit2
			// 
			this.lcGroupEdit2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcItemStartDate,
            this.lcItemChannel,
            this.emptySpaceItem1});
			this.lcGroupEdit2.Location = new System.Drawing.Point(0, 62);
			this.lcGroupEdit2.Name = "lcGroupEdit2";
			this.lcGroupEdit2.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
			this.lcGroupEdit2.Size = new System.Drawing.Size(494, 62);
			this.lcGroupEdit2.TextVisible = false;
			// 
			// lcItemStartDate
			// 
			this.lcItemStartDate.Control = this.datStartDate;
			this.lcItemStartDate.Location = new System.Drawing.Point(0, 0);
			this.lcItemStartDate.Name = "lcItemStartDate";
			this.lcItemStartDate.Size = new System.Drawing.Size(240, 24);
			this.lcItemStartDate.TextSize = new System.Drawing.Size(118, 14);
			// 
			// datStartDate
			// 
			this.datStartDate.EditValue = null;
			this.datStartDate.Location = new System.Drawing.Point(133, 73);
			this.datStartDate.Name = "datStartDate";
			this.datStartDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.datStartDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.datStartDate.Size = new System.Drawing.Size(114, 20);
			this.datStartDate.StyleController = this.lc;
			this.datStartDate.TabIndex = 29;
			// 
			// lcItemChannel
			// 
			this.lcItemChannel.Control = this.txtChannelID;
			this.lcItemChannel.Location = new System.Drawing.Point(0, 24);
			this.lcItemChannel.Name = "lcItemChannel";
			this.lcItemChannel.Size = new System.Drawing.Size(480, 24);
			this.lcItemChannel.TextSize = new System.Drawing.Size(118, 14);
			// 
			// txtChannelID
			// 
			this.txtChannelID.CodeField = "Code";
			this.txtChannelID.CodeGroup = "Codes";
			this.txtChannelID.CodeWidth = 100;
			this.txtChannelID.DisplayFields = new string[] {
        "Code",
        "Name"};
			this.txtChannelID.EditText = null;
			this.txtChannelID.EditValue = null;
			this.txtChannelID.Location = new System.Drawing.Point(133, 97);
			this.txtChannelID.MaximumSize = new System.Drawing.Size(0, 20);
			this.txtChannelID.MinimumSize = new System.Drawing.Size(0, 20);
			this.txtChannelID.Name = "txtChannelID";
			this.txtChannelID.NameField = "Name";
			this.txtChannelID.Parameters = null;
			this.txtChannelID.Size = new System.Drawing.Size(354, 20);
			this.txtChannelID.TabIndex = 30;
			// 
			// emptySpaceItem1
			// 
			this.emptySpaceItem1.AllowHotTrack = false;
			this.emptySpaceItem1.Location = new System.Drawing.Point(240, 0);
			this.emptySpaceItem1.Name = "emptySpaceItem1";
			this.emptySpaceItem1.Size = new System.Drawing.Size(240, 24);
			this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
			// 
			// memDescription
			// 
			this.memDescription.Location = new System.Drawing.Point(133, 135);
			this.memDescription.Name = "memDescription";
			this.memDescription.Size = new System.Drawing.Size(354, 94);
			this.memDescription.StyleController = this.lc;
			this.memDescription.TabIndex = 28;
			// 
			// lcItemDescription
			// 
			this.lcItemDescription.Control = this.memDescription;
			this.lcItemDescription.Location = new System.Drawing.Point(0, 0);
			this.lcItemDescription.Name = "lcItemDescription";
			this.lcItemDescription.Size = new System.Drawing.Size(480, 98);
			this.lcItemDescription.TextSize = new System.Drawing.Size(118, 14);
			// 
			// lcGroupEdit3
			// 
			this.lcGroupEdit3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcItemDescription});
			this.lcGroupEdit3.Location = new System.Drawing.Point(0, 124);
			this.lcGroupEdit3.Name = "lcGroupEdit3";
			this.lcGroupEdit3.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
			this.lcGroupEdit3.Size = new System.Drawing.Size(494, 112);
			this.lcGroupEdit3.TextVisible = false;
			// 
			// CustomerChannelEditForm
			// 
			this.Appearance.BackColor = System.Drawing.Color.White;
			this.Appearance.Options.UseBackColor = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(498, 368);
			this.LookAndFeel.SkinName = "Office 2016 Dark";
			this.Name = "CustomerChannelEditForm";
			this.Text = "CustomerChannelEditForm";
			((System.ComponentModel.ISupportInitialize)(this.lc)).EndInit();
			this.lc.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupEdit1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemID)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemCustomer)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupRegInfo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemCreateDate)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtCreateDate.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemCreateByName)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtCreateByName.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemUpdateDate)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtUpdateDate.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemUpdateByName)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtUpdateByName.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupEdit2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemStartDate)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.datStartDate.Properties.CalendarTimeProperties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.datStartDate.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemChannel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.memDescription.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemDescription)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupEdit3)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private DevExpress.XtraLayout.LayoutControlGroup lcGroupEdit1;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupRegInfo;
		private DevExpress.XtraEditors.TextEdit txtUpdateByName;
		private DevExpress.XtraEditors.TextEdit txtUpdateDate;
		private DevExpress.XtraEditors.TextEdit txtCreateByName;
		private DevExpress.XtraEditors.TextEdit txtCreateDate;
		private DevExpress.XtraLayout.LayoutControlItem lcItemCreateDate;
		private DevExpress.XtraLayout.LayoutControlItem lcItemCreateByName;
		private DevExpress.XtraLayout.LayoutControlItem lcItemUpdateDate;
		private DevExpress.XtraLayout.LayoutControlItem lcItemUpdateByName;
		private Core.Controls.Common.XSearch txtCustomerID;
		private DevExpress.XtraEditors.TextEdit txtID;
		private DevExpress.XtraLayout.LayoutControlItem lcItemID;
		private DevExpress.XtraLayout.LayoutControlItem lcItemCustomer;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupEdit2;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
		private DevExpress.XtraEditors.MemoEdit memDescription;
		private DevExpress.XtraLayout.LayoutControlItem lcItemDescription;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupEdit3;
		private Core.Controls.Common.XSearch txtChannelID;
		private DevExpress.XtraEditors.DateEdit datStartDate;
		private DevExpress.XtraLayout.LayoutControlItem lcItemStartDate;
		private DevExpress.XtraLayout.LayoutControlItem lcItemChannel;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
	}
}