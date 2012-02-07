using System.Collections.ObjectModel;
using System.ComponentModel;

namespace TouchComic.Model
{
	class ComicBook : ObservableObject, IDataErrorInfo
	{
		public enum Direction
		{
			Previous = -1,
			None = 0,
			Next = 1,
			Jump = 2
		}

		public ComicInfo MetaData { get; set; }
		public bool HasMetaData { get; set; }

		#region State Properties
		private ObservableCollection<ComicBookPage> _pages = new ObservableCollection<ComicBookPage>();

		/// <summary>
		/// Gets/sets the current page of the comic book. Value cannot be outside the bounds of the Pages collection.
		/// </summary>
		public int CurrentPage { get; set; }

		/// <summary>
		/// Gets the total number of pages in the comic.
		/// </summary>
		public int TotalPages
		{
			get { return _pages.Count; }
		}

		/// <summary>
		/// Returns the Comic books collection of ComicBookPages
		/// </summary>
		public ObservableCollection<ComicBookPage> Pages
		{
			get { return _pages; }
			private set { _pages = value; }
		}

		public string CurrentPath
		{
			get
			{
				return Pages[CurrentPage].Path;
			}
		}

		/// <summary>
		/// Indicates if it is possible to go to the previous page.
		/// </summary>
		public bool HasPreviousPage
		{
			get
			{
				if (CurrentPage > 0)
					return true;
				else
					return false;
			}
		}

		/// <summary>
		/// Indicates if it is possible to go to the next page.
		/// </summary>
		public bool HasNextPage
		{
			get
			{
				if (CurrentPage < Pages.Count - 1)
					return true;
				else
					return false;
			}
		}

		/// <summary>
		/// Returns the direction of the latest navigation event.
		/// </summary>
		public Direction LastNavigate { get; private set; }

		#endregion

		#region Navigation Methods
		public ComicBookPage Page(int index)
		{
			CurrentPage = index;
			// Check if we have reached the last page.
			if (CurrentPage >= Pages.Count)
			{
				CurrentPage = Pages.Count - 1;
			}
			// If by some chance the current page is not loaded, load it.
			if (Pages[CurrentPage].IsLoaded == false)
			{
				Pages[CurrentPage].LoadBitmap();
			}
			LastNavigate = Direction.Next;
			return (Pages[CurrentPage]);
		}


		public ComicBookPage NextPage()
		{
			CurrentPage++;
			// Check if we have reached the last page.
			if (CurrentPage >= Pages.Count)
			{
				CurrentPage = Pages.Count - 1;
			}
			// If by some chance the current page is not loaded, load it.
			if (Pages[CurrentPage].IsLoaded == false)
			{
				Pages[CurrentPage].LoadBitmap();
			}
			LastNavigate = Direction.Next;
			return (Pages[CurrentPage]);
		}

		public ComicBookPage PreviousPage()
		{
			CurrentPage--;
			// Check if we have reached the first page.
			if (CurrentPage < 0)
			{
				CurrentPage = 0;
			}
			// If by some chance the current page is not loaded, load it.
			if (Pages[CurrentPage].IsLoaded == false)
			{
				Pages[CurrentPage].LoadBitmap();
			}
			LastNavigate = Direction.Previous;
			return (Pages[CurrentPage]);

		}

		#endregion

		#region IDataErrorInfo Members

		string IDataErrorInfo.Error { get { return null; } }

		string IDataErrorInfo.this[string propertyName]
		{
			get { return GetValidationError(propertyName); }
		}

		#endregion

		#region Validation

		static string GetValidationError(string propertyName)
		{
			string error = null;

			return error;

		}

		#endregion

	}
}
