using System;
using System.Collections.Generic;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.Scrap.Common;
using IKaan.Win.Core.Enum;
using IKaan.Win.Core.Forms;
using IKaan.Win.Core.Model;
using IKaan.Win.Core.Utils;
using IKaan.Win.Core.Was.Handler;

namespace IKaan.Win.View.Scrap.Common
{
	public partial class ScrapOptionEditForm : EditForm
	{ 
		public ScrapOptionEditForm()
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
			SetToolbarButtons(new ToolbarButtons() { Save = true, SaveAndClose = true });
		}
		protected override void InitControls()
		{
			base.InitControls();

			if (this.ParamsData.GetType() != typeof(List<ScrapOptionModel>))
				lcItemName.Tag = true;

			SetFieldNames();

			lcItemName.SetFieldName("OptionName");

			txtID.SetEnable(false);
			txtCreatedOn.SetEnable(false);
			txtCreatedByName.SetEnable(false);
			txtUpdatedOn.SetEnable(false);
			txtUpdatedByName.SetEnable(false);

			lupOption1Type.BindData("OptionType", "옵션없음");
			lupOption2Type.BindData("OptionType", "옵션없음");

			if (this.ParamsData.GetType() == typeof(List<ScrapOptionModel>))
				txtName.SetEnable(false);
		}

		protected override void DataLoad(object param = null)
		{
			try
			{
				if (param.GetType() != typeof(List<ScrapOptionModel>))
				{
					var model = WasHandler.GetData<ScrapOptionModel>("Scrap", "GetData", "Select", new DataMap() { { "ID", param } });
					if (model == null)
						throw new Exception("조회할 데이터가 없습니다.");

					SetControlData(model);
					SetToolbarButtons(new ToolbarButtons() { Save = true, SaveAndClose = true, Delete = true });
					this.EditMode = EditModeEnum.Modify;
					txtName.Focus();
				}
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
				if (txtID.EditValue != null)
				{
					var model = this.GetControlData<ScrapOptionModel>();
					using (var res = WasHandler.Execute<ScrapOptionModel>("Scrap", "Save", "Insert", model, "ID"))
					{
						if (res.Error.Number != 0)
							throw new Exception(res.Error.Message);

						ShowMsgBox("저장하였습니다.");
						callback(arg, res.Result.ReturnValue);
					}
				}
				else
				{
					if (this.ParamsData.GetType() == typeof(List<ScrapOptionModel>))
					{
						foreach(var option in this.ParamsData as List<ScrapOptionModel>)
						{
							option.Option1Type = lupOption1Type.EditValue.ToStringNullToNull();
							option.Option1Name = txtOption1Name.EditValue.ToStringNullToNull();
							option.Option1Value = txtOption1Value.EditValue.ToStringNullToNull();
							option.Option2Type = lupOption2Type.EditValue.ToStringNullToNull();
							option.Option2Name = txtOption2Name.EditValue.ToStringNullToNull();
							option.Option2Value = txtOption2Value.EditValue.ToStringNullToNull();

							using (var res = WasHandler.Execute<ScrapOptionModel>("Scrap", "Save", "Insert", option, "ID"))
							{
								if (res.Error.Number != 0)
									throw new Exception(res.Error.Message);
							}
						}
						ShowMsgBox("저장하였습니다.");
						this.SetModifiedCount();
						Close();
					}
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
				if (txtID.EditValue != null)
				{
					using (var res = WasHandler.Execute<DataMap>("Scrap", "Delete", "DeleteScrapOption", new DataMap() { { "ID", txtID.EditValue } }))
					{
						if (res.Error.Number != 0)
							throw new Exception(res.Error.Message);
					}
					ShowMsgBox("삭제하였습니다.");
					Close();
				}
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}
	}
}