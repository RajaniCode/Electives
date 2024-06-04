using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;


public partial class _Default : System.Web.UI.Page
{
    string SQLiteQuery = "SELECT WellheadID, WellheadName FROM Wellhead;";
    
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            int Index = 0;

            DatabaseConnection ConnectionDatabase = new DatabaseConnection();

            DataSet DatSet = ConnectionDatabase.GetDataSet(SQLiteQuery);

            DataRow drow = DatSet.Tables[0].Rows[Index];
            
            BindData(drow);

            ButtonPrevious.Visible = false;
        }
        catch (Exception ex)
        {
            string Error = ex.ToString();
        }
    }

    public void BindData(DataRow drow)
    {
        try
        {
            TextBox1.Text = drow["WellheadID"].ToString();
            TextBox2.Text = drow["WellheadName"].ToString(); 
        }
        catch (Exception ex)
        {
            string Error = ex.ToString();
        }
    }

    protected void ButtonPrevious_Click(object sender, EventArgs e)
    {
        try
        {
            int Index = 0;

            if (ViewState["index"] != null)
            {
                Index = (int)ViewState["index"];
            }

            ButtonNext.Visible = true;

            DatabaseConnection ConnectionDatabase = new DatabaseConnection();

            DataSet DatSet = ConnectionDatabase.GetDataSet(SQLiteQuery);

            if ((Index > 0) && (Index <= DatSet.Tables[0].Rows.Count - 1))
            {

                Index = Index - 1;

                DataRow drow = DatSet.Tables[0].Rows[Index];

                BindData(drow);

                if (Index == 0)
                {
                    ButtonPrevious.Visible = false;
                    ButtonNext.Visible = true;
                }
                else
                {
                    ButtonPrevious.Visible = true;
                }
            }

            ViewState["index"] = Index;
        }
        catch (Exception ex)
        {
            string Error = ex.ToString();
        }
    }

    protected void ButtonNext_Click(object sender, EventArgs e)
    {
        try
        {
            int Index = 0;

            if (ViewState["index"] != null)
            {
                Index = (int)ViewState["index"];
            }

            ButtonPrevious.Visible = true;

            DatabaseConnection ConnectionDatabase = new DatabaseConnection();

            DataSet DatSet = ConnectionDatabase.GetDataSet(SQLiteQuery);

            if ((Index >= 0) && (Index < DatSet.Tables[0].Rows.Count - 1))
            {
                Index = Index + 1;

                DataRow drow = DatSet.Tables[0].Rows[Index];

                BindData(drow);

                if (Index > 0 && Index == DatSet.Tables[0].Rows.Count - 1)
                {
                    ButtonNext.Visible = false;
                }

            }
            ViewState["index"] = Index;  
        }
        catch (Exception ex)
        {
            string Error = ex.ToString();
        }                   
    }
}

