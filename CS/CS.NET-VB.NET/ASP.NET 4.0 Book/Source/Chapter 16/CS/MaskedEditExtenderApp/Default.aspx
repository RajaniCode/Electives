<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

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

    Enter the details below in the textboxes and you will see how the masked control 
		works<br />
		<div>
<asp:Label ID="Label1" runat="server" Text="Enter your name" >
</asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:TextBox ID="TextBox1" runat="server" Width="150px"></asp:TextBox><br /><br />
<asp:Label ID="Label2" runat="server" Text="Enter your roll 
number"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;        
	<asp:TextBox ID="TextBox2" runat="server" Width="150px"></asp:TextBox>                
	<ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" 
 	  TargetControlID="TextBox2" MaskType="Number" Mask="999" MessageValidatorTip="true" 
 	  AcceptNegative="None" InputDirection="RightToLeft" ErrorTooltipEnabled="true" >
	</ajaxToolkit:MaskedEditExtender>
	<ajaxToolkit:MaskedEditValidator ID="MaskedEditValidator1" runat="server" 
 	  ControlToValidate="TextBox2" ControlExtender="MaskedEditExtender1" MinimumValue="1" 
 	  MaximumValue="105" MinimumValueMessage="Please enter correct roll number" 
 	  MaximumValueMessage="Invalid roll number! The highest roll number is 105" 
 	  Display="Dynamic" IsValidEmpty="false" InvalidValueMessage="The roll number does not 
 	  exist" EmptyValueMessage="The roll number is not entered">
	</ajaxToolkit:MaskedEditValidator>                    
	<br />
	<br /><asp:Label ID="Label3" runat="server" Text="Enter date of birth 
 	(mm/dd/yyyy)"></asp:Label>        
	&nbsp;<asp:TextBox ID="TextBox3" runat="server" Width="150px"></asp:TextBox>        
	<ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" 
 	  TargetControlID="TextBox3" MaskType="Date" Mask="99/99/9999" 
 	  MessageValidatorTip="true" UserDateFormat="None" UserTimeFormat="None" 
 	  InputDirection="RightToLeft" ErrorTooltipEnabled="true" >
	</ajaxToolkit:MaskedEditExtender>
	<ajaxToolkit:MaskedEditValidator ID="MaskedEditValidator2" runat="server" 
 	  ControlToValidate="TextBox3" ControlExtender="MaskedEditExtender2" Display="Dynamic" 
 	  IsValidEmpty="false" InvalidValueMessage="Invalid date!" EmptyValueMessage="The date 
 	  is not entered">
	</ajaxToolkit:MaskedEditValidator> 

    </div>
    </form>
</body>
</html>
