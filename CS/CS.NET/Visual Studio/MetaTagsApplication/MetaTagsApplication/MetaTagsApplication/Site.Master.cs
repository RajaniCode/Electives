using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;

namespace MetaTagsApplication
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {   
            XDocument doc = XDocument.Load(Server.MapPath("~/TagData.xml"));
            var metaTags = doc.Descendants("tag")
                           .Where(o => o.Parent.Attribute("pageName").Value == Request.Url.AbsolutePath)
                           .Select(o => new
                           {
                               Value = o.Attribute("value").Value,
                               Name = o.Attribute("name").Value
                           });

            foreach (var item in metaTags)
	        {                
                HtmlMeta meta = new HtmlMeta();
                meta.Name = item.Name;
                meta.Content = item.Value;
                Page.Header.Controls.Add(meta); 
	        }
        }
    }
}
