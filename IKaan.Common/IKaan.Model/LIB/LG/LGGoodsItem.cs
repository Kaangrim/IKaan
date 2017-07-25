using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Base;

namespace IKaan.Model.LIB.LG
{
	public class LGGoodsItem : ModelBase
	{
		[DataMember]
		[Display(Name = "상품ID")]
		public int? GoodsID { get; set; }

		[DataMember]
		[Display(Name = "언어코드")]
		public string LanguageCode { get; set; }

		[DataMember]
		[Display(Name = "이미지그룹")]
		public string Option1Type { get; set; }

		[DataMember]
		[Display(Name = "이미지URL")]
		public string Option1Name { get; set; }

		[DataMember]
		[Display(Name = "이미지유형명")]
		public string Option2Type{ get; set; }

		[DataMember]
		[Display(Name = "이미지그룹명")]
		public string Option2Name { get; set; }

		[DataMember]
		[Display(Name = "언어명")]
		public string LanguageName { get; set; }
	}
}
