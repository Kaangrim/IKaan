using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.Data;
using DevExpress.Utils;
using IKaan.Base.Map;
using IKaan.Model.Biz.Master.Brand;
using IKaan.Model.Scrap.Common;
using IKaan.Win.Core.Controls.Grid;
using IKaan.Win.Core.Forms;
using IKaan.Win.Core.Utils;
using IKaan.Win.Core.Was.Handler;

namespace IKaan.Win.View.Biz.Master.Brand
{
	public partial class BrandFromScrapForm : EditForm
	{
		public BrandFromScrapForm()
		{
			InitializeComponent();

			btnSearch.Click += (object sender, EventArgs e) => { DataLoad(); };
			btnAccept.Click += (object sender, EventArgs e) => { DataSave(null, null); };
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			txtFindText.Focus();
		}

		protected override void InitButton()
		{
			base.InitButton();
			this.VisibleToolbar = false;
		}
		protected override void InitControls()
		{
			base.InitControls();

			lcItemFindText.Tag = true;

			SetFieldNames();

			lupSiteID.BindData("ScrapSite");
			lupUseYn.BindData("Yn", "All");

			InitGrid();
		}

		void InitGrid()
		{
			#region Result
			gridResult.Init();
			gridResult.ShowFooter = true;
			gridResult.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "Checked", HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "SiteID", Visible = false },
				new XGridColumn() { FieldName = "Code", CaptionCode = "BrandCode", Width = 80 },
				new XGridColumn() { FieldName = "Name", CaptionCode = "BrandName", Width = 200, IsSummary = true, SummaryItemType = SummaryItemType.Count, SummaryFormatString = "N0" },
				new XGridColumn() { FieldName = "ProductCount", Width = 80, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString = "N0", IsSummary = true, SummaryItemType = SummaryItemType.Sum },
				new XGridColumn() { FieldName = "ScrapProductCount", Width = 80, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString = "N0", IsSummary = true, SummaryItemType = SummaryItemType.Sum },
				new XGridColumn() { FieldName = "ScrapImageCount", Width = 80, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString = "N0", IsSummary = true, SummaryItemType = SummaryItemType.Sum },
				new XGridColumn() { FieldName = "GenderMen", Width = 80, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString = "N0", IsSummary = true, SummaryItemType = SummaryItemType.Sum },
				new XGridColumn() { FieldName = "GenderFemale", Width = 80, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString = "N0", IsSummary = true, SummaryItemType = SummaryItemType.Sum },
				new XGridColumn() { FieldName = "GenderUnisex", Width = 80, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString = "N0", IsSummary = true, SummaryItemType = SummaryItemType.Sum },
				new XGridColumn() { FieldName = "Description", Width = 200 },
				new XGridColumn() { FieldName = "Url", Width = 200 },
				new XGridColumn() { FieldName = "CreatedOn" },
				new XGridColumn() { FieldName = "CreatedByName" },
				new XGridColumn() { FieldName = "UpdatedOn" },
				new XGridColumn() { FieldName = "UpdatedByName" }
			);
			gridResult.ColumnFix("RowNo");
			gridResult.ColumnFix("Checked");
			gridResult.SetRepositoryItemCheckEdit("Checked");
			gridResult.SetEditable("Checked");
			#endregion
		}

		protected override void DataLoad(object param = null)
		{
			try
			{
				SplashUtils.ShowWait("조회하는 중입니다... 잠시만...");
				gridResult.BindList<ScrapBrandModel>("Scrap", "GetList", "Select", new DataMap()
				{
					{ "SiteID", lupSiteID.EditValue },
					{ "FindText", txtFindText.EditValue },
					{ "UseYn", lupUseYn.EditValue }
				});
				SplashUtils.CloseWait();
			}
			catch (Exception ex)
			{
				SplashUtils.CloseWait();
				ShowErrBox(ex);
			}
		}

		protected override void DataSave(object arg, SaveCallback callback)
		{
			try
			{
				var list = new List<BrandModel>();
				var selected = gridResult.GetFilteredData<ScrapBrandModel>().Where(x => x.Checked == "Y").ToList();
				foreach(var data in selected)
				{
					list.Add(new BrandModel()
					{
						Name = data.Name,
						Code = data.Code,
						Description = data.Description
					});
				}
				using (var res = WasHandler.Execute<BrandModel>("Biz", "Save", "Insert", list, "ID"))
				{
					if (res.Error.Number != 0)
						throw new Exception(res.Error.Message);
				}
				this.SetModifiedCount();
				ShowMsgBox("저장하였습니다.");
				DataLoad();
			}
			catch(Exception ex)
			{
				ShowErrBox(ex);
			}
		}
	}
}