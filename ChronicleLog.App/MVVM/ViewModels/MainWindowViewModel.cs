using ChronicleLog.App.MVVM.ViewModels.Commands;
using ChronicleLog.App.Stores;
using System.Windows.Input;

namespace ChronicleLog.App.MVVM.ViewModels
{
	public class MainWindowViewModel : ViewModelBase
	{
		private readonly LogQueriesStore _logQueriesStore;
		private readonly Services.DataService _dataService;

		private object _currentView;
		public object CurrentView
		{
			get => _currentView;
			set
			{
				_currentView = value;
				OnPropertyChanged(nameof(CurrentView));
			}
		}

		public ICommand NavigateToDetachLogViewCommand { get; }
		public ICommand NavigateToListingLogViewCommand { get; }
		public ICommand NavigateToAddLogViewCommand { get; }

		public MainWindowViewModel(Services.DataService dataService, LogQueriesStore logQueriesStore)
		{
			_logQueriesStore = logQueriesStore;
			_dataService = dataService;
			NavigateToDetachLogView();

			NavigateToDetachLogViewCommand = new RelayCommand(parameter => NavigateToDetachLogView());
			NavigateToListingLogViewCommand = new RelayCommand(parameter => NavigateToListingLogView());
			NavigateToAddLogViewCommand = new RelayCommand(parameter => NavigateToAddLogView());
		}

		public void NavigateToDetachLogView() => CurrentView = new DetachLogViewModel(_dataService, _logQueriesStore);
		public void NavigateToListingLogView() => CurrentView = new ListingLogViewModel(_logQueriesStore);
		public void NavigateToAddLogView() => CurrentView = new AddLogViewModel(_dataService, _logQueriesStore);
	}
}
