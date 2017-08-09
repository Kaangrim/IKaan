using System.Runtime.Serialization;

namespace IKaan.Model.UserModels
{
	[DataContract]
	public class UMCodeValue
	{
		[DataMember]
		public string Code { get; set; }

		[DataMember]
		public string Value { get; set; }
	}
}
