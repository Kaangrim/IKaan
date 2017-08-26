using System;
using System.Collections.Generic;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using IKaan.Base.Map;
using IKaan.Model.IKBase;
using IKaan.Win.Core.Controls.Grid;
using IKaan.Win.Core.Enum;
using IKaan.Win.Core.Forms;
using IKaan.Win.Core.Model;
using IKaan.Win.Core.Utils;
using IKaan.Win.Core.Was.Handler;

namespace IKaan.Win.View.Base.Common
{
	public partial class DictionaryEditForm : EditForm
	{
		public DictionaryEditForm()
		{
			InitializeComponent();

			lupLanguageCode.EditValueChanged += delegate (object sender, EventArgs e) { DataLoad(null); };
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			txtFindText.Focus();
		}

		protected override void InitButton()
		{
			base.InitButton();
			SetToolbarButtons(new ToolbarButtons() { New = true, Refresh = true, Save = true, SaveAndNew = true });
		}
		protected override void InitControls()
		{
			base.InitControls();

			lcItemPhysicalName.Tag = true;
			lcItemLogicalName.Tag = true;

			SetFieldNames();

			txtID.SetEnable(false);
			txtCreateDate.SetEnable(false);
			txtCreateByName.SetEnable(false);
			txtUpdateDate.SetEnable(false);
			txtUpdateByName.SetEnable(false);

			lupLanguageCode.BindData("LanguageCode", null, true);
			InitGrid();
		}

		void InitGrid()
		{
			#region List
			gridList.Init();
			gridList.AddGridColumns
			(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", HorzAlignment = HorzAlignment.Center, Width = 80 },
				new XGridColumn() { FieldName = "LogicalName", Width = 200 },
				new XGridColumn() { FieldName = "PhysicalName", Width = 200 },
				new XGridColumn() { FieldName = "CreateDate" },
				new XGridColumn() { FieldName = "CreateByName" },
				new XGridColumn() { FieldName = "UpdateDate" },
				new XGridColumn() { FieldName = "UpdateByName" }
			);
			gridList.ColumnFix("RowNo");

			gridList.RowCellClick += delegate (object sender, RowCellClickEventArgs e)
			{
				if (e.RowHandle < 0)
					return;

				try
				{
					if (e.Button == System.Windows.Forms.MouseButtons.Left && e.Clicks == 1)
					{
						GridView view = sender as GridView;
						DetailDataLoad(view.GetRowCellValue(e.RowHandle, "ID"));
					}
				}
				catch(Exception ex)
				{
					ShowErrBox(ex);
				}
			};

			#endregion

			#region List
			gridLangList.Init();
			gridLangList.AddGridColumns
			(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "LanguageCode", Visible = false },
				new XGridColumn() { FieldName = "LanguageName", Width = 200 },
				new XGridColumn() { FieldName = "LogicalName", Width = 200 },
				new XGridColumn() { FieldName = "PhysicalName", Visible = false },
				new XGridColumn() { FieldName = "CreateDate" },
				new XGridColumn() { FieldName = "CreateByName" },
				new XGridColumn() { FieldName = "UpdateDate" },
				new XGridColumn() { FieldName = "UpdateByName" }
			);
			gridLangList.SetEditable("LogicalName");
			gridLangList.SetRespositoryItemTextEdit("LogicalName");
			gridLangList.ColumnFix("RowNo");
			#endregion
		}

		protected override void LoadForm()
		{
			base.LoadForm();
			DataLoad();
		}
		protected override void DataInit()
		{
			ClearControlData<DictionaryModel>();
			gridLangList.Clear<DictionaryModel>();
			SetToolbarButtons(new ToolbarButtons() { New = true, Refresh = true, Save = true, SaveAndNew = true });
			this.EditMode = EditModeEnum.New;
			txtPhysicalName.Focus();
		}

		protected override void DataLoad(object param = null)
		{
			var parameters = new DataMap()
			{
				{ "LanguageCode", lupLanguageCode.EditValue },
				{ "FindText", txtFindText.EditValue }
			};
			gridList.BindList<DictionaryModel>("Base", "GetList", "Select", parameters);

			if (param != null)
				DetailDataLoad(param);
			else
				DataInit();
		}

		void DetailDataLoad(object id)
		{
			try
			{
				var parameters = new DataMap()
				{
					{ "LanguageCode", lupLanguageCode.EditValue },
					{ "ID", id }
				};
				var data = WasHandler.GetData<DictionaryModel>("Base", "GetData", "Select", parameters);
				if (data == null)
					throw new Exception("조회할 데이터가 없습니다.");

				SetControlData(data);
				gridLangList.DataSource = data.LanguageList;
				SetToolbarButtons(new ToolbarButtons() { New = true, Refresh = true, Save = true, SaveAndNew = true, Delete = true });
				this.EditMode = EditModeEnum.Modify;
				txtPhysicalName.Focus();

			}
			catch(Exception ex)
			{
				ShowErrBox(ex);
			}
		}

		protected override void DataSave(object arg, SaveCallback callback)
		{
			try
			{
				var model = GetControlData<DictionaryModel>();
				model.LanguageCode = lupLanguageCode.EditValue.ToString();

				List<DictionaryModel> languageList = new List<DictionaryModel>();

				if (gridLangList.RowCount > 0)
					languageList = gridLangList.DataSource as List<DictionaryModel>;

				model.LanguageList = languageList;

				using (var res = WasHandler.Execute<DictionaryModel>("Base", "Save", (this.EditMode == EditModeEnum.New) ? "Insert" : "Update", model, "ID"))
				{
					if (res.Error.Number != 0)
						throw new Exception(res.Error.Message);

					ShowMsgBox("저장하였습니다.");
					callback(arg, res.Result.ReturnValue);
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
				DataMap data = new DataMap()
				{
					{ "ID", txtID.EditValue }
				};

				using (var res = WasHandler.Execute<DataMap>("Base", "Delete", "DeleteDictionary", data, null))
				{
					if (res.Error.Number != 0)
						throw new Exception(res.Error.Message);

					ShowMsgBox("삭제하였습니다.");
					callback(arg, null);
				}
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}
	}
}