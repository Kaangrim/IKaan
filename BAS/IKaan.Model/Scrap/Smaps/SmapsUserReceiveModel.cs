using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace IKaan.Model.Scrap.Smaps
{
	[DataContract]
	public class SmapsUserReceiveModel
	{
		[DataMember]
		[Display(Name = "UID")]
		public int? uid { get; set; }

		[DataMember]
		[Display(Name = "사용자명")]
		public string name { get; set; }

		[DataMember]
		[Display(Name = "사용자유형")]
		public string utype { get; set; }

		[DataMember]
		[Display(Name = "대행사UID")]
		public int agency_uid { get; set; }
	}
}
