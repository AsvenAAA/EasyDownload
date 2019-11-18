using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;
//using FluentFTP;

namespace EasyDownload
{
    class FileDownload
    {
        public string URI { get; set; } = @"https://mirror.yandex.ru/centos/8.0.1905/isos/x86_64/CentOS-8-x86_64-1905-boot.iso";
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string DownloadState { get; set; } // Пока не знаю какой тип будет представлять
        public System.Net.HttpStatusCode test { get; set; }

        public FileDownload() { }
        public FileDownload(string any_string)
        { }

        public async Task<HttpResponseMessage> CheckDownloadFile()
        {
            HttpClient httpClient = new HttpClient();
            Uri uri = new Uri(URI);
            HttpResponseMessage response = await httpClient.GetAsync(uri);
            test = response.StatusCode;
            return response?.EnsureSuccessStatusCode();
        }
        //public async Task<Stream> DownloadFile()
        //{
        //    HttpResponseMessage response = await CheckDownloadFile();
        //    return await response.Content.ReadAsStreamAsync();
        //}
        public async Task DownloadFile()
        {
            HttpResponseMessage response = await CheckDownloadFile();
            Stream str = await response.Content.ReadAsStreamAsync();

            //using(FileStream fstream = F
        }



        public void DownloadOK()
        { }
        public void GiveTimeSpent()
        { }
        public void StateKeeper()
        { }
        public void CheckDownloadState()
        { }
    }
}
