using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;

using HentaiDownloader.Utils;

namespace HentaiDownloader.Model
{
    public class Doujin
    {
        public Doujin(string name) 
        {
            Name = name;
        }

        public string Name;
        public string DownloadPath;

        private int PagesTotal;
        private List<DoujinPage> PageList = new List<DoujinPage>();

        public void DownloadAll()
        {
            foreach(var page in PageList)
            {
                PageDownloader.DownloadPage(page,DownloadPath + "\\" + Name);
            }
        }

        public void AddPage(DoujinPage page) 
        {
            this.PageList.Add(page);
        }
    }
}
