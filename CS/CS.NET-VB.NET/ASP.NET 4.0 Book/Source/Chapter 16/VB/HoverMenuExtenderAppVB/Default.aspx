<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register
    Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit"
    TagPrefix="ajaxToolkit" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajaxToolkit:ToolkitScriptManager>

    <div>
    <asp:Button ID="Button1" runat="server" Text="Hover To Learn" />
			<asp:UpdatePanel ID="up1" runat="server"><ContentTemplate>
			<asp:Panel ID="Panel1" runat="server" Width="200px" Height="200px">
			<asp:RadioButtonList ID="RadioButtonList1" runat="server" >
			<asp:ListItem>Visual Basic.NET</asp:ListItem>
			<asp:ListItem>C#.NET</asp:ListItem>
			<asp:ListItem>ASP.NET</asp:ListItem>
			<asp:ListItem>ASP.NET AJAX</asp:ListItem>
			<asp:ListItem>AJAX Control Toolkit</asp:ListItem>
			</asp:RadioButtonList>
			<br />
			</asp:Panel></ContentTemplate>
			<Triggers>
			<asp:AsyncPostBackTrigger ControlID="RadioButtonList1" />
			</Triggers>
			</asp:UpdatePanel>
			<ajaxToolkit:HoverMenuExtender ID="HoverMenuExtender1" runat="server" 
 			  TargetControlID="Button1" PopupControlID="Panel1" PopupPosition="Right" 
 			  OffsetX="4" OffsetY="4" PopDelay="30">
			</ajaxToolkit:HoverMenuExtender>
    </div>
    </form>
</body>
</html>
