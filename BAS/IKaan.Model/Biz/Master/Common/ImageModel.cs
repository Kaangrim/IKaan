using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Biz.Master.Common
{
	[DataContract]
	public class ImageModel : ModelBase
	{
		[DataMember]
		[Display(Name = "파일명")]
		public string Name { get; set; }

		[DataMember]
		[Display(Name = "이미지유형")]
		public string ImageType { get; set; }

		[DataMember]
		[Display(Name = "경로")]
		public string Url { get; set; }

		[DataMember]
		[Display(Name = "Width")]
		public int Width { get; set; }

		[DataMember]
		[Display(Name = "Height")]
		public int Height { get; set; }
	}
}
