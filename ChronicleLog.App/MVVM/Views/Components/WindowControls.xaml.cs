using System.Windows;
using System.Windows.Controls;

namespace ChronicleLog.App.MVVM.Views.Components
{
	/// <summary>
	/// Interaction logic for WindowControls.xaml
	/// </summary>
	public partial class WindowControls : UserControl
	{
		public WindowControls()
		{
			InitializeComponent();
		}

		private void MinimizeButton_Click(object sender, RoutedEventArgs e)
		{
			Application.Current.MainWindow.WindowState = WindowState.Minimized;
		}

		private void WindowStateButton_Click(object sender, RoutedEventArgs e)
		{
			if ( Application.Current.MainWindow.WindowState != WindowState.Maximized )
			{
				Application.Current.MainWindow.WindowState = WindowState.Maximized;
				( (Button)sender ).Content = "⤦";
			}
			else if ( Application.Current.MainWindow.WindowState != WindowState.Normal )
			{
				Application.Current.MainWindow.WindowState = WindowState.Normal;
				( (Button)sender ).Content = "⤤";
			}
		}

		private void CloseButton_Click(object sender, RoutedEventArgs e)
		{
			Application.Current.Shutdown();
		}
	}
}
