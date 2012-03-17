using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using JulMar.Windows.Mvvm;
using Microsoft.Win32;
using TouchComic.DataAccess;
using TouchComic.Model;

namespace TouchComic.ViewModel
{
	public class MainWindowViewModel : JulMar.Windows.Mvvm.ViewModel
	{
		private ComicBookRepository cbRepos = null;
		private ComicBook _Comic = new ComicBook();
		private ComicBookPage _currentPage;
		private ZoomMode _currentZoomMode = ZoomMode.Fit;
		private bool _showToolbar = true;

		public ICommand OpenFile { get; private set; }

		public ICommand OpenList { get; private set; }

		public ICommand NextPage { get; private set; }

		public ICommand PrevPage { get; private set; }

		public ICommand Close { get; private set; }

		public ICommand FullScreen { get; set; }

		public ObservableCollection<CheckValues<ZoomMode>> ZoomModeValues { get; set; }

		internal ComicBook Comic
		{
			get { return _Comic; }
			set { _Comic = value; }
		}

		public bool ShowToolbar
		{
			get { return _showToolbar; }
			set { _showToolbar = value; }
		}

		public ZoomMode CurrentZoomMode
		{
			get { return _currentZoomMode; }
			set { _currentZoomMode = value; }
		}

		public BitmapFrame CurrentFrame
		{
			get
			{
				if (cbRepos == null)
					return null;
				if (!_currentPage.IsLoaded)
					_currentPage.LoadBitmap();
				return _currentPage.Frame;
			}
		}

		public MainWindowViewModel()
		{
			OpenFile = new DelegatingCommand(OnOpenFile);
			OpenList = new DelegatingCommand(OnOpenList, CanOpenList);
			NextPage = new DelegatingCommand(OnNextPage, CanNextPage);
			PrevPage = new DelegatingCommand(OnPrevPage, CanPrevPage);
			Close = new DelegatingCommand(OnClose);
			FullScreen = new DelegatingCommand(OnFullScreen);
			ZoomModeValues = new ObservableCollection<CheckValues<ZoomMode>>();
			foreach (object t in Enum.GetValues(typeof(ZoomMode)))
			{
				ZoomModeValues.Add(new CheckValues<ZoomMode> { Value = (ZoomMode)t });
			}
			ZoomModeValues[0].IsChecked = true;
		}

		#region Commands

		private void OnOpenFile()
		{
			IO.File.OpenComic(OpenComic_FileOk);
		}

		private void OnOpenList()
		{
			throw new NotImplementedException();
		}

		private bool CanOpenList()
		{
			return false;
		}

		private void OnNextPage()
		{
			_currentPage = Comic.NextPage();
			OnPropertyChanged("CurrentFrame");
		}

		private bool CanNextPage()
		{
			return Comic.HasNextPage;
		}

		private void OnPrevPage()
		{
			_currentPage = Comic.PreviousPage();
			OnPropertyChanged("CurrentFrame");
		}

		private bool CanPrevPage()
		{
			return Comic.HasPreviousPage;
		}

		#endregion Commands

		#region RequestFullScreen [event]

		public event EventHandler RequestFullScreen;

		private void OnFullScreen()
		{
			var handler = RequestFullScreen;
			if (handler != null)
				handler(this, EventArgs.Empty);
		}

		#endregion RequestFullScreen [event]

		#region RequestClose [event]

		/// <summary>
		/// Raised when this workspace should be removed from the UI.
		/// </summary>
		public event EventHandler RequestClose;

		private void OnClose()
		{
			var handler = RequestClose;
			if (handler != null)
				handler(this, EventArgs.Empty);
		}

		#endregion RequestClose [event]

		private void OpenComic_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
		{
			var dlg = (OpenFileDialog)sender;
			cbRepos = new DataAccess.ComicBookRepository(dlg.FileName);
			Comic = cbRepos._comicbook;
			_currentPage = Comic.Page(0);
			OnPropertyChanged("CurrentFrame");
		}
	}
}