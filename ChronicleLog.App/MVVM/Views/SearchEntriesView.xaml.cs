using System.Windows.Controls;
using System.Windows.Input;

namespace ChronicleLog.App.MVVM.Views
{
	/// <summary>
	/// Interaction logic for DetachLogView.xaml
	/// </summary>
	public partial class SearchEntriesView : UserControl
	{
		public SearchEntriesView()
		{
			InitializeComponent();
		}

		private void SearchCategoryTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Space)
				e.Handled = true;

			if (e.Key == Key.Enter)
			{
				SearchEntriesButton.Command.Execute(null);
			}
		}
	}
}
