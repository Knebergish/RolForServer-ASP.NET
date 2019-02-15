namespace RolForServer.Models {
	public class Container {
		public int Id { get; set; }
		public int? ParentId { get; set; }
		public string Title { get; set; }
		public int AuthorId { get; set; }
		public string ImageName { get; set; }
		public string Description { get; set; }
	}
}