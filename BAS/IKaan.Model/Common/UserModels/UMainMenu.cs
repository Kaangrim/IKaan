using System.Runtime.Serialization;

namespace IKaan.Model.Common.UserModels
{
	[DataContract]
	public class UMainMenu
	{
		[DataMember]
		public int MenuID { get; set; }

		[DataMember]
		public int ParentID { get; set; }

		[DataMember]
		public string MenuName { get; set; }

		[DataMember]
		public int MenuLevel { get; set; }

		[DataMember]
		public string HierID { get; set; }

		[DataMember]
		public string Assembly { get; set; }

		[DataMember]
		public string Namespace { get; set; }

		[DataMember]
		public string Instance { get; set; }

		[DataMember]
		public string ViewType { get; set; }

		[DataMember]
		public string BookmarkYn { get; set; }

		[DataMember]
		public int ChildCount { get; set; }

		[DataMember]
		public string ViewYn { get; set; }

		[DataMember]
		public string EditYn { get; set; }
	}
}
