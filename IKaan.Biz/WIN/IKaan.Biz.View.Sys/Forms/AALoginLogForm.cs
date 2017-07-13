using System;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using IKaan.Base.Map;
using IKaan.Biz.Core.Controls.Grid;
using IKaan.Biz.Core.Enum;
using IKaan.Biz.Core.Forms;
using IKaan.Biz.Core.Model;
using IKaan.Biz.Core.Utils;
using IKaan.Biz.Core.Was.Handler;
using IKaan.Model.SYS.AA;

namespace IKaan.Biz.View.Sys.Forms
{
	public partial class AALoginLogForm : EditForm
	{
		public AALoginLogForm()
		{
			InitializeComponent();
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

			datStartDate.Init(CalendarViewType.DayView);
			datEndDate.Init(CalendarViewType.DayView);
			
			InitGrid();
		}

		void InitGrid()
		{
			#region 로그인 사용자 목록
			gridList.Init();
			gridList.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "UserID", Visible = false },
				new XGridColumn() { FieldName = "UserName", Width = 100 },
				new XGridColumn() { FieldName = "LoginID", Width = 150 },
				new XGridColumn() { FieldName = "LoginCount", Width = 100, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString = "N0" },
				new XGridColumn() { FieldName = "FirstLoginDate", Width = 150, HorzAlignment = HorzAlignment.Center, FormatType = FormatType.DateTime, FormatString = "yyyy.MM.dd HH:mm:ss" },
				new XGridColumn() { FieldName = "LastLoginDate", Width = 150, HorzAlignment = HorzAlignment.Center, FormatType = FormatType.DateTime, FormatString = "yyyy.MM.dd HH:mm:ss" }
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
						DetailDataLoad(view.GetRowCellValue(e.RowHandle, "UserID"));
					}
				}
				catch(Exception ex)
				{
					ShowErrBox(ex);
				}
			};
			#endregion

			#region 로그인 로그
			gridLogList.Init();
			gridLogList.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "LoginDate", Width = 150, HorzAlignment = HorzAlignment.Center, FormatType = FormatType.DateTime, FormatString = "yyyy.MM.dd HH:mm:ss" },
				new XGridColumn() { FieldName = "LogoutDate", Width = 150, HorzAlignment = HorzAlignment.Center, FormatType = FormatType.DateTime, FormatString = "yyyy.MM.dd HH:mm:ss" },
				new XGridColumn() { FieldName = "UserID", Visible = false },
				new XGridColumn() { FieldName = "UserName", Width = 80, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "LoginID", Width = 150 },
				new XGridColumn() { FieldName = "Version", Width = 100, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "MainSkin", Width = 150, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "GridSkin", Width = 150, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "IpAddress", Width = 100, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "MacAddress", Width = 150, HorzAlignment = HorzAlignment.Center }
			);
			gridLogList.SetColumnBackColor(SkinUtils.ForeColor, "RowNo");
			gridLogList.SetColumnForeColor(SkinUtils.BackColor, "RowNo");
			gridLogList.ColumnFix("RowNo");
			#endregion
		}

		protected override void LoadForm()
		{
			base.LoadForm();
			DataLoad();
		}

		protected override void DataLoad(object param = null)
		{
			try
			{
				DataMap parameter = new DataMap()
			{
				{ "FindText", txtFindText.EditValue },
				{ "StartDate", datStartDate.GetDateChar8() },
				{ "EndDate", datEndDate.GetDateChar8() }
			};
				gridList.BindList<AALoginLogUser>("AA", "GetList", "Select", parameter);
			}
			catch(Exception ex)
			{
				ShowErrBox(ex);
			}
		}

		void DetailDataLoad(object id)
		{
			try
			{
				gridLogList.BindList<AALoginLog>("AA", "GetList", "Select", new DataMap() { { "UserID", id } });
			}
			catch(Exception ex)
			{
				ShowErrBox(ex);
			}
		}
	}
}