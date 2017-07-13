using IKaan.Model.Base;

namespace IKaan.Model.BIZ.BS
{
	public class BSSales: ModelBase
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
