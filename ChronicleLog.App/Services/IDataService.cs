﻿using ChronicleLog.App.MVVM.Models;
using ChronicleLog.App.Stores;
using System.Threading.Tasks;

namespace ChronicleLog.App.Services
{
	interface IDataService
	{
		void Create(LogQueryModel query);
		void ReadAll(LogQueriesStore logStore);
		void SpecifiedRead(LogQueriesStore logStore, string requestedCategory);
		void Update(LogQueryModel query);
		void Delete();
	}
}
