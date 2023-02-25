using ChronicleLog.App.MVVM.ViewModels.Commands;
using ChronicleLog.App.Services;
using ChronicleLog.App.Stores;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace ChronicleLog.App.MVVM.ViewModels
{
	public class EntryListingViewModel : ViewModelBase
	{
		private readonly DataService _dataService;
		private readonly EntriesStore _entriesStore;
		private readonly NavigationStore _navigationStore;
		private readonly ObservableCollection<EntryViewModel> _entryViewModels;

		public IEnumerable<EntryViewModel> EntryViewModels => _entryViewModels;

		private EntryViewModel _selectedEntry;

		public EntryViewModel SelectedEntry
		{
			get => _selectedEntry;
			set
			{
				_selectedEntry = value;
				OnPropertyChanged(nameof(SelectedEntry));
			}
		}

		public RelayCommand DeleteEntryCommand { get; set; }
		public RelayCommand EditEntryCommand { get; set; }

		public EntryListingViewModel(EntriesStore entriesStores, DataService dataService, NavigationStore navigationStore)
		{
			_entriesStore = entriesStores;
			_navigationStore = navigationStore;
			_dataService = dataService;

			_entryViewModels = _entriesStore.RequestedEntries;
			DeleteEntryCommand = new RelayCommand(parameter => DeleteEntry());
			EditEntryCommand = new RelayCommand(parameter => EditEntry());
		}

		private void DeleteEntry()
		{
			if (SelectedEntry != null)
			{
				MessageBoxResult isConfirmed = MessageBox.Show("Are you sure want to delete this entry?", "Confirmation", MessageBoxButton.OKCancel, MessageBoxImage.Question);

				if (isConfirmed == MessageBoxResult.OK)
				{
					_dataService.Delete(SelectedEntry.Id);
					_entryViewModels.Remove(SelectedEntry);
					SelectedEntry = null;
				}
			}
		}

		private void EditEntry()
		{
			if (SelectedEntry != null)
			{
				_navigationStore.CurrentView = new CreateEditEntryViewModel(_dataService, _entriesStore, _navigationStore, SelectedEntry);
			}
		}
	}
}
