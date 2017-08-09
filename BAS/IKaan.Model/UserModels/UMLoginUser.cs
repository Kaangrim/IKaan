using System.Collections.Generic;
using System.Runtime.Serialization;

namespace IKaan.Model.UserModels
{
	[DataContract]
	public class UMLoginUser
	{
		[DataMember]
		public int UserId { get; set; }

		[DataMember]
		public string UserName { get; set; }

		[DataMember]
		public string LoginId { get; set; }

		[DataMember]
		public string UseYn { get; set; }

		[DataMember]
		public int IsPwCheck { get; set; }

		[DataMember]
		public IList<UMCodeLookup> Codes { get; set; }

		public UMLoginUser()
		{
			Codes = new List<UMCodeLookup>();
		}
	}
}
