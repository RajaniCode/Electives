<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </ajaxToolkit:ToolkitScriptManager>
   		<br />
		Click on the listbox and type the search string using keyboard to search for 
		particular list item.<br />
	-------------------------------------------------------------<div>        
		<br />
		<asp:ListBox ID="ListBox1" runat="server" Width="128px" 
 		  DataSourceID="SqlDataSource1" DataTextField="ProductName" 
                DataValueField="ProductName" Height="244px">
		</asp:ListBox>
		<ajaxToolkit:ListSearchExtender ID="ListSearchExtender1" runat="server" 
 		  TargetControlID="ListBox1" PromptText="Type to search" PromptPosition="Top">            
		</ajaxToolkit:ListSearchExtender>         </div>
    </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:northwndConnectionString %>" 
        SelectCommand="SELECT [ProductName] FROM [Alphabetical list of products]"></asp:SqlDataSource>
    </form>
</body>
</html>
