using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HentaiDownloader.Model;
using System.IO;
using System.Net;

namespace HentaiDownloader.Utils
{
    public class PageDownloader
    {
        public static WebClient webClient = new WebClient();
        public static string CurrentPage = null;
        public static event EventHandler OnDoujinDownloadFinished = delegate { };

        public async static void DownloadDoujin(Doujin doujin)
        {
            List<DoujinPage> pages = doujin.PageList;
            webClient.DownloadFileCompleted += (s, e) =>
            {
                webClient.Dispose();
            };
            try
            {
                foreach (var p in pages)
                {
                    CurrentPage = p.Name;
                    Uri url = new Uri(p.Url, UriKind.Absolute);
                    await webClient.DownloadFileTaskAsync(url, Path.Combine(doujin.DownloadPath, p.Name));
                }
                CurrentPage = null;
                DownloadFinished();
            }
            catch (Exception e)
            {
                e.ToString();
            }
        }

        private static void DownloadFinished()
        {
            OnDoujinDownloadFinished(null, EventArgs.Empty);
        }
        
    }
}
