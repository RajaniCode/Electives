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
        string[] words = { "apple", "banana", "pineapple", "apricot", "papaya", "blueberry", "abascus", "cheery", "parrot", "black" };
		var GroupWords = from w in words
		group w by w[0] into g
		select new { FirstLetter = g.Key, Words = g };
		foreach (var g in GroupWords)
		{
			ListBox1.Items.Add("Words that starts from letter: "+g.FirstLetter.ToString());
			foreach (var w in g.Words)
			{
				ListBox1.Items.Add(w);
			}
		}

    }
}