using ChronicleLog.App.MVVM.ViewModels.Commands;
using ChronicleLog.App.Services;
using ChronicleLog.App.Stores;
using LiteDB;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ChronicleLog.App.MVVM.ViewModels
{
	public class ListingLogViewModel : ViewModelBase
	{
		private readonly DataService _dataService;
		private readonly ObservableCollection<LogQueryViewModel> _logQueryViewModels;
		public IEnumerable<LogQueryViewModel> LogQueryViewModels => _logQueryViewModels;

		private LogQueryViewModel _selectedLog;

		public LogQueryViewModel SelectedLog
		{
			get { return _selectedLog; }
			set { 
				_selectedLog = value;
				OnPropertyChanged(nameof(SelectedLog));
			}
		}

		public RelayCommand DeleteQueryCommand { get; set; }

		public ListingLogViewModel(LogQueriesStore logQueriesStore, DataService dataService)
		{
			_logQueryViewModels = logQueriesStore.RequestedLogQueryViewModels;
			_dataService = dataService;

			DeleteQueryCommand = new RelayCommand(parameter => Delete());
		}

		private void Delete()
		{
			if (SelectedLog != null)
			{
				_dataService.Delete(SelectedLog.Id);
				_logQueryViewModels.Remove(SelectedLog);
				SelectedLog = null;
			}
		}
	}
}
