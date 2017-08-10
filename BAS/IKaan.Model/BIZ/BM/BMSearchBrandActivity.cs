using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Base;

namespace IKaan.Model.BIZ.BM
{
	[DataContract]
	public class BMSearchBrandActivity : ModelBase
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
	}
}
