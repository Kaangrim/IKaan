using System;
using System.Collections.Generic;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Biz.Core.Controls.Grid;
using IKaan.Biz.Core.Enum;
using IKaan.Biz.Core.Forms;
using IKaan.Biz.Core.Model;
using IKaan.Biz.Core.Utils;
using IKaan.Biz.Core.Was.Handler;
using IKaan.Model.SYS.AD;

namespace IKaan.Biz.View.Sys.Forms
{
	public partial class ADTableStatForm : EditForm
	{
		public ADTableStatForm()
		{
			InitializeComponent();

			lupServerID.EditValueChanged += delegate (object sender, EventArgs e)
			{
				lupDatabaseID.Clear();				
				lupDatabaseID.BindData("DatabaseList", null, true, new DataMap()
				{
					{ "ServerID", lupServerID.EditValue }
				});
			};

			lupDatabaseID.EditValueChanged += delegate (object sender, EventArgs e)
			{
				lupSchemaID.Clear();
				lupSchemaID.BindData("SchemaList", null, true, new DataMap()
				{
					{ "ServerID", lupServerID.EditValue },
					{ "DatabaseID", lupDatabaseID.EditValue }
				});
			};

			lupSchemaID.EditValueChanged += delegate (object sender, EventArgs e)
			{
				if (this.IsLoaded)
					DataLoad(null);
			};
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			txtFindText.Focus();
		}

		protected override void InitButtons()
		{
			base.InitButtons();
			SetToolbarButtons(new ToolbarButtons() { New = true, Refresh = true, Save = true, SaveAndNew = true });
		}
		protected override void InitControls()
		{
			base.InitControls();

			SetFieldNames();

			txtID.SetEnable(false);
			txtCreateDate.SetEnable(false);
			txtCreateByName.SetEnable(false);
			txtUpdateDate.SetEnable(false);
			txtUpdateByName.SetEnable(false);

			InitCombo();
			InitGrid();
		}

		void InitCombo()
		{
			lupServerID.BindData("ServerList", null, true);
			lupDatabaseID.BindData("DatabaseList", null, true, new DataMap()
			{
				{ "ServerID", lupServerID.EditValue }
			});
			lupSchemaID.BindData("SchemaList", null, true, new DataMap()
			{
				{ "ServerID", lupServerID.EditValue },
				{ "DatabaseID", lupDatabaseID.EditValue }
			});
		}

		void InitGrid()
		{
			#region Table
			gridList.Init();
			gridList.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "TableName", Width = 100 },
				new XGridColumn() { FieldName = "Description", Width = 100 },
				new XGridColumn() { FieldName = "SchemaName", Width = 200 },
				new XGridColumn() { FieldName = "DatabaseName", Width = 100, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "CreateDate", Width = 150, HorzAlignment = HorzAlignment.Center, FormatType = FormatType.DateTime, FormatString = "yyyy.MM.dd HH:mm:ss" },
				new XGridColumn() { FieldName = "CreateByName", Width = 80, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "UpdateDate", Width = 150, HorzAlignment = HorzAlignment.Center, FormatType = FormatType.DateTime, FormatString = "yyyy.MM.dd HH:mm:ss" },
				new XGridColumn() { FieldName = "UpdateByName", Width = 80, HorzAlignment = HorzAlignment.Center }
			);
			gridList.SetColumnBackColor(SkinUtils.ForeColor, "RowNo");
			gridList.SetColumnForeColor(SkinUtils.BackColor, "RowNo");
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

			#region Column
			gridColumns.Init();
			gridColumns.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "PysicalName", Width = 100 },
				new XGridColumn() { FieldName = "LogicalName", Width = 100 },
				new XGridColumn() { FieldName = "Description", Width = 200 },
				new XGridColumn() { FieldName = "DataType", Width = 100, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "NullYn", HorzAlignment = HorzAlignment.Center, Width = 60, RepositoryItem = gridList.GetRepositoryItemCheckEdit() },
				new XGridColumn() { FieldName = "PkYn", HorzAlignment = HorzAlignment.Center, Width = 60, RepositoryItem = gridList.GetRepositoryItemCheckEdit() },
				new XGridColumn() { FieldName = "FkYn", HorzAlignment = HorzAlignment.Center, Width = 60, RepositoryItem = gridList.GetRepositoryItemCheckEdit() },
				new XGridColumn() { FieldName = "IdentityYn", HorzAlignment = HorzAlignment.Center, Width = 60, RepositoryItem = gridList.GetRepositoryItemCheckEdit() },
				new XGridColumn() { FieldName = "DefaultValue", Width = 100, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "SortOrder", Width = 80, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "CreateDate", Width = 150, HorzAlignment = HorzAlignment.Center, FormatType = FormatType.DateTime, FormatString = "yyyy.MM.dd HH:mm:ss" },
				new XGridColumn() { FieldName = "CreateByName", Width = 80, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "UpdateDate", Width = 150, HorzAlignment = HorzAlignment.Center, FormatType = FormatType.DateTime, FormatString = "yyyy.MM.dd HH:mm:ss" },
				new XGridColumn() { FieldName = "UpdateByName", Width = 80, HorzAlignment = HorzAlignment.Center }
			);
			gridColumns.SetRespositoryItemTextEdit("LogicalName");
			gridColumns.SetRespositoryItemTextEdit("Description");
			gridColumns.SetEditable("LogicalName", "Description");
			gridColumns.SetColumnBackColor(SkinUtils.ForeColor, "RowNo");
			gridColumns.SetColumnForeColor(SkinUtils.BackColor, "RowNo");
			gridColumns.ColumnFix("RowNo");
			#endregion
		}

		protected override void LoadForm()
		{
			base.LoadForm();
			DataLoad();
		}

		protected override void DataInit()
		{
			ClearControlData<ADTable>();
			SetToolbarButtons(new ToolbarButtons() { New = true, Refresh = true, Save = true, SaveAndNew = true });
			EditMode = EditModeEnum.New;
			txtTableName.Focus();
		}

		protected override void DataLoad(object param = null)
		{
			DataMap parameter = new DataMap()
			{
				{ "ServerID", lupServerID.EditValue },
				{ "DatabaseID", lupDatabaseID.EditValue },
				{ "SchemaID", lupSchemaID.EditValue },
				{ "FindText", txtFindText.EditValue }
			};
			gridList.BindList<ADTable>("AD", "GetList", "Select", parameter);

			if (param != null)
				DetailDataLoad(param);
			else
				DataInit();
		}

		void DetailDataLoad(object id)
		{
			try
			{
				var model = WasHandler.GetData<ADTable>("AD", "GetData", "Select", new DataMap() { { "ID", id } });
				if (model == null)
					throw new Exception("조회할 데이터가 없습니다.");

				SetControlData(model);
				SetToolbarButtons(new ToolbarButtons() { New = true, Refresh = true, Save = true, SaveAndNew = true, Delete = true });
				this.EditMode = EditModeEnum.Modify;
				txtTableName.Focus();
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
				var model = this.GetControlData<ADTable>();
				model.DatabaseID = lupDatabaseID.EditValue.ToIntegerNullToZero();
				model.SchemaID = lupSchemaID.EditValue.ToIntegerNullToZero();
				List<ADColumn> columns = new List<ADColumn>();

				if (gridColumns.RowCount > 0)
					columns = gridColumns.DataSource as List<ADColumn>;

				model.Columns = columns;

				using (var res = WasHandler.Execute<ADTable>("AD", "Save", (this.EditMode == EditModeEnum.New) ? "Insert" : "Update", model, "ID"))
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
				DataMap map = new DataMap() { { "ID", txtID.EditValue } };
				using (var res = WasHandler.Execute<DataMap>("AA", "Delete", "DeleteADTable", map, "ID"))
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