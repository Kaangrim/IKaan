namespace IKaan.Win.Core.Model
{
	public class UserMenu
	{
		public string HierId { get; set; }
		public int ID { get; set; }
		public string ParentId { get; set; }
		public string Name { get; set; }
		public int ChildCount { get; set; }
		public string ViewYn { get; set; }
		public string BookmarkYn { get; set; }
	}
}
