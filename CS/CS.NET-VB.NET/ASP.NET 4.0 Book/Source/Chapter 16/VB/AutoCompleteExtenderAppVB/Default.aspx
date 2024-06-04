<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

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
       <script runat="server"  language="VB">
           <WebMethod()> _
           <System.Web.Script.Services.ScriptMethod()> _
           Public Shared Function GetCustList(ByVal prefixText As String) As String()
               Dim con As String = System.Configuration.ConfigurationManager.ConnectionStrings("northwndConnectionString").ToString()
               Dim sqlc As String
               sqlc = "SELECT ProductName FROM Products where ProductName LIKE " & "@prefixText"
               Dim ad As New SqlDataAdapter(sqlc, con)
               ad.SelectCommand.Parameters.Add("@prefixText", SqlDbType.VarChar, 50).Value = prefixText + "%"
               Dim dt As New DataTable()
               ad.Fill(dt)
               Dim items As String() = New String(dt.Rows.Count - 1) {}
               Dim i As Integer = 0
               For Each dr As DataRow In dt.Rows
                   items.SetValue(dr("ProductName"), i)
                   i += 1
               Next
               Return items
           End Function
   </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </ajaxToolkit:ToolkitScriptManager>
        Enter the first letter of the product name and it will show you a list, showing 
		names of products starting with that letter. After this, select the product from 
		that list and press enter to auto complete the text in the textbox.<br />
		<br />
		<b><span class="style1">Enter <asp:Label ID="Label1" runat="server" 
 		  Text="Product Name:"></asp:Label>        
		</span>        
		<br class="style1" />
		</b>        
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
		&nbsp;&nbsp;&nbsp;&nbsp;
		<ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="TextBox1" ServiceMethod="GetCustList" MinimumPrefixLength="1" CompletionSetCount="10" Enabled="true" EnableCaching="true" >
		</ajaxToolkit:AutoCompleteExtender>
		<asp:Button ID="Button1" runat="server" Text="Go" onclick="Button1_Click" />
		<br />
		<br /><br />
		<asp:Label ID="Label2" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
