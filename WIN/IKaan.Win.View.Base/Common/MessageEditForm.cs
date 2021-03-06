﻿using System;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using IKaan.Base.Map;
using IKaan.Model.Base.Common;
using IKaan.Win.Core.Controls.Grid;
using IKaan.Win.Core.Enum;
using IKaan.Win.Core.Forms;
using IKaan.Win.Core.Model;
using IKaan.Win.Core.Utils;
using IKaan.Win.Core.Was.Handler;

namespace IKaan.Win.View.Base.Common
{
	public partial class TMessageForm : EditForm
	{
		public TMessageForm()
		{
			InitializeComponent();
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

			lcItemLogicalName.Tag = true;
			lcItemPhysicalName.Tag = true;

			SetFieldNames();

			txtID.SetEnable(false);
			txtCreatedOn.SetEnable(false);
			txtCreatedByName.SetEnable(false);
			txtUpdatedOn.SetEnable(false);
			txtUpdatedByName.SetEnable(false);

			lupFindLanguage.BindData("LanguageCode");
			InitGrid();
		}

		void InitGrid()
		{
			gridList.Init();
			gridList.AddGridColumns
			(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", HorzAlignment = HorzAlignment.Center, Width = 80 },
				new XGridColumn() { FieldName = "LogicalName", Width = 200 },
				new XGridColumn() { FieldName = "PhysicalName", Width = 200 },
				new XGridColumn() { FieldName = "CreatedOn" },
				new XGridColumn() { FieldName = "CreatedByName" },
				new XGridColumn() { FieldName = "UpdatedOn" },
				new XGridColumn() { FieldName = "UpdatedByName" }
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
		}

		protected override void LoadForm()
		{
			base.LoadForm();
			DataLoad();
		}
		protected override void DataInit()
		{
			txtID.Clear();
			lupLanguageCode.BindData("LanguageCode");
			txtLogicalName.Clear();
			txtPhysicalName.Clear();
			memDescription.Clear();

			txtCreatedOn.Clear();
			txtCreatedByName.Clear();
			txtUpdatedOn.Clear();
			txtUpdatedByName.Clear();

			SetToolbarButtons(new ToolbarButtons() { New = true, Refresh = true, Save = true, SaveAndNew = true });
			this.EditMode = EditModeEnum.New;
			txtLogicalName.Focus();
		}

		protected override void DataLoad(object param = null)
		{
			var parameters = new DataMap()
			{
				{ "LanguageCode", lupFindLanguage.EditValue },
				{ "FindText", txtFindText.EditValue }
			};
			gridList.BindList<MessageModel>("Base", "GetList", "Select", parameters);

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
					{ "LanguageCode", lupFindLanguage.EditValue },
					{ "ID", id }
				};
				var data = WasHandler.GetData<MessageModel>("Base", "GetData", "Select", parameters);
				if (data == null)
					throw new Exception("조회할 데이터가 없습니다.");

				SetControlData(data);

				SetToolbarButtons(new ToolbarButtons() { New = true, Refresh = true, Save = true, SaveAndNew = true, Delete = true });
				this.EditMode = EditModeEnum.Modify;
				txtLogicalName.Focus();

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
				var model = GetControlData<MessageModel>();
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
				using (var res = WasHandler.Execute<DataMap>("Base", "Delete", "DeleteMessage", new DataMap() { { "ID", txtID.EditValue } }, null))
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