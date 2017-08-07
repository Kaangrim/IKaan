namespace IKaan.Win.View.Biz.BC
{
	partial class BCAppointmentForm
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
			DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
			this.lcGroupEdit = new DevExpress.XtraLayout.LayoutControlGroup();
			this.lupEmployeeID = new IKaan.Win.Core.Controls.Common.XLookup();
			this.lcItemEmployee = new DevExpress.XtraLayout.LayoutControlItem();
			this.lupDepartmentID = new IKaan.Win.Core.Controls.Common.XLookup();
			this.lcItemDepartment = new DevExpress.XtraLayout.LayoutControlItem();
			this.txtPosition = new DevExpress.XtraEditors.TextEdit();
			this.lcItemPosition = new DevExpress.XtraLayout.LayoutControlItem();
			this.datStartDate = new DevExpress.XtraEditors.DateEdit();
			this.lcItemStartDate = new DevExpress.XtraLayout.LayoutControlItem();
			this.chkMainYn = new DevExpress.XtraEditors.CheckEdit();
			this.lcItemMainYn = new DevExpress.XtraLayout.LayoutControlItem();
			this.memDescription = new DevExpress.XtraEditors.MemoEdit();
			this.lcItemDescription = new DevExpress.XtraLayout.LayoutControlItem();
			this.txtID = new DevExpress.XtraEditors.TextEdit();
			this.lcItemID = new DevExpress.XtraLayout.LayoutControlItem();
			((System.ComponentModel.ISupportInitialize)(this.lc)).BeginInit();
			this.lc.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lupEmployeeID.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemEmployee)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lupDepartmentID.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemDepartment)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtPosition.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemPosition)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.datStartDate.Properties.CalendarTimeProperties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.datStartDate.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemStartDate)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.chkMainYn.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemMainYn)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.memDescription.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemDescription)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemID)).BeginInit();
			this.SuspendLayout();
			// 
			// lc
			// 
			this.lc.Controls.Add(this.txtID);
			this.lc.Controls.Add(this.memDescription);
			this.lc.Controls.Add(this.chkMainYn);
			this.lc.Controls.Add(this.datStartDate);
			this.lc.Controls.Add(this.txtPosition);
			this.lc.Controls.Add(this.lupDepartmentID);
			this.lc.Controls.Add(this.lupEmployeeID);
			this.lc.Location = new System.Drawing.Point(0, 44);
			this.lc.Margin = new System.Windows.Forms.Padding(0);
			this.lc.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(922, 207, 450, 400);
			this.lc.OptionsView.UseDefaultDragAndDropRendering = false;
			this.lc.Padding = new System.Windows.Forms.Padding(2);
			this.lc.Size = new System.Drawing.Size(398, 302);
			// 
			// lcGroupBase
			// 
			this.lcGroupBase.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcGroupEdit});
			this.lcGroupBase.Name = "Root";
			this.lcGroupBase.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
			this.lcGroupBase.Size = new System.Drawing.Size(398, 302);
			// 
			// lcGroupEdit
			// 
			this.lcGroupEdit.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcItemEmployee,
            this.lcItemDepartment,
            this.lcItemPosition,
            this.lcItemStartDate,
            this.lcItemMainYn,
            this.lcItemDescription,
            this.lcItemID});
			this.lcGroupEdit.Location = new System.Drawing.Point(0, 0);
			this.lcGroupEdit.Name = "lcGroupEdit";
			this.lcGroupEdit.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
			this.lcGroupEdit.Size = new System.Drawing.Size(394, 298);
			this.lcGroupEdit.TextVisible = false;
			// 
			// lupEmployeeID
			// 
			this.lupEmployeeID.DisplayMember = "";
			this.lupEmployeeID.GroupCode = null;
			this.lupEmployeeID.ListMember = "ListName";
			this.lupEmployeeID.Location = new System.Drawing.Point(115, 35);
			this.lupEmployeeID.Name = "lupEmployeeID";
			this.lupEmployeeID.NullText = "[EditValue is null]";
			this.lupEmployeeID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Redo, "", -1, true, true, false, editorButtonImageOptions2, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), "재구성")});
			this.lupEmployeeID.SelectedIndex = -1;
			this.lupEmployeeID.Size = new System.Drawing.Size(272, 20);
			this.lupEmployeeID.StyleController = this.lc;
			this.lupEmployeeID.TabIndex = 4;
			this.lupEmployeeID.ValueMember = "";
			// 
			// lcItemEmployee
			// 
			this.lcItemEmployee.Control = this.lupEmployeeID;
			this.lcItemEmployee.Location = new System.Drawing.Point(0, 24);
			this.lcItemEmployee.Name = "lcItemEmployee";
			this.lcItemEmployee.Size = new System.Drawing.Size(380, 24);
			this.lcItemEmployee.TextSize = new System.Drawing.Size(100, 14);
			// 
			// lupDepartmentID
			// 
			this.lupDepartmentID.DisplayMember = "";
			this.lupDepartmentID.GroupCode = null;
			this.lupDepartmentID.ListMember = "ListName";
			this.lupDepartmentID.Location = new System.Drawing.Point(115, 59);
			this.lupDepartmentID.Name = "lupDepartmentID";
			this.lupDepartmentID.NullText = "[EditValue is null]";
			this.lupDepartmentID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Redo, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), "재구성")});
			this.lupDepartmentID.SelectedIndex = -1;
			this.lupDepartmentID.Size = new System.Drawing.Size(272, 20);
			this.lupDepartmentID.StyleController = this.lc;
			this.lupDepartmentID.TabIndex = 5;
			this.lupDepartmentID.ValueMember = "";
			// 
			// lcItemDepartment
			// 
			this.lcItemDepartment.Control = this.lupDepartmentID;
			this.lcItemDepartment.Location = new System.Drawing.Point(0, 48);
			this.lcItemDepartment.Name = "lcItemDepartment";
			this.lcItemDepartment.Size = new System.Drawing.Size(380, 24);
			this.lcItemDepartment.TextSize = new System.Drawing.Size(100, 14);
			// 
			// txtPosition
			// 
			this.txtPosition.Location = new System.Drawing.Point(115, 83);
			this.txtPosition.Name = "txtPosition";
			this.txtPosition.Size = new System.Drawing.Size(272, 20);
			this.txtPosition.StyleController = this.lc;
			this.txtPosition.TabIndex = 6;
			// 
			// lcItemPosition
			// 
			this.lcItemPosition.Control = this.txtPosition;
			this.lcItemPosition.Location = new System.Drawing.Point(0, 72);
			this.lcItemPosition.Name = "lcItemPosition";
			this.lcItemPosition.Size = new System.Drawing.Size(380, 24);
			this.lcItemPosition.TextSize = new System.Drawing.Size(100, 14);
			// 
			// datStartDate
			// 
			this.datStartDate.EditValue = null;
			this.datStartDate.Location = new System.Drawing.Point(115, 107);
			this.datStartDate.Name = "datStartDate";
			this.datStartDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.datStartDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.datStartDate.Size = new System.Drawing.Size(272, 20);
			this.datStartDate.StyleController = this.lc;
			this.datStartDate.TabIndex = 7;
			// 
			// lcItemStartDate
			// 
			this.lcItemStartDate.Control = this.datStartDate;
			this.lcItemStartDate.Location = new System.Drawing.Point(0, 96);
			this.lcItemStartDate.Name = "lcItemStartDate";
			this.lcItemStartDate.Size = new System.Drawing.Size(380, 24);
			this.lcItemStartDate.TextSize = new System.Drawing.Size(100, 14);
			// 
			// chkMainYn
			// 
			this.chkMainYn.Location = new System.Drawing.Point(115, 131);
			this.chkMainYn.Name = "chkMainYn";
			this.chkMainYn.Properties.Caption = "";
			this.chkMainYn.Size = new System.Drawing.Size(272, 19);
			this.chkMainYn.StyleController = this.lc;
			this.chkMainYn.TabIndex = 8;
			// 
			// lcItemMainYn
			// 
			this.lcItemMainYn.Control = this.chkMainYn;
			this.lcItemMainYn.Location = new System.Drawing.Point(0, 120);
			this.lcItemMainYn.Name = "lcItemMainYn";
			this.lcItemMainYn.Size = new System.Drawing.Size(380, 23);
			this.lcItemMainYn.TextSize = new System.Drawing.Size(100, 14);
			// 
			// memDescription
			// 
			this.memDescription.Location = new System.Drawing.Point(115, 154);
			this.memDescription.Name = "memDescription";
			this.memDescription.Size = new System.Drawing.Size(272, 137);
			this.memDescription.StyleController = this.lc;
			this.memDescription.TabIndex = 9;
			// 
			// lcItemDescription
			// 
			this.lcItemDescription.Control = this.memDescription;
			this.lcItemDescription.Location = new System.Drawing.Point(0, 143);
			this.lcItemDescription.Name = "lcItemDescription";
			this.lcItemDescription.Size = new System.Drawing.Size(380, 141);
			this.lcItemDescription.TextSize = new System.Drawing.Size(100, 14);
			// 
			// txtID
			// 
			this.txtID.Location = new System.Drawing.Point(115, 11);
			this.txtID.Name = "txtID";
			this.txtID.Size = new System.Drawing.Size(272, 20);
			this.txtID.StyleController = this.lc;
			this.txtID.TabIndex = 10;
			// 
			// lcItemID
			// 
			this.lcItemID.Control = this.txtID;
			this.lcItemID.Location = new System.Drawing.Point(0, 0);
			this.lcItemID.Name = "lcItemID";
			this.lcItemID.Size = new System.Drawing.Size(380, 24);
			this.lcItemID.TextSize = new System.Drawing.Size(100, 14);
			// 
			// BCAppointmentForm
			// 
			this.Appearance.BackColor = System.Drawing.Color.White;
			this.Appearance.Options.UseBackColor = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(398, 368);
			this.LookAndFeel.SkinName = "Office 2016 Dark";
			this.Name = "BCAppointmentForm";
			this.Text = "BCAppointmentForm";
			((System.ComponentModel.ISupportInitialize)(this.lc)).EndInit();
			this.lc.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lupEmployeeID.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemEmployee)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lupDepartmentID.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemDepartment)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtPosition.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemPosition)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.datStartDate.Properties.CalendarTimeProperties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.datStartDate.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemStartDate)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.chkMainYn.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemMainYn)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.memDescription.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemDescription)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemID)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private DevExpress.XtraLayout.LayoutControlGroup lcGroupEdit;
		private Core.Controls.Common.XLookup lupDepartmentID;
		private Core.Controls.Common.XLookup lupEmployeeID;
		private DevExpress.XtraLayout.LayoutControlItem lcItemEmployee;
		private DevExpress.XtraLayout.LayoutControlItem lcItemDepartment;
		private DevExpress.XtraEditors.CheckEdit chkMainYn;
		private DevExpress.XtraEditors.DateEdit datStartDate;
		private DevExpress.XtraEditors.TextEdit txtPosition;
		private DevExpress.XtraLayout.LayoutControlItem lcItemPosition;
		private DevExpress.XtraLayout.LayoutControlItem lcItemStartDate;
		private DevExpress.XtraLayout.LayoutControlItem lcItemMainYn;
		private DevExpress.XtraEditors.MemoEdit memDescription;
		private DevExpress.XtraLayout.LayoutControlItem lcItemDescription;
		private DevExpress.XtraEditors.TextEdit txtID;
		private DevExpress.XtraLayout.LayoutControlItem lcItemID;
	}
}