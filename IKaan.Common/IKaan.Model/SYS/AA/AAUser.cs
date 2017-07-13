using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Base;

namespace IKaan.Model.SYS.AA
{
	[DataContract]
	public class AAUser : ModelBase
	{
		[DataMember]
		[Display(Name = "사용자명")]
		public string UserName { get; set; }

		[DataMember]
		[Display(Name = "사용자구분")]
		public string UserType { get; set; }

		[DataMember]
		[Display(Name = "로그인ID")]
		public string LoginID { get; set; }

		[DataMember]
		[Display(Name = "사용여부")]
		[StringLength(1)]
		public string UseYn { get; set; }

		[DataMember]
		[Display(Name = "설명")]
		public string Description { get; set; }

		[DataMember]
		[Display(Name = "사용자유형명")]
		public string UserTypeName { get; set; }

		[DataMember]
		[Display(Name = "사용자그룹")]
		public IList<AAUserGroup> UserGroup { get; set; }

		[DataMember]
		[Display(Name = "사용자권한그룹")]
		public IList<AAUserRole> UserRole { get; set; }

		[DataMember]
		[Display(Name = "비밀번호변경이력")]
		public IList<AAUserPasswordHist> UserPasswordHist { get; set; }

		public AAUser()
		{
			UserGroup = new List<AAUserGroup>();
			UserRole = new List<AAUserRole>();
			UserPasswordHist = new List<AAUserPasswordHist>();
		}
	}
}
