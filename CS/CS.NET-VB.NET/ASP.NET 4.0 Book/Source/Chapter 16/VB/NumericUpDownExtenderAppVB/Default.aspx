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

    <h2> Select the Date and month requested below using NumericUpDown 
 			  control</h2><br />
			<br />
			<asp:Label ID="Label1" runat="server" Text="Select Date of joining"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
			<asp:TextBox ID="TextBox1" runat="server" Height="18px" 
 			  Enabled="False"></asp:TextBox>
 			  <br /><br />
			<asp:Label ID="Label2" runat="server" Text="Select your month of 
 			  joining"></asp:Label>&nbsp;
			<asp:TextBox ID="TextBox2" runat="server" Height="18px"></asp:TextBox>
 			  <br /><br />
			       
			<ajaxToolkit:NumericUpDownExtender ID="NumericUpDownExtender1" runat="server" 
 			  TargetControlID="Textbox1" Width="150" Step="1" Minimum="1" 
 			  Maximum="31">
			</ajaxToolkit:NumericUpDownExtender>
			<ajaxToolkit:NumericUpDownExtender ID="NumericUpDownExtender2" runat="server" 
 			  Step="1" TargetControlID="TextBox2" Width="150" RefValues="January;February; March; April; May;Jun;July;August;September;October;November;December">
			</ajaxToolkit:NumericUpDownExtender>
    </div>
    </form>
</body>
</html>
