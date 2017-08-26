using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace IKaan.Model.IKBiz
{
	[DataContract]
	public class OrderSumSalesModel
	{
		[DataMember]
		[Display(Name = "Row번호")]
		public int RowNo { get; set; }

		[DataMember]
		[Display(Name = "채널ID")]
		public int ChannelID { get; set; }

		[DataMember]
		[Display(Name = "채널명")]
		public string ChannelName { get; set; }

		[DataMember]
		[Display(Name = "채널매니저")]
		public string ChannelManager { get; set; }

		[DataMember]
		[Display(Name = "브랜드ID")]
		public int BrandID { get; set; }

		[DataMember]
		[Display(Name = "브랜드명")]
		public string BrandName { get; set; }

		[DataMember]
		[Display(Name = "브랜드매니저")]
		public string BrandManager { get; set; }

		[DataMember]
		[Display(Name = "수량")]
		public int OrderQty { get; set; }

		[DataMember]
		[Display(Name = "금액")]
		public decimal OrderAmt { get; set; }

		[DataMember]
		[Display(Name = "채널마진")]
		public decimal ChannelMargin { get; set; }

		[DataMember]
		[Display(Name = "채널정산액")]
		public decimal ChannelAccAmt { get; set; }

		[DataMember]
		[Display(Name = "브랜드마진")]
		public decimal BrandMargin { get; set; }

		[DataMember]
		[Display(Name = "브랜드정산액")]
		public decimal BrandAccAmt { get; set; }

		[DataMember]
		[Display(Name = "판매마진")]
		public decimal SaleMargin { get; set; }

		[DataMember]
		[Display(Name = "매출액")]
		public decimal SaleAmt { get; set; }


	}
}
