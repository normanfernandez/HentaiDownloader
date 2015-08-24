using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace HentaiDownloader.Model
{
    public class DoujinPage
    {
        public DoujinPage(string name, string url) 
        {
            this.Name = name;
            this.Url = url;
        }

        public string Name;
        public string Url;
    }
}
