using System.Runtime.Serialization;

namespace IKaan.Model.Common.Was
{
	[DataContract]
	public class WasUser
	{
		[DataMember]
		public int UserId { get; set; }

		[DataMember]
		public string UserName { get; set; }

		[DataMember]
		public string LanguageCode { get; set; }
	}
}
