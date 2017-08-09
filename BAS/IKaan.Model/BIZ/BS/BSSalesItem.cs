using IKaan.Model.Base;

namespace IKaan.Model.BIZ.BS
{
	public class BSSalesItem: ModelBase
	{
		public int SaleId { get; set; }
		public int ItemId { get; set; }
		public decimal SalePrice { get; set; }
		public int DiscountRate { get; set; }
		public decimal DiscountPrice { get; set; }
		public int SaleQty { get; set; }
		public decimal SaleAmount { get; set; }
		public decimal DiscountAmount { get; set; }
		public string DiscountType { get; set; }
	}
}
