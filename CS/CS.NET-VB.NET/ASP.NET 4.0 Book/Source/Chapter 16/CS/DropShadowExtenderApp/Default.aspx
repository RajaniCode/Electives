<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ Register
    Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit"
    TagPrefix="ajaxToolkit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </ajaxToolkit:ToolkitScriptManager>
    <br />
		Demo Showing the use of DropShadow Control<br />
		<asp:Panel ID="Panel1" runat="server" Width="200px" Height="120px" 
 		  BorderColor="Red"
		BackColor="LightSkyBlue">
		&nbsp;<asp:Label ID="Label1" runat="server" Text="Enter your name"></asp:Label>
		<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br />
		<asp:Label ID="Label2" runat="server" Text="Enter your roll number"></asp:Label>
		<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
		<asp:Button ID="Button1" runat="server" Text="Submit" />
		<br />
		<br />
		<br />
		<br />
		<br />
		</asp:Panel>
		<ajaxToolkit:DropShadowExtender ID="DropShadowExtender1" runat="server" 
 		  TargetControlID="Panel1"
		Opacity="0.5" Rounded="true" Width="10" TrackPosition="true" Radius="10">
		</ajaxToolkit:DropShadowExtender>

    </div>
    </form>
</body>
</html>
