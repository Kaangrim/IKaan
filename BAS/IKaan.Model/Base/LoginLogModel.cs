using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace IKaan.Model.Base
{
	[DataContract]
	public class LoginLogModel
	{
		[DataMember]
		[Display(Name = "Row번호")]
		public int RowNo { get; set; }

		[DataMember]
		[Display(Name = "ID")]
		public int ID { get; set; }

		[DataMember]
		[Display(Name = "사용자ID")]
		public int UserID { get; set; }

		[DataMember]
		[Display(Name = "사용자명")]
		public string UserName { get; set; }

		[DataMember]
		[Display(Name = "로그인아이디")]
		public string LoginID { get; set; }

		[DataMember]
		[Display(Name = "버전")]
		public string Version { get; set; }

		[DataMember]
		[Display(Name = "메인스킨")]
		public string MainSkin { get; set; }

		[DataMember]
		[Display(Name = "그리드스킨")]
		public string GridSkin { get; set; }

		[DataMember]
		[Display(Name = "IP주소")]
		public string IpAddress { get; set; }

		[DataMember]
		[Display(Name = "Mac주소")]
		public string MacAddress { get; set; }

		[DataMember]
		[Display(Name = "상태")]
		public string Status { get; set; }

		[DataMember]
		[Display(Name = "로그인일시")]
		public DateTime? LoginDate { get; set; }

		[DataMember]
		[Display(Name = "로그아웃일시")]
		public DateTime? LogoutDate { get; set; }
	}
}
