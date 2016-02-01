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

        public readonly string Name;
        public string DownloadPath;
        public readonly List<DoujinPage> PageList = new List<DoujinPage>();

        public void AddPage(DoujinPage page) 
        {
            this.PageList.Add(page);
        }
    }
}
