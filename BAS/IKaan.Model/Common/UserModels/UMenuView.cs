using System.Collections.Generic;
using System.Runtime.Serialization;

namespace IKaan.Model.Common.UserModels
{
	[DataContract]
	public class UMenuView
	{
		[DataMember]
		public int MenuID { get; set; }

		[DataMember]
		public string MenuName { get; set; }

		[DataMember]
		public string MenuPath { get; set; }

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
		public IList<UMenuViewButton> ViewButtons { get; set; }

		public UMenuView()
		{
			ViewButtons = new List<UMenuViewButton>();
		}
	}	
}
