<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
			</asp:ScriptManager>
			<asp:UpdatePanel ID="UpdatePanel1" runat="server">
			<ContentTemplate>
			<h2>
				<asp:Label ID="LabelHadding" runat="server" Text="Simple 
 				Application With AJAX"></asp:Label>
			</h2>
			<asp:Label ID="TimeLabel" runat="server" Text="Click the Button to 
 			Display Current System Time"></asp:Label>
			&nbsp;
			<asp:Button ID="Btndisplay" runat="server" Text="Display" />
			</ContentTemplate>
			</asp:UpdatePanel>

    </div>
    </form>
</body>
</html>
