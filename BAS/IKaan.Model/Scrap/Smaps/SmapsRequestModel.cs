using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Scrap.Smaps
{
	[DataContract]
	public class SmapsRequestModel : ModelBase
	{
		[DataMember]
		[Display(Name = "요청유형")]
		public string RequestType { get; set; }

		[DataMember]
		[Display(Name = "요청일자")]
		public DateTime RequestDate { get; set; }

		[DataMember]
		[Display(Name = "상태")]
		public string Status { get; set; }

		[DataMember]
		[Display(Name = "요청문자열")]
		public string RequestText { get; set; }

		[DataMember]
		[Display(Name = "반환문자열")]
		public string ReturnText { get; set; }

		[DataMember]
		[Display(Name = "전달데이터값")]
		public object Data { get; set; }
	}
}
