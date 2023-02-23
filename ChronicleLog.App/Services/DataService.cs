﻿using ChronicleLog.App.MVVM.Models;
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
				new ObjectId(),
				DateTime.Now,
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
			using(LiteDatabase db = new LiteDatabase(GetConnectionString()))
			{
				ILiteCollection<LogQueryModel> collection = db.GetCollection<LogQueryModel>(_collectionName);
				collection.Update(query);
			}
		}

		public void Delete(ObjectId id)
		{
			using(LiteDatabase db = new LiteDatabase(GetConnectionString()))
			{
				ILiteCollection<LogQueryModel> collection = db.GetCollection<LogQueryModel>(_collectionName);
				collection.Delete(id);
			}
		}

		private string GetConnectionString()
		{
			string path = Directory.GetCurrentDirectory();
			string databaseFileName = "JournalEntryStorage.db";
			return Path.Combine(path, databaseFileName);
		}
	}
}
