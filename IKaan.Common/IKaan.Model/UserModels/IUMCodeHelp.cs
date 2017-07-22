namespace IKaan.Model.UserModels
{
	public interface IUMCodeHelp
	{
		int ID { get; set; }		
		string Code { get; set; }
		string Name { get; set; }
		string ListName { get; set; }
		string DispName { get; set; }
		string Value { get; set; }
		int SortOrder { get; set; }
		int MaxLength { get; set; }
		object Option1 { get; set; }
		object Option2 { get; set; }
		object Option3 { get; set; }
		object Option4 { get; set; }
		object Option5 { get; set; }
		object Option6 { get; set; }
		object Option7 { get; set; }
		object Option8 { get; set; }
		object Option9 { get; set; }
	}
}
