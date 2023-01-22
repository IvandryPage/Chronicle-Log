using ChronicleLog.App.MVVM.Models;
using System.Globalization;

namespace ChronicleLog.App.MVVM.ViewModels
{
	public class LogQueryViewModel : ViewModelBase
	{
		private readonly LogQueryModel _logQueryModel;
		public string Time => _logQueryModel.CreatedAt.ToShortTimeString();
		public string Day => _logQueryModel.CreatedAt.ToString("dd", CultureInfo.InvariantCulture);
		public string Month => _logQueryModel.CreatedAt.ToString("MMM", CultureInfo.InvariantCulture);
		public string Category => _logQueryModel.Category;
		public string Title => _logQueryModel.Title;
		public string Paragraph => _logQueryModel.Paragraph;

		public LogQueryViewModel(LogQueryModel logQueryModel)
		{
			_logQueryModel = logQueryModel;
		}
	}
}
