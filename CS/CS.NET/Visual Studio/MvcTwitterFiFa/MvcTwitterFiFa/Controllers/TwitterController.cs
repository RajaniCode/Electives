using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Xml.Linq;

namespace MvcApplication1.Controllers
{
    public class TwitterController : Controller
    {
        public ActionResult Index()
        {
            var request = WebRequest.Create("http://search.twitter.com/search.atom?q=worldcup&rpp=5") as HttpWebRequest;
            var twitterViewData = new List<TwitterViewData>();

            if (request != null)
            {
                using (var response = request.GetResponse() as HttpWebResponse)
                {
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        var document = XDocument.Parse(reader.ReadToEnd());
                        XNamespace xmlns = "http://www.w3.org/2005/Atom";

                        twitterViewData = (from entry in document.Descendants(xmlns + "entry")
                                    select new TwitterViewData
                                    {
                                        Content = entry.Element(xmlns + "content").Value,
                                        Updated = entry.Element(xmlns + "updated").Value,
                                        AuthorName = entry.Element(xmlns + "author").Element(xmlns + "name").Value,
                                        AuthorUri = entry.Element(xmlns + "author").Element(xmlns + "uri").Value,
                                        Link = (from o in entry.Descendants(xmlns + "link")
                                                where o.Attribute("rel").Value == "image"
                                                select new { Val = o.Attribute("href").Value }).First().Val
                                    }).ToList();
                    }
                }
            }
            return View(twitterViewData);
        }
    }
}
