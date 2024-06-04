<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Menu Control Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Label ID="Label1" runat="server" Text="Static Menu with vertical 
 			 orientation"></asp:Label><br />
			<br />
			<asp:Menu ID="Menu1" runat="server" BackColor="#B5C7DE" 
 			 DynamicHorizontalOffset="2"
			 Font-Names="Verdana" Font-Size="Medium" ForeColor="#284E98" 
 			 StaticSubMenuIndent="10px"
			 StaticDisplayLevels="2">
			<StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
			<DynamicHoverStyle BackColor="#284E98" ForeColor="White" />
			<DynamicMenuStyle BackColor="#B5C7DE" />
			<StaticSelectedStyle BackColor="#507CD1" />
			<DynamicSelectedStyle BackColor="#507CD1" />
			<DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
			<Items>
			<asp:MenuItem Text="MenuItem1" Value="MenuItem1">
			<asp:MenuItem Text="MenuItem1Leaf" Value="MenuItem1Leaf"></asp:MenuItem>
			<asp:MenuItem Text="MenuItem1Leaf" Value="MenuItem1Leaf"></asp:MenuItem>
			</asp:MenuItem>
			<asp:MenuItem Text="MenuItem2" Value="MenuItem2">
			<asp:MenuItem Text="MenuItem2Leaf" Value="MenuItem2Leaf"></asp:MenuItem>
			<asp:MenuItem Text="MenuItem2Leaf" Value="MenuItem2Leaf"></asp:MenuItem>
			<asp:MenuItem Text="MenuItem2Leaf" Value="MenuItem2Leaf"></asp:MenuItem>
			</asp:MenuItem>
			</Items>
			<StaticHoverStyle BackColor="#284E98" ForeColor="White" />
			</asp:Menu>
			<br />
			<asp:Label ID="Label2" runat="server" Text="Static Menu with horizontal 
 			 orientation"></asp:Label><br />
			<br />
			<asp:Menu ID="Menu2" runat="server" BackColor="#FFFBD6" 
 			 DynamicHorizontalOffset="2"
			 Font-Names="Verdana" Font-Size="Medium" ForeColor="#990000" 
 			 StaticSubMenuIndent="10px"
			 Orientation="Horizontal" StaticDisplayLevels="2">
			<StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
			<DynamicHoverStyle BackColor="#990000" ForeColor="White" />
			<DynamicMenuStyle BackColor="#FFFBD6" />
			<StaticSelectedStyle BackColor="#FFCC66" />
			<DynamicSelectedStyle BackColor="#FFCC66" />
			<DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
			<Items>
			<asp:MenuItem Text="MenuItem1" Value="MenuItem1">
			<asp:MenuItem Text="MenuItem1Leaf" Value="MenuItem1Leaf"></asp:MenuItem>
			</asp:MenuItem>
			<asp:MenuItem Text="MenuItem2" Value="MenuItem2">
			<asp:MenuItem Text="MenuItem2Leaf" Value="MenuItem2Leaf"></asp:MenuItem>
			<asp:MenuItem Text="MenuItem2Leaf" Value="MenuItem2Leaf"></asp:MenuItem>
			</asp:MenuItem>
			</Items>
			<StaticHoverStyle BackColor="#990000" ForeColor="White" />
			</asp:Menu>

    </div>
    </form>
</body>
</html>
