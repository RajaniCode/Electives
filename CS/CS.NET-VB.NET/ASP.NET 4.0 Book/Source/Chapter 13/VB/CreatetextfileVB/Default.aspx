<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>Creates a file and opens it to work with it.Mention the path and file name such 
 		  as D:/directoryname/filename.doc<br />
		<br />
		<br />
		&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		<asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Italic="True" 
		Text="Enter name and path of File "></asp:Label>
		
		<asp:TextBox ID="TextBox1" runat="server" Width="205px"></asp:TextBox>
		&nbsp;<br />
		<br />
		<br />
		
		
		&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Write the text into the multiline text 
 		  box.&nbsp;&nbsp;&nbsp;
		<br />
		<asp:TextBox ID="TextBox2" runat="server" Height="135px" TextMode="MultiLine" 
		Width="405px"></asp:TextBox><br />
		<br />
        <asp:Button ID="BtnCreate" runat="server"  Text="Create and Write to File " 
 		  Width="212px" Font-Bold="True" 
		Font-Italic="True"  />
            
        <br />
        <br />
        <br />
            
    <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
    </div>
    </form>
</body>
</html>
