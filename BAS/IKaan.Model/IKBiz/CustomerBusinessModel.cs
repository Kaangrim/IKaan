using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.IKBiz
{
	[DataContract]
	public class CustomerBusinessModel : ModelBase
	{
		[DataMember]
		[Display(Name = "거래처ID")]
		public int? CustomerID { get; set; }

		[DataMember]
		[Display(Name = "사업자ID")]
		public int? BusinessID { get; set; }

		[DataMember]
		[Display(Name = "시작일")]
		public DateTime? StartDate { get; set; }

		[DataMember]
		[Display(Name = "종료일")]
		public DateTime? EndDate { get; set; }

		[DataMember]
		[Display(Name = "사업자번호")]
		public string BizNo { get; set; }

		[DataMember]
		[Display(Name = "상호")]
		public string BizName { get; set; }

		[DataMember]
		[Display(Name = "대표자")]
		public string RepName { get; set; }

		[DataMember]
		[Display(Name = "거래처명")]
		public string CustomerName { get; set; }

		[DataMember]
		[Display(Name = "사업자정보")]
		public BusinessModel Business { get; set; }
	}
}
