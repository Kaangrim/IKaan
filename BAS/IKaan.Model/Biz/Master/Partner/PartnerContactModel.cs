using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Biz.Common;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Biz.Partner
{
	[DataContract]
	public class PartnerContactModel : ModelBase
	{
		[DataMember]
		[Display(Name = "브랜드ID")]
		public int? PartnerID { get; set; }

		[DataMember]
		[Display(Name = "담당자ID")]
		public int? ContactID { get; set; }

		[DataMember]
		[Display(Name = "포지션")]
		public string Position { get; set; }

		[DataMember]
		[Display(Name = "담당직무")]
		public string AssignedTask { get; set; }

		[DataMember]
		[Display(Name = "설명")]
		public string Description { get; set; }

		[DataMember]
		[Display(Name = "담당자명")]
		public string ContactName { get; set; }

		[DataMember]
		[Display(Name = "담당자")]
		public ContactModel Contact { get; set; }
	}
}
