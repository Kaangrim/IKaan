﻿using System;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Biz.Core.Enum;
using IKaan.Biz.Core.Forms;
using IKaan.Biz.Core.Model;
using IKaan.Biz.Core.Utils;
using IKaan.Biz.Core.Was.Handler;
using IKaan.Model.BIZ.BM;

namespace IKaan.Biz.View.Biz.BM
{
	public partial class BMBrandChannelForm : EditForm
	{
		public BMBrandChannelForm()
		{
			InitializeComponent();
		}
		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			txtChannelID.Focus();
		}
		protected override void InitButtons()
		{
			base.InitButtons();
			SetToolbarButtons(new ToolbarButtons() { New = true, Save = true, SaveAndClose = true, SaveAndNew = true });
		}
		protected override void InitControls()
		{
			base.InitControls();

			lcItemChannel.Tag = true;
			lcItemStartDate.Tag = true;

			SetFieldNames();

			txtID.SetEnable(false);
			datEndDate.SetEnable(false);
			txtBrandID.SetEnable(false);

			txtChannelID.CodeGroup = "ChannelList";
			datStartDate.Init(CalendarViewType.DayView);
			datEndDate.Init(CalendarViewType.DayView);
			datEndDate.EditValue = null;
			spnChannelMargin.SetFormat("N2", false);
			spnBrandMargin.SetFormat("N2", false);

			if (this.ParamsData != null && this.ParamsData.GetType() == typeof(DataMap))
			{
				txtBrandID.EditValue = (this.ParamsData as DataMap).GetValue("BrandID");
				txtBrandID.EditText = (this.ParamsData as DataMap).GetValue("BrandName");
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
				DataMap parameter = new DataMap() { { "ID", (param as DataMap).GetValue("ID") } };
				var model = WasHandler.GetData<BMChannelBrand>("BM", "GetData", "Select", parameter);
				if (model == null)
					throw new Exception("조회할 데이터가 없습니다.");

				SetControlData(model);
				txtChannelID.EditValue = model.ChannelID;
				txtChannelID.EditText = model.ChannelName;

				SetToolbarButtons(new ToolbarButtons() { New = true, Save = true, SaveAndNew = true, SaveAndClose = true, Delete = true });
				this.EditMode = EditModeEnum.Modify;
				txtChannelID.Focus();
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}
		protected override void DataInit()
		{
			ClearControlData<BMChannelBrand>();

			if (this.ParamsData != null && this.ParamsData.GetType() == typeof(DataMap))
			{
				txtBrandID.EditValue = (this.ParamsData as DataMap).GetValue("BrandID");
				txtBrandID.EditText = (this.ParamsData as DataMap).GetValue("BrandName");
			}

			SetToolbarButtons(new ToolbarButtons() { New = true, Save = true, SaveAndNew = true, SaveAndClose = true });
			EditMode = EditModeEnum.New;
			txtChannelID.Focus();
		}
		protected override void DataSave(object arg, SaveCallback callback)
		{
			try
			{
				var model = this.GetControlData<BMChannelBrand>();

				using (var res = WasHandler.Execute<BMChannelBrand>("BM", "Save", (this.EditMode == EditModeEnum.New) ? "Insert" : "Update", model, "ID"))
				{
					if (res.Error.Number != 0)
						throw new Exception(res.Error.Message);

					ShowMsgBox("저장하였습니다.");
					(this.ParamsData as DataMap).SetValue("ID", res.Result.ReturnValue);
					callback(arg, this.ParamsData);
				}
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
				DataMap map = new DataMap() { { "ID", txtID.EditValue } };
				using (var res = WasHandler.Execute<DataMap>("BM", "Delete", "DeleteBMChannelBrand", map, "ID"))
				{
					if (res.Error.Number != 0)
						throw new Exception(res.Error.Message);

					ShowMsgBox("삭제하였습니다.");
					(this.ParamsData as DataMap).SetValue("ID", null);
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