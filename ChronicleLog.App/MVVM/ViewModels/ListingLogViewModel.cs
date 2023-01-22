using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ChronicleLog.App.MVVM.ViewModels
{
	public class ListingLogViewModel : ViewModelBase
	{
		private readonly ObservableCollection<LogQueryViewModel> _logQueryViewModels;
		public IEnumerable<LogQueryViewModel> LogQueryViewModels => _logQueryViewModels;

		public ListingLogViewModel(Stores.LogQueriesStore logQueriesStore)
		{
			_logQueryViewModels = logQueriesStore.RequestedLogQueryViewModels;
		}
	}
}
