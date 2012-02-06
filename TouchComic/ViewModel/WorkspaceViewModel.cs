using System;
using System.Windows.Input;

namespace TouchComic.ViewModel
{
	/// <summary>
	/// This ViewModelBase subclass requests to be removed 
	/// from the UI when its CloseCommand executes.
	/// This class is abstract.
	/// </summary>
	public abstract class WorkspaceViewModel : ObservableObject
	{
		#region Fields

		RelayCommand _closeCommand;

		#endregion // Fields

		#region CloseCommand

		/// <summary>
		/// Returns the command that, when invoked, attempts
		/// to remove this workspace from the user interface.
		/// </summary>
		public ICommand CloseCommand
		{
			get { return _closeCommand ?? (_closeCommand = new RelayCommand(this.OnRequestClose)); }
		}

		#endregion // CloseCommand

		#region RequestClose [event]

		/// <summary>
		/// Raised when this workspace should be removed from the UI.
		/// </summary>
		public event EventHandler RequestClose;

		void OnRequestClose()
		{
			var handler = RequestClose;
			if (handler != null)
				handler(this, EventArgs.Empty);
		}

		#endregion // RequestClose [event]
	}
}