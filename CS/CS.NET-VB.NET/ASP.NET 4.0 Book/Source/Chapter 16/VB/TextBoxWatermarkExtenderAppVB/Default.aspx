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
    <asp:Panel ID="Panel1" runat="server" BorderColor="Red" BorderWidth="3" 
 		  Width="200" HorizontalAlign="Center" >
		<div style="padding-left:10px">
		<asp:Label ID="Label1" runat="server" Text="Enter your name"></asp:Label>
		<asp:TextBox ID="TextBox1" runat="server" BackColor="LightGray"></asp:TextBox>
		</div>
		<div style="padding-left:10px">
		<asp:Label ID="Label2" runat="server" Text="Enter your favorite 
 		  food"></asp:Label>
		<asp:TextBox ID="TextBox2" runat="server" BackColor="LightGray"></asp:TextBox>
		</div>
		<ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" 
 		  TargetControlID="TextBox1" WatermarkCssClass="watermarked" WatermarkText="Type your name here">
		</ajaxToolkit:TextBoxWatermarkExtender>
		<ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" 
 		  TargetControlID="TextBox2" WatermarkCssClass="watermarked" WatermarkText="Type your favorite food" >
		</ajaxToolkit:TextBoxWatermarkExtender>
		<center><asp:Button ID="Button1" runat="server" Text="Go" />
		</center>
		</asp:Panel>

    </div>
    </form>
</body>
</html>
