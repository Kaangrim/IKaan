﻿using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Biz
{
	[DataContract]
	public class ChannelAttributeModel : ModelBase
	{
		[DataMember]
		[Display(Name = "채널ID")]
		public int? ChannelID { get; set; }

		[DataMember]
		[Display(Name = "속성유형ID")]
		public int AttributeTypeID { get; set; }

		[DataMember]
		[Display(Name = "속성ID")]
		public int AttributeID { get; set; }

		[DataMember]
		[Display(Name = "속성명")]
		public string AttributeName { get; set; }
	}
}
