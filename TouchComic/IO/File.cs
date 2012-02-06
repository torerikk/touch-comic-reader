using System.ComponentModel;
using Microsoft.Win32;

namespace TouchComic.IO
{
    class File
    {
        public static void OpenComic(CancelEventHandler fileOkEvent )
        {
            var dlg = new OpenFileDialog
                          {
                              CheckFileExists = true,
                              CheckPathExists = true,
                              Filter =
                                  "Comic Books (*.cbr, *.cbz, *.cb7, *.rar, *.zip, *.7z)|*.cbr;*.cbz;*.cb7;*.rar;*.zip;*.7z|All Files|*.*"
                          };
            dlg.CustomPlaces.Add(new FileDialogCustomPlace("D:\\klausen\\"));
            
            dlg.FileOk += fileOkEvent;

            dlg.ShowDialog();
        }



    }
}
