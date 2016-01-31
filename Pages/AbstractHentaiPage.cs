using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HentaiDownloader.Pages
{
    public abstract class AbstractHentaiPage
    {
        protected string hentaiUrl;

        public AbstractHentaiPage(string hentaiUrl)
        {
            this.hentaiUrl = hentaiUrl;
        }
    }
}
