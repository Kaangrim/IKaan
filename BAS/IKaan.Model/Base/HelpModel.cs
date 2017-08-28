using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Base
{
	[DataContract]
	public class HelpModel: ModelBase
	{
		[DataMember]
		[Display(Name = "도움말명")]
		public string HelpName { get; set; }

		[DataMember]
		[Display(Name = "도움말구분")]
		public string HelpType { get; set; }

		[DataMember]
		[Display(Name = "내용")]
		public string Content { get; set; }

		[DataMember]
		[Display(Name = "내용(RTE)")]
		public string ContentByRte { get; set; }

		[DataMember]
		[Display(Name = "도움말구분명")]
		public string HelpTypeName { get; set; }
	}
}
