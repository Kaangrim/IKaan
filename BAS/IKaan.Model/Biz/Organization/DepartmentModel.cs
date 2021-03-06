﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Biz.Organization
{
	[DataContract]
	public class DepartmentModel : ModelBase
	{
		[DataMember]
		[Display(Name = "부서명")]
		public string Name { get; set; }

		[DataMember]
		[Display(Name = "상위ID")]
		public int? ParentID { get; set; }

		[DataMember]
		[Display(Name = "사용여부")]
		public string UseYn { get; set; }

		[DataMember]
		[Display(Name = "부서장ID")]
		public int? ManagerID { get; set; }

		[DataMember]
		[Display(Name = "정렬순서")]
		public int? SortOrder { get; set; }

		[DataMember]
		[Display(Name = "부서장명")]
		public string ManagerName { get; set; }

		[DataMember]
		[Display(Name = "시작일")]
		public DateTime? StartDate { get; set; }

		[DataMember]
		[Display(Name = "계층ID")]
		public string HierID { get; set; }

		[DataMember]
		[Display(Name = "계층명")]
		public string HierName { get; set; }

		[DataMember]
		[Display(Name = "단계")]
		public int Level { get; set; }

		[DataMember]
		[Display(Name = "변동이력")]
		public IList<DepartmentHistoryModel> Histories { get; set; }

		[DataMember]
		[Display(Name = "사원목록")]
		public IList<AppointmentModel> Appointments { get; set; }

		public DepartmentModel()
		{
			Histories = new List<DepartmentHistoryModel>();
			Appointments = new List<AppointmentModel>();
		}
	}
}
