<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>Rotating ads using ASP.NET AdRotator and jQuery</title>
    <script type="text/javascript"
        src="http://code.jquery.com/jquery-latest.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            setInterval(function () {
                $("#adr").load(location.href + " #adr", "" + Math.random() + "");
            }, 4000);
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
<div class="ads">
        <asp:AdRotator
        id="adr"
        AdvertisementFile="~/App_Data/Ads.xml"
        KeywordFilter="small"
        Runat="server" />
</div>
    <br /><br />
    Time when Page First Loaded : 
    <asp:Label ID="lblTime" runat="server" Text=""></asp:Label>    
    </form>
</body>
</html>
