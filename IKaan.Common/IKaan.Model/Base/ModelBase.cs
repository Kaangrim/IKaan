using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace IKaan.Model.Base
{
	[DataContract]
	public class ModelBase: IModelBase
	{
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
		public DateTime? CreateDate { get; set; }

		[DataMember]
		[Display(Name = "생성자ID")]
		public int? CreateBy { get; set; }

		[DataMember]
		[Display(Name = "생성자명")]
		public string CreateByName { get; set; }

		[DataMember]
		[Display(Name = "수정일시")]
		public DateTime? UpdateDate { get; set; }

		[DataMember]
		[Display(Name = "수정자ID")]
		public int? UpdateBy { get; set; }

		[DataMember]
		[Display(Name = "수정자명")]
		public string UpdateByName { get; set; }
	}
}
