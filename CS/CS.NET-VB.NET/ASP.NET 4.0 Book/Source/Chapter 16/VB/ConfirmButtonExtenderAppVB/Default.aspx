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
    <center>Click on the button to learn about confirm button<br />
		<br />
		<asp:Button ID="Button1" runat="server" Text="Submit" /></center>
		<ajaxToolkit:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" 
 		  TargetControlID="Button1" ConfirmText="Are you sure to submit the form" >
		</ajaxToolkit:ConfirmButtonExtender>       
		<asp:Label ID="Label1" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
