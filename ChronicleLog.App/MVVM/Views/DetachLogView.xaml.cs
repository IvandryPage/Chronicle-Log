using System.Windows.Controls;
using System.Windows.Input;

namespace ChronicleLog.App.MVVM.Views
{
	/// <summary>
	/// Interaction logic for DetachLogView.xaml
	/// </summary>
	public partial class DetachLogView : UserControl
	{
		public DetachLogView()
		{
			InitializeComponent();
		}

		private void DetachLogCategoryTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
		{
			if ( e.Key == Key.Space )
				e.Handled = true;

			if ( e.Key == Key.Enter )
			{
				DetachLogCategoryButton.Command.Execute(null);
			}
		}
	}
}
