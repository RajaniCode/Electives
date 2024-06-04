<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>DynamicMenu Control Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:XmlDataSource ID="XmlDataSource1" runat="server" 						DataFile="~/Data.xml"></asp:XmlDataSource>
			<br />
			<asp:SiteMapDataSource ID="SiteMapDataSource1" 							runat="server" />
			<asp:Label ID="Label1" runat="server" Text="Menu using 						XMLDataSource"></asp:Label><br />
			<br />
			<asp:Menu ID="Menu1" runat="server" BackColor="#FFFBD6" 					DataSourceID="XmlDataSource1"
			DynamicHorizontalOffset="2" Font-Names="Tahoma" Font-Size="Medium" ForeColor="#990000"
			 StaticSubMenuIndent="10px" Orientation="Horizontal">
			<StaticMenuItemStyle HorizontalPadding="5px" 							 VerticalPadding="2px" />
			<DynamicHoverStyle BackColor="#990000" ForeColor="White" 					   />
			<DynamicMenuStyle BackColor="#FFFBD6" />
			<StaticSelectedStyle BackColor="#FFCC66" />
			<DynamicSelectedStyle BackColor="#FFCC66" />
			<DynamicMenuItemStyle HorizontalPadding="5px" 							 VerticalPadding="2px" />
			<DataBindings>
			<asp:MenuItemBinding DataMember="setction" 							 NavigateUrlField="value" TextField="title"
			 ValueField="value" />
			<asp:MenuItemBinding DataMember="subpage" 							 NavigateUrlField="value" TextField="title"
			 ToolTipField="title" ValueField="value" />
			</DataBindings>
			<StaticHoverStyle BackColor="#990000" ForeColor="White" 					    />
			</asp:Menu>
			<br />
			<asp:Label ID="Label2" runat="server" Text="Menu using 						 SiteMapDataSource"></asp:Label>
			<br />
			<br />
			<asp:Menu ID="Menu2" runat="server" BackColor="#FFFBD6" 					 DataSourceID="SiteMapDataSource1"
			 DynamicHorizontalOffset="2" Font-Names="Tahoma" Font-Size="Medium" ForeColor="#990000"
			 StaticSubMenuIndent="10px">
			<StaticMenuItemStyle HorizontalPadding="5px" 							 VerticalPadding="2px" />
			<DynamicHoverStyle BackColor="#990000" ForeColor="White" 					   />
			<DynamicMenuStyle BackColor="#FFFBD6" />
			<StaticSelectedStyle BackColor="#FFCC66" />
			<DynamicSelectedStyle BackColor="#FFCC66" />
			<DynamicMenuItemStyle HorizontalPadding="5px" 							 VerticalPadding="2px" />
			<DataBindings>
			<asp:MenuItemBinding DataMember="setction" 							 NavigateUrlField="value" TextField="title"
			 ValueField="value" />
			<asp:MenuItemBinding DataMember="subpage" 							 NavigateUrlField="value" TextField="title"
			 ToolTipField="title" ValueField="value" />
			</DataBindings>
			<StaticHoverStyle BackColor="#990000" ForeColor="White" 					    />
			</asp:Menu>
    </div>
    </form>
</body>
</html>
