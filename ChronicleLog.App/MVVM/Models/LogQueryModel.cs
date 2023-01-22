using System;

namespace ChronicleLog.App.MVVM.Models
{
	public class LogQueryModel
	{
		public DateTime CreatedAt { get; set; }
		public string Category { get; set; }
		public string Title { get; set; }
		public string Paragraph { get; set; }

		public LogQueryModel() { }

		public LogQueryModel(DateTime createdAt, string category, string title, string paragraph)
		{
			CreatedAt = createdAt;
			Category = category;
			Title = title;
			Paragraph = paragraph;
		}
	}
}
