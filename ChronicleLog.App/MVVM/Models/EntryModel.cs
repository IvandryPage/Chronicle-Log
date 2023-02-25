using LiteDB;
using System;

namespace ChronicleLog.App.MVVM.Models
{
	public class EntryModel
	{
		[BsonId]
		public ObjectId Id { get; set; }
		public DateTime CreatedAt { get; set; }
		public string Category { get; set; }
		public string Title { get; set; }
		public string Paragraph { get; set; }

		public EntryModel(ObjectId id, DateTime createdAt, string category, string title, string paragraph)
		{
			Id = id;
			CreatedAt = createdAt;
			Category = category;
			Title = title;
			Paragraph = paragraph;
		}
	}
}
