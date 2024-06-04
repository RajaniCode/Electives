using System;
using System.Linq;
using System.Web.UI.HtmlControls;

namespace WebApplication1
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FetchMetaData();    
            }            
        }

        private void FetchMetaData()
        {
            using (var dc = new MetaDataDataContext())
            {
                var query = from page in dc.Pages
                            join meta in dc.MetaDatas on page.PageId equals meta.PageId
                            where page.PageName.ToLower() == Request.Url.AbsolutePath.ToLower()
                            select new
                            {
                                Key = meta.KeyName,
                                meta.Value
                            };

                foreach (var item in query)
                {
                    HtmlMeta meta = new HtmlMeta();                    
                    meta.Name = item.Key;
                    meta.Content = item.Value;
                    Page.Header.Controls.Add(meta); 
                }
            }
        }
    }
}
