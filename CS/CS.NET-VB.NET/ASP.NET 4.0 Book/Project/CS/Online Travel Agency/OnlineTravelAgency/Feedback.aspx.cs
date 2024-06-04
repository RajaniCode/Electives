using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class Feedback : System.Web.UI.Page
{DataTable dt=new DataTable ();
SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString.ToString());
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindfeedback();
        }
    }
    public void bindfeedback()
    {
        SqlDataAdapter dabind = new SqlDataAdapter("Select * from Feedback", conn);
        dabind.Fill(dt);
        dabind.Update(dt);
        dlFeedback.DataSource = dt;
        dlFeedback.DataBind();
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string strmsg;
        strmsg = editor.Content;
        DataSet ds = new DataSet();     
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString.ToString());

        SqlCommand savefeedback = new SqlCommand("Insert into Feedback values('" + txtName.Text + "', '" + txtEMail.Text + "','" + strmsg + "')", conn);

        if (conn.State == ConnectionState.Closed)
        {
            conn.Open();
        }
        savefeedback.ExecuteNonQuery();
        if (conn.State == ConnectionState.Open)
        {
            conn.Close();
        }
        bindfeedback();
        txtName.Text = "";
        txtEMail.Text = "";
        editor.Content = "";
    }
   
}
