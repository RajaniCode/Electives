<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    
        <ajaxtoolkit:toolkitscriptmanager runat="server"></ajaxtoolkit:toolkitscriptmanager>
    
		Select the checkbox and you will see the use of Mutually exclusive checkboxes<br />
		------------------------------------------<div>
		<table style="background-color:#ffff00">
		<tr>
			<td class="style1">
			<br />
			<asp:Label ID="Label1" runat="server" Text="Likes and Dislikes" 
 			Font-Bold="true" Font-Size="Larger" BackColor="LightGray"></asp:Label>
			</td>        
		</tr>
		<tr>
			<td class="style1">
			Like music:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
			<asp:CheckBox ID="CheckBox1" runat="server" />
			</td>
			<td>
			&nbsp;&nbsp;&nbsp;
			</td>
			<td>
			Don't like music:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
			<asp:CheckBox ID="CheckBox2" runat="server" />
			</td>
		</tr>
		<tr>
			<td class="style1">
			Like veg recepies:
			<asp:CheckBox ID="CheckBox3" runat="server" />
			</td>
			<td>
			&nbsp;&nbsp;&nbsp;
			</td>
			<td>
			Like non-veg recepies:
			<asp:CheckBox ID="CheckBox4" runat="server" />
			</td>
		</tr>
		</table>
		<ajaxToolkit:MutuallyExclusiveCheckBoxExtender ID="MutuallyExclusiveCheckBoxExtender1" 
 		  runat="server" TargetControlID="CheckBox1" Key="music">
		</ajaxToolkit:MutuallyExclusiveCheckBoxExtender>
		<ajaxToolkit:MutuallyExclusiveCheckBoxExtender ID="MutuallyExclusiveCheckBoxExtender2" 
 		  runat="server" TargetControlID="CheckBox2" Key="music">
		</ajaxToolkit:MutuallyExclusiveCheckBoxExtender>
		<ajaxToolkit:MutuallyExclusiveCheckBoxExtender ID="MutuallyExclusiveCheckBoxExtender3" 
 		  runat="server" TargetControlID="CheckBox3" Key="recepies">
		</ajaxToolkit:MutuallyExclusiveCheckBoxExtender>
		<ajaxToolkit:MutuallyExclusiveCheckBoxExtender ID="MutuallyExclusiveCheckBoxExtender4" 
 		  runat="server" TargetControlID="CheckBox4" Key="recepies">
		</ajaxToolkit:MutuallyExclusiveCheckBoxExtender>

    </div>
    </form>
</body>
</html>
