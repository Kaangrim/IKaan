using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Biz.Master.Common;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Biz.Master.Partner
{
	[DataContract]
	public class PartnerBusinessModel : ModelBase
	{
		[DataMember]
		[Display(Name = "파트너ID")]
		public int? PartnerID { get; set; }

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
		[Display(Name = "설명")]
		public string Description { get; set; }

		[DataMember]
		[Display(Name = "사업자정보")]
		public BusinessModel Business { get; set; }
	}
}
