<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CustomValidator Control Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <script language="vbscript" type="text/vbscript">

		Sub Validate (source, arguments)
			If (arguments.Value = "testuser")Then
            
				arguments.IsValid = True
            
			Else 
				arguments.IsValid = False
			End IF          
		End Sub
    
		</script>

    <div>
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" 
		Font-Underline="True" Text="CustomValidator Control Example"></asp:Label>
		<br />
		<br />
		<br />
		<asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Small" 
		Text="Enter User Name:"></asp:Label>
		&nbsp;&nbsp;
		<asp:TextBox ID="TextBox1" runat="server" Width="179px"></asp:TextBox>
		<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
		ControlToValidate="TextBox1" ErrorMessage="This field can not be blank."></asp:RequiredFieldValidator>
		<br />
		<asp:CustomValidator ID="CustomValidator1" runat="server" 
		ErrorMessage="Invalid entry. Correct username is 'testuser'." 
		ClientValidationFunction="Validate" 
 		ControlToValidate="TextBox1"></asp:CustomValidator>
		<br />
		<br />
		<br />
		&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
 		&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		<asp:Button ID="Button1" runat="server" BackColor="Black" Font-Bold="True" 
		Font-Size="Small" ForeColor="White" Text="Submit" />

    </div>
    </form>
</body>
</html>
