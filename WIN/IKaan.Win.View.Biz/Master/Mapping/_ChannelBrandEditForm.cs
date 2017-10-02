using System;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.Biz.Master.Channel;
using IKaan.Win.Core.Enum;
using IKaan.Win.Core.Forms;
using IKaan.Win.Core.Model;
using IKaan.Win.Core.Utils;
using IKaan.Win.Core.Was.Handler;

namespace IKaan.Win.View.Biz.Master.Mapping
{
	public partial class _ChannelBrandEditForm : EditForm
	{
		private string _type = string.Empty;
		private object _id = null;

		public _ChannelBrandEditForm()
		{
			InitializeComponent();
		}
		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			lupBrandID.Focus();
		}
		protected override void InitButton()
		{
			base.InitButton();
			SetToolbarButtons(new ToolbarButtons() { New = true, Save = true, SaveAndClose = true, SaveAndNew = true });
		}
		protected override void InitControls()
		{
			base.InitControls();

			lcItemBrand.Tag = true;
			lcItemStartDate.Tag = true;

			SetFieldNames();

			datEndDate.SetEnable(false);
			lupChannelID.SetEnable(false);

			datStartDate.Init(CalendarViewType.DayView);
			datEndDate.Init(CalendarViewType.DayView);
			datEndDate.EditValue = null;
			spnChannelMargin.SetFormat("N2", false);
			spnBrandMargin.SetFormat("N2", false);

			_type = (this.ParamsData as DataMap).GetValue("MappingType").ToStringNullToEmpty();
			if (_type.IsNullOrEmpty())
			{
				ShowMsgBox("매핑유형을 알 수 없습니다.");
				Close();
				return;
			}

			lcItemChannel.SetFieldName(_type);
			lupChannelID.BindData(string.Format("{0}List", _type));
			lupChannelID.EditValue = (this.ParamsData as DataMap).GetValue(string.Format("{0}ID", _type)).ToStringNullToEmpty();

			if (_type.ToUpper() == "CHANNEL")
			{
				lcItemBrand.SetFieldName("Brand");
				lupBrandID.BindData("BrandList");
				lupBrandID.EditValue = (this.ParamsData as DataMap).GetValue(string.Format("{0}ID", "Brand")).ToStringNullToEmpty();
			}
			else if (_type.ToUpper() == "BRAND")
			{
				lcItemBrand.SetFieldName("Channel");
				lupBrandID.BindData("ChannelList");
				lupBrandID.EditValue = (this.ParamsData as DataMap).GetValue(string.Format("{0}ID", "Channel")).ToStringNullToEmpty();
			}
		}
		protected override void DataLoad(object param = null)
		{
			if (param == null || param.GetType() != typeof(DataMap) || (param as DataMap).GetValue("ID").IsNullOrEmpty())
			{
				DataInit();
				return;
			}

			try
			{
				var parameter = new DataMap() { { "ID", (param as DataMap).GetValue("ID") } };
				var model = WasHandler.GetData<ChannelBrandModel>("Biz", "GetData", "Select", parameter);
				if (model != null)
				{
					SetControlData(model);
					if (_type.ToUpper() == "BRAND")
					{
						lupChannelID.EditValue = model.ChannelID.ToStringNullToEmpty();
						lupBrandID.EditValue = model.BrandID.ToStringNullToEmpty();
					}
					else if (_type.ToUpper() == "CHANNEL")
					{
						lupChannelID.EditValue = model.BrandID.ToStringNullToEmpty();
						lupBrandID.EditValue = model.ChannelID.ToStringNullToEmpty();
					}
					_id = model.ID;
				}
				SetToolbarButtons(new ToolbarButtons() { New = true, Save = true, SaveAndNew = true, SaveAndClose = true, Delete = true });
				this.EditMode = EditModeEnum.Modify;
				lupBrandID.Focus();
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}
		protected override void DataInit()
		{
			ClearControlData<ChannelBrandModel>();

			if (_type.ToUpper() == "BRAND")
			{
				lupChannelID.EditValue = (this.ParamsData as DataMap).GetValue("BrandID").ToStringNullToEmpty();
			}
			else if (_type.ToUpper() == "CHANNEL")
			{
				lupChannelID.EditValue = (this.ParamsData as DataMap).GetValue("ChannelID").ToStringNullToEmpty();
			}

			_id = null;
			SetToolbarButtons(new ToolbarButtons() { New = true, Save = true, SaveAndNew = true, SaveAndClose = true });
			EditMode = EditModeEnum.New;
			lupBrandID.Focus();
		}
		protected override void DataSave(object arg, SaveCallback callback)
		{
			try
			{
				object id = null;
				var model = this.GetControlData<ChannelBrandModel>();
				model.ID = _id.ToIntegerNullToNull();
				if (_type.ToUpper() == "BRAND")
				{
					model.ChannelID = lupBrandID.EditValue.ToIntegerNullToNull();
					model.BrandID = lupChannelID.EditValue.ToIntegerNullToNull();
				}
				else
				{
					model.ChannelID = lupChannelID.EditValue.ToIntegerNullToNull();
					model.BrandID = lupBrandID.EditValue.ToIntegerNullToNull();
				}

				using (var res = WasHandler.Execute<ChannelBrandModel>("Biz", "Save", "Insert", model, "ID"))
				{
					if (res.Error.Number != 0)
						throw new Exception(res.Error.Message);
					id = res.Result.ReturnValue;
				}
				ShowMsgBox("저장하였습니다.");
				(this.ParamsData as DataMap).SetValue("ID", id);
				callback(arg, this.ParamsData);
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}
		protected override void DataDelete(object arg, DeleteCallback callback)
		{
			try
			{
				using (var res = WasHandler.Execute<DataMap>("Biz", "Delete", "DeleteChannelBrand", new DataMap() { { "ID", _id } }))
				{
					if (res.Error.Number != 0)
						throw new Exception(res.Error.Message);
				}
				ShowMsgBox("삭제하였습니다.");
				(this.ParamsData as DataMap).SetValue("ID", null);
				callback(arg, this.ParamsData);
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}
	}
}