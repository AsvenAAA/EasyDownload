using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.WindowsAPICodePack.Dialogs;
using Prism.Mvvm;
using System.Collections.ObjectModel;

namespace EasyDownload
{
    public class DirectoryManager : BindableBase
    {
        private string _path = $@"C:\Users\{Environment.UserName}\Downloads\";
        public int FileDirectory
        {
            get => default;
            set
            {
            }
        }


        private readonly ObservableCollection<int> _myValues = new ObservableCollection<int>();
        public readonly ReadOnlyObservableCollection<int> MyPublicValues;
        public DirectoryManager()
        {
            MyPublicValues = new ReadOnlyObservableCollection<int>(_myValues);
        }

        public void OpenFolderBrowser()
        {
            CommonOpenFileDialog fileDialog = new CommonOpenFileDialog();
            fileDialog.IsFolderPicker = true;
            if (fileDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                _path = fileDialog.FileName;
                RaisePropertyChanged("Path");
            }
        }

        public string Path => _path;

        public void SetNewDirectory()
        {
            throw new System.NotImplementedException();
        }
    }
}