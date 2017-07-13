using System.Collections.Generic;
using System.Runtime.Serialization;

namespace IKaan.Model.UserModels
{
	[DataContract]
	public class UMMenuView
	{
		[DataMember]
		public int MenuID { get; set; }
		[DataMember]
		public string MenuName { get; set; }
		[DataMember]
		public int ViewID { get; set; }
		[DataMember]
		public string ViewName { get; set; }
		[DataMember]
		public string ViewType { get; set; }
		[DataMember]
		public string Assembly { get; set; }
		[DataMember]
		public string Namespace { get; set; }
		[DataMember]
		public string Instance { get; set; }
		[DataMember]
		public IList<UMMenuViewButton> ViewButtons { get; set; }

		public UMMenuView()
		{
			ViewButtons = new List<UMMenuViewButton>();
		}
	}	
}
