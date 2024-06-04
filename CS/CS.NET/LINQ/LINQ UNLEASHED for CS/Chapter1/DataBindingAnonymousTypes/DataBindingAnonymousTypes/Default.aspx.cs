using System;
using System.Data;
using System.Diagnostics;
using System.Configuration;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Web.Services ; 
using System.Net; 
using System.IO; 
using System.Text; 

namespace DataBindingAnonymousTypes
{
  public partial class _Default : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      Update();
    }

    private void Update()
    {
      var quote1 = new {Stock="DELL", Quote=GetQuote("DELL")};
      var quote2 = new {Stock="MSFT", Quote=GetQuote("MSFT")};
      var quote3 = new {Stock="GOOG", Quote=GetQuote("GOOG")};

      var quotes = new object[]{ quote1, quote2, quote3 };
      DataList1.DataSource = quotes;
      DataList1.DataBind();
      Label3.Text = DateTime.Now.ToLongTimeString();
    }

    protected void Timer1_Tick(object sender, EventArgs e)
    {
        //Update();
    }
  

    public string GetQuote(string stock)
    {
      try
      {
        return InnerGetQuote(stock);
      }
      catch(Exception ex)
      {
        Debug.WriteLine(ex.Message);
        return "N/A";
      }
    }

    private string InnerGetQuote(string stock)
	  {
		  string url = @"http://quote.yahoo.com/d/quotes.csv?s={0}&f=pc";
	    var request = HttpWebRequest.Create(string.Format(url, stock));
        
        using(var response = request.GetResponse())
        {
          using(var reader = new StreamReader(response.GetResponseStream(), 
            Encoding.ASCII))
          {
            return reader.ReadToEnd();
          }
        }
    }
  }
}
	