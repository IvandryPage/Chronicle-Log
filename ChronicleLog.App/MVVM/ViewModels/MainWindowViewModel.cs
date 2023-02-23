using ChronicleLog.App.MVVM.ViewModels.Commands;
using ChronicleLog.App.Stores;
using System.Windows.Input;

namespace ChronicleLog.App.MVVM.ViewModels
{
	public class MainWindowViewModel : ViewModelBase
	{
		private readonly LogQueriesStore _logQueriesStore;
		private readonly Services.DataService _dataService;
		private readonly NavigationStore _navigationStore;
		public object CurrentView => _navigationStore.CurrentView;

		public ICommand NavigateToDetachLogViewCommand { get; }
		public ICommand NavigateToListingLogViewCommand { get; }
		public ICommand NavigateToAddLogViewCommand { get; }

		public MainWindowViewModel(Services.DataService dataService, LogQueriesStore logQueriesStore, NavigationStore navigationStore)
		{
			_logQueriesStore = logQueriesStore;
			_dataService = dataService;
			_navigationStore = navigationStore;

			_navigationStore.CurrentView = NavigateToDetachLogView();

			_navigationStore.CurrentViewChanged += NavigationStore_CurrentViewChanged;

			NavigateToDetachLogViewCommand = new RelayCommand(parameter => _navigationStore.CurrentView = NavigateToDetachLogView());
			NavigateToListingLogViewCommand = new RelayCommand(parameter => _navigationStore.CurrentView = NavigateToListingLogView());
			NavigateToAddLogViewCommand = new RelayCommand(parameter => _navigationStore.CurrentView = NavigateToAddLogView());
		}

		private void NavigationStore_CurrentViewChanged()
		{
			OnPropertyChanged(nameof(CurrentView));
		}

		public object NavigateToDetachLogView() => new DetachLogViewModel(_dataService, _logQueriesStore, _navigationStore);
		public object NavigateToListingLogView() => new ListingLogViewModel(_logQueriesStore, _dataService);
		public object NavigateToAddLogView() => new AddLogViewModel(_dataService, _logQueriesStore);
	}
}
