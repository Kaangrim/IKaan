using System;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.Biz.Master.Partner;
using IKaan.Model.Biz.Search;
using IKaan.Win.Core.Enum;
using IKaan.Win.Core.Forms;
using IKaan.Win.Core.Model;
using IKaan.Win.Core.Utils;
using IKaan.Win.Core.Was.Handler;

namespace IKaan.Win.View.Biz.Activity
{
	public partial class SearchBrandActivityEditForm : EditForm
	{
		public SearchBrandActivityEditForm()
		{
			InitializeComponent();
		}
		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			datActivityDate.Focus();
		}
		protected override void InitButton()
		{
			base.InitButton();
			SetToolbarButtons(new ToolbarButtons() { New = true, Save = true, SaveAndClose = true, SaveAndNew = true });
		}
		protected override void InitControls()
		{
			base.InitControls();

			lcItemActivityDate.Tag = true;

			SetFieldNames();

			txtID.SetEnable(false);
			txtSearchBrandID.SetEnable(false);

			datActivityDate.Init(CalendarViewType.DayView);

			txtSearchBrandID.EditValue = (this.ParamsData as DataMap).GetValue("SearchBrandID");
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
				var model = WasHandler.GetData<SearchBrandActivityModel>("Biz", "GetData", "Select", parameter);
				if (model == null)
					throw new Exception("조회할 데이터가 없습니다.");

				SetControlData(model);
				if (model.DescriptionRTF.IsNullOrEmpty() == false)
				{
					rteDescription.EditValue = model.DescriptionRTF;
				}
				else
				{
					if (model.Description.IsNullOrEmpty() == false)
						rteDescription.EditText = model.Description;
				}

				SetToolbarButtons(new ToolbarButtons() { New = true, Save = true, SaveAndNew = true, SaveAndClose = true, Delete = true });
				this.EditMode = EditModeEnum.Modify;
				datActivityDate.Focus();
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}
		protected override void DataInit()
		{
			ClearControlData<PartnerManagerModel>();
			rteDescription.Clear();
			
			txtSearchBrandID.EditValue = (this.ParamsData as DataMap).GetValue("SearchBrandID");

			SetToolbarButtons(new ToolbarButtons() { New = true, Save = true, SaveAndNew = true, SaveAndClose = true });
			EditMode = EditModeEnum.New;
			datActivityDate.Focus();
		}
		protected override void DataSave(object arg, SaveCallback callback)
		{
			try
			{
				var model = this.GetControlData<SearchBrandActivityModel>();
				model.Description = rteDescription.EditText;
				model.DescriptionRTF = rteDescription.EditValue;

				using (var res = WasHandler.Execute<SearchBrandActivityModel>("Biz", "Save", (this.EditMode == EditModeEnum.New) ? "Insert" : "Update", model, "ID"))
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
				var map = new DataMap() { { "ID", txtID.EditValue } };
				using (var res = WasHandler.Execute<DataMap>("Biz", "Delete", "DeleteSearchBrandActivity", map, "ID"))
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