using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace HentaiDownloader.Utils
{
    public class PageParser
    {
        public static string [] ParsePagesList(string hentaiUrl)
        {
            List<string> resultList = new List<string>();

            WebClient client = new WebClient();
            string url = client.DownloadString(hentaiUrl);
            string jsVariable = "wpm_mng_rdr_img_lst";
            int variableIndex = url.IndexOf(jsVariable);
            if (variableIndex == -1)
                throw new Exception("Not valid hentai page!");
            url = url.Substring(variableIndex, url.Length - variableIndex);
            int arrayTerminator = url.IndexOf("]");
            int arrayInitiator = url.IndexOf("[") + 1;
            url = url.Substring(0, arrayTerminator);
            url = url.Substring(arrayInitiator, url.Length - arrayInitiator - 1);
            string [] urlList = url.Split(',');
            foreach (var str in urlList)
            {
                string parsedUrl = str;
                parsedUrl = parsedUrl.Replace("\\","");
                parsedUrl = parsedUrl.Replace("\"", "");
                parsedUrl = parsedUrl.Replace("\\", "");
                parsedUrl = parsedUrl.Replace("*", "");
                parsedUrl = parsedUrl.Replace("?", "");
                parsedUrl = parsedUrl.Replace("|", "");
                resultList.Add(parsedUrl);
            }
            return resultList.ToArray();
        }

        public static string ParseDoujinName(string hentaiUrl) 
        {
            WebClient client = new WebClient();
            string result = client.DownloadString(hentaiUrl);
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
    }
}
