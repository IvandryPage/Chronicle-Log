using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace ChronicleLog.App.MVVM.Views
{
	/// <summary>
	/// Interaction logic for ListingLogView.xaml
	/// </summary>
	public partial class EntryListingView : UserControl
	{
		public EntryListingView()
		{
			InitializeComponent();
		}

		private void ListingUserControl_SizeChanged(object sender, System.Windows.SizeChangedEventArgs e)
		{
			ListingListView.MinWidth = this.ActualWidth - 80;
		}

		private void ListingUserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
		{
			DoubleAnimation heightAnimation = new DoubleAnimation(90, this.ActualHeight, new Duration(System.TimeSpan.FromMilliseconds(500)), FillBehavior.Stop);
			ListingListView.BeginAnimation(HeightProperty, heightAnimation);
		}
	}
}
