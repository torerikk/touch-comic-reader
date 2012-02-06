using System;
using System.IO;
using SevenZip;
using TouchComic.Model;

namespace TouchComic.DataAccess
{
    class ComicBookRepository
    {
        public readonly ComicBook _comicbook;

        #region Constructor

        public ComicBookRepository(string archiveFile)
        {
            _comicbook = new ComicBook();
            LoadComicBook(archiveFile);
        }
        #endregion

        #region Private Helpers

        private string _tempPath;

        private void LoadComicBook(string archivePath)
        {
            // Clean old temp folder if new comic is opened.
            if (!string.IsNullOrEmpty(_tempPath))
            {
                CleanTempPath();
            }

            // Decompress an archive file to a temporary path and read image files from there.
            //  Get a temporary path and create it.
            _tempPath = Path.GetTempPath() + Path.GetRandomFileName();
            Directory.CreateDirectory(_tempPath);

            // Decompress comic book file.
            if (Decompress(archivePath, _tempPath))
            {
                // TODO: Load archive to memory stream and decompress only x next pages.

                // Create pages form each image file in temp path.
                FindFiles(_tempPath);
            }
            //else
            //{
            //    // TODO: Handle that the comic failed to load.
            //}
        }

        /// <summary>
        /// Decompresses an comic book to a specified path.
        /// </summary>
        /// <param name="archivePath">Full path to the comic book file.</param>
        /// <param name="outputPath">Full path where the archived files will be written.</param>
        /// <returns>True on success.</returns>
        private static bool Decompress(string archivePath, string outputPath)
        {
            try
            {
                using (var extr = new SevenZipExtractor(archivePath))
                {
                    extr.ExtractArchive(outputPath);
                }
                return (true);
            }
            catch (Exception ex)
            {
                throw(new ApplicationException(string.Format("Extraction of comic book archive {0} failed.", Path.GetFileName(archivePath)), ex));
            }
        }

        private void CleanTempPath()
        {
            // Clean up the temp directory.
            try
            {
                Directory.Delete(_tempPath, true);
                _tempPath = "";
            }
            catch (IOException)
            {
                // TODO: Notify the user that cleanup failed?
            }
        }

        ~ComicBookRepository()
        {
            CleanTempPath();
        }

        private void FindFiles(string path)
        {
            var files = Directory.GetFiles(path);
            var pageCounter = 0;
            foreach (var file in files)
            {
                // TODO: Better file type check.

                var ext = Path.GetExtension(file).ToLower();
                if (ext == ".jpg" || ext == ".bmp" || ext == ".gif" || ext == ".png" || ext == ".jpeg" || ext == ".tif" || ext == ".tiff" || ext == ".jpe" || ext == ".jif" || ext == ".jfif" || ext == ".jfi")
                {
                    _comicbook.Pages.Add(pageCounter > 6
                                             ? new ComicBookPage(file, false)
                                             : new ComicBookPage(file, true));
                }
                pageCounter++;
                // TODO: Parse any comicrack xml file present.
            }

            var dirs = Directory.GetDirectories(path);
            foreach (var dir in dirs)
            {
                FindFiles(dir);
            }

        }
        #endregion
    }
}
