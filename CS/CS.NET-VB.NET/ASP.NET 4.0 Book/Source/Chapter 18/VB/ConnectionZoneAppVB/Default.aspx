<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>
<%@ Register Src="Consumer.ascx" TagName="Consumer" TagPrefix="cc" %>
<%@ Register Src="Provider.ascx" TagName="Provider" TagPrefix="pp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Connection zone Example</title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
		<div id="header">
			<h1>
				ASP.NET 4.0 Black Book
			</h1>
		</div>
		<div id="sidebar">
			<div id="nav">
				&nbsp;
			</div>
		</div>
		<div id="content">
			<div class="itemContent">
			<asp:WebPartManager ID="WebPartManager1" runat="server">
			</asp:WebPartManager>
			<br />
			<asp:LinkButton ID="LinkButton1" runat="server">Connections</asp:LinkButton> &nbsp;
			&nbsp; &nbsp;<asp:LinkButton ID="LinkButton3" runat="server">Browse</asp:LinkButton>&nbsp;&nbsp;<br />
			<asp:WebPartZone ID="WebPartZone1" runat="server" BorderColor="#CCCCCC" Font-Names="Verdana" Padding="6">
			<ZoneTemplate>
			<pp:Provider ID="ProviderWebPart1" runat="server" />
			</ZoneTemplate>
			<PartChromeStyle BackColor="#F7F6F3" BorderColor="#E2DED6" Font-Names="Verdana" ForeColor="White" />
			<MenuLabelHoverStyle ForeColor="#E2DED6" />
			<EmptyZoneTextStyle Font-Size="0.8em" />
			<MenuLabelStyle ForeColor="White" />
			<MenuVerbHoverStyle BackColor="#F7F6F3" BorderColor="#CCCCCC" BorderStyle="Solid"
			BorderWidth="1px" ForeColor="#333333" />
			<HeaderStyle Font-Size="0.7em" ForeColor="#CCCCCC" HorizontalAlign="Center" />
			<MenuVerbStyle BorderColor="#5D7B9D" BorderStyle="Solid" BorderWidth="1px" ForeColor="White" />
			<PartStyle Font-Size="0.8em" ForeColor="#333333" />
			<TitleBarVerbStyle Font-Size="0.6em" Font-Underline="False" ForeColor="White" />
			<MenuPopupStyle BackColor="#5D7B9D" BorderColor="#CCCCCC" BorderWidth="1px" Font-Names="Verdana"
			Font-Size="0.6em" />
			<PartTitleStyle BackColor="#5D7B9D" Font-Bold="True" Font-Size="0.8em" ForeColor="White" />
			</asp:WebPartZone>
			&nbsp;<br />
			<asp:WebPartZone ID="WebPartZone2" runat="server">
			<ZoneTemplate>
			<cc:Consumer ID="ConsumerWebPart1" runat="server" />
			</ZoneTemplate>
			</asp:WebPartZone>
			&nbsp;&nbsp;&nbsp; &nbsp;<br />
			<asp:ConnectionsZone ID="ConnectionsZone1" runat="server">
			<EditUIStyle BorderStyle="Solid" />
			</asp:ConnectionsZone>
			<br />
		</div>
	</div>
			</div>
			<div id="footer">
				<p class="left">
					All content copyright &copy; Kogent Solutions Inc.</p>
			</div>
		

    </form>
</body>
</html>
