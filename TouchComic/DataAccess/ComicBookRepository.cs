﻿using System;
using System.IO;
using System.Linq;
using SevenZip;
using TouchComic.Model;
using System.Collections.Generic;

namespace TouchComic.DataAccess
{
	class ComicBookRepository
	{
		public readonly ComicBook _comicbook;
		#region Constructor

		public ComicBookRepository(string archiveFile)
		{
			_comicbook = new ComicBook();
			_comicbook.HasMetaData = false;
			_comicbook.MetaData = new ComicInfo();
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
				Dictionary<int, string> imageFiles = new Dictionary<int, string>();
				FindFiles(_tempPath, ref imageFiles);
				GetPages(imageFiles);
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
				throw (new ApplicationException(string.Format("Extraction of comic book archive {0} failed.", Path.GetFileName(archivePath)), ex));
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

		private void FindFiles(string path, ref Dictionary<int, string> imageFiles)
		{
			int index = 0;
			var files = Directory.GetFiles(path);
			foreach (var file in files)
			{
				string filename = file.ToLowerInvariant();
				// Check if ComicInfo.xml is present in the file (Meta data from ComicRack).
				if (filename.EndsWith("comicinfo.xml"))
				{
					using (var metaRepos = new ComicInfoRepository(file))
					{
						_comicbook.MetaData = metaRepos.GetInfo();
						_comicbook.MetaData.XmlFile = file;
						_comicbook.HasMetaData = true;
					}
				}
				// TODO: Better file type check.

				var ext = Path.GetExtension(filename);
				if (ext == ".jpg" || ext == ".bmp" || ext == ".gif" || ext == ".png" || ext == ".jpeg" || ext == ".tif" || ext == ".tiff" || ext == ".jpe" || ext == ".jif" || ext == ".jfif" || ext == ".jfi")
				{
					imageFiles.Add(index, file);
					index++;
				}
			}

			// TODO: Verify that ComicRack handles cb files in this order (or how cb files with multiple dirs with files in them are handled).
			var dirs = Directory.GetDirectories(path);
			foreach (var dir in dirs)
			{
				FindFiles(dir, ref imageFiles);
			}

		}

		private void GetPages(Dictionary<int, string> imageFiles)
		{
			int pageCounter = 0;
			if (_comicbook.HasMetaData)
			{
				foreach (var pageinfo in _comicbook.MetaData.Pages)
				{
					string file = imageFiles.SingleOrDefault(z => z.Key == pageinfo.Image).Value;
					if (!string.IsNullOrWhiteSpace(file))
					{
						_comicbook.Pages.Add(
							pageCounter > 6
								? new ComicBookPage(file, false) { PageType = pageinfo.Type }
								: new ComicBookPage(file, true){ PageType = pageinfo.Type }
						);
						pageCounter++;
						imageFiles.Remove(pageinfo.Image);
					}
				}

			}

			// Now handle the rest of the files in the comic
			foreach (var file in imageFiles)
			{
				_comicbook.Pages.Add(
					pageCounter > 6
						? new ComicBookPage(file.Value, false) 
						: new ComicBookPage(file.Value, true));
				pageCounter++;
			}

		}
		#endregion
	}
}
