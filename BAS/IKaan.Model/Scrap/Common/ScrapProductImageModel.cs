using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Scrap.Common
{
	[DataContract]
	public class ScrapProductImageModel : ModelBase
	{
		[DataMember]
		[Display(Name = "이미지명")]
		public string Name { get; set; }

		[DataMember]
		[Display(Name = "상품ID")]
		public int? ProductID { get; set; }

		[DataMember]
		[Display(Name = "이미지유형")]
		public string ImageType { get; set; }

		[DataMember]
		[Display(Name = "URL")]
		public string Url { get; set; }

		[DataMember]
		[Display(Name = "Width")]
		public int Width { get; set; }

		[DataMember]
		[Display(Name = "Height")]
		public int Height { get; set; }
	}
}
