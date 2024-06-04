<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:ScriptManager runat="server" ID="scriptManagerId">
			<Services>
				<asp:ServiceReference Path="~/WebService.asmx" />
			</Services>
            <Scripts>
				<asp:ScriptReference Path="~/CallingWebService.js" />
			</Scripts>			
			</asp:ScriptManager>		
			
			<button id="BtnMultiply"  onclick="Multiplication(2, 5); return false;">Mutiply</button>
       
			<br />
			<br />
			<asp:Label ID="LblResult" runat="server" Text="Result"></asp:Label>
    </div>
    </form>
</body>
</html>
