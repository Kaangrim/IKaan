using System.Collections.Generic;
using System.Runtime.Serialization;

namespace IKaan.Model.Common.UserModels
{
	[DataContract]
	public class ULoginUser
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
		public IList<UCodeLookup> Codes { get; set; }

		public ULoginUser()
		{
			Codes = new List<UCodeLookup>();
		}
	}
}
