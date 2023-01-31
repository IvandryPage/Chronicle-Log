using System.Windows.Controls;

namespace ChronicleLog.App.MVVM.Views
{
	/// <summary>
	/// Interaction logic for ListingLogView.xaml
	/// </summary>
	public partial class ListingLogView : UserControl
	{
		public ListingLogView()
		{
			InitializeComponent();
		}

		private void ListingUserControl_SizeChanged(object sender, System.Windows.SizeChangedEventArgs e)
		{
			ListingListView.MinWidth = this.ActualWidth - 80;
		}
	}
}
