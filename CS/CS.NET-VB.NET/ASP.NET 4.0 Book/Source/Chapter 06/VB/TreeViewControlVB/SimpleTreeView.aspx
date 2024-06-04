<%@ Page Language="VB" AutoEventWireup="false" CodeFile="SimpleTreeView.aspx.vb" Inherits="SimpleTreeView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TreeView Control Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="Example of a Simple TreeView Control" Font-Bold="true" Font-Size="Medium"></asp:Label>
    
    <asp:Table ID="Table1" runat="server" Height="91px" Width="594px">
			<asp:TableRow ID="TableRow1" runat="server">
			<asp:TableCell ID="TableCell1" runat="server">
			<asp:TreeView ID="TreeView2" runat="server" ImageSet="Arrows">
			<Nodes>
			<asp:TreeNode Text="Root Node 1" Value="Root Node 1">
			<asp:TreeNode Text="Leaf Node" 	Value="Leaf Node"></asp:TreeNode>
			<asp:TreeNode Text="Leaf Node" Value="Leaf Node"></asp:TreeNode>
			</asp:TreeNode>
			<asp:TreeNode Text="Root Node 2"  Value="Root Node 2"></asp:TreeNode>
			</Nodes>
			<ParentNodeStyle Font-Bold="False" />
			<HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
			<SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" HorizontalPadding="0px"
			 VerticalPadding="0px" />
			<NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
			 NodeSpacing="0px" VerticalPadding="0px" />
			</asp:TreeView>
			</asp:TableCell>
			<asp:TableCell ID="TableCell2" runat="server">
			<asp:TreeView ID="TreeView3" runat="server" ImageSet="News" NodeIndent="10">
			<ParentNodeStyle Font-Bold="False" />
			<HoverNodeStyle Font-Underline="True" />
			<SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px"  VerticalPadding="0px" />
			<Nodes>
			<asp:TreeNode Text="Root Node 1" Value="Root Node 1">
			<asp:TreeNode Text="Leaf Node" Value="Leaf Node"></asp:TreeNode>
			<asp:TreeNode Text="Leaf Node" Value="Leaf Node"></asp:TreeNode>
			</asp:TreeNode>
			<asp:TreeNode Text="Root Node 2" Value="Root Node 2"></asp:TreeNode>
			</Nodes>
			<NodeStyle Font-Names="Arial" Font-Size="10pt" ForeColor="Black" HorizontalPadding="5px"
			 NodeSpacing="0px" VerticalPadding="0px"/>
			</asp:TreeView>
			</asp:TableCell>
			<asp:TableCell ID="TableCell3" runat="server">
			<asp:TreeView ID="TreeView4" runat="server" ShowCheckBoxes="All" ShowLines="True">
			<Nodes>
			<asp:TreeNode Text="Root Node 1" Value="Root Node 1">
			<asp:TreeNode Text="Leaf Node" Value="Leaf Node"></asp:TreeNode>
			<asp:TreeNode Text="Leaf Node" Value="Leaf Node"></asp:TreeNode>
			</asp:TreeNode>
			<asp:TreeNode Text="Root Node 2" Value="Root Node 2"></asp:TreeNode>
			</Nodes>
			</asp:TreeView>
			</asp:TableCell>
			</asp:TableRow>
			<asp:TableRow ID="TableRow2" runat="server">
			<asp:TableCell ID="TableCell4" runat="server">
			<asp:TreeView ID="TreeView6" runat="server" ImageSet="Contacts" NodeIndent="10">
			<ParentNodeStyle Font-Bold="True" ForeColor="#5555DD" />
			<HoverNodeStyle Font-Underline="False" />
			<SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" VerticalPadding="0px" />
			<Nodes>
			<asp:TreeNode Text="Root Node 1" Value="Root Node 1" Expanded="False">
			<asp:TreeNode Text="Leaf Node" Value="Leaf Node"></asp:TreeNode>
			<asp:TreeNode Text="Leaf Node" Value="Leaf Node"></asp:TreeNode>
			</asp:TreeNode>
			<asp:TreeNode Text="Root Node 2" Value="Root Node 2"></asp:TreeNode>
			</Nodes>
			<NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
			 NodeSpacing="0px" VerticalPadding="0px"/>
			</asp:TreeView>
			</asp:TableCell>
			<asp:TableCell ID="TableCell5" runat="server">
			<asp:TreeView ID="TreeView5" runat="server" ShowLines="True">
			<Nodes>
			<asp:TreeNode Text="Root Node 1" Value="Root Node 1" Expanded="True">
			<asp:TreeNode Text="Leaf Node" Value="Leaf Node"></asp:TreeNode>
			<asp:TreeNode Text="Leaf Node" Value="Leaf Node"></asp:TreeNode>
			</asp:TreeNode>
			<asp:TreeNode Text="Root Node 2" Value="Root Node 2"></asp:TreeNode>
			</Nodes>
			<LeafNodeStyle BackColor="#FFC0C0" BorderColor="Blue" BorderStyle="Solid" Font-Bold="True"
			 Font-Italic="True" />
			</asp:TreeView>
			</asp:TableCell>
			<asp:TableCell ID="TableCell6" runat="server">
			<asp:TreeView ID="TreeView7" runat="server" ShowCheckBoxes="All">
			<Nodes>
			<asp:TreeNode Text="Root Node 1" Value="Root Node 1" Checked="True" Expanded="False"
			 ShowCheckBox="True">
			<asp:TreeNode Text="Leaf Node" Value="Leaf Node"></asp:TreeNode>
			<asp:TreeNode Text="Leaf Node" Value="Leaf Node"></asp:TreeNode>
			</asp:TreeNode>
			<asp:TreeNode Text="Root Node 2" Value="Root Node 2"></asp:TreeNode>
			</Nodes>
			</asp:TreeView>
			</asp:TableCell>
			</asp:TableRow>
			</asp:Table>

    </div>
    </form>
</body>
</html>
