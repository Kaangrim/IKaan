using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Base;

namespace IKaan.Model.BIZ.BT
{
	[DataContract]
	public class BTOrderSumByBrand : ModelBase
	{
		[DataMember]
		[Display(Name = "브랜드ID")]
		public int? BrandID { get; set; }

		[DataMember]
		[Display(Name = "주문일자")]
		public DateTime? OrderDate { get; set; }

		[DataMember]
		[Display(Name = "수량")]
		public IList<BTOrderSum> OrderSumList { get; set; }

		public BTOrderSumByBrand()
		{
			OrderSumList = new List<BTOrderSum>();
		}
	}
}
