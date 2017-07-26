using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Base;

namespace IKaan.Model.BIZ.BG
{
	public class BGGoodsItem : ModelBase
	{
		[DataMember]
		[Display(Name = "상품ID")]
		public int? GoodsID { get; set; }

		[DataMember]
		[Display(Name = "언어코드")]
		public string LanguageCode { get; set; }

		[DataMember]
		[Display(Name = "옵션1유형")]
		public string Option1Type { get; set; }

		[DataMember]
		[Display(Name = "옵션1명")]
		public string Option1Name { get; set; }

		[DataMember]
		[Display(Name = "옵션2유형")]
		public string Option2Type{ get; set; }

		[DataMember]
		[Display(Name = "옵션2명")]
		public string Option2Name { get; set; }

		[DataMember]
		[Display(Name = "언어명")]
		public string LanguageName { get; set; }
	}
}
