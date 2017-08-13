using System;
using IKaan.Base.Map;
using IKaan.Model.SYS.AD;
using IKaan.Win.Core.Controls.Grid;
using IKaan.Win.Core.Forms;
using IKaan.Win.Core.Model;

namespace IKaan.Win.View.Sys.AD
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
				if (this.IsLoaded)
					DataLoad(null);
			};
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			txtTableName.Focus();
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
		}

		void InitGrid()
		{
			#region Table Statistic
			gridList.Init();
			gridList.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "SchemaName", Width = 80 },
				new XGridColumn() { FieldName = "TableName", Width = 150 },
				new XGridColumn() { FieldName = "Description", Width = 150 },
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
				{ "DatabaseID", lupDatabaseID.EditValue },
				{ "TableName", txtTableName.EditValue }
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