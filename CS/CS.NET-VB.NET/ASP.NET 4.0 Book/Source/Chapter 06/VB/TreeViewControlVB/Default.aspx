<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TreeView Control Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Static TreeView" Font-Bold="true" Font-Size="Medium"></asp:Label>
        <asp:TreeView ID="TreeView1" runat="server">
            <Nodes>
                <asp:TreeNode Text="Navigate" Value="Navigate">
                    <asp:TreeNode Text="Simple TreeView" Value="Simple TreeView" NavigateUrl="~/SimpleTreeView.aspx"></asp:TreeNode>
                    <asp:TreeNode Text="TreeView from Database" Value="TreeView from Database" NavigateUrl="~/TreeViewDatabase.aspx">
                    </asp:TreeNode>
                    <asp:TreeNode Text="TreeView with XmlDataSource" 
                        Value="TreeView with XmlDataSource" NavigateUrl="~/TreeViewXMLData.aspx"></asp:TreeNode>
                    <asp:TreeNode Text="TreeView with SiteMapDataSource" 
                        Value="TreeView with SiteMapDataSource" NavigateUrl="~/TreeViewSiteMapDataSource.aspx"></asp:TreeNode>
                </asp:TreeNode>
            </Nodes>
        </asp:TreeView>
    
    </div>
    </form>
</body>
</html>
