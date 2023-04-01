using ChronicleLog.App.MVVM.ViewModels.Commands;
using ChronicleLog.App.Services;
using ChronicleLog.App.Stores;
using System.Windows;
using System.Windows.Input;

namespace ChronicleLog.App.MVVM.ViewModels
{
	public class SearchEntriesViewModel : ViewModelBase
	{
		private readonly EntriesStore _entriesStore;
		private readonly DataService _dataService;
		private readonly NavigationStore _navigationStore;

		private string _categoryToSearch;
		public string CategoryToSearch
		{
			get => _categoryToSearch;
			set => SetAndNotify(ref _categoryToSearch, value, nameof(CategoryToSearch));
		}

		public ICommand SearchCategoryCommand { get; }

		public SearchEntriesViewModel(DataService dataService, EntriesStore entriesStore, NavigationStore navigationStore)
		{
			_entriesStore = entriesStore;
			_dataService = dataService;
			_navigationStore = navigationStore;

			SearchCategoryCommand = new RelayCommand(parameter => SearchEntries());
		}

		private void SearchEntries()
		{
			Mouse.OverrideCursor = Cursors.Wait;
			try
			{
				if (!string.IsNullOrEmpty(_categoryToSearch))
				{
					_dataService.SpecifiedRead(_entriesStore, _categoryToSearch);

					if (_entriesStore.RequestedEntries.Count != 0)
					{
						_navigationStore.CurrentView = new EntryListingViewModel(_entriesStore, _dataService, _navigationStore);
					}
					else
					{
						if (MessageBox.Show("Would you like to create it?", "Category Not Found", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
							_navigationStore.CurrentView = new CreateEditEntryViewModel(_dataService, _entriesStore, _navigationStore, _categoryToSearch);
					}
				}
			}
			finally
			{
				Mouse.OverrideCursor = null;
			}
		}
	}
}
