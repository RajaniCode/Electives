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
        <asp:Timer ID="Timer1" runat="server" Interval="1000" ontick="TimeUpdater_Tick">
        </asp:Timer>       
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
	<Triggers>
		<asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
	</Triggers>
    <ContentTemplate>
    <asp:Label ID="LabelHeading" runat="server" Text="Application Using Timer Control"></asp:Label>
		</h2>
		<asp:Label ID="TimeLabel" runat="server" Text="Current System Time"></asp:Label>
    </ContentTemplate>
</asp:UpdatePanel>    
    </div>
    </form>
</body>
</html>
