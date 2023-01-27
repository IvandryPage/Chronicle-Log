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
		public void Create(LogQueryModel query)
		{
			using var db = new LiteDatabase(GetConnectionString());

			var collection = db.GetCollection<LogQueryModel>(_collectionName);

			var queryModel = new LogQueryModel(
				System.DateTime.Now,
				query.Category,
				query.Title,
				query.Paragraph
			);

			collection.Insert(queryModel);
		}

		public void ReadAll(LogQueriesStore logStore)
		{
			throw new NotImplementedException();
		}

		public void SpecifiedRead(LogQueriesStore logStore, string requestedCategory)
		{
			logStore.RequestedLogQueryViewModels.Clear();
			using var db = new LiteDatabase(GetConnectionString());

			ILiteCollection<LogQueryModel> collection = db.GetCollection<LogQueryModel>(_collectionName);

			IEnumerable<LogQueryModel> requestedLogQueries = collection.Find(y => y.Category == requestedCategory);

			foreach ( LogQueryModel model in requestedLogQueries )
			{
				logStore.RequestedLogQueryViewModels.Add(new LogQueryViewModel(model));
			}
		}

		public void Update(LogQueryModel query)
		{
			throw new NotImplementedException();
		}

		public void Delete()
		{
			throw new NotImplementedException();
		}

		private string GetConnectionString()
		{
			string path = Directory.GetCurrentDirectory();
			string databaseFileName = "80-224-002-36315.db";
			return Path.Combine(path, databaseFileName);
		}
	}
}
