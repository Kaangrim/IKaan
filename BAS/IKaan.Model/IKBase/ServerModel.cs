using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.IKBase
{
	[DataContract]
	public class ServerModel: ModelBase
	{
		[DataMember]
		[Display(Name = "서버명")]
		public string ServerName { get; set; }

		[DataMember]
		[Display(Name = "설명")]
		public string Description { get; set; }
	}
}
