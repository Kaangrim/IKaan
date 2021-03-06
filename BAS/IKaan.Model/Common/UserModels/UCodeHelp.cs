﻿using System.Runtime.Serialization;

namespace IKaan.Model.Common.UserModels
{
	[DataContract]
	public class UCodeHelp : IUCodeHelp
	{
		[DataMember]
		public int ID { get; set; }
		[DataMember]
		public string Code { get; set; }
		[DataMember]
		public string Name { get; set; }
		[DataMember]
		public string ListName { get; set; }
		[DataMember]
		public string DispName { get; set; }
		[DataMember]
		public string Value { get; set; }
		[DataMember]
		public int SortOrder { get; set; }
		[DataMember]
		public int MaxLength { get; set; }
		[DataMember]
		public object Option1 { get; set; }
		[DataMember]
		public object Option2 { get; set; }
		[DataMember]
		public object Option3 { get; set; }
		[DataMember]
		public object Option4 { get; set; }
		[DataMember]
		public object Option5 { get; set; }
		[DataMember]
		public object Option6 { get; set; }
		[DataMember]
		public object Option7 { get; set; }
		[DataMember]
		public object Option8 { get; set; }
		[DataMember]
		public object Option9 { get; set; }
	}
}
