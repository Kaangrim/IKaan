using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Base;

namespace IKaan.Model.LIB.LG
{
	public class LGGoodsImage : ModelBase
	{
		[DataMember]
		[Display(Name = "상품ID")]
		public int? GoodsID { get; set; }

		[DataMember]
		[Display(Name = "이미지유형")]
		public string ImageType { get; set; }

		[DataMember]
		[Display(Name = "이미지그룹")]
		public string ImageGroup { get; set; }

		[DataMember]
		[Display(Name = "이미지URL")]
		public string ImageUrl { get; set; }

		[DataMember]
		[Display(Name = "이미지유형명")]
		public string ImageTypeName{ get; set; }

		[DataMember]
		[Display(Name = "이미지그룹명")]
		public string ImageGroupName { get; set; }
	}
}
