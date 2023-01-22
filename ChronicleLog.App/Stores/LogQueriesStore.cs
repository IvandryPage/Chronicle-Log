using ChronicleLog.App.MVVM.ViewModels;
using System.Collections.ObjectModel;

namespace ChronicleLog.App.Stores
{
	public class LogQueriesStore
	{
		public ObservableCollection<LogQueryViewModel> LogQueryViewModels { get; set; }
		public ObservableCollection<LogQueryViewModel> RequestedLogQueryViewModels { get; set; }

		public LogQueriesStore()
		{
			LogQueryViewModels = new ObservableCollection<LogQueryViewModel>();
			RequestedLogQueryViewModels = new ObservableCollection<LogQueryViewModel>();
		}
	}
}
