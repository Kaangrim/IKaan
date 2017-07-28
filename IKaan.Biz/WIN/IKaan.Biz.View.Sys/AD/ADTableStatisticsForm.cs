using System;
using IKaan.Base.Map;
using IKaan.Biz.Core.Controls.Grid;
using IKaan.Biz.Core.Forms;
using IKaan.Biz.Core.Model;
using IKaan.Biz.Core.Utils;
using IKaan.Model.SYS.AD;

namespace IKaan.Biz.View.Sys.AD
{
	public partial class ADTableStatisticsForm : EditForm
	{
		public ADTableStatisticsForm()
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
			SetToolbarButtons(new ToolbarButtons() { Refresh = true });
		}
		protected override void InitControls()
		{
			base.InitControls();

			SetFieldNames();

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
			#region Table Statistic
			gridList.Init();
			gridList.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "SchemaName", Width = 80 },
				new XGridColumn() { FieldName = "TableID", Visible = false },
				new XGridColumn() { FieldName = "TableName", Width = 100 },
				new XGridColumn() { FieldName = "Description", Width = 100 },
				new XGridColumn() { FieldName = "RowCnt", Width = 80 },
				new XGridColumn() { FieldName = "TableSize", Width = 80 },
				new XGridColumn() { FieldName = "DataSize", Width = 80 },
				new XGridColumn() { FieldName = "IndexSize", Width = 80 },
				new XGridColumn() { FieldName = "LastUserSeek", Width = 150 },
				new XGridColumn() { FieldName = "LastUserScan", Width = 150 },
				new XGridColumn() { FieldName = "LastUserLookup", Width = 150 },
				new XGridColumn() { FieldName = "LastUserUpdate", Width = 150 },
				new XGridColumn() { FieldName = "LastSystemUpdate", Width = 150 }
			);
			gridList.ColumnFix("RowNo");
			#endregion
		}

		protected override void DataLoad(object param = null)
		{
			DataMap parameter = new DataMap()
			{
				{ "DatabaseName", lupDatabaseID.Text },
				{ "SchemaName", lupSchemaID.Text },
				{ "FindText", txtFindText.EditValue }
			};
			object value = lupDatabaseID.GetSelectedDataRow();
			if (value != null)
			{
				LookupSource ls = (LookupSource)value;
				gridList.BindList<ADTableStatistics>("AD", "GetList", string.Concat("SelectADTableBy", ls.Option2), parameter);
			}
		}
	}
}