using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;
using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Diagnostics;

namespace EasyDownload
{
    class Program : Application
    {
        [STAThread]
        //async Task
        static void Main()
        {

            //Downloader download = new Downloader();

            //await download.DownloadFile();
            //await download.Test();

            //Console.WriteLine("Done");

            // Console.ReadKey();


            Program app = new Program();
            app.Startup += new StartupEventHandler(AppStartAp);
            app.Exit += new ExitEventHandler(AppExit);
            app.Run();
        }

        static void AppExit(object sender, ExitEventArgs e)
        {
            MessageBox.Show("App has exited!");
        }

        static void AppStartAp(object sender, StartupEventArgs e)
        {
            Application.Current.Properties["GodMode"] = false;
            foreach(string arg in e.Args)
            {
                if(arg.ToLower() == "/godmode")
                {
                    Application.Current.Properties["GodMode"] = true;
                    break;
                }
            }
            MainWindow mainWindow = new MainWindow("TestApp!", 400, 500);
            mainWindow.Show();
        }


    }

}
