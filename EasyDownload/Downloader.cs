using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Net;

namespace EasyDownload
{
    class Downloader : IDownload
    {
        public string URI { get; set; } = @"https://mirror.yandex.ru/centos/8.0.1905/isos/x86_64/CentOS-8-x86_64-1905-boot.iso";

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string DownloadState { get; set; }

        public async Task<HttpResponseMessage> CheckDownloadFile()
        {
            //HttpClient httpClient = new HttpClient();
            //Uri uri = new Uri(URI);
            //HttpResponseMessage response = await httpClient.GetAsync(uri);
            HttpResponseMessage response = new HttpResponseMessage();
            return response?.EnsureSuccessStatusCode();

 
        }

        public async Task DownloadFile()
        {
            //WebClient is obsolete sincd 2012 and the two snippets are doing different things. 
            //You can use HttpClient.GetStreamAsync to get a stream to the file in one line and 
            //then use .CopyToAsync() to copy the stream's contents to a file stream 
            //https://stackoverflow.com/questions/45711428/download-file-with-webclient-or-httpclient

            //HttpResponseMessage response = await CheckDownloadFile();
            //HttpResponseMessage response = new HttpResponseMessage();
            //Stream content = await response.Content.ReadAsStreamAsync();

            //var test = new FileStream(@"C:\CentOS-8-x86_64-1905-boot.iso", FileMode.CreateNew);

            //Uri uri = new Uri(URI);
            //WebClient download = new WebClient();
            //download.DownloadFileAsync(uri, @"C:\Users\Asven\Desktop\CentOS-8-x86_64-1905-boot.iso");

            HttpClient client = new HttpClient();
            Uri uri = new Uri(URI);
            HttpResponseMessage response = await client.GetAsync(uri);
            using (FileStream fileSave = File.Create(@"C:\Users\Asven\Desktop\CentOS-8-x86_64-1905-boot.iso"))
            {
                await response.Content.CopyToAsync(fileSave);
                fileSave.Close();
            }
        }

        public async Task Test()
        {
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Head, URI);
            await client.SendAsync(request);

            //Console.WriteLine(request.Content.Headers);
        }

        public void DownloadOK()
        {}

        public void GiveTimeSpent()
        {}

        public void StateKeeper()
        {}

        public void CheckDownloadState()
        {}
    }
}