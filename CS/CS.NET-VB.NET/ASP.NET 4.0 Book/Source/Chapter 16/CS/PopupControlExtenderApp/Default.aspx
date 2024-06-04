<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
  
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
    <div>
    <asp:Label ID="Label1" runat="server" Text="Enter your 
 		  name"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br /><br />
		<asp:Label ID="Label2" runat="server" Text="Enter your 
 		  address"></asp:Label>&nbsp;
		<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox><br />
		<asp:Panel ID="Panel1" runat="server" BorderWidth="3" BorderColor="Blue">
		<asp:RadioButtonList ID="RadioButtonList1" runat="server" 
		onselectedindexchanged="RadioButtonList1_SelectedIndexChanged">
		<asp:ListItem Value="South Delhi" />
		<asp:ListItem Value="North Delhi" />
		<asp:ListItem Value="East Delhi" />
		<asp:ListItem Value="West Delhi" />
		<asp:ListItem Value="Central Delhi" />
		</asp:RadioButtonList>
		</asp:Panel>
		<ajaxToolkit:PopupControlExtender ID="PopupControlExtender1" runat="server" 
 		  TargetControlID="TextBox2" PopupControlID="Panel1" Position="Bottom">
		</ajaxToolkit:PopupControlExtender>        
		<asp:Button ID="Button1" runat="server" Text="Submit" />
    </div>
    </form>
</body>
</html>
