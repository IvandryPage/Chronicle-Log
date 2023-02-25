using ChronicleLog.App.MVVM.Models;
using LiteDB;
using System.Globalization;

namespace ChronicleLog.App.MVVM.ViewModels
{
	public class EntryViewModel : ViewModelBase
	{
		private readonly EntryModel _entryModel;
		public ObjectId Id => _entryModel.Id;
		public System.DateTime CreatedAt => _entryModel.CreatedAt;
		public string Time => _entryModel.CreatedAt.ToShortTimeString();
		public string Day => _entryModel.CreatedAt.ToString("dd", CultureInfo.InvariantCulture);
		public string Month => _entryModel.CreatedAt.ToString("MMM", CultureInfo.InvariantCulture);
		public string Category => _entryModel.Category;
		public string Title => _entryModel.Title;
		public string Paragraph => _entryModel.Paragraph;

		public EntryViewModel(EntryModel entryModel)
		{
			_entryModel = entryModel;
		}
	}
}
