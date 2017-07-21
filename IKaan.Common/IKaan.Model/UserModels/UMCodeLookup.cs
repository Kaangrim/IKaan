using System.Runtime.Serialization;

namespace IKaan.Model.UserModels
{
	[DataContract]
	public class UMCodeLookup
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
		public string GroupCode { get; set; }
		[DataMember]
		public int SortOrder { get; set; }
		[DataMember]
		public string Option1 { get; set; }
		[DataMember]
		public string Option2 { get; set; }
		[DataMember]
		public string Option3 { get; set; }
		[DataMember]
		public string Option4 { get; set; }
		[DataMember]
		public string Option5 { get; set; }
		[DataMember]
		public string Option6 { get; set; }
		[DataMember]
		public string Option7 { get; set; }
		[DataMember]
		public string Option8 { get; set; }
		[DataMember]
		public string Option9 { get; set; }
	}
}
