using System;
using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            XElement xFeed = XElement.Load(@"http://feeds.feedburner.com/netCurryRecentArticles");

            IEnumerable<ArticlesList> items = from item in xFeed.Elements("channel").Elements("item")
                    select new ArticlesList
                    {
                        Title = item.Element("title").Value,
                        Link = item.Element("link").Value,
                        Description = item.Element("description").Value,
                        Author = item.Element("author").Value
                    };

            //store items in a session
            Session["feed"] = items;

            var authors = items.Select(p => p.Author).Distinct();

            DropDownList1.DataSource = authors;
            DropDownList1.DataBind();
            string selAuth = DropDownList1.SelectedValue;
            PopulateGrid(selAuth);
        }
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {        
        string selAuth = DropDownList1.SelectedValue;
        PopulateGrid(selAuth);       
    }

    protected void PopulateGrid(string author)
    {
        var items = (IEnumerable<ArticlesList>)Session["feed"];

        if (items != null)
        {
            var filteredList = from p in items
                               where p.Author == author
                               select p;

            GridView1.DataSource = filteredList;
            GridView1.DataBind();
        }
    }
}

public class ArticlesList
{
    public string Title { get; set; }
    public string Link { get; set; }
    public string Description { get; set; }
    public string Author { get; set; }
}
