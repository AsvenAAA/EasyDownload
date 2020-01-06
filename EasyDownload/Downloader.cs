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
        public string URI { get; set; } = @"https://1.eu.dl.wireshark.org/win64/Wireshark-win64-3.0.7.exe";

        public string PathToTheFile { get; set; } = @"C:\Wireshark-win64-3.0.7.exe";

        public long totalRead { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string DownloadState { get; set; }

        public long FileSize { get; set; }

        public async Task<HttpResponseMessage> CheckDownloadFile()
        {
            HttpClient httpClient = new HttpClient();
            Uri uri = new Uri(URI);
            HttpResponseMessage response = await httpClient.GetAsync(uri);
           // HttpResponseMessage response = new HttpResponseMessage();
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

            using (HttpClient client = new HttpClient())
            {
                Uri uri = new Uri(URI);
                HttpResponseMessage response = await client.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead);
                var fileSize = response.Content.Headers.ContentLength;
                //using (FileStream fileSave = File.Create(PathToTheFile))
                //{
                //    await response.Content.CopyToAsync(fileSave);
                //    fileSave.Close();
                //    fileSave.Dispose();

                //****************************************************************************************************************
                //С помощью FileMode.Append и FileAccess.Write можно дозависывать в файл, но он просто
                //скачивает все заного, добавляя к существующему
                using (Stream contentStream = await response.Content.ReadAsStreamAsync(),
                       fileSave = new FileStream(PathToTheFile, FileMode.Create, FileAccess.ReadWrite,
                                                 FileShare.ReadWrite, 1048576, true))
                {
                    //Глянуть LoadIntoBufferAsync(Int64)
                    //await response.Content.CopyToAsync(await fileSave.WriteAsync(, bytePointer, test));
                    //byte[] buffer = new byte[4096];
                    //int bytePointer = 0;
                    //int test = (int)fileSize;
                    //int step = 16384;
                    //while (bytePointer < test && test - bytePointer != 0)
                    //{
                    //    await fileSave.WriteAsync(response.Content.ReadAsByteArrayAsync().Result, bytePointer, test);
                    //    bytePointer += step;
                    //    if (test - bytePointer < step)
                    //    {
                    //        step = test - bytePointer;
                    //    }
                    //}


                    long totalRead = 0L;
                    long currentReads = 0L;
                    byte[] buffer = new byte[1048576];
                    var isMoreToRead = true;

                    do
                    {
                        var read = await contentStream.ReadAsync(buffer, 0, buffer.Length);
                        if (read == 0)
                        {
                            isMoreToRead = false;
                        }
                        else
                        {
                            await fileSave.WriteAsync(buffer, 0, read);

                            totalRead += read;
                            currentReads += 1;

                            if (currentReads % 2000 == 0)
                            {
                                Console.WriteLine(string.Format("Download progress: {0}", totalRead));
                            }
                        }
                    }
                    while (isMoreToRead);
                    fileSave.Close();
                    fileSave.Dispose();
                    //}
                    Console.WriteLine("{0} byte download", fileSize);
                }
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