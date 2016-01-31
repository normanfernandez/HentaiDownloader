using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HentaiDownloader.Pages
{
    public class DoujinMoe : AbstractHentaiPage, PageDataInterface
    {
        public DoujinMoe(string hentaiUrl) : base(hentaiUrl) { }

        string PageDataInterface.GetDoujinName()
        {
            List<string> resultList = new List<string>();
            WebClient client = new WebClient();

            string result = client.DownloadString(hentaiUrl); //whole html code of the page
            string titleStart = "<div class=\"title\">";
            string titleEnd = "<div class=\"counter\">";
            int initialIndex = result.IndexOf(titleStart);
            
            result = result.Substring(initialIndex);

            int endIndex = result.IndexOf(titleEnd);

            result = result.Substring(0, endIndex); //By these part, the title must be parsed twice from <a> tag

            result = result.Replace("'", "");
            result = result.Replace(":", "");
            result = result.Replace("\\", "");
            result = result.Replace("*", "");
            result = result.Replace("?", "");
            result = result.Replace("|", "");
            result = result.Replace("\n", "");
            result = result.Replace("\t", "");

            result = result.Substring(result.IndexOf("<a href=\"") + "<a href=\"".Length);
            result = result.Substring(result.IndexOf("<a href=\"") + "<a href=\"".Length);
            result = result.Substring(result.IndexOf(">") + 1, result.IndexOf("</a>"));
            result = result.Replace("</a></div>", "");

            return result;
        }

        string[] PageDataInterface.GetPagesList()
        {
            List<string> resultList = new List<string>();
            WebClient client = new WebClient();

            string result = client.DownloadString(hentaiUrl); //whole html code of the page
            string collectionStart = "<div id=\"gallery\" nozip=\"\"";
            int initialIndex = result.IndexOf(collectionStart);
            result = result.Substring(initialIndex);

            int nameStart = result.IndexOf(">") + 1;
            result = result.Substring(nameStart, result.Length - nameStart - 1);
            int nameEnd = result.IndexOf("</div>");

            result = result.Substring(0, nameEnd);
            result = WebUtility.HtmlDecode(result);

            result = result.Replace("'", "");
            result = result.Replace("\\", "");
            result = result.Replace("*", "");
            result = result.Replace("|", "");
            result = result.Replace("\n", "");
            result = result.Replace("\t", "");
            result = result.Replace("</djm>", ",");
            string[] urlList = result.Split(",".ToCharArray());

            foreach (var url in urlList)
            {
                if (url.Equals(""))
                    continue;
                int urlStart = url.IndexOf("<djm file=\"") + "<djm file=\"".Length;
                string parsedUrl = url.Substring(urlStart);
                int urlEnd = parsedUrl.IndexOf("\"");
                parsedUrl = parsedUrl.Substring(0, urlEnd);
                resultList.Add(parsedUrl);
            }

            return resultList.ToArray();
            
        }
    }
}
