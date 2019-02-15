using System;

namespace RolForServer.Models {
	public class Message {
		public int Id { get; set; }
		public int TopicId { get; set; }
		public int UserId { get; set; }
		public DateTime Date { get; set; }
		public string Text { get; set; }
	}
}