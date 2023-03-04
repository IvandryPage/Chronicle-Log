using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace ChronicleLog.App.MVVM.Views
{
	/// <summary>
	/// Interaction logic for AddLogView.xaml
	/// </summary>
	public partial class CreateEditView : UserControl
	{
		public CreateEditView()
		{
			InitializeComponent();
		}

		private void CategoryTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Space)
				e.Handled = true;
		}

		private void UserControl_SizeChanged(object sender, System.Windows.SizeChangedEventArgs e)
		{
			if (Application.Current.MainWindow.ActualWidth >= 580)
			{
				double width = DescriptionTextBox.ActualWidth / 2.25;

				TitleTextBox.Width = width;
				CategoryTextBox.Width = width;
			}
			else if (Application.Current.MainWindow.ActualWidth <= 360)
			{
				TitleTextBox.Width = TitleTextBox.MinWidth;
				CategoryTextBox.Width = CategoryTextBox.MinWidth;
			}
		}
	}
}
