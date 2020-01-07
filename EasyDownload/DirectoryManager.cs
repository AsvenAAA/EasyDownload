using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace EasyDownload
{
    public class DirectoryManager
    {
        private string _path = $@"C:\Users\{Environment.UserName}\Downloads\";
        public int FileDirectory
        {
            get => default;
            set
            {
            }
        }

        public string GetDirectories()
        {
            CommonOpenFileDialog fileDialog = new CommonOpenFileDialog();
            fileDialog.IsFolderPicker = true;
            if (fileDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                return _path = fileDialog.FileName;
            }
            return _path;
        }

        public void SetNewDirectory()
        {
            throw new System.NotImplementedException();
        }
    }
}