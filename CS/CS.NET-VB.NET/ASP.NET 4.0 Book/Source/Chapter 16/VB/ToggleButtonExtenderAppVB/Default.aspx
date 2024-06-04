<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>
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
    Click on the image based checkboxes to see the working<br />
	
		<div>
           
		<asp:CheckBox ID="CheckBox1" runat="server" />&nbsp;&nbsp;&nbsp;&nbsp;
		<asp:Label ID="Label1" runat="server" Text="I am a post-graduate" Font-Size="Larger"></asp:Label><br /><br />
		<asp:CheckBox ID="CheckBox2" runat="server" />&nbsp;&nbsp;&nbsp;&nbsp;
		<asp:Label ID="Label2" runat="server" Text="I am appearing for PHD" Font-Size="Large"></asp:Label>
		<ajaxToolkit:ToggleButtonExtender ID="ToggleButtonExtender1" runat="server" 
		TargetControlID="CheckBox1" ImageWidth="30" ImageHeight="30" 
		CheckedImageAlternateText="Checked" UncheckedImageAlternateText="UnChecked" CheckedImageUrl="images/checked.GIF" UncheckedImageUrl="images/unchecked.gif">
		</ajaxToolkit:ToggleButtonExtender>
		<ajaxToolkit:ToggleButtonExtender ID="ToggleButtonExtender2" runat="server" 
 		  TargetControlID="CheckBox2" ImageHeight="30" ImageWidth="30" 
 		  CheckedImageAlternateText="Checked" UncheckedImageAlternateText="Unchecked" CheckedImageUrl="images/check.GIF" UncheckedImageUrl="images/unchecked.gif">
		</ajaxToolkit:ToggleButtonExtender>
        <br />
		<br />
		<asp:Button ID="Button1" runat="server" Text="Go" onclick="Button1_Click" />
		<br />
		<br />
		<asp:Label ID="Label3" runat="server"></asp:Label>

    </div>
    </form>
</body>
</html>
