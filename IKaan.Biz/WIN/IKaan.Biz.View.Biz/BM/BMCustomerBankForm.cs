using System;
using DevExpress.XtraEditors.Controls;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Biz.Core.Enum;
using IKaan.Biz.Core.Forms;
using IKaan.Biz.Core.Handler;
using IKaan.Biz.Core.Model;
using IKaan.Biz.Core.Utils;
using IKaan.Biz.Core.Variables;
using IKaan.Biz.Core.Was.Handler;
using IKaan.Model.BIZ.BM;

namespace IKaan.Biz.View.Biz.BM
{
	public partial class BMCustomerBankForm : EditForm
	{
		private string loadUrl = string.Empty;

		public BMCustomerBankForm()
		{
			InitializeComponent();

			picImage.EditValueChanged += delegate (object sender, EventArgs e)
			{
				if (this.IsLoaded)
				{
					txtImageUrl.EditValue = picImage.GetLoadedImageLocation();
				}
			};
			picImage.LoadCompleted += delegate (object sender, EventArgs e)
			{
				txtImageUrl.EditValue = loadUrl;
			};
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			txtBankName.Focus();
		}
		protected override void InitButtons()
		{
			base.InitButtons();
			SetToolbarButtons(new ToolbarButtons() { Save = true, SaveAndClose = true });
		}
		protected override void InitControls()
		{
			base.InitControls();

			lcItemBankName.Tag = true;
			lcItemAccountNo.Tag = true;
			lcItemDepositor.Tag = true;

			SetFieldNames();

			txtID.SetEnable(false);
			txtCustomerID.SetEnable(false);
			txtImageUrl.SetEnable(false);

			txtCustomerID.EditValue = (this.ParamsData as DataMap).GetValue("CustomerID");
			txtCustomerID.EditText = (this.ParamsData as DataMap).GetValue("CustomerName");
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
				DataMap parameter = new DataMap(){ { "ID", (param as DataMap).GetValue("ID") } };
				var model = WasHandler.GetData<BMCustomerBank>("BM", "GetData", "Select", parameter);
				if (model == null)
					throw new Exception("조회할 데이터가 없습니다.");

				SetControlData(model);
				loadUrl = model.ImageUrl;
				if (model.ImageUrl.IsNullOrEmpty())
					picImage.EditValue = null;
				else
					picImage.LoadAsync(ConstsVar.IMG_URL + model.ImageUrl);

				SetToolbarButtons(new ToolbarButtons() { Save = true, SaveAndClose = true, Delete = true });
				this.EditMode = EditModeEnum.Modify;
				txtBankName.Focus();
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}
		protected override void DataInit()
		{
			ClearControlData<BMCustomerBank>();
			txtCustomerID.EditValue = (this.ParamsData as DataMap).GetValue("CustomerID");
			txtCustomerID.EditText = (this.ParamsData as DataMap).GetValue("CustomerName");

			txtBankName.Clear();
			txtAccountNo.Clear();
			txtDepositor.Clear();
			picImage.EditValue = null;
			loadUrl = string.Empty;

			SetToolbarButtons(new ToolbarButtons() { Save = true, SaveAndClose = true });
			EditMode = EditModeEnum.New;
			txtBankName.Focus();
		}
		protected override void DataSave(object arg, SaveCallback callback)
		{
			try
			{
				var model = this.GetControlData<BMCustomerBank>();

				string path = picImage.GetLoadedImageLocation();
				if (path.IsNullOrEmpty() == false)
				{
					string url = FTPHandler.UploadBank(txtImageUrl.EditValue.ToString(), txtBankName.EditValue.ToString(), txtAccountNo.EditValue.ToString().Replace("-", ""));
					model.ImageUrl = url;
				}

				using (var res = WasHandler.Execute<BMCustomerBank>("BM", "Save", (this.EditMode == EditModeEnum.New) ? "Insert" : "Update", model, "ID"))
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
				using (var res = WasHandler.Execute<DataMap>("BM", "Delete", "DeleteBMCustomerBank", map, "ID"))
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