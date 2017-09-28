using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Scrap.Smaps
{
	[DataContract]
	public class SmapsBaseModel : ModelBase
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
		[Display(Name = "UID")]
		public int? uid { get; set; }
	}
}
