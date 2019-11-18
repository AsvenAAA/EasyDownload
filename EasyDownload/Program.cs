using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;
using System.Collections;

using System.Diagnostics;

namespace EasyDownload
{
    class Program
    {
        static async Task Main()
        {

            Downloader download = new Downloader();

            //await download.DownloadFile();
            await download.Test();

            Console.WriteLine("Done");

            Console.ReadKey();
        }
    }

}
