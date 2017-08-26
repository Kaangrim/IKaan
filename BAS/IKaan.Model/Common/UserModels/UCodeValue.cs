using System.Runtime.Serialization;

namespace IKaan.Model.Common.UserModels
{
	[DataContract]
	public class UCodeValue
	{
		[DataMember]
		public string Code { get; set; }

		[DataMember]
		public string Value { get; set; }
	}
}
