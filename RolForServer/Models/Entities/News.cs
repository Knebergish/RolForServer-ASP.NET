using System;

namespace RolForServer.Models.Entities {
	public class News {
		public int Id { get; set; }
		public string Title { get; set; }
		public DateTime Date { get; set; }
		public int AuthorId { get; set; }
		public string Text { get; set; }
	}
}