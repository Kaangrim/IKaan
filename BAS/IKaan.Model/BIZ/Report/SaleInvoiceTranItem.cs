namespace IKaan.Model.Report
{
	public class SaleInvoiceTranItem
	{
		public int ItemID { get; set; }
		public int SaleID { get; set; }
		public int ProductID { get; set; }
		public decimal SalePrice { get; set; }
		public int DiscRate { get; set; }
		public decimal DiscPrice { get; set; }
		public int SaleQty { get; set; }
		public decimal SaleAmt { get; set; }
		public decimal DiscAmt { get; set; }
		public decimal NpayAmt { get; set; }
		public string DiscType { get; set; }
		public string ProductName { get; set; }
		public int RowNo { get; set; }
	}
}
