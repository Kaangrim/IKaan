using System.Runtime.Serialization;

namespace IKaan.Model.Common.UserModels
{
	[DataContract]
	public class UMenuViewButton
	{
		[DataMember]
		public int ButtonID { get; set; }
		[DataMember]
		public string ButtonName { get; set; }
		[DataMember]
		public string Instance { get; set; }
	}
}
