using System;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using IKaan.Base.Map;
using IKaan.Model.Base;
using IKaan.Win.Core.Controls.Grid;
using IKaan.Win.Core.Enum;
using IKaan.Win.Core.Forms;
using IKaan.Win.Core.Model;
using IKaan.Win.Core.Utils;

namespace IKaan.Win.View.Base.Authority
{
	public partial class LoginLogListForm : EditForm
	{
		public LoginLogListForm()
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
				gridList.BindList<LoginLogUserModel>("Base", "GetList", "Select", parameter);
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
				gridLogList.BindList<LoginLogModel>("Base", "GetList", "Select", new DataMap() { { "UserID", id } });
			}
			catch(Exception ex)
			{
				ShowErrBox(ex);
			}
		}
	}
}