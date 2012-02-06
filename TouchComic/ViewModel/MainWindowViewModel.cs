using System;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using TouchComic.DataAccess;
using TouchComic.Model;

namespace TouchComic.ViewModel
{
	public class MainWindowViewModel : WorkspaceViewModel
	{
		private ComicBookRepository cbRepos = null;
		private ComicBook _Comic = new ComicBook();
		private ComicBookPage _currentPage;
		private ZoomMode _currentZoomMode = ZoomMode.Fit;
		private bool _showToolbar = true;

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

		#region Commands
		void OpenFileExecute()
		{
			IO.File.OpenComic(OpenComic_FileOk);
		}
		public ICommand OpenFile
		{
			get { return new RelayCommand(OpenFileExecute); }
		}

		void OpenListExecute()
		{
			throw new NotImplementedException();
		}
		bool CanOpenListExecute()
		{
			return false;
		}
		public ICommand OpenList
		{
			get { return new RelayCommand(OpenListExecute, CanOpenListExecute); }
		}

		void NextPageExecute()
		{
			_currentPage = Comic.NextPage();
			RaisePropertyChanged("CurrentFrame");
		}
		bool CanNextPageExecute()
		{
			return Comic.HasNextPage;
		}
		public ICommand NextPage
		{
			get { return new RelayCommand(NextPageExecute, CanNextPageExecute); }
		}

		void PrevPageExecute()
		{
			_currentPage = Comic.PreviousPage();
			RaisePropertyChanged("CurrentFrame");
		}
		bool CanPrevPageExecute()
		{
			return Comic.HasPreviousPage;
		}
		public ICommand PrevPage
		{
			get { return new RelayCommand(PrevPageExecute, CanPrevPageExecute); }
		}
		#endregion

		void OpenComic_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
		{
			var dlg = (OpenFileDialog)sender;
			cbRepos = new DataAccess.ComicBookRepository(dlg.FileName);
			Comic = cbRepos._comicbook;
			_currentPage = Comic.Page(0);
			RaisePropertyChanged("CurrentFrame");
		}
	}
}