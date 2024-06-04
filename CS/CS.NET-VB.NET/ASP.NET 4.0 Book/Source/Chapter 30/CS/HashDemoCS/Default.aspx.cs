using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;

public partial class _Default : System.Web.UI.Page
{
    byte[] hashValue, MessageBytes;
    string StringtoConvert;
    UnicodeEncoding MyUniCodeEncoding;

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Btnsha1_Click(object sender, EventArgs e)
    {
        TextBox2.Text = "";
        StringtoConvert = TextBox1.Text;
        MyUniCodeEncoding = new UnicodeEncoding();
        MessageBytes = MyUniCodeEncoding.GetBytes(StringtoConvert);
        SHA1Managed SHhash = new SHA1Managed();
        hashValue = SHhash.ComputeHash(MessageBytes);
        foreach (byte b in hashValue)
        {
            TextBox2.Text = TextBox2.Text + string.Format("{0:X2}", b);
        }

    }
    protected void btnsh256_Click(object sender, EventArgs e)
    {
        
        StringtoConvert = TextBox1.Text;
        MyUniCodeEncoding = new UnicodeEncoding();
        MessageBytes = MyUniCodeEncoding.GetBytes(StringtoConvert);
        SHA256Managed SHhash = new SHA256Managed();
        hashValue = SHhash.ComputeHash(MessageBytes);
        foreach (byte b in hashValue)
        {
            TextBox3.Text = TextBox3.Text + string.Format("{0:X2}", b);
        }

    }
    protected void Btnsh384_Click(object sender, EventArgs e)
    {
        
        StringtoConvert = TextBox1.Text;
        MyUniCodeEncoding = new UnicodeEncoding();
        MessageBytes = MyUniCodeEncoding.GetBytes(StringtoConvert);
        SHA384Managed SHhash = new SHA384Managed();
        hashValue = SHhash.ComputeHash(MessageBytes);
        foreach (byte b in hashValue)
        {
            TextBox4.Text = TextBox4.Text + string.Format("{0:X2}", b);
        }


    }
    protected void BTN512_Click(object sender, EventArgs e)
    {
     
        StringtoConvert = TextBox1.Text;
        MyUniCodeEncoding = new UnicodeEncoding();
        MessageBytes = MyUniCodeEncoding.GetBytes(StringtoConvert);
        SHA512Managed SHhash = new SHA512Managed();
        hashValue = SHhash.ComputeHash(MessageBytes);
        foreach (byte b in hashValue)
        {
            TextBox5.Text = TextBox5.Text + string.Format("{0:X2}", b);
        }

    }

    
}