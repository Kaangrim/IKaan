using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Scrap.Api
{
	[DataContract]
	public class ApiRequestModel : ModelBase
	{
		[DataMember]
		[Display(Name = "API명")]
		public string ApiName { get; set; }

		[DataMember]
		[Display(Name = "API형태")]
		public string ApiType { get; set; }

		[DataMember]
		[Display(Name = "API모델")]
		public string ApiModel { get; set; }

		[DataMember]
		[Display(Name = "Request일자")]
		public DateTime RequestDate { get; set; }

		[DataMember]
		[Display(Name = "상태")]
		public string Status { get; set; }

		[DataMember]
		[Display(Name = "메시지")]
		public string Message { get; set; }

		[DataMember]
		[Display(Name = "전송데이터")]
		public string SendData { get; set; }

		[DataMember]
		[Display(Name = "수신데이터")]
		public string ReceiveData { get; set; }

		[DataMember]
		[Display(Name = "전달데이터값")]
		public object Data { get; set; }
	}
}
