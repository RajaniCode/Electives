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
        string[] text = new string[] { "Hello everybody", "this is an", "example on using", "select many operator", "with linq." };
		IEnumerable<string[]> words = text.Select(w => w.Split(' '));
		foreach (string[] segment in words)
			foreach (string word in segment)
				ListBox1.Items.Add(word);

    }
}