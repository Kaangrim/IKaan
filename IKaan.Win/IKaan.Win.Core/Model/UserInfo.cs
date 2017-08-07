namespace IKaan.Win.Core.Model
{
	public class UserInfo
	{
		public int UserId { get; set; }
		public string UserName { get; set; }
		public string LoginId { get; set; }

		public string LanguageCode { get; set; }

		public int CustomerId { get; set; }
		public string CustomerName { get; set; }
		public int DepartmentId { get; set; }
		public string DepartmentName { get; set; }
		public int EmployeeId { get; set; }
	}
}
