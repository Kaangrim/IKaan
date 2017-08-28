using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Biz
{
	[DataContract]
	public class ChannelContactModel : ModelBase
	{
		[DataMember]
		[Display(Name = "채널ID")]
		public int? ChannelID { get; set; }

		[DataMember]
		[Display(Name = "사람ID")]
		public int? PersonID { get; set; }

		[DataMember]
		[Display(Name = "포지션")]
		public string Position { get; set; }

		[DataMember]
		[Display(Name = "담당업무")]
		public string AssignedTask { get; set; }

		[DataMember]
		[Display(Name = "설명")]
		public string Description { get; set; }

		[DataMember]
		[Display(Name = "성명")]
		public string PersonName { get; set; }

		[DataMember]
		[Display(Name = "이메일")]
		public string Email { get; set; }

		[DataMember]
		[Display(Name = "연락처1")]
		public string PhoneNo1 { get; set; }

		[DataMember]
		[Display(Name = "연락처2")]
		public string PhoneNo2 { get; set; }

		[DataMember]
		[Display(Name = "팩스번호")]
		public string FaxNo { get; set; }
	}
}
