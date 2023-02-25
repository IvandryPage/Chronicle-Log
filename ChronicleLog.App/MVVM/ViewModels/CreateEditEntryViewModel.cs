using ChronicleLog.App.MVVM.Models;
using ChronicleLog.App.MVVM.ViewModels.Commands;
using ChronicleLog.App.Services;
using ChronicleLog.App.Stores;
using LiteDB;
using System.Windows.Input;

namespace ChronicleLog.App.MVVM.ViewModels
{
	public class CreateEditEntryViewModel : ViewModelBase
	{
		private readonly EntriesStore _entriesStore;
		private readonly NavigationStore _navigationStore;
		private readonly DataService _dataService;

		private string _entryCategory;
		public string EntryCategory
		{
			get => _entryCategory;
			set
			{
				_entryCategory = value;
				OnPropertyChanged(nameof(EntryCategory));
			}
		}

		private string _entryTitle;
		public string EntryTitle
		{
			get => _entryTitle;
			set
			{
				_entryTitle = value;
				OnPropertyChanged(nameof(EntryTitle));
			}
		}

		private string _entryParagraph;
		public string EntryParagraph
		{
			get => _entryParagraph;
			set
			{
				_entryParagraph = value;
				OnPropertyChanged(nameof(EntryParagraph));
			}
		}

		public ICommand CreateOrEditEntryCommand { get; }
		public ICommand ClearInputCommand { get; }

		public CreateEditEntryViewModel(DataService dataService, EntriesStore entriesStore, NavigationStore navigationStore, string category = null)
		{
			_entriesStore = entriesStore;
			_navigationStore = navigationStore;
			_dataService = dataService;
			ClearInputCommand = new RelayCommand(parameter => ClearInput());

			SetEntryValues(category);

			CreateOrEditEntryCommand = new RelayCommand(parameter => CreateEntry());
		}

		public CreateEditEntryViewModel(DataService dataService, EntriesStore entriesStore, NavigationStore navigationStore, EntryViewModel selectedEntry)
		{
			_entriesStore = entriesStore;
			_navigationStore = navigationStore;
			_dataService = dataService;
			ClearInputCommand = new RelayCommand(parameter => ClearInput());

			SetEntryValues(selectedEntry.Category, selectedEntry.Title, selectedEntry.Paragraph);

			CreateOrEditEntryCommand = new RelayCommand(parameter => EditEntry(selectedEntry));
		}

		private void SetEntryValues(string category = null, string title = null, string paragraph = null)
		{
			EntryCategory = ( !string.IsNullOrEmpty(category) ) ?
				category : string.Empty;
			EntryTitle = ( !string.IsNullOrEmpty(title) ) ?
				title : string.Empty;
			EntryParagraph = ( !string.IsNullOrEmpty(paragraph) ) ?
				paragraph : string.Empty;
		}

		private void ClearInput() => EntryCategory = EntryTitle = EntryParagraph = string.Empty;

		private void CreateEntry()
		{
			Mouse.OverrideCursor = Cursors.Wait;
			try
			{
				EntryModel entryModel = new EntryModel(new ObjectId(), System.DateTime.Now, EntryCategory, EntryTitle, EntryParagraph.Trim());

				EntryTitle = EntryParagraph = string.Empty;

				_dataService.Create(entryModel);

				_dataService.SpecifiedRead(_entriesStore, EntryCategory);
			}
			finally
			{
				Mouse.OverrideCursor = null;
			}
		}

		private void EditEntry(EntryViewModel entry)
		{
			Mouse.OverrideCursor = Cursors.Wait;
			try
			{
				EntryModel entryModel = new EntryModel(entry.Id, entry.CreatedAt, EntryCategory, EntryTitle, EntryParagraph);

				_dataService.Update(entryModel);

				_dataService.SpecifiedRead(_entriesStore, EntryCategory);

				_navigationStore.CurrentView = new EntryListingViewModel(_entriesStore, _dataService, _navigationStore);
			}
			finally
			{
				Mouse.OverrideCursor = null;
			}
		}
	}
}