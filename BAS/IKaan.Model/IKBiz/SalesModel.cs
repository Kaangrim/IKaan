using IKaan.Model.Common.Base;

namespace IKaan.Model.IKBiz
{
	public class SalesModel: ModelBase
	{
		public string SaleNo { get; set; }
		public string SaleDate { get; set; }
		public string SaleType { get; set; }
		public string PayType { get; set; }
		public int CustomerId { get; set; }
		public string CustomerName { get; set; }
		public string Remarks { get; set; }
	}
}
