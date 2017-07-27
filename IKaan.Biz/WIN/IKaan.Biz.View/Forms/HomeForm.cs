using System;
using System.Windows.Forms;
using IKaan.Base.Utils;
using IKaan.Biz.Core.Forms;
using IKaan.Biz.Core.Variables;

namespace IKaan.Biz.View.Forms
{
	public partial class HomeForm : BaseForm
	{
		public HomeForm()
		{
			InitializeComponent();
			Init();
		}

		private void Init()
		{			
		}

		protected override void LoadForm()
		{
			base.LoadForm();
			this.Padding = new Padding(4);

			doHomeRefresh();

			DataLoad();
		}

		private void doHomeRefresh()
		{
			string url = @"https://demos.devexpress.com/Dashboard/?mode=viewer&dashboardId=SalesOverview"; //@"http://pc.shopping2.naver.com/home/p/index.nhn#";
			if (GlobalVar.MainInfo.HomePage.IsNullOrEmpty() == false)
				url = GlobalVar.MainInfo.HomePage.ToStringNullToEmpty();
			wb.Navigate(new Uri(url));
		}
		
		private void DataLoad()
		{
			//try
			//{
			//	var res = DBTranHelper.GetData("Sales", "GetSaleDashboard", new DataMap() { { "SALE_DATE", DateTime.Now.ToString("yyyyMMdd") } });

			//	if (res.TranList.Length > 0)
			//	{
			//		for (int i = 0; i < chart1.Series.Count; i++)
			//			chart1.Series[i].Points.Clear();

			//		var data1 = res.TranList[0].Data as List<DataMap>;
			//		foreach (DataMap data in data1)
			//		{
			//			chart1.Series[0].Points.Add(new SeriesPoint(data.GetValue("SALE_DATE").ToString().ToDateTime(), data.GetValue("SALE_AMT").ToDecimalNullToZero()));
			//		}
			//	}

			//	if (res.TranList.Length > 1)
			//	{
			//		for (int i = 0; i < chart2.Series.Count; i++)
			//			chart2.Series[i].Points.Clear();

			//		var data2 = res.TranList[1].Data as List<DataMap>;
			//		foreach (DataMap data in data2)
			//		{
			//			chart2.Series[0].Points.Add(new SeriesPoint((data.GetValue("SALE_YM").ToString() + "01").ToDateTime(), data.GetValue("SALE_AMT").ToDecimalNullToZero()));
			//		}
			//	}
			//}
			//catch (Exception ex)
			//{
			//	MsgBox.Show(ex);
			//}
		}
	}
}