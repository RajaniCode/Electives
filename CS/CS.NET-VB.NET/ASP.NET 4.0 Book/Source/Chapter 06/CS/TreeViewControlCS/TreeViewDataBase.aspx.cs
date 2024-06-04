using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;


public partial class TreeViewDataBase : System.Web.UI.Page
{
    public void GetCategories(TreeNode node)
    {
        SqlCommand sqlQuery = new SqlCommand("Select CategoryName, CategoryID From Categories");
        DataSet ResultSet = null;
        ResultSet = PopulateDataFunction(sqlQuery);
        if (ResultSet.Tables.Count > 0)
        {

            foreach (DataRow row in ResultSet.Tables[0].Rows)
            {
                TreeNode NewNode = new TreeNode(row["CategoryName"].ToString(), row["CategoryID"].ToString());
                NewNode.PopulateOnDemand = true;
                NewNode.SelectAction = TreeNodeSelectAction.Expand;
                node.ChildNodes.Add(NewNode);
            }
        }
    }
    public void GetProducts(TreeNode node)
    {
        SqlCommand sqlQuery = new SqlCommand();
        sqlQuery.CommandText = "Select ProductName From Products Where CategoryID = @categoryid";
        sqlQuery.Parameters.Add("@categoryid", SqlDbType.Int).Value = node.Value;
        DataSet ResultSet = PopulateDataFunction(sqlQuery);
        if (ResultSet.Tables.Count > 0)
        {

            foreach (DataRow row in ResultSet.Tables[0].Rows)
            {
                TreeNode NewNode = new TreeNode(row["ProductName"].ToString());
                NewNode.PopulateOnDemand = false;
                NewNode.SelectAction = TreeNodeSelectAction.None;
                node.ChildNodes.Add(NewNode);
            }
        }
    }
    public DataSet PopulateDataFunction(SqlCommand sqlQuery)
    {
       SqlConnection dbConnection = new SqlConnection("Data Source=AVANTIKA-PC\\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True");
        SqlDataAdapter dbAdapter = new SqlDataAdapter();
        dbAdapter.SelectCommand = sqlQuery;
        sqlQuery.Connection = dbConnection;
        DataSet resultsDataSet = new DataSet();
        try
        {
            dbAdapter.Fill(resultsDataSet);
        }
        catch (Exception ex)
        {
        }
        return resultsDataSet;
    }

    
    protected void Page_Load(object sender, EventArgs e)
    {
        TreeView2.ExpandDepth = 1;
    }
    protected void TreeView2_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {
        if (e.Node.ChildNodes.Count == 0)
        {
            switch (e.Node.Depth)
            {
                case 0:
                    GetCategories(e.Node);
                    break;
                case 1:
                    GetProducts(e.Node);
                    break;
            }
        }
    }
}