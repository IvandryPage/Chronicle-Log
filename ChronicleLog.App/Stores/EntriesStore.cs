using ChronicleLog.App.MVVM.ViewModels;
using System.Collections.ObjectModel;

namespace ChronicleLog.App.Stores
{
	public class EntriesStore
	{
		public ObservableCollection<EntryViewModel> RequestedEntries { get; set; }

		public EntriesStore()
		{
			RequestedEntries = new ObservableCollection<EntryViewModel>();
		}

		public string GetEntriesCategory()
		{
			if (RequestedEntries.Count != 0)
				return RequestedEntries[0].Category;
			else
				return null;
		}
	}
}
