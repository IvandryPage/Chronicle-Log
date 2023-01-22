using ChronicleLog.App.MVVM.Models;
using ChronicleLog.App.MVVM.ViewModels.Commands;
using ChronicleLog.App.Stores;
using System.Windows.Input;

namespace ChronicleLog.App.MVVM.ViewModels
{
	public class AddLogViewModel : ViewModelBase
	{
		private readonly LogQueriesStore _logQueriesStore;
		private readonly Services.DataService _dataService;
		public string QueryCategory { get; set; }
		public string QueryTitle { get; set; }
		public string QueryParagraph { get; set; }

		public ICommand CreateQueryCommand { get; }
		public ICommand ClearInputCommand { get; }

		public AddLogViewModel(Services.DataService dataservices, LogQueriesStore logQueriesStore)
		{
			_logQueriesStore = logQueriesStore;
			_dataService = dataservices;
			ClearInputCommand = new RelayCommand(parameter => ClearInput());
			CreateQueryCommand = new RelayCommand(parameter => CreateQuery());
			QueryCategory = ( _logQueriesStore.RequestedLogQueryViewModels.Count != 0 ) ?
				_logQueriesStore.RequestedLogQueryViewModels[0].Category : string.Empty;
		}

		private void ClearInput()
		{
			QueryCategory = QueryTitle = QueryParagraph = string.Empty;
			NotifyUI();
		}

		private void CreateQuery()
		{
			LogQueryModel queryModel = new LogQueryModel(System.DateTime.Now, QueryCategory, QueryTitle, QueryParagraph.Trim());
			LogQueryViewModel queryViewModel = new LogQueryViewModel(queryModel);

			_dataService.Create(queryModel);

			if ( _logQueriesStore.RequestedLogQueryViewModels.Count > 0 && QueryCategory == _logQueriesStore.RequestedLogQueryViewModels[0].Category )
				_logQueriesStore.RequestedLogQueryViewModels.Add(queryViewModel);

			QueryTitle = QueryParagraph = string.Empty;
			NotifyUI();
		}

		private void NotifyUI()
		{
			OnPropertyChanged(QueryTitle);
			OnPropertyChanged(QueryParagraph);
			OnPropertyChanged(QueryCategory);
		}
	}
}