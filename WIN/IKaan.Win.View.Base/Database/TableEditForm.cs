using System;
using System.Collections.Generic;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.Base.Database;
using IKaan.Win.Core.Controls.Grid;
using IKaan.Win.Core.Enum;
using IKaan.Win.Core.Forms;
using IKaan.Win.Core.Model;
using IKaan.Win.Core.Utils;
using IKaan.Win.Core.Was.Handler;

namespace IKaan.Win.View.Base.Database
{
	public partial class TableEditForm : EditForm
	{
		public TableEditForm()
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
				if (IsLoaded)
					DataLoad(null);
			};
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			txtFindText.Focus();
		}

		protected override void InitButton()
		{
			base.InitButton();
			SetToolbarButtons(new ToolbarButtons() { Refresh = true, Save = true });
		}
		protected override void InitControls()
		{
			base.InitControls();

			SetFieldNames();

			txtID.SetEnable(false);
			txtCreatedOn.SetEnable(false);
			txtCreatedByName.SetEnable(false);
			txtUpdatedOn.SetEnable(false);
			txtUpdatedByName.SetEnable(false);
			txtSchemaName.SetEnable(false);

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
		}

		void InitGrid()
		{
			#region Table
			gridList.Init();
			gridList.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "TableName", Width = 150 },
				new XGridColumn() { FieldName = "Description", Width = 200 },
				new XGridColumn() { FieldName = "SchemaName", Width = 80 },
				new XGridColumn() { FieldName = "DatabaseName", Width = 100, HorzAlignment = HorzAlignment.Center },
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
						DetailDataLoad(view.GetRowCellValue(e.RowHandle, "TableName"));
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
				new XGridColumn() { FieldName = "PhysicalName", Width = 100 },
				new XGridColumn() { FieldName = "LogicalName", Width = 100 },
				new XGridColumn() { FieldName = "Description", Width = 200 },
				new XGridColumn() { FieldName = "DataType", Width = 100, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "NullYn", HorzAlignment = HorzAlignment.Center, Width = 60, RepositoryItem = gridList.GetRepositoryItemCheckEdit() },
				new XGridColumn() { FieldName = "PkYn", HorzAlignment = HorzAlignment.Center, Width = 60, RepositoryItem = gridList.GetRepositoryItemCheckEdit() },
				new XGridColumn() { FieldName = "FkYn", HorzAlignment = HorzAlignment.Center, Width = 60, RepositoryItem = gridList.GetRepositoryItemCheckEdit() },
				new XGridColumn() { FieldName = "IdentityYn", HorzAlignment = HorzAlignment.Center, Width = 60, RepositoryItem = gridList.GetRepositoryItemCheckEdit() },
				new XGridColumn() { FieldName = "DefaultValue", Width = 100, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "SortOrder", Width = 80, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "CreatedOn" },
				new XGridColumn() { FieldName = "CreatedByName" },
				new XGridColumn() { FieldName = "UpdatedOn" },
				new XGridColumn() { FieldName = "UpdatedByName" }
			);
			gridColumns.SetRespositoryItemTextEdit("LogicalName");
			gridColumns.SetRespositoryItemTextEdit("Description");
			gridColumns.SetEditable("LogicalName", "Description");
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
			ClearControlData<TableModel>();
			gridColumns.Clear<ColumnModel>();

			SetToolbarButtons(new ToolbarButtons() { Refresh = true, Save = true });
			EditMode = EditModeEnum.New;
			txtTableName.Focus();
		}

		protected override void DataLoad(object param = null)
		{
			var parameter = new DataMap()
			{
				{ "ServerID", lupServerID.EditValue },
				{ "DatabaseID", lupDatabaseID.EditValue },
				{ "FindText", txtFindText.EditValue }
			};
			gridList.BindList<TableModel>("Base", "GetList", "Select", parameter);

			if (param != null)
				DetailDataLoad(param);
			else
				DataInit();
		}

		void DetailDataLoad(object id)
		{
			try
			{
				var map = new DataMap()
				{
					{ "DatabaseID", lupDatabaseID.EditValue },
					{ "TableName", id }
				};
				var model = WasHandler.GetData<TableModel>("Base", "GetData", "Select", map);
				if (model == null)
					throw new Exception("조회할 데이터가 없습니다.");

				SetControlData(model);
				if (model.Columns == null)
					model.Columns = new List<ColumnModel>();

				foreach (var col in model.Columns)
				{
					if (col.LogicalName.IsNullOrEmpty())
					{
						switch (col.PhysicalName)
						{
							case "ID":
								col.LogicalName = "ID";
								break;
							case "CreatedOn":
								col.LogicalName = "최초생성일";
								break;
							case "CreatedBy":
								col.LogicalName = "최초생성자ID";
								break;
							case "CreatedByName":
								col.LogicalName = "최초생성자명";
								break;
							case "UpdatedOn":
								col.LogicalName = "최종수정일";
								break;
							case "UpdatedBy":
								col.LogicalName = "최종수정자ID";
								break;
							case "UpdatedByName":
								col.LogicalName = "최종수정자명";
								break;
							default:
								col.LogicalName = DomainUtils.GetFieldName(col.PhysicalName);
								break;
						}
					}
				}
				gridColumns.DataSource = model.Columns;

				SetToolbarButtons(new ToolbarButtons() { Refresh = true, Save = true, Delete = true });
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
				var model = this.GetControlData<TableModel>();
				model.DatabaseID = lupDatabaseID.EditValue.ToIntegerNullToZero();
				var columns = new List<ColumnModel>();

				if (gridColumns.RowCount > 0)
					columns = gridColumns.DataSource as List<ColumnModel>;

				model.Columns = columns;
				using (var res = WasHandler.Execute<TableModel>("Base", "Save", (this.EditMode == EditModeEnum.New) ? "Insert" : "Update", model, "ID"))
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
				using (var res = WasHandler.Execute<DataMap>("Base", "Delete", "DeleteTable", new DataMap() { { "ID", txtID.EditValue } }, "ID"))
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