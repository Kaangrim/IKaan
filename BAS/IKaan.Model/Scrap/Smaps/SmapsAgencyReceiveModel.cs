using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace IKaan.Model.Scrap.Smaps
{
	[DataContract]
	public class SmapsAgencyReceiveModel
	{
		[DataMember]
		[Display(Name = "UID")]
		public int? uid { get; set; }

		[DataMember]
		[Display(Name = "대행사명")]
		public string agency_name { get; set; }

		[DataMember]
		[Display(Name = "무시")]
		public string sel { get; set; }
	}
}
