﻿using ChronicleLog.App.MVVM.ViewModels.Commands;
using ChronicleLog.App.Stores;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ChronicleLog.App.MVVM.ViewModels
{
	public class DetachLogViewModel : ViewModelBase
	{
		private readonly LogQueriesStore _logQueriesStore;
		private readonly Services.DataService _dataService;
		private readonly NavigationStore _navigationStore;

		private string _logCategoryValue;
		public string LogCategoryValue
		{
			get => _logCategoryValue;
			set
			{
				_logCategoryValue = value;
				OnPropertyChanged(nameof(LogCategoryValue));
			}
		}

		public ICommand DetachLogCategoryCommand { get; }

		public DetachLogViewModel(Services.DataService dataService, LogQueriesStore logQueriesStore, NavigationStore navigationStore)
		{
			_logQueriesStore = logQueriesStore;
			_dataService = dataService;
			_navigationStore = navigationStore;

			DetachLogCategoryCommand = new RelayCommand(parameter => DetachLogCategory());
		}

		private void DetachLogCategory()
		{
			Mouse.OverrideCursor = Cursors.Wait;
			try
			{
				if (!string.IsNullOrEmpty(_logCategoryValue))
				{
					_dataService.SpecifiedRead(_logQueriesStore, _logCategoryValue);

					if (_logQueriesStore.RequestedLogQueryViewModels.Count != 0)
					{
						_navigationStore.CurrentView = new ListingLogViewModel(_logQueriesStore, _dataService, _navigationStore);
					}
					else
					{
						if (MessageBox.Show("Would you like to create it?", "Category Not Found", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
							_navigationStore.CurrentView = new AddLogViewModel(_dataService, _logQueriesStore, _navigationStore, _logCategoryValue);
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
