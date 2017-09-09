using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace IKaan.Model.Base.Authority
{
	[DataContract]
	public class LoginLogUserModel
	{
		[DataMember]
		[Display(Name = "ROW번호")]
		public int RowNo { get; set; }

		[DataMember]
		[Display(Name = "사용자ID")]
		public int UserID { get; set; }

		[DataMember]
		[Display(Name = "사용자명")]
		public string UserName { get; set; }

		[DataMember]
		[Display(Name = "아이디")]
		public string LoginID { get; set; }

		[DataMember]
		[Display(Name = "접속건수")]
		public int LoginCount { get; set; }

		[DataMember]
		[Display(Name = "최조접속일자")]
		public DateTime? FirstLoginDate { get; set; }

		[DataMember]
		[Display(Name = "최근접속일자")]
		public DateTime? LastLoginDate { get; set; }
	}
}
