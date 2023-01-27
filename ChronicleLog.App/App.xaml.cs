﻿using ChronicleLog.App.MVVM.ViewModels;
using ChronicleLog.App.Services;
using ChronicleLog.App.Stores;
using System.Windows;

namespace ChronicleLog.App
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		private readonly LogQueriesStore _logQueriesStore;
		private readonly DataService _dataService;

		public App()
		{
			_logQueriesStore = new LogQueriesStore();
			_dataService = new DataService();
		}

		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);

			MainWindow window = new MainWindow()
			{
				DataContext = new MainWindowViewModel(_dataService, _logQueriesStore)
			};
			window.Show();
		}
	}
}
