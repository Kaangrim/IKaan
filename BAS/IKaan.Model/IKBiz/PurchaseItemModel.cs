using IKaan.Model.Common.Base;

namespace IKaan.Model.IKBiz
{
	public class PurchaseItemModel: ModelBase
	{
		public int PurchaseId { get; set; }
		public int ItemId { get; set; }
		public string ProductUnit { get; set; }
		public decimal PurchasePrice { get; set; }
		public int PurchaseQty { get; set; }
		public decimal PurchaseAmount { get; set; }
	}
}
