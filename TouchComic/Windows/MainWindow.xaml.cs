using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;
using TouchComic.ViewModel;

namespace TouchComic.Windows
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow
	{
		private WindowState wndStateFullScrn;
		private Point mouseStart;

		public MainWindow()
		{

			InitializeComponent();
			var viewModel = DataContext as MainWindowViewModel;
			viewModel.RequestClose += delegate
			{
				this.Close();
			};
			mniFile.Focus();
		}

		#region Commands
		void FullScreenExecute()
		{
			ToggleFullscreen();
		}

		bool FullScreenFileExecute()
		{
			return true;
		}

		public ICommand FullScreen
		{
			get { return new RelayCommand(FullScreenExecute, FullScreenFileExecute); }
		}

		#endregion

		private void Always_CanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = true;
			e.Handled = true;
		}

		private void MniHelpAboutClick(object sender, RoutedEventArgs e)
		{
			var wnd = new AboutWindow();
			wnd.Owner = this;
			wnd.ShowDialog();
		}

		void imgView_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			Point mouseEnd = e.GetPosition(imgView);
			double movementX = (mouseStart.X - mouseEnd.X);
			if (movementX > 50)
			{
				// There might be a better way to do this. But this seemed by far the easiest. :)
				var viewModel = DataContext as MainWindowViewModel;
				viewModel.NextPage.Execute(null);
				//btnRight.Command.Execute(null);
			}
			else if (movementX < -50)
			{
				var viewModel = DataContext as MainWindowViewModel;
				viewModel.PrevPage.Execute(null);
				//btnLeft.Command.Execute(null);
			}
		}

		void imgView_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			mouseStart = e.GetPosition(imgView);

		}

		private void ToggleFullscreen()
		{
			if (this.WindowState == WindowState.Maximized && this.Topmost == true)
			{
				this.imgView.Visibility = Visibility.Hidden;
				this.WindowState = wndStateFullScrn;
				this.Topmost = false;
				this.ResizeMode = ResizeMode.CanResize;
				this.mnuMain.Visibility = Visibility.Visible;
				// If the toolbar is supposed to be visible, make it so.. 
				if (mniViewToolbar.IsChecked == true)
				{
					tlbMain.Visibility = System.Windows.Visibility.Visible;
				}
				else
				{
					tlbMain.Visibility = Visibility.Collapsed;
				}
				this.WindowStyle = WindowStyle.SingleBorderWindow;
				this.imgView.Visibility = Visibility.Visible;
			}
			else
			{
				this.imgView.Visibility = Visibility.Hidden;
				wndStateFullScrn = this.WindowState;
				if (this.WindowState == WindowState.Maximized)
				{
					this.WindowState = WindowState.Normal;
				}
				this.ResizeMode = ResizeMode.NoResize;
				this.WindowStyle = WindowStyle.None;
				this.Topmost = true;
				this.mnuMain.Visibility = Visibility.Collapsed;
				this.tlbMain.Visibility = System.Windows.Visibility.Collapsed;
				//if (Options.Default.FullscreenToolbar == false)
				//{
				//    tbtMainTray.Visibility = Visibility.Collapsed;
				//}
				//else
				//{
				//    tbtMainTray.Visibility = Visibility.Visible;
				//}
				this.WindowState = WindowState.Maximized;
				this.imgView.Visibility = Visibility.Visible;
			}
		}

		private void imgView_TargetUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
		{
			var model = this.DataContext as MainWindowViewModel;
			if (model != null && model.CurrentFrame != null)
			{
				ResizeImage(model.CurrentZoomMode, model.CurrentFrame.PixelHeight, model.CurrentFrame.PixelWidth);
				toastText.Text = string.Format("Page {0} of {1}", model.Comic.CurrentPage + 1, model.Comic.TotalPages);
				((Storyboard)FindResource("toastfade")).Begin(toast);

			}
		}

		private void ResizeImage()
		{
			var model = this.DataContext as MainWindowViewModel;
			if (model != null && model.CurrentFrame != null)
			{
				ResizeImage(model.CurrentZoomMode, model.CurrentFrame.PixelHeight, model.CurrentFrame.PixelWidth);
			}
		}

		private void ResizeImage(ZoomMode zoomMode, double orgHeight, double orgWidth)
		{
			switch (zoomMode)
			{
				case ZoomMode.Fit:
					imgView.MaxHeight = scvScroll.ViewportHeight;
					imgView.MaxWidth = scvScroll.ViewportWidth;
					goto default;
				case ZoomMode.FitHeight:
					//// FitHeight means that the comic books full height is shown regardless of window size (and rotation).
					//if (rotationState == Rotation.Rotate0 || rotationState == Rotation.Rotate180)
					//{
					imgView.MaxWidth = double.MaxValue;
					imgView.MaxHeight = scvScroll.ViewportHeight;
					//}
					//else
					//{
					//    imgView.MaxHeight = double.MaxValue;
					//    imgView.MaxWidth = scvScroll.ViewportWidth;
					//}
					goto default;
				case ZoomMode.FitWidth:
					// FitWidth means that the comic books full width is shown regardless of window size (and rotation).
					//if (rotationState == Rotation.Rotate0 || rotationState == Rotation.Rotate180)
					//{
					imgView.MaxHeight = double.MaxValue;
					imgView.MaxWidth = scvScroll.ViewportWidth;
					//}
					//else
					//{
					//    imgView.MaxWidth = double.MaxValue;
					//    imgView.MaxHeight = scvScroll.ViewportHeight;
					//}

					goto default;
				case ZoomMode.Original:
					imgView.MaxHeight = orgHeight;
					imgView.MaxWidth = orgWidth;
					goto default;
				default:
					break;
			}

		}

		private void scvScroll_LayoutUpdated(object sender, System.EventArgs e)
		{
			ResizeImage();
		}

		//Scrolling
		private Point scrollStartPoint;
		private Point scrollStartOffset;

		protected override void OnPreviewMouseDown(MouseButtonEventArgs e)
		{
			if (scvScroll.IsMouseOver)
			{
				// Save starting point, used later when determining 
				//how much to scroll.
				scrollStartPoint = e.GetPosition(this);
				scrollStartOffset.X = scvScroll.HorizontalOffset;
				scrollStartOffset.Y = scvScroll.VerticalOffset;

				// Update the cursor if can scroll or not.
				if (scvScroll.ExtentWidth > scvScroll.ViewportWidth && scvScroll.ExtentHeight > scvScroll.ViewportHeight)
					this.Cursor = Cursors.ScrollAll;
				else if (scvScroll.ExtentWidth > scvScroll.ViewportWidth)
					this.Cursor = Cursors.ScrollWE;
				else if (scvScroll.ExtentHeight > scvScroll.ViewportHeight)
					this.Cursor = Cursors.ScrollNS;
				else
					this.Cursor = Cursors.Arrow;

				this.CaptureMouse();
			}

			base.OnPreviewMouseDown(e);
		}

		protected override void OnPreviewMouseMove(MouseEventArgs e)
		{
			if (this.IsMouseCaptured)
			{
				// Get the new scroll position.
				Point point = e.GetPosition(this);

				// Determine the new amount to scroll.
				Point delta = new Point(
					(point.X > this.scrollStartPoint.X) ?
						-(point.X - this.scrollStartPoint.X) :
						(this.scrollStartPoint.X - point.X),

					(point.Y > this.scrollStartPoint.Y) ?
						-(point.Y - this.scrollStartPoint.Y) :
						(this.scrollStartPoint.Y - point.Y));

				// Scroll to the new position.
				scvScroll.ScrollToHorizontalOffset(
					this.scrollStartOffset.X + delta.X);
				scvScroll.ScrollToVerticalOffset(
					this.scrollStartOffset.Y + delta.Y);
			}

			base.OnPreviewMouseMove(e);
		}



		protected override void OnPreviewMouseUp(
			MouseButtonEventArgs e)
		{
			if (this.IsMouseCaptured)
			{
				this.Cursor = Cursors.Arrow;
				this.ReleaseMouseCapture();
			}

			base.OnPreviewMouseUp(e);
		}
		// End scrolling

	}
}
