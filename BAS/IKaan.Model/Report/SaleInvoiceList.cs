namespace IKaan.Model.IKReport
{
	public class SaleInvoiceList
	{
		public int ROW_NO { get; set; }
		public int SALE_ID { get; set; }
		public string SALE_NO { get; set; }
		public string SALE_DATE { get; set; }
		public string SALE_TYPE { get; set; }
		public string PAY_TYPE { get; set; }
		public int CUSTOMER_ID { get; set; }
		public string CUSTOMER_NAME { get; set; }
		public string REMARKS { get; set; }
		public int SALE_QTY { get; set; }
		public decimal SALE_AMT { get; set; }
		public decimal DISC_AMT { get; set; }
		public decimal NPAY_AMT { get; set; }
	}
}
