using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Base;

namespace IKaan.Model.BIZ.BM
{
	[DataContract]
	public class BMCustomerBusiness : ModelBase
	{
		[DataMember]
		[Display(Name = "거래처ID")]
		public int? CustomerID { get; set; }

		[DataMember]
		[Display(Name = "사업자ID")]
		public int? BusinessID { get; set; }

		[DataMember]
		[Display(Name = "시작일")]
		public DateTime StartDate { get; set; }

		[DataMember]
		[Display(Name = "종료일")]
		public DateTime EndDate { get; set; }
	}
}
