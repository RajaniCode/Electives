using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NewPublisherModel;

public partial class _Default : System.Web.UI.Page
{
    private NewPublisherEntities2 PublisherContext;

    protected void Page_Load(object sender, EventArgs e)
    {
        PublisherContext = new NewPublisherEntities2();
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Int32 AuthorID = Convert.ToInt32(DropDownList1.SelectedValue);
        var BookDetails = from bookD in PublisherContext.Books
                          where bookD.Author.AuthorID == AuthorID
                          select new
                          {
                              BookName = bookD.Title,
                              Pages = bookD.Pages,
                              ISBN = bookD.BookISBN
                          };
        GridView1.DataSource = BookDetails;
        GridView1.DataBind();
    }
}