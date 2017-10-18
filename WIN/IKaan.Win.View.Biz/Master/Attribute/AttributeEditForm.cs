using System;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.Biz.Master.Attribute;
using IKaan.Model.Biz.Master.Common;
using IKaan.Win.Core.Enum;
using IKaan.Win.Core.Forms;
using IKaan.Win.Core.Model;
using IKaan.Win.Core.Utils;
using IKaan.Win.Core.Was.Handler;

namespace IKaan.Win.View.Biz.Master.Attribute
{
	public partial class AttributeEditForm : EditForm
	{
		public AttributeEditForm()
		{
			InitializeComponent();
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			txtName.Focus();
		}

		protected override void InitButton()
		{
			base.InitButton();
			SetToolbarButtons(new ToolbarButtons() { New = true, Save = true, SaveAndNew = true, SaveAndClose = true });
		}
		protected override void InitControls()
		{
			base.InitControls();

			lcItemName.Tag = true;

			SetFieldNames();
			lcItemName.SetFieldName("AttributeName");

			txtID.SetEnable(false);
			txtCreatedOn.SetEnable(false);
			txtCreatedByName.SetEnable(false);
			txtUpdatedOn.SetEnable(false);
			txtUpdatedByName.SetEnable(false);
			lupAttributeTypeID.SetEnable(false);

			lupAttributeTypeID.BindData("AttributeType");
			if (this.ParamsData != null && this.ParamsData.GetType() == typeof(DataMap))
				lupAttributeTypeID.EditValue = (this.ParamsData as DataMap).GetValue("AttributeTypeID").ToStringNullToNull();
		}

		protected override void DataInit()
		{
			ClearControlData<AttributeModel>();
			if (this.ParamsData != null && this.ParamsData.GetType() == typeof(DataMap))
				lupAttributeTypeID.EditValue = (this.ParamsData as DataMap).GetValue("AttributeTypeID").ToStringNullToNull();
			SetToolbarButtons(new ToolbarButtons() { New = true, Save = true, SaveAndNew = true, SaveAndClose = true });
			EditMode = EditModeEnum.New;
			txtName.Focus();
		}

		protected override void DataLoad(object param = null)
		{
			if (param == null || param.GetType() != typeof(DataMap) || (param as DataMap).GetValue("ID") == null)
			{
				DataInit();
				return;
			}

			try
			{
				var model = WasHandler.GetData<AttributeModel>("Biz", "GetData", "Select", new DataMap() { { "ID", (param as DataMap).GetValue("ID") } });
				SetControlData(model);
				SetToolbarButtons(new ToolbarButtons() { New = true, Save = true, SaveAndNew = true, SaveAndClose = true, Delete = true });
				this.EditMode = EditModeEnum.Modify;
				txtName.Focus();
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}

		protected override void DataSave(object arg, SaveCallback callback)
		{
			try
			{
				var model = this.GetControlData<AttributeModel>();
				using (var res = WasHandler.Execute<AttributeModel>("Biz", "Save", (this.EditMode == EditModeEnum.New) ? "Insert" : "Update", model, "ID"))
				{
					if (res.Error.Number != 0)
						throw new Exception(res.Error.Message);

					ShowMsgBox("저장하였습니다.");
					this.ParamsData = new DataMap()
					{
						{ "AttributeTypeID", lupAttributeTypeID.EditValue },
						{ "ID", res.Result.ReturnValue }
					};
					callback(arg, this.ParamsData);
				}
			}
			catch(Exception ex)
			{
				ShowErrBox(ex);
			}
		}

		protected override void DataDelete(object arg, DeleteCallback callback)
		{
			try
			{
				using (var res = WasHandler.Execute<DataMap>("Biz", "Delete", "DeleteAttribute", new DataMap() { { "ID", txtID.EditValue } }))
				{
					if (res.Error.Number != 0)
						throw new Exception(res.Error.Message);

					ShowMsgBox("삭제하였습니다.");
					this.ParamsData = new DataMap()
					{
						{ "AttributeTypeID", lupAttributeTypeID.EditValue },
						{ "ID", null }
					};
					callback(arg, this.ParamsData);
				}
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}
	}
}