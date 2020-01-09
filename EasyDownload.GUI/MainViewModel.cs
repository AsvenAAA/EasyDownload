using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyDownload;
using Prism.Mvvm;
using Prism.Commands;
using System.ComponentModel;


namespace EasyDownload.GUI
{
    class MainViewModel : BindableBase, INotifyPropertyChanged
    {
        //public event PropertyChangedEventHandler PropertyChanged;
        //protected virtual void OnPropertyChanged(string propertyName)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}

        private readonly DirectoryManager _dirManager = new DirectoryManager();
        //public string PathToFolder
        //{
        //    get { return _pathToFolder; }
        //    set
        //    {
        //        _pathToFolder = value;
        //        OnPropertyChanged("Path");
        //    }
        //}
        public MainViewModel()
        {
            _dirManager.PropertyChanged += (s, e) => { RaisePropertyChanged(e.PropertyName); };
            ViewExplorer = new DelegateCommand<string>(str => { _dirManager.OpenFolderBrowser(); });
        }
        public DelegateCommand<string> ViewExplorer { get; }
        public string Path => _dirManager.Path;
    }
}
