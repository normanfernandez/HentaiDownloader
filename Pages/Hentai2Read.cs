using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HentaiDownloader.Pages
{
    public class Hentai2Read : AbstractHentaiPage, PageDataInterface
    {
        public Hentai2Read(string hentaiUrl) : base(hentaiUrl) { }

        string PageDataInterface.GetDoujinName()
        {
            WebClient client = new WebClient();
            string result = client.DownloadString(hentaiUrl); //whole html code of the page

            string collectionStart = "<span itemprop=\"itemreviewed\">";
            int initialIndex = result.IndexOf(collectionStart);
            result = result.Substring(initialIndex, result.Length - initialIndex);
            int nameStart = result.IndexOf(">") + 1;
            result = result.Substring(nameStart, result.Length - nameStart - 1);
            int nameEnd = result.IndexOf("<");
            result = result.Substring(0, nameEnd);
            result = WebUtility.HtmlDecode(result);
            result = result.Replace("'", "");
            result = result.Replace(":", "");
            result = result.Replace("\\", "");
            result = result.Replace("*", "");
            result = result.Replace("?", "");
            result = result.Replace("|", "");

            return result;
        }

        string[] PageDataInterface.GetPagesList()
        {
            string baseUrl = "http://hentaicdn.com/hentai";
            List<string> resultList = new List<string>(); 
            WebClient client = new WebClient();

            string url = client.DownloadString(hentaiUrl); //whole html code of the page
            string jsVariable = "var rff_imageList = ";
            int variableIndex = url.IndexOf(jsVariable);
            if (variableIndex == -1)
                throw new Exception("Not valid hentai page!");
            url = url.Substring(variableIndex, url.Length - variableIndex);
            int arrayTerminator = url.IndexOf("]");
            int arrayInitiator = url.IndexOf("[") + 1;
            url = url.Substring(0, arrayTerminator);
            url = url.Substring(arrayInitiator, url.Length - arrayInitiator - 1);
            string[] urlList = url.Split(',');
            foreach (var str in urlList)
            {
                string parsedUrl = str;
                parsedUrl = parsedUrl.Replace("\\", "");
                parsedUrl = parsedUrl.Replace("\"", "");
                parsedUrl = parsedUrl.Replace("\\", "");
                parsedUrl = parsedUrl.Replace("*", "");
                parsedUrl = parsedUrl.Replace("?", "");
                parsedUrl = parsedUrl.Replace("|", "");
                var result = baseUrl + parsedUrl;
                resultList.Add(result);
            }

            return resultList.ToArray();
        }
    }
}
