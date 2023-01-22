using ChronicleLog.App.MVVM.ViewModels.Commands;
using ChronicleLog.App.Stores;
using System.Windows;
using System.Windows.Input;

namespace ChronicleLog.App.MVVM.ViewModels
{
	public class DetachLogViewModel : ViewModelBase
	{
		private readonly LogQueriesStore _logQueriesStore;
		private readonly Services.DataService _dataService;

		private Visibility _messageVisibility;
		public Visibility MessageVisibility
		{
			get => _messageVisibility;
			set
			{
				_messageVisibility = value;
				OnPropertyChanged(nameof(MessageVisibility));
			}
		}

		private string _messageText;
		public string MessageText
		{
			get => _messageText;
			set
			{
				_messageText = value;
				OnPropertyChanged(nameof(MessageText));
			}
		}

		private string _logCategoryValue;
		public string LogCategoryValue
		{
			get => _logCategoryValue;
			set
			{
				_logCategoryValue = value;
				MessageVisibility = Visibility.Collapsed;
				OnPropertyChanged(nameof(LogCategoryValue));
			}
		}

		private bool _isSucceed;
		public bool IsSucceed
		{
			get => _isSucceed;
			set
			{
				_isSucceed = value;
				OnPropertyChanged(nameof(IsSucceed));
			}
		}

		public ICommand DetachLogCategoryCommand { get; }

		public DetachLogViewModel(Services.DataService dataService, LogQueriesStore logQueriesStore)
		{
			_logQueriesStore = logQueriesStore;
			_dataService = dataService;
			MessageVisibility = Visibility.Collapsed;
			DetachLogCategoryCommand = new RelayCommand(parameter => DetachLogCategory());
		}

		private void DetachLogCategory()
		{
			_logQueriesStore.RequestedLogQueryViewModels.Clear();

			_dataService.SpecifiedRead(_logQueriesStore, _logCategoryValue);

			if ( _logQueriesStore.RequestedLogQueryViewModels.Count != 0 )
			{
				MessageText = "Logs succesfully detached! Check \"Listing\" Menu";
				IsSucceed = true;
			}
			else
			{
				MessageText = "Failed to detach logs. Category not found!";
				IsSucceed = false;
			}
			MessageVisibility = Visibility.Visible;
		}
	}
}
