<%@ Page Language="C#" AutoEventWireup="true" %>

<%@ Register Assembly="System.Web.Silverlight" Namespace="System.Web.UI.SilverlightControls"
    TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="CallingSilverlight.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <h1>Search Australian Postcodes</h1>
    <input type="button" onclick="loadPicturesSilverlight();" value="Search" />
    <input type="text" name="txtPostCode" maxlength="4" />
    <div id="sampleDiv">
    </div>
    <div>
        <asp:Silverlight ID="Xaml1" runat="server" Source="~/ClientBin/SilverlightApplication1.xap"
            MinimumVersion="2.0.31005.0" Width="100%" />
    </div>
    
    </form>
</body>
</html>
