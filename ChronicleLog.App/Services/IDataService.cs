using ChronicleLog.App.MVVM.Models;
using ChronicleLog.App.Stores;
using LiteDB;

namespace ChronicleLog.App.Services
{
	interface IDataService
	{
		void Create(EntryModel query);
		void SpecifiedRead(EntriesStore logStore, string requestedCategory);
		void Update(EntryModel query);
		void Delete(ObjectId id);
	}
}
