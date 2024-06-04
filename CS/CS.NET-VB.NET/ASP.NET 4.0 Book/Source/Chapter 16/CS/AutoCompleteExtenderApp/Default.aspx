<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register
    Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit"
    TagPrefix="ajaxToolkit" %>
    <%@ Import Namespace="System.Web.Services" %>
      <%@ Import Namespace="System.Data" %>
        <%@ Import Namespace="System.Data.SqlClient" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script runat="server">
    [WebMethod]
	public static string[] GetCustList(string prefixText)
	{
		
		string con = 
 		ConfigurationManager.ConnectionStrings["NORTHWNDConnectionString"].ToString();
        string sql = "SELECT ProductName FROM Products where ProductName LIKE @prefixText";
		SqlDataAdapter ad = new SqlDataAdapter(sql,con);
		ad.SelectCommand.Parameters.Add("@prefixText", SqlDbType.VarChar, 50).Value = prefixText + "%";
		DataTable dt = new DataTable();
		ad.Fill(dt);
		string[] items = new string[dt.Rows.Count];
		int i = 0;        
		foreach (DataRow dr in dt.Rows)
		{
            items.SetValue(dr["ProductName"], i);
			i++;                      
		}
		return items;
	}    

    </script>
</head>
<body>
    <form id="form1" runat="server">
 
<ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
  
</ajaxToolkit:ToolkitScriptManager>
   
		<div>
		Enter the first letter of the product name and it will show you a list, showing 
		names of products starting with that letter. After this, select the product from 
		that list and press enter to auto complete the text in the textbox.<br />
		<br />
		<b><span class="style1">Enter         <asp:Label ID="Label1" runat="server" 
 		  Text="Product Name:"></asp:Label>        
		</span>        
		<br class="style1" />
		</b>        
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
		&nbsp;&nbsp;&nbsp;&nbsp;
		<ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="TextBox1"  ServiceMethod="GetCustList" MinimumPrefixLength="1" CompletionSetCount="10" Enabled="true" EnableCaching="true" >
		</ajaxToolkit:AutoCompleteExtender>
		<asp:Button ID="Button1" runat="server" Text="Go" onclick="Button1_Click" />
		<br />
		<br /><br />
		<asp:Label ID="Label2" runat="server"></asp:Label>

    </div>
    </form>
</body>
</html>
