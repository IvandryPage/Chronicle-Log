using System;

namespace ChronicleLog.App.Stores
{
	public class NavigationStore
	{
		private object _currentView;
		public object CurrentView
		{
			get => _currentView;
			set
			{
				_currentView = value;
				OnCurrentViewChanged();
			}
		}

		public event Action CurrentViewChanged;
		private void OnCurrentViewChanged()
		{
			CurrentViewChanged?.Invoke();
		}
	}
}
