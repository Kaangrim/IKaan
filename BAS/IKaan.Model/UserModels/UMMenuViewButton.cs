using System.Runtime.Serialization;

namespace IKaan.Model.UserModels
{
	[DataContract]
	public class UMMenuViewButton
	{
		[DataMember]
		public int ButtonID { get; set; }
		[DataMember]
		public string ButtonName { get; set; }
		[DataMember]
		public string Instance { get; set; }
	}
}
