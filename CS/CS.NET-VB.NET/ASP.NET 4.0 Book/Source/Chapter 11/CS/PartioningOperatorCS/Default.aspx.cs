using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string[] presidents = {"Adams", "Arthur", "Buchanan", "Bush", "Carter",
		 "Cleveland", "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford",
		 "Grafiled", "Grant", "Harrison", "Hoover", "Lincoln", "Washington", 
		 "Wilson", "Tyler", "Polk", "Nixon", "Truman"};
        int PageSize = 5;
        int numberPages = (int)Math.Ceiling(presidents.Count() / (double)PageSize);
        for (int page = 0; page < numberPages; page++)
        {
            ListBox1.Items.Add("Page " + page + ":");
            var names = (from p in presidents
                         orderby p descending
                         select p).Skip(page * PageSize).Take(PageSize);
            foreach (var name in names)
            {
                ListBox1.Items.Add(name);
            }
        }

    }
}