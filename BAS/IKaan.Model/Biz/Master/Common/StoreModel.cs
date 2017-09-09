using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Biz.Common
{
	[DataContract]
	public class StoreModel : ModelBase
	{
		[DataMember]
		[Display(Name = "상점명")]
		public string Name { get; set; }

		[DataMember]
		[Display(Name = "상점유형")]
		public string StoreType { get; set; }

		[DataMember]
		[Display(Name = "URL")]
		public string Url { get; set; }

		[DataMember]
		[Display(Name = "호스트명")]
		public string Hosts { get; set; }

		[DataMember]
		[Display(Name = "설명")]
		public string Description { get; set; }

		[DataMember]
		[Display(Name = "사용여부")]
		public string UseYn { get; set; }

		[DataMember]
		[Display(Name = "이미지ID")]
		public int? ImageID { get; set; }

		[DataMember]
		[Display(Name = "이미지")]
		public ImageModel Image { get; set; }
	}
}
