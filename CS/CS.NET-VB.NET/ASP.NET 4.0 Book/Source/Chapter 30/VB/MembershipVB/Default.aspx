<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table id="tblLogin" cellspacing="1" cellpadding="1" style="border-right: 
 			  blue thin solid; border-top: blue thin solid; border-left: blue thin 
 			  solid; border-bottom: blue thin solid; width: 422px; height: 189px;" 
 			  bgcolor="#cccc66">
			<tr>
				<td colspan="2" >
					<div style="text-align: center">
					<strong><span style="text-decoration: underline">Create User</span></strong>
					</div>
				</td>
			</tr>
			<tr>
				<td width="40%">User ID:</td>
				<td class="style1">
					<asp:textbox id="myUserId" runat="server" 
 					  width="100%"></asp:textbox>
				</td>
			</tr>
			<tr>
				<td>Password:</td>
				<td class="style1">
					<asp:textbox id="myPassword" runat="server" textmode="Password" width="100%"></asp:textbox>
				</td>
			</tr>
			<tr>
				<td>
				Email:</td>
				<td class="style1">
					<asp:textbox id="myEmail" runat="server" width="100%"></asp:textbox>
				</td>
			</tr>
			<tr>
				<td>
  				Password Question:</td>
				<td class="style1">
				<asp:DropDownList ID="dropdownlist1" Runat="server" Width="100%">
				<asp:ListItem>Your favorite place?</asp:ListItem>
				<asp:ListItem>Your favorite color?</asp:ListItem>
				<asp:ListItem>Your role model?</asp:ListItem>
				</asp:DropDownList>
				</td>
			</tr>
			<tr>
				<td>
				Password Answer:</td>
				<td class="style1">
					<asp:textbox id="myPasswordAnswer" runat="server" width="100%"></asp:textbox>
				</td>
			</tr>                    
			<tr>
				<td style="TEXT-ALIGN: center" colspan="2">
<asp:Button ID="createbutton" runat="server" Text="Click to Create User" />
				</td>
			</tr>
        
			</table>
			<br />
			<br />
            <asp:Label ID="lblresults" runat="server" Visible="false">Results:</asp:Label>
    </div>
    </form>
</body>
</html>
