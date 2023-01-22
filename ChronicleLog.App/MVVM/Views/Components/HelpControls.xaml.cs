using System.Windows;
using System.Windows.Controls;

namespace ChronicleLog.App.MVVM.Views.Components
{
	/// <summary>
	/// Interaction logic for HelpButton.xaml
	/// </summary>
	public partial class HelpButton : UserControl
	{
		public HelpButton()
		{
			InitializeComponent();
		}

		private void HelpButton_Click(object sender, RoutedEventArgs e)
		{
			if ( HelpBox.Visibility == Visibility.Visible )
				HelpBox.Visibility = Visibility.Collapsed;
			else
				HelpBox.Visibility = Visibility.Visible;
		}
	}
}
