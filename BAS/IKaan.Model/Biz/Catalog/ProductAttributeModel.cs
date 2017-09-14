﻿using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Biz.Catalog
{
	[DataContract]
	public class ProductAttributeModel : ModelBase
	{
		[DataMember]
		[Display(Name = "상품ID")]
		public int? ProductID { get; set; }

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