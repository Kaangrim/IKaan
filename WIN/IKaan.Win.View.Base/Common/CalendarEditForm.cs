using System;
using System.Drawing;
using System.Windows.Forms;
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
	public partial class CalendarEditForm : EditForm
	{
		public CalendarEditForm()
		{
			InitializeComponent();

			datFindCalYear.EditValueChanged += (object sender, EventArgs e) => { DataLoad(null); };
			btnCreateCalendar.Click += (object sender, EventArgs e) => { CreateCalendar(); };
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			datFindCalYear.Focus();
		}

		protected override void InitButton()
		{
			base.InitButton();
			SetToolbarButtons(new ToolbarButtons() { New = true, Refresh = true, Save = true, SaveAndNew = true });
		}
		protected override void InitControls()
		{
			base.InitControls();

			SetFieldNames();
		
			txtID.SetEnable(false);
			datCalDate.SetEnable(false);
			spnCalYear.SetEnable(false);
			spnCalMonth.SetEnable(false);
			spnCalDay.SetEnable(false);
			spnQuarter.SetEnable(false);
			spnDayOfWeek.SetEnable(false);
			spnDayOfYear.SetEnable(false);
			spnWeekOfYear.SetEnable(false);
			txtCreatedOn.SetEnable(false);
			txtCreatedByName.SetEnable(false);
			txtUpdatedOn.SetEnable(false);
			txtUpdatedByName.SetEnable(false);

			datFindCalYear.Init(CalendarViewType.YearView);
			datCalDate.Init(CalendarViewType.DayView);
			spnCalYear.SetFormat("D", false, HorzAlignment.Near);
			spnCalMonth.SetFormat("D", false, HorzAlignment.Near);
			spnCalDay.SetFormat("D", false, HorzAlignment.Near);
			spnQuarter.SetFormat("D", false, HorzAlignment.Near);
			spnDayOfWeek.SetFormat("D", false, HorzAlignment.Near);
			spnDayOfYear.SetFormat("D", false, HorzAlignment.Near);
			spnWeekOfMonth.SetFormat("D", false, HorzAlignment.Near);
			spnWeekOfYear.SetFormat("D", false, HorzAlignment.Near);

			InitGrid();
		}

		void InitGrid()
		{
			gridList.Init();
			gridList.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "CalDate", Width = 100, HorzAlignment= HorzAlignment.Center },
				new XGridColumn() { FieldName = "CalYear", Width = 60, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "CalMonth", Width = 60, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "CalDay", Width = 60, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "Quarter", Width = 60, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "DayOfWeek", Width = 60, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "DayOfYear", Width = 60, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "WeekOfMonth", Width = 60, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "WeekOfYear", Width = 60, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "DayOfWeekName", Width = 60, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "HolidayYn", Width = 60, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "Description", Width = 200 },
				new XGridColumn() { FieldName = "CreatedOn" },
				new XGridColumn() { FieldName = "CreatedByName" },
				new XGridColumn() { FieldName = "UpdatedOn" },
				new XGridColumn() { FieldName = "UpdatedByName" }
			);
			gridList.ColumnFix("RowNo");
			gridList.SetRepositoryItemCheckEdit("HolidayYn");

			gridList.RowCellClick += delegate (object sender, RowCellClickEventArgs e)
			{
				if (e.RowHandle < 0)
					return;

				try
				{
					if (e.Button == MouseButtons.Left && e.Clicks == 1)
					{
						GridView view = sender as GridView;
						DetailDataLoad(view.GetRowCellValue(e.RowHandle, "ID"));
					}
				}
				catch (Exception ex)
				{
					ShowErrBox(ex);
				}
			};

			gridList.RowCellStyle += (object sender, RowCellStyleEventArgs e) =>
			{
				if (e.RowHandle < 0)
					return;

				try
				{
					GridView view = sender as GridView;
					if (view.GetRowCellValue(e.RowHandle, "DayOfWeek").ToString() == "1")
						e.Appearance.BackColor = Color.LightPink;
					else if (view.GetRowCellValue(e.RowHandle, "DayOfWeek").ToString() == "7")
						e.Appearance.BackColor = Color.LightBlue;
					else if (view.GetRowCellValue(e.RowHandle, "HolidayYn").ToString() == "Y")
						e.Appearance.BackColor = Color.LightGreen;
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
			ClearControlData<CalendarModel>();

			SetToolbarButtons(new ToolbarButtons() { New = true, Refresh = true, Save = true, SaveAndNew = true });
			this.EditMode = EditModeEnum.New;
			memDescription.Focus();
		}

		protected override void DataLoad(object param = null)
		{
			gridList.BindList<CalendarModel>("Base", "GetList", "Select", new DataMap()
			{
				{ "CalYear", datFindCalYear.DateTime.Year }
			});

			if (param != null)
				DetailDataLoad(param);
			else
				DataInit();
		}

		void DetailDataLoad(object id)
		{
			try
			{
				var data = WasHandler.GetData<CalendarModel>("Base", "GetData", "Select", new DataMap() { { "ID", id } });
				SetControlData(data);

				SetToolbarButtons(new ToolbarButtons() { New = true, Refresh = true, Save = true, SaveAndNew = true, Delete = true });
				this.EditMode = EditModeEnum.Modify;
				memDescription.Focus();
			}
			catch(Exception ex)
			{
				ShowErrBox(ex);
			}
		}

		protected override void DataSave(object arg, SaveCallback callback)
		{
			if (DataValidate() == false) return;

			try
			{
				var model = GetControlData<CalendarModel>();
				using (var res = WasHandler.Execute<CalendarModel>("Base", "Save", (this.EditMode == EditModeEnum.New) ? "Insert" : "Update", model, "ID"))
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
				using (var res = WasHandler.Execute<DataMap>("Base", "Delete", "DeleteCalendar", new DataMap() { { "ID", txtID.EditValue } }, null))
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

		private void CreateCalendar()
		{
			try
			{
				SplashUtils.ShowWait("생성하는 중입니다... 잠시만...");
				using (var res = WasHandler.Execute<CalendarModel>("Base", "Save", "CreateCalendar", new DataMap() { { "CalYear", datFindCalYear.DateTime.Year } }))
				{
					if (res.Error.Number != 0)
						throw new Exception(res.Error.Message);

					SplashUtils.CloseWait();
					ShowMsgBox("생성하였습니다.");
					DataLoad(null);
				}
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}
	}
}