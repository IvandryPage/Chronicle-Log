﻿using System.Windows.Controls;
using System.Windows.Input;

namespace ChronicleLog.App.MVVM.Views
{
	/// <summary>
	/// Interaction logic for AddLogView.xaml
	/// </summary>
	public partial class AddLogView : UserControl
	{
		public AddLogView()
		{
			InitializeComponent();
		}

		private void CategoryTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
		{
			if ( e.Key == Key.Space )
				e.Handled = true;
		}
	}
}
