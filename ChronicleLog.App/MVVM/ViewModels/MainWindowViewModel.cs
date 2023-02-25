using ChronicleLog.App.MVVM.ViewModels.Commands;
using ChronicleLog.App.Services;
using ChronicleLog.App.Stores;
using System.Windows.Input;

namespace ChronicleLog.App.MVVM.ViewModels
{
	public class MainWindowViewModel : ViewModelBase
	{
		private readonly EntriesStore _entriesStore;
		private readonly DataService _dataService;
		private readonly NavigationStore _navigationStore;
		public object CurrentView => _navigationStore.CurrentView;

		public ICommand NavigateToSearchEntriesViewCommand { get; }
		public ICommand NavigateToEntriesListViewCommand { get; }
		public ICommand NavigateToCreateEntryViewCommand { get; }

		public MainWindowViewModel(DataService dataService, EntriesStore entriesStore, NavigationStore navigationStore)
		{
			_entriesStore = entriesStore;
			_dataService = dataService;
			_navigationStore = navigationStore;

			NavigateToSearchEntriesViewCommand = new RelayCommand(parameter => _navigationStore.CurrentView = NavigateToSearchCategoryView());
			NavigateToEntriesListViewCommand = new RelayCommand(parameter => _navigationStore.CurrentView = NavigateToEntriesListView());
			NavigateToCreateEntryViewCommand = new RelayCommand(parameter => _navigationStore.CurrentView = NavigateToCreateEntryView());
			
			_navigationStore.CurrentView = NavigateToSearchCategoryView();

			_navigationStore.CurrentViewChanged += NavigationStore_CurrentViewChanged;
		}

		private void NavigationStore_CurrentViewChanged()
		{
			OnPropertyChanged(nameof(CurrentView));
		}

		public object NavigateToSearchCategoryView() => new SearchEntriesViewModel(_dataService, _entriesStore, _navigationStore);
		public object NavigateToEntriesListView() => new EntryListingViewModel(_entriesStore, _dataService, _navigationStore);
		public object NavigateToCreateEntryView() => new CreateEditEntryViewModel(_dataService, _entriesStore, _navigationStore);
	}
}
