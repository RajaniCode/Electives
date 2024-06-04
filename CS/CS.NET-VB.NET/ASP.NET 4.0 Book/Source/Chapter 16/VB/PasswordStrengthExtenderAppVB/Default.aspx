<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style id="Style1" runat="server" type="text/css">
	.strpoor
	{
		background-color:Red;
		font-weight:bolder;
	}
	.straverage
	{
		background-color:Yellow;
		font-weight:bold;
		
	}
	.strunbreakable
	{
		background-color:Green;
		font-weight:normal;    	
	}
	</style>        

</head>
<body>
    <form id="form1" runat="server">
   
<ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
</ajaxToolkit:ToolkitScriptManager>
    Enter the Password in the text box to validate its strength<br />
		<div>
		<asp:Label ID="Label2" runat="server" Text="Enter 
 		  password"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		<asp:TextBox ID="TextBox2" runat="server" TextMode="Password" 
 		  Text="*"></asp:TextBox>
		<ajaxToolkit:PasswordStrength ID="PasswordStrength1" runat="server" 
 		  TargetControlID="TextBox2" DisplayPosition="RightSide" PrefixText="Strength of 
 		  your password is:" StrengthIndicatorType="Text" MinimumNumericCharacters="1" 
 		  MinimumSymbolCharacters="1" RequiresUpperAndLowerCaseCharacters="true" 
 		  PreferredPasswordLength="10" TextStrengthDescriptions="Poor; Average; 
 		  Unbreakable"  StrengthStyles="strpoor;straverage;strunbreakable" >
		</ajaxToolkit:PasswordStrength>

    </div>
    </form>
</body>
</html>
