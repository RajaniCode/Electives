<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    
    <h3> Enter the required information<br /></h3>
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
		
		<div>
		<asp:Label ID="Label1" runat="server" Text="Enter your 
 		  name"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
		<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
 		  ErrorMessage="Missing Name!" ControlToValidate="TextBox1" 
 		  Display="None"></asp:RequiredFieldValidator>
		<ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" 
 		  TargetControlID="RequiredFieldValidator1">
		</ajaxToolkit:ValidatorCalloutExtender>
		<br /><br /><asp:Label ID="Label2" runat="server" Text="Enter your employee 
 		  id"></asp:Label>
		&nbsp;between 1 to 999
		<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
		<asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="The 
 		  employee id does not exist. Please enter employee id between 1 to 999"  
 		  ControlToValidate="TextBox2" MinimumValue="1" MaximumValue="999" 
 		  Display="None" Enabled="true"></asp:RangeValidator>
		<ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" 
 		  TargetControlID="RangeValidator1">
		</ajaxToolkit:ValidatorCalloutExtender>
		<br /><br /><asp:Button ID="Button1" runat="server" Text="Login" />

    </div>
    </form>
</body>
</html>
