using ChronicleLog.App.MVVM.Models;
using ChronicleLog.App.MVVM.ViewModels.Commands;
using ChronicleLog.App.Stores;
using LiteDB;
using System.Windows.Input;

namespace ChronicleLog.App.MVVM.ViewModels
{
	public class AddLogViewModel : ViewModelBase
	{
		private readonly LogQueriesStore _logQueriesStore;
		private readonly Services.DataService _dataService;

		private string _queryCategory;
		public string QueryCategory
		{
			get => _queryCategory;
			set
			{
				_queryCategory = value;
				OnPropertyChanged(nameof(QueryCategory));
			}
		}

		private string _queryTitle;
		public string QueryTitle
		{
			get => _queryTitle;
			set
			{
				_queryTitle = value;
				OnPropertyChanged(nameof(QueryTitle));
			}
		}

		private string _queryParagraph;
		public string QueryParagraph
		{
			get => _queryParagraph;
			set
			{
				_queryParagraph = value;
				OnPropertyChanged(nameof(QueryParagraph));
			}
		}

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

		private void ClearInput() => QueryCategory = QueryTitle = QueryParagraph = string.Empty;

		private void CreateQuery()
		{
			Mouse.OverrideCursor = Cursors.Wait;
			try
			{
				LogQueryModel queryModel = new LogQueryModel(new ObjectId(), System.DateTime.Now, QueryCategory, QueryTitle, QueryParagraph.Trim());

				QueryTitle = QueryParagraph = string.Empty;

				_dataService.Create(queryModel);

				_dataService.SpecifiedRead(_logQueriesStore, QueryCategory);
			}
			finally
			{
				Mouse.OverrideCursor = null;
			}
		}
	}
}