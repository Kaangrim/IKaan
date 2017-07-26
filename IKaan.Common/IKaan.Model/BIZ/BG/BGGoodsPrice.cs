using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Base;

namespace IKaan.Model.BIZ.BG
{
	public class BGGoodsPrice : ModelBase
	{
		[DataMember]
		[Display(Name = "상품ID")]
		public int? GoodsID { get; set; }

		[DataMember]
		[Display(Name = "통화구분")]
		public string Currency { get; set; }

		[DataMember]
		[Display(Name = "정가")]
		public decimal ListPrice { get; set; }

		[DataMember]
		[Display(Name = "판매가")]
		public decimal SalePrice { get; set; }

		[DataMember]
		[Display(Name = "통화명")]
		public string CurrencyName { get; set; }
	}
}
