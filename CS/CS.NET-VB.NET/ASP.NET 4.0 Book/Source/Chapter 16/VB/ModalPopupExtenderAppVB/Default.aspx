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
    <div>
    <asp:Button ID="Button1" runat="server" Text="Click here to start" />
		<asp:Panel ID="Panel1" runat="server" BorderColor="Red" BorderWidth="3">
		<asp:Label ID="Label1" runat="server" Text="Select your favorite game"></asp:Label><br />
		<asp:Label ID="Label2" runat="server" Text="Football"></asp:Label>
		<asp:RadioButton ID="RadioButton1" runat="server" GroupName="Game" /><br />
		<asp:Label ID="Label3" runat="server" Text="Cricket"></asp:Label>
		&nbsp;<asp:RadioButton ID="RadioButton2" runat="server" GroupName="Game"/><br />
		<asp:Button ID="Button2" runat="server" Text="Submit" />
		</asp:Panel>
		<br />
		<br />
		<asp:Label ID="Label4" runat="server"></asp:Label>
		<ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" 
 		  TargetControlID="Button1" PopupControlID="Panel1">
		</ajaxToolkit:ModalPopupExtender>  

    </div>
    </form>
</body>
</html>
