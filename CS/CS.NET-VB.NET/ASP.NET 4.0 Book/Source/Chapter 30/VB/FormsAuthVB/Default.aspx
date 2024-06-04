<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <asp:Label ID="label1" runat="server" style="z-index: 100; position: 
 		  absolute; top: 30px; left: 150px; width: 200px"/>
		<br /><br /><br/>                        
		<asp:Label ID="label2" runat="server" Text="Conference in progress..." 
		style="z-index: 100; position: absolute; top: 90px; left: 350px; width: 200px"/>
		<br/>
		<br/>
		<asp:Button ID="button1" runat="server" Text="Log out" OnClick="button1_Click" 
		style="z-index: 100; left: 350px; position: absolute; top: 200px; width: 200px;" 
 		  />
    </div>
    </form>
</body>
</html>
