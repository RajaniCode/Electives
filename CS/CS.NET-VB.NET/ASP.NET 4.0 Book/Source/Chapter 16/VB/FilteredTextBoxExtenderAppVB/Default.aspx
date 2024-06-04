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
    <h3>
		Demo showing the use of FilteredTextBox control.</h3>

    <asp:Label ID="Label1" runat="server" Text="Enter text here (Only Accept Uppercase/Lowercase)"></asp:Label>
		<div>
		<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br />
		<asp:Label ID="Label2" runat="server" Text="Enter text here (Only accept UPPERCASE letters)"></asp:Label><br />
		<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
		<br />
		<asp:Label ID="Label3" runat="server" Text="Enter text here (Only accept Numbers)"></asp:Label><br />
		<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>

		<ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" 
 		  TargetControlID="TextBox1" FilterType="UppercaseLetters,LowercaseLetters">
		</ajaxToolkit:FilteredTextBoxExtender>
		<ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" 
 		  TargetControlID="TextBox2" FilterType="UppercaseLetters">
		</ajaxToolkit:FilteredTextBoxExtender>
		<ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" 
 		  TargetControlID="TextBox3" FilterType="Numbers">
		</ajaxToolkit:FilteredTextBoxExtender>

    </div>
    </form>
</body>
</html>
