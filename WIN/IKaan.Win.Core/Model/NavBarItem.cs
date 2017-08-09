namespace IKaan.Win.Core.Model
{
	public class NavBarItem
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string WebUrl { get; set; }
		public string Group { get; set; }
		public string ImageName { get; set; }

		public NavBarItem()
		{
		}
		public NavBarItem(int id, string name, string webUrl, string group, string imageName)
		{
			Id = id;
			Name = name;
			WebUrl = webUrl;
			Group = group;
			ImageName = imageName;
		}
	}
}
