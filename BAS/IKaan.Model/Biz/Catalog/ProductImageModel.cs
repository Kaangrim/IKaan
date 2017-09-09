using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Biz.Catalog
{
	[DataContract]
	public class ProductImageModel : ModelBase
	{
		[DataMember]
		[Display(Name = "상품ID")]
		public int? ProductID { get; set; }

		[DataMember]
		[Display(Name = "이미지유형")]
		public string ImageType { get; set; }

		[DataMember]
		[Display(Name = "이미지그룹")]
		public string ImageGroup { get; set; }

		[DataMember]
		[Display(Name = "이미지ID")]
		public int? ImageID { get; set; }

		[DataMember]
		[Display(Name = "이미지유형명")]
		public string ImageTypeName{ get; set; }

		[DataMember]
		[Display(Name = "이미지그룹명")]
		public string ImageGroupName { get; set; }

		[DataMember]
		[Display(Name = "이미지URL")]
		public string ImageUrl { get; set; }
	}
}
