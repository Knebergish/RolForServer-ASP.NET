using System;

namespace RolForServer.Models.Entities {
	public class Message {
		public int Id { get; set; }
		public int ContainerId { get; set; }
		public int UserId { get; set; }
		public DateTime Date { get; set; }
		public string Text { get; set; }
	}
}