using System;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using IKaan.Base.Map;
using IKaan.Model.Biz.Master.Customer;
using IKaan.Win.Core.Controls.Grid;
using IKaan.Win.Core.Forms;
using IKaan.Win.Core.Model;

namespace IKaan.Win.View.Biz.Master.Customer
{
	public partial class CustomerListForm : EditForm
	{
		public CustomerListForm()
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
			SetToolbarButtons(new ToolbarButtons() { New = true, Refresh = true });
		}
		protected override void InitControls()
		{
			base.InitControls();

			SetFieldNames();

			lupCustomerType.BindData("CustomerType", "All");
			lupUseYn.BindData("Yn", "All");
			lupUseYn.EditValue = "Y";

			InitGrid();
		}

		void InitGrid()
		{
			gridList.Init();
			gridList.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "Name", CaptionCode = "CustomerName", Width = 200 },
				new XGridColumn() { FieldName = "CustomerType", Visible = false },
				new XGridColumn() { FieldName = "CustomerTypeName", Width = 100 },
				new XGridColumn() { FieldName = "BizNo", Width = 100, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "RepName", Width = 100, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "UseYn", Width = 80, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "CreatedOn" },
				new XGridColumn() { FieldName = "CreatedByName" },
				new XGridColumn() { FieldName = "UpdatedOn" },
				new XGridColumn() { FieldName = "UpdatedByName" }
			);
			gridList.SetRepositoryItemCheckEdit("UseYn");
			gridList.ColumnFix("RowNo");

			gridList.RowCellClick += delegate (object sender, RowCellClickEventArgs e)
			{
				if (e.RowHandle < 0)
					return;

				try
				{
					if (e.Button == MouseButtons.Left && e.Clicks == 2)
					{
						GridView view = sender as GridView;
						ShowEdit(view.GetRowCellValue(e.RowHandle, "ID"));
					}
				}
				catch(Exception ex)
				{
					ShowErrBox(ex);
				}
			};
		}

		protected override void DataLoad(object param = null)
		{
			gridList.BindList<CustomerModel>("Biz", "GetList", "Select", new DataMap()
			{
				{ "FindText", txtFindText.EditValue },
				{ "CustomerType", txtFindText.EditValue },
				{ "UseYn", lupUseYn.EditValue }
			});
		}

		protected override void ActNew()
		{
			ShowEdit(null);
		}

		protected override void ShowEdit(object data = null)
		{
			using(var form = new CustomerEditForm())
			{
				form.Text = "거래처등록";
				form.StartPosition = FormStartPosition.CenterScreen;
				form.IsLoadingRefresh = true;
				form.ParamsData = data;
				if (form.ShowDialog() == DialogResult.OK)
					DataLoad();
			}
		}
	}
}