using System;
using System.Runtime.Serialization;

namespace IKaan.Biz.Core.Model
{
	[DataContract]
	public class FtpList
	{
		[DataMember]
		public string Checked { get; set; }

		[DataMember]
		public int ID { get; set; }

		[DataMember]
		public string Name { get; set; }

		[DataMember]
		public string FullName { get; set; }

		[DataMember]
		public string Type { get; set; }

		[DataMember]
		public string Size { get; set; }

		[DataMember]
		public string ModifiedDate { get; set; }

		[DataMember]
		public int? ParentID { get; set; }
	}
}
