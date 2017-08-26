using IKaan.Model.Common.Base;

namespace IKaan.Model.IKBiz
{
	public class PurchaseModel : ModelBase
	{
		public string PurchaseNo { get; set; }
		public string PurchaseDate { get; set; }
		public string PurchaseType { get; set; }
		public int CustomerId { get; set; }
		public string CustomerName { get; set; }
		public string Remarks { get; set; }
	}
}
