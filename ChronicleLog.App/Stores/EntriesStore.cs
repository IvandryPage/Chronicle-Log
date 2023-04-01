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
			return RequestedEntries.Count != 0 ? RequestedEntries[0].Category : null;
		}
	}
}
