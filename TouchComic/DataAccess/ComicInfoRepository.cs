using System.IO;
using System.Xml.Serialization;
using System;

namespace TouchComic.DataAccess
{
	public class ComicInfoRepository: IDisposable
	{
		private string _Filename;
		private Stream _FileStream;

		public ComicInfoRepository(string filename)
		{
			_Filename = filename;
			_FileStream = File.Open(_Filename, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
		}

		public ComicInfo GetInfo()
		{
			XmlSerializer serializer = new XmlSerializer(typeof(ComicInfo));
			ComicInfo output;

			output = (ComicInfo)serializer.Deserialize(_FileStream);
			return output;
		}

		public void Dispose()
		{
			_FileStream.Close();
			_Filename = null;
		}
	}
}
