using System.Runtime.Serialization;

namespace IKaan.Model.UserModels.Mail
{
	[DataContract]
	public class UMSendMail
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
