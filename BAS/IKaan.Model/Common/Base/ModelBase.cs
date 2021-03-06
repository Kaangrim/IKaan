﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace IKaan.Model.Common.Base
{
	[DataContract]
	public class ModelBase: IModelBase
	{
		[DataMember]
		[Display(Name = "ROW상태")]
		public string RowState { get; set; }

		[DataMember]
		[Display(Name = "선택여부")]
		public string Checked { get; set; }

		[DataMember]
		[Display(Name = "Row번호")]
		public int? RowNo { get; set; }

		[DataMember]
		[Key]
		[Display(Name = "ID")]
		public int? ID { get; set; }

		[DataMember]
		[Display(Name = "생성일시")]
		public DateTime? CreatedOn { get; set; }

		[DataMember]
		[Display(Name = "생성자ID")]
		public int? CreatedBy { get; set; }

		[DataMember]
		[Display(Name = "생성자명")]
		public string CreatedByName { get; set; }

		[DataMember]
		[Display(Name = "수정일시")]
		public DateTime? UpdatedOn { get; set; }

		[DataMember]
		[Display(Name = "수정자ID")]
		public int? UpdatedBy { get; set; }

		[DataMember]
		[Display(Name = "수정자명")]
		public string UpdatedByName { get; set; }
	}
}
