﻿using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Base;

namespace IKaan.Model.SYS.AA
{
	[DataContract]
	public class AAViewRoleButton: ModelBase
	{
		[DataMember]
		[Display(Name = "화면ID")]
		public string ViewID { get; set; }

		[DataMember]
		[Display(Name = "권한ID")]
		public string RoleID { get; set; }

		[DataMember]
		[Display(Name = "버튼ID")]
		public string ButtonID { get; set; }

		[DataMember]
		[Display(Name = "사용여부")]
		public string UseYn { get; set; }
	}
}
