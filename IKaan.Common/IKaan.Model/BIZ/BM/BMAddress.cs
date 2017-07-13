using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Base;

namespace IKaan.Model.BIZ.BM
{
	[DataContract]
	public class BMAddress : ModelBase
	{
		[DataMember]
		[Display(Name = "우편번호(6)")]
		public string PostNo { get; set; }

		[DataMember]
		[Display(Name = "구역코드(5)")]
		public string ZoneNo { get; set; }

		[DataMember]
		[Display(Name = "주소1")]
		public string Address1 { get; set; }

		[DataMember]
		[Display(Name = "주소2")]
		public string Address2 { get; set; }
	}
}
