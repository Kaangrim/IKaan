using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Base;

namespace IKaan.Model.LIB.LM
{
	public class LMCustomerChannel : ModelBase
	{
		[DataMember]
		[Display(Name = "거래처ID")]
		public int? CustomerID { get; set; }

		[DataMember]
		[Display(Name = "채널ID")]
		public int? ChannelID { get; set; }

		[DataMember]
		[Display(Name = "시작일")]
		public DateTime StartDate { get; set; }

		[DataMember]
		[Display(Name = "종료일")]
		public DateTime EndDate { get; set; }

		[DataMember]
		[Display(Name = "거래처명")]
		public string CustomerName { get; set; }

		[DataMember]
		[Display(Name = "채널명")]
		public string ChannelName { get; set; }
	}
}
