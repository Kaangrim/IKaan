using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Scrap.Smaps
{
	[DataContract]
	public class SmapsSizeModel : ModelBase
	{
		[DataMember]
		[Display(Name = "요청ID")]
		public int? RequestID { get; set; }

		[DataMember]
		[Display(Name = "UID")]
		public int? uid { get; set; }

		[DataMember]
		[Display(Name = "사이즈명")]
		public string text { get; set; }

		[DataMember]
		[Display(Name = "카테고리UID")]
		public int category_uid { get; set; }

		[DataMember]
		[Display(Name = "성별")]
		public string sex { get; set; }
	}
}
