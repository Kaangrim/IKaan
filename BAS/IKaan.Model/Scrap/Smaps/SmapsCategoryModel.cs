using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Scrap.Smaps
{
	[DataContract]
	public class SmapsCategoryModel : ModelBase
	{
		[DataMember]
		[Display(Name = "요청ID")]
		public int? RequestID { get; set; }

		[DataMember]
		[Display(Name = "카테고리UID")]
		public int? uid { get; set; }

		[DataMember]
		[Display(Name = "카테고리명")]
		public string name { get; set; }
	}
}
