<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ Register Assembly="AjaxControlToolkit"    Namespace="AjaxControlToolkit"    TagPrefix="ajaxToolkit" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.SqlClient" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </ajaxToolkit:ToolkitScriptManager>
        <h3>Enter the first letter of the Productname</h3><br /><br />
        <ajaxToolkit:ComboBox ID="ComboBox1"  runat="server" AutoCompleteMode="Suggest" 
            DataSourceID="SqlDataSource1" DataTextField="ProductName" 
            DataValueField="ProductName" MaxLength="0" style="display: inline;">
        </ajaxToolkit:ComboBox>
    </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:northwndConnectionString %>" 
        SelectCommand="SELECT [ProductName] FROM [Alphabetical list of products]">
    </asp:SqlDataSource>

    </form>
</body>
</html>
