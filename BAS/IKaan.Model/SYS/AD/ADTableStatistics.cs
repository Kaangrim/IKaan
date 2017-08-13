using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Base;

namespace IKaan.Model.SYS.AD
{
	[DataContract]
	public class ADTableStatistics : ModelBase
	{
		[DataMember]
		[Display(Name = "스키마명")]
		public string SchemaName { get; set; }

		[DataMember]
		[Display(Name = "테이블ID")]
		public int TableID { get; set; }

		[DataMember]
		[Display(Name = "테이블명")]
		public string TableName { get; set; }

		[DataMember]
		[Display(Name = "설명")]
		public string Description { get; set; }

		[DataMember]
		[Display(Name = "ROW수")]
		public int RowCount { get; set; }

		[DataMember]
		[Display(Name = "테이블사이즈")]
		public decimal TableSize { get; set; }

		[DataMember]
		[Display(Name = "데이터사이즈")]
		public decimal DataSize { get; set; }

		[DataMember]
		[Display(Name = "인덱스사이즈")]
		public decimal IndexSize { get; set; }

		[DataMember]
		[Display(Name = "Last User Seek")]
		public DateTime? LastUserSeek { get; set; }

		[DataMember]
		[Display(Name = "Last User Scan")]
		public DateTime? LastUserScan { get; set; }

		[DataMember]
		[Display(Name = "Last User Lookup")]
		public DateTime? LastUserLookup { get; set; }

		[DataMember]
		[Display(Name = "Last User Update")]
		public DateTime? LastUserUpdate { get; set; }

		[DataMember]
		[Display(Name = "Last System Update")]
		public DateTime? LastSystemUpdate { get; set; }
	}
}
