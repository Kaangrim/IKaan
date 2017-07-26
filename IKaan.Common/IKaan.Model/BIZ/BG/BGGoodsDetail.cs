using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Base;

namespace IKaan.Model.BIZ.BG
{
	public class BGGoodsDetail : ModelBase
	{
		[DataMember]
		[Display(Name = "상품ID")]
		public int? GoodsID { get; set; }

		[DataMember]
		[Display(Name = "언어코드")]
		public string LanguageCode { get; set; }

		[DataMember]
		[Display(Name = "상품명")]
		public string GoodsName { get; set; }

		[DataMember]
		[Display(Name = "상세설명")]
		public string Description { get; set; }

		[DataMember]
		[Display(Name = "언어명")]
		public string LanguageName{ get; set; }
	}
}
