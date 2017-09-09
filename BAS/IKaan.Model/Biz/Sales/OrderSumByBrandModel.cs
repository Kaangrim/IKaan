using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Biz.Sales
{
	[DataContract]
	public class OrderSumByBrandModel : ModelBase
	{
		[DataMember]
		[Display(Name = "브랜드ID")]
		public int? BrandID { get; set; }

		[DataMember]
		[Display(Name = "주문일자")]
		public DateTime? OrderDate { get; set; }

		[DataMember]
		[Display(Name = "수량")]
		public IList<OrderSumModel> OrderSumList { get; set; }

		public OrderSumByBrandModel()
		{
			OrderSumList = new List<OrderSumModel>();
		}
	}
}
