using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Scrap.Smaps
{
	[DataContract]
	public class SmapsColorModel : ModelBase
	{
		[DataMember]
		[Display(Name = "요청ID")]
		public int? ApiRequestID { get; set; }

		[DataMember]
		[Display(Name = "API유형")]
		public string ApiType { get; set; }

		[DataMember]
		[Display(Name = "상태")]
		public string Status { get; set; }

		[DataMember]
		[Display(Name = "유형")]
		public DateTime? RequestDate { get; set; }

		[DataMember]
		[Display(Name = "색상값")]
		public string value { get; set; }

		[DataMember]
		[Display(Name = "색상명")]
		public string text { get; set; }
	}
}
