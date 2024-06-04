<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>WebPartsDemo</title>
</head>
<link href="StyleSheet.css" rel="stylesheet" type="text/css" />
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
				&nbsp; &nbsp; &nbsp;
				<asp:LoginStatus ID="LoginStatus1" runat="server" 
 				LogoutAction="RedirectToLoginPage" />
				<br />
				<br />
				<br />
				<asp:LinkButton ID="LinkButton2" runat="server" onclick="LinkButton2_Click">
				Browse
				</asp:LinkButton>
				&nbsp;
				<asp:LinkButton ID="LinkButton3" runat="server" onclick="LinkButton3_Click">
				Edit
				</asp:LinkButton>
				&nbsp;
                <asp:LinkButton ID="LinkButton4" runat="server" onclick="LinkButton4_Click">
				Catalog
				</asp:LinkButton>
				&nbsp;
				<asp:LinkButton ID="LinkButton5" runat="server" onclick="LinkButton5_Click">
				Design
				</asp:LinkButton>
				<table>
				<tr>
				<td valign="top" align="left">
				<asp:WebPartZone ID="WebPartZone1" runat="server" Height="166px" 
 				Width="273px" BorderColor="#CCCCCC"
				Font-Names="Verdana" Padding="6" LayoutOrientation="Horizontal">
				<ZoneTemplate>
				<asp:Calendar ID="Calendar1" runat="server" Title="My Calendar"></asp:Calendar>
				</ZoneTemplate>
				<PartChromeStyle BackColor="#F7F6F3" BorderColor="#E2DED6" Font-Names="Verdana" ForeColor="White" />
				<MenuLabelHoverStyle ForeColor="#E2DED6" />
				<EmptyZoneTextStyle Font-Size="0.8em" />
				<MenuLabelStyle ForeColor="White" />
				<MenuVerbHoverStyle BackColor="#F7F6F3" BorderColor="#CCCCCC" 
 				BorderStyle="Solid"
				BorderWidth="1px" ForeColor="#333333" />
				<HeaderStyle Font-Size="0.7em" ForeColor="#CCCCCC" 
 				HorizontalAlign="Center" />
				<MenuVerbStyle BorderColor="#5D7B9D" BorderStyle="Solid" 
 				BorderWidth="1px" ForeColor="White" />
				<PartStyle Font-Size="0.8em" ForeColor="#333333" />
				<TitleBarVerbStyle Font-Size="0.6em" Font-Underline="False" 
 				ForeColor="White" />
				<MenuPopupStyle BackColor="#5D7B9D" BorderColor="#CCCCCC" 
 				BorderWidth="1px" Font-Names="Verdana"
				Font-Size="0.6em" />
				<PartTitleStyle BackColor="#5D7B9D" Font-Bold="True" Font-Size="0.8em" ForeColor="White" />
				</asp:WebPartZone>
				</td>
				<td valign="top" align="center">
				<asp:WebPartZone ID="WebPartZone3" runat="server" Height="87px" 
 				Width="87px" BorderColor="#CCCCCC"
				Font-Names="Verdana" Padding="6">
				<ZoneTemplate>
				<asp:Image ID="Image1" runat="server" AlternateText="Error 
 				Displaying Image" Height="50px"
				ImageUrl="~/organisation.jpg" Width="100px" Title="My Logo" />
				</ZoneTemplate>
				<PartChromeStyle BackColor="#F7F6F3" BorderColor="#E2DED6" Font-Names="Verdana" ForeColor="White" />
				<MenuLabelHoverStyle ForeColor="#E2DED6" />
				<EmptyZoneTextStyle Font-Size="0.8em" />
				<MenuLabelStyle ForeColor="White" />
				<MenuVerbHoverStyle BackColor="#F7F6F3" BorderColor="#CCCCCC" 
 				BorderStyle="Solid"
				BorderWidth="1px" ForeColor="#333333" />
				<HeaderStyle Font-Size="0.7em" ForeColor="#CCCCCC" 
 				HorizontalAlign="Center" />
				<MenuVerbStyle BorderColor="#5D7B9D" BorderStyle="Solid" 
 				BorderWidth="1px" ForeColor="White" />
				<PartStyle Font-Size="0.8em" ForeColor="#333333" />
                <TitleBarVerbStyle Font-Size="0.6em" Font-Underline="False" 
 				ForeColor="White" />
				<MenuPopupStyle BackColor="#5D7B9D" BorderColor="#CCCCCC" 
 				BorderWidth="1px" Font-Names="Verdana"
				Font-Size="0.6em" />
				<PartTitleStyle BackColor="#5D7B9D" Font-Bold="True" Font-Size="0.8em" ForeColor="White" />
				</asp:WebPartZone>
				<asp:WebPartZone ID="WebPartZone2" runat="server" Width="87px" 
 				Height="67px" BorderColor="#CCCCCC"
				Font-Names="Verdana" Padding="6">
				<ZoneTemplate>
				<asp:Label ID="Label1" runat="server" Text="City Name: New York" 
 				Width="50px" Title="My City">
				</asp:Label>
				</ZoneTemplate>
				<PartChromeStyle BackColor="#F7F6F3" BorderColor="#E2DED6" Font-Names="Verdana" ForeColor="White" />
				<MenuLabelHoverStyle ForeColor="#E2DED6" />
				<EmptyZoneTextStyle Font-Size="0.8em" />
				<MenuLabelStyle ForeColor="White" />
				<MenuVerbHoverStyle BackColor="#F7F6F3" BorderColor="#CCCCCC" 
 				BorderStyle="Solid"
				BorderWidth="1px" ForeColor="#333333" />
				<HeaderStyle Font-Size="0.7em" ForeColor="#CCCCCC" 
 				HorizontalAlign="Center" />
				<MenuVerbStyle BorderColor="#5D7B9D" BorderStyle="Solid" 
 				BorderWidth="1px" ForeColor="White" />
				<PartStyle Font-Size="0.8em" ForeColor="#333333" />
				<TitleBarVerbStyle Font-Size="0.6em" Font-Underline="False" 
 				ForeColor="White" />
				<MenuPopupStyle BackColor="#5D7B9D" BorderColor="#CCCCCC" 
 				BorderWidth="1px" Font-Names="Verdana"
				Font-Size="0.6em" />
				<PartTitleStyle BackColor="#5D7B9D" Font-Bold="True" Font-Size="0.8em" ForeColor="White" />
				</asp:WebPartZone>
				</td>
				<td valign="top" align="right">
				<asp:EditorZone ID="Editorzone1" runat="server" 
 				BackColor="#F7F6F3" BorderColor="#CCCCCC"
				BorderWidth="1px" Font-Names="Verdana" Padding="6">
				<ZoneTemplate>
				<asp:AppearanceEditorPart ID="Appearanceeditorpart1" 
 				runat="server" />
				<asp:LayoutEditorPart ID="Layouteditorpart1" runat="server" />
				<asp:PropertyGridEditorPart ID="Propertygrideditorpart1" 
 				runat="server" />
				</ZoneTemplate>
				<LabelStyle Font-Size="0.8em" ForeColor="#333333" />
				<HeaderStyle BackColor="#E2DED6" Font-Bold="True" Font-Size="0.8em" ForeColor="#333333" />
				<HeaderVerbStyle Font-Bold="False" Font-Size="0.8em" Font-Underline="False" ForeColor="#333333" />
				<PartChromeStyle BorderColor="#E2DED6" BorderStyle="Solid" 
 				BorderWidth="1px" />
				<PartStyle BorderColor="#F7F6F3" BorderWidth="5px" />
				<FooterStyle BackColor="#E2DED6" HorizontalAlign="Right" />
				<EditUIStyle Font-Names="Verdana" Font-Size="0.8em" 
 				ForeColor="#333333" />
				<InstructionTextStyle Font-Size="0.8em" ForeColor="#333333" />
				<ErrorStyle Font-Size="0.8em" />
<VerbStyle Font-Names="Verdana" Font-Size="0.8em" 
 				ForeColor="#333333" />
				<EmptyZoneTextStyle Font-Size="0.8em" ForeColor="#333333" />
				<PartTitleStyle Font-Bold="True" Font-Size="0.8em" 
 				ForeColor="#333333" />
				</asp:EditorZone>
				</td>
				<td valign="top" align="right" style="width: 312px">
				<asp:CatalogZone ID="CatalogZone1" runat="server" Height="122px" 
 				BackColor="#F7F6F3"
				BorderColor="#CCCCCC" BorderWidth="1px" Font-Names="Verdana" 
 				Padding="6">
				<ZoneTemplate>
				<asp:PageCatalogPart ID="PageCatalogPart1" runat="server" />
				<asp:DeclarativeCatalogPart ID="DeclarativeCatalogPart1" 
 				runat="server">
				</asp:DeclarativeCatalogPart>
				</ZoneTemplate>
				<HeaderVerbStyle Font-Bold="False" Font-Size="0.8em" Font-Underline="False" ForeColor="#333333" />
				<PartTitleStyle BackColor="#5D7B9D" Font-Bold="True" Font-Size="0.8em" ForeColor="White" />
				<FooterStyle BackColor="#E2DED6" HorizontalAlign="Right" />
				<PartChromeStyle BorderColor="#E2DED6" BorderStyle="Solid" 
 				BorderWidth="1px" />
				<InstructionTextStyle Font-Size="0.8em" ForeColor="#333333" />
				<LabelStyle Font-Size="0.8em" ForeColor="#333333" />
				<PartLinkStyle Font-Size="0.8em" />
				<SelectedPartLinkStyle Font-Size="0.8em" />
				<VerbStyle Font-Names="Verdana" Font-Size="0.8em" 
 				ForeColor="#333333" />
				<HeaderStyle BackColor="#E2DED6" Font-Bold="True" Font-Size="0.8em" ForeColor="#333333" />
				<EmptyZoneTextStyle Font-Size="0.8em" ForeColor="#333333" />
				<EditUIStyle Font-Names="Verdana" Font-Size="0.8em" 
 				ForeColor="#333333" />
				<PartStyle BorderColor="#F7F6F3" BorderWidth="5px" />
				</asp:CatalogZone>
				</td>
				</tr>
				</table>
			</div></div>
			<div id="footer">
				<p class="left">
					All content copyright &copy; Kogent Solutions Inc.
				</p>
			</div>
		

    
    </div>
    </form>
</body>
</html>

