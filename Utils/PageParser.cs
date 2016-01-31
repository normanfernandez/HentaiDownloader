using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using HentaiDownloader.Pages;

namespace HentaiDownloader.Utils
{
    public class PageParser
    {
        private const string HENTAI2READ = "http://hentai2read.com";
        private const string DOUJINMOE = "http://www.doujin-moe.us";

        public static string[] ParsePagesList(string hentaiUrl)
        {
            PageDataInterface pageData;
            string domain = new Uri(hentaiUrl).GetLeftPart(UriPartial.Authority);
            switch (domain)
            {
                case HENTAI2READ:
                    pageData = new Hentai2Read(hentaiUrl);
                    break;
                case DOUJINMOE:
                    pageData = new DoujinMoe(hentaiUrl);
                    break;
                default:
                    throw new Exception("Not a valid hentai page!");
            }

            return pageData.GetPagesList(); ;
        }

        public static string ParseDoujinName(string hentaiUrl)
        {
            PageDataInterface pageData;
            string domain = new Uri(hentaiUrl).GetLeftPart(UriPartial.Authority);
            switch (domain)
            {
                case HENTAI2READ:
                    pageData = new Hentai2Read(hentaiUrl);
                    break;
                case DOUJINMOE:
                    pageData = new DoujinMoe(hentaiUrl);
                    break;
                default:
                    throw new Exception("Not a valid hentai page!");
            }

            return pageData.GetDoujinName();
        }

        public static string ParsePageIndexName(int index, int listSize, string pageUrl)
        {
            string result = "";
            string extension = Path.GetExtension(pageUrl);
            int paramInit = extension.IndexOf("?");

            if (paramInit > 1)
            {
                extension = extension.Substring(0, paramInit);
            }

            result = (index.ToString("D" + listSize.ToString().Length)) + extension;

            return result;
        }
    }
}
