using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using EasyDownload;

namespace EasyDownload.GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _filePath;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ExplorerClick(object sender, RoutedEventArgs e)
        {
            //Install-Package WindowsAPICodePack-Shell


            //OpenFileDialog fileAndDirectoryDialog = new OpenFileDialog();
            //fileAndDirectoryDialog.Filter = "ISO (*.iso)|*.iso|All files (*.*)|*.*";
            //if (fileAndDirectoryDialog.ShowDialog() == true)
            //    textEditor.Text = fileAndDirectoryDialog.SafeFileName;

            //SaveFileDialog save = new SaveFileDialog();
            //if (save.ShowDialog() == true)
            //{
            //    _filePath = save.FileName;
            //    textEditor.Text = _filePath;

            //}

            //CommonOpenFileDialog fileDialog = new CommonOpenFileDialog();
            //fileDialog.IsFolderPicker = true;
            //if(fileDialog.ShowDialog() == CommonFileDialogResult.Ok)
            //{
            //    textEditor.Text = fileDialog.FileName;
            //}

            DirectoryManager manageDir = new DirectoryManager();
            textEditor.Text = manageDir.GetDirectories();
        }

        private void HistoryButtonClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
