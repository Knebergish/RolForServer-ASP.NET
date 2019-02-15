namespace RolForServer.Models {
	public class Topic {
		public int Id { get; set; }
		public int ForumId { get; set; }
		public string Title { get; set; }
		public int AuthorId { get; set; }
		public string ImageName { get; set; }
		public string Description { get; set; }
	}
}