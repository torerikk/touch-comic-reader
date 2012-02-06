using System;
using System.Windows.Media.Imaging;

namespace TouchComic.Model
{
    class ComicBookPage : ObservableObject
    {
        /// <summary>
        /// Gets a bool that describes if this page has a bitmap in memory or not.
        /// </summary>
        public bool IsLoaded{ get; private set; }

        public BitmapFrame Frame { get; private set; }

        public string Path{ get; private set; }

        public ComicBookPage(string path, bool loadBitmap)
        {
            Path = path;
            if (loadBitmap)
            {
                LoadBitmap();
            }
        }

        public void UnloadBitmap()
        {
            Frame = null;
            IsLoaded = false;
        }

        public void LoadBitmap()
        {
            Frame = BitmapFrame.Create(new Uri(Path));
            IsLoaded = true;

        }
    }
}
