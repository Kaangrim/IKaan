using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Biz
{
	[DataContract]
	public class SearchBrandActivityModel : ModelBase
	{
		[DataMember]
		[Display(Name = "브랜드검색ID")]
		public int? SearchBrandID { get; set; }

		[DataMember]
		[Display(Name = "활동일자")]
		public DateTime ActivityDate { get; set; }

		[DataMember]
		[Display(Name = "내용")]
		public string Description { get; set; }

		[DataMember]
		[Display(Name = "내용(RTF)")]
		public string DescriptionRTF { get; set; }
	}
}
