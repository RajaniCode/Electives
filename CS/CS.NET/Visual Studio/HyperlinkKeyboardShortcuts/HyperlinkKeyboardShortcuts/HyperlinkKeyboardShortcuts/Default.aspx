<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Implement KeyBoard Shortcuts on Hyperlinks</title>
    <script src="Scripts/jquery-1.3.2.min.js" 
    type="text/javascript"></script>
    <script type="text/javascript">
        $(function() {
            $(document).keyup(function(e) {
                var key = (e.keyCode ? e.keyCode : e.charCode);
                switch (key) {
                    case 49:
                        navigateUrl($('a[id$=linkA]'));
                        break;
                    case 50:
                        navigateUrl($('a[id$=linkB]'));
                        break;
                    case 51:
                        navigateUrl($('a[id$=linkC]'));
                        break;
                    default: ;
                }
            });

            function navigateUrl(jObj) {
                window.location.href = $(jObj).attr("href");
                alert("Navigating to " + $(jObj).attr("href"));
            }
        });        
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>Use Keyboard Keys 1, 2 or 3 to invoke respective 
            websites</h2><br />
        <asp:HyperLink ID="linkA" runat="server" 
            NavigateUrl="http://www.dotnetcurry.com">
            DotNetCurry</asp:HyperLink><br /><br />
        <asp:HyperLink ID="linkB" runat="server" 
            NavigateUrl="http://www.sqlservercurry.com">
            SqlServerCurry</asp:HyperLink><br /><br />
        <asp:HyperLink ID="linkC" runat="server"
            NavigateUrl="http://www.devcurry.com">
            DevCurry</asp:HyperLink><br /><br />
    </div> 
    </form>
</body>
</html>
