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
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></ajaxToolkit:ToolkitScriptManager>
    <div>
    <br />
    <br />
    <br />
    <br />
    <center>
    <asp:Label ID="Label1" runat="server" Text="Move the slider to see its working:"></asp:Label>
		<asp:UpdatePanel ID="UpdatePanel1" runat="server">
		<ContentTemplate>
			<table>
				<tr>
				<td>
				<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
				</td>
				<td align="char">
				<asp:TextBox ID="TextBox2" runat="server" Width="50px" BackColor="Gray" BorderColor="Red"></asp:TextBox>
				</td>
				</tr>
			</table>
			<ajaxToolkit:SliderExtender ID="SliderExtender1" runat="server" TargetControlID="TextBox1" BoundControlID="TextBox2" EnableHandleAnimation="true" Minimum="0" 
 			  Maximum="100" Steps="100" TooltipText="Move Slider" Orientation="Horizontal">
			</ajaxToolkit:SliderExtender>
		</ContentTemplate>
		</asp:UpdatePanel>
        </center>
    </div>
    </form>
</body>
</html>
