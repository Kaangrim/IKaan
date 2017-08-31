using System;

namespace IKaan.Model.Common.Base
{
	public interface IModelBase
	{
		string RowState { get; set; }
		string Checked { get; set; }
		int? RowNo { get; set; }
		int? ID { get; set; }
		DateTime? CreatedOn { get; set; }
		int? CreatedBy { get; set; }
		string CreatedByName { get; set; }
		DateTime? UpdatedOn { get; set; }
		int? UpdatedBy { get; set; }
		string UpdatedByName { get; set; }
	}
}
