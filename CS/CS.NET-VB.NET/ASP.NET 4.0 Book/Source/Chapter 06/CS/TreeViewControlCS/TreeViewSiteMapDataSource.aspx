<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TreeViewSiteMapDataSource.aspx.cs" Inherits="TreeViewSiteMapDataSource" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TreeView Control Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Label ID="Label2" runat="server" Text="TreeView generated from SiteMapDataSource"></asp:Label><br />
				<br />
				<asp:SiteMapDataSource ID="SiteMapSource1" runat="server" />
				<asp:TreeView ID="TreeView2" DataSourceID="SiteMapSource1" runat="server">
				<DataBindings>
				<asp:TreeNodeBinding TextField="Title" NavigateUrlField="Url" />
				</DataBindings>
				</asp:TreeView>

    </div>
    </form>
</body>
</html>
