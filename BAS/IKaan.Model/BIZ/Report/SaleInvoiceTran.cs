namespace IKaan.Model.Report
{
	public class SaleInvoiceTran
	{
		public int SaleID { get; set; }
		public string SaleNo { get; set; }
		public string SaleDate { get; set; }
		public string SaleType { get; set; }
		public string PayType { get; set; }
		public int CustomerID { get; set; }
		public string CustomerName { get; set; }
		public string Remarks { get; set; }
		public int SaleQty { get; set; }
		public decimal SaleAmt { get; set; }
		public decimal DiscAmt { get; set; }
		public decimal NpayAmt { get; set; }
		public decimal SupAmt { get; set; }
		public decimal TaxAmt { get; set; }
		public string CustomerBizRegNo { get; set; }
		public string CustomerBizName { get; set; }
		public string CustomerRepName { get; set; }
		public string CustomerBizType { get; set; }
		public string CustomerBizItem { get; set; }
		public string CustomerAddress { get; set; }
		public string CompanyBizRegNo { get; set; }
		public string CompanyBizName { get; set; }
		public string CompanyRepName { get; set; }
		public string CompanyBizType { get; set; }
		public string CompanyBizItem { get; set; }
		public string CompanyAddress { get; set; }
	}
}
