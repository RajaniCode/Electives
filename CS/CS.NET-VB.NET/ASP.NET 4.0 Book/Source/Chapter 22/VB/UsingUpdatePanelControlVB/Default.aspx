<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
  
    <asp:ScriptManager ID="ScriptManager1" runat="server">
		<Services>
			<asp:ServiceReference Path="~/WebService.asmx" />
		</Services>
	</asp:ScriptManager>
	<div style="border-style: double; background-color: Gray; font-size: large; width: 
 	350px;">
	<asp:Label ID="Label1" runat="server"></asp:Label>
		<div>
			<asp:UpdatePanel ID="UpdatePanel1" runat="server">
			<ContentTemplate>
			<div style="border-style: dotted; background-color: Silver; font-size: 
 			larger; width: 300px;">
			<asp:Label ID="Label2" runat="server"></asp:Label>
			<asp:Button ID="Button1" runat="server" Text="Partial Update" />
		</div>
		<br />
		</ContentTemplate>
		</asp:UpdatePanel>
		<asp:Button ID="Button2" runat="server" Text="Full Update" />
		</div>

    </div>
    </form>
</body>
</html>
