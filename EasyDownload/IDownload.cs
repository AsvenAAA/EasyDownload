using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;

namespace EasyDownload
{
    interface IDownload
    {
        string URI { get; set; }
        DateTime StartTime { get; set; }
        DateTime EndTime { get; set; }
        string DownloadState { get; set; }
        Task<HttpResponseMessage> CheckDownloadFile();
        //Task<Stream> DownloadFile();
        Task DownloadFile();
        void DownloadOK();
        void GiveTimeSpent();
        void StateKeeper();
        void CheckDownloadState();

    }
}
