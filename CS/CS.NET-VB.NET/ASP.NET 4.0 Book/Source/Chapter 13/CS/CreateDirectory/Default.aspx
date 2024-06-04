<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <h4>This Application creates a directory at specified path in the textbox </h4>
        <h4>For example 
 		  C:/ProgramFiles/DirectoryName</h4><br />
		<br />
		<br />
		<asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Italic="True" Text="Enter the Path To Create a directory "></asp:Label>
		
		<asp:TextBox ID="TextBox1" runat="server" Width="323px"></asp:TextBox>
		<br />
		<br />
		<br />
		
		<asp:Button ID="BtnCreate" runat="server"	Text="Create Directory" 
            Width="111px" onclick="BtnCreate_Click" />
            <br />
        <br />
        <br />
            <asp:Label 
		ID="Label2" runat="server" Font-Bold="True" Font-Italic="True" 
		Text="Label"></asp:Label>
    </div>
    </form>
</body>
</html>
