using ChronicleLog.App.MVVM.Models;
using ChronicleLog.App.MVVM.ViewModels;
using ChronicleLog.App.Stores;
using LiteDB;
using System;
using System.Collections.Generic;
using System.IO;

namespace ChronicleLog.App.Services
{
	public class DataService : IDataService
	{
		private readonly string _collectionName = "logs";
		
		public void Create(EntryModel query)
		{
			using (var db = new LiteDatabase(GetConnectionString()))
			{
				var collection = db.GetCollection<EntryModel>(_collectionName);

				var queryModel = new EntryModel(
					id: new ObjectId(),
					createdAt: DateTime.Now,
					category: query.Category,
					title: query.Title,
					paragraph: query.Paragraph
				);

				collection.Insert(queryModel);
			}
		}

		public void SpecifiedRead(EntriesStore entryStore, string requestedCategory)
		{
			entryStore.RequestedEntries.Clear();
			using (LiteDatabase db = new LiteDatabase(GetConnectionString()))
			{
				ILiteCollection<EntryModel> collection = db.GetCollection<EntryModel>(_collectionName);

				IEnumerable<EntryModel> requestedEntries = collection.Find(y => y.Category == requestedCategory);

				foreach (EntryModel entry in requestedEntries)
				{
					entryStore.RequestedEntries.Add(new EntryViewModel(entry));
				}
			}
		}

		public void Update(EntryModel query)
		{
			using (LiteDatabase db = new LiteDatabase(GetConnectionString()))
			{
				ILiteCollection<EntryModel> collection = db.GetCollection<EntryModel>(_collectionName);
				collection.Update(query);
			}
		}

		public void Delete(ObjectId id)
		{
			using (LiteDatabase db = new LiteDatabase(GetConnectionString()))
			{
				ILiteCollection<EntryModel> collection = db.GetCollection<EntryModel>(_collectionName);
				collection.Delete(id);
			}
		}

		private string GetConnectionString()
		{
			string path = Directory.GetCurrentDirectory();
			string databaseFileName = "ChronicleLogDatabase.db";
			return Path.Combine(path, databaseFileName);
		}
	}
}
