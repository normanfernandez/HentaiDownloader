using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HentaiDownloader.Model;
using System.IO;
using System.Net;

namespace HentaiDownloader.Utils
{
    public class PageDownloader
    {
        public static void DownloadPage(DoujinPage page, string path) 
        {
            WebClient webClient = new WebClient();
            Uri url = new Uri(page.Url, UriKind.Absolute);
            webClient.DownloadFile(url, Path.Combine(path, page.Name));
        }
    }
}
