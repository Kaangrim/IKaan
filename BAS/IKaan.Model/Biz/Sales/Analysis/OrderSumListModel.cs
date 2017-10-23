using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Biz.Sales.Analysis
{
	[DataContract]
	public class OrderSumListModel : ModelBase
	{
		[DataMember]
		[Display(Name = "상점ID")]
		public int StoreID { get; set; }

		[DataMember]
		[Display(Name = "상점명")]
		public string StoreName { get; set; }

		[DataMember]
		[Display(Name = "채널ID")]
		public int ChannelID { get; set; }

		[DataMember]
		[Display(Name = "채널명")]
		public string ChannelName { get; set; }

		[DataMember]
		[Display(Name = "브랜드ID")]
		public int BrandID { get; set; }

		[DataMember]
		[Display(Name = "브랜드명")]
		public string BrandName { get; set; }

		[DataMember]
		[Display(Name = "주문일자")]
		public DateTime OrderDate { get; set; }

		[DataMember]
		[Display(Name = "채널마진")]
		public int ChannelMargin { get; set; }

		[DataMember]
		[Display(Name = "브랜드마진")]
		public int BrandMargin { get; set; }

		[DataMember]
		[Display(Name = "수량")]
		public decimal OrderQty { get; set; }

		[DataMember]
		[Display(Name = "금액")]
		public decimal OrderAmt { get; set; }
	}
}
