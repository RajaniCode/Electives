<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
    <h3>Click on the required letter and see the items associated with it</h3><br />
	----------------------------------------------------------------------------<div>
		<asp:BulletedList ID="BulletedList1" runat="server" 
            DataSourceID="SqlDataSource1" DataTextField="ProductName" 
            DataValueField="ProductName">
		</asp:BulletedList>
		
		<ajaxToolkit:PagingBulletedListExtender ID="PagingBulletedListExtender1" runat="server" 
 		  TargetControlID="BulletedList1" ClientSort="true" IndexSize="1" Separator="-">
		</ajaxToolkit:PagingBulletedListExtender>

    </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:northwndConnectionString %>" 
        SelectCommand="SELECT [ProductName] FROM [Alphabetical list of products]">
    </asp:SqlDataSource>
    </form>
</body>
</html>
