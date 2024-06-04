<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Rotating ads</title>
</head>
<body>
<form id="form1" runat="server">
<div>
<asp:ScriptManager ID="ScriptManager1" runat="server" />
<asp:Timer ID="Timer1" Interval="2000" runat="server" />

    <asp:UpdatePanel ID="up1" runat="server">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
        </Triggers>
        <ContentTemplate>
            <asp:AdRotator
            id="AdRotator1"
            AdvertisementFile="~/App_Data/Ads.xml"
            KeywordFilter="small"
            Runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>    
</div>
</form>
</body>
</html>
