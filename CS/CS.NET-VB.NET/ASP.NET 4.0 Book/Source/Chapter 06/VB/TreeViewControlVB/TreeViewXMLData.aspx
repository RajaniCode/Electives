<%@ Page Language="VB" AutoEventWireup="false" CodeFile="TreeViewXMLData.aspx.vb" Inherits="TreeViewXMLData" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TreeView Control Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/Navigation.xml"></asp:XmlDataSource>
				<br />
				<asp:Label ID="Label2" runat="server" Text="TreeView generated from XMLDataSource"></asp:Label><br />
				<br />
				<asp:TreeView ID="TreeView2" runat="server" DataSourceID="XmlDataSource1">
				<DataBindings>
				<asp:TreeNodeBinding DataMember="homepage" TextField="title" NavigateUrlField="value"
				 ToolTipField="title" />
				<asp:TreeNodeBinding DataMember="subpage" TextField="title" ToolTipField="value"
				 NavigateUrlField="value" />
				</DataBindings>
				</asp:TreeView>

    </div>
    </form>
</body>
</html>
