using IKaan.Model.Base;

namespace IKaan.Model.BIZ.BP
{
	public class BPPurchaseItem: ModelBase
	{
		public int PurchaseId { get; set; }
		public int ItemId { get; set; }
		public string ProductUnit { get; set; }
		public decimal PurchasePrice { get; set; }
		public int PurchaseQty { get; set; }
		public decimal PurchaseAmount { get; set; }
	}
}
