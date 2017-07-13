using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Base;

namespace IKaan.Model.SYS.AD
{
	[DataContract]
	public class ADServer: ModelBase
	{
		[DataMember]
		[Display(Name = "서버명")]
		public string ServerName { get; set; }

		[DataMember]
		[Display(Name = "설명")]
		public string Description { get; set; }
	}
}
