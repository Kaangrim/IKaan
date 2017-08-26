using System.Runtime.Serialization;

namespace IKaan.Model.Common.UserModels.Mail
{
	[DataContract]
	public class USendMail
	{
		[DataMember]
		public string From { get; set; }

		[DataMember]
		public string To { get; set; }

		[DataMember]
		public string Subject { get; set; }

		[DataMember]
		public string Body { get; set; }
	}
}
