<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Renaming jQuery's UI Tabs</title>
    <link type="text/css" href="CSS/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <script src="Scripts/jquery-1.3.2.js" type="text/javascript"></script>
	<script src="Scripts/jquery-ui-1.7.2.custom.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function() {
            // Tabs
            $('#tabs').tabs({
                selected: -1
            });

            //hover states on the static widgets
            $('#dialog_link, ul#icons li').hover(
					function() { $(this).addClass('ui-state-hover'); },
					function() { $(this).removeClass('ui-state-hover'); }
				);

            $("img[alt=Rename]").click(function(e) {
                var reply = prompt("Type in a name for the tab");
                if (reply != null && reply.trim().length > 0) {
                    $(e.target).prev("a").text(reply);
                }
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="tabs">
            <ul>
                <li><a href="#tabs-0">Nunc tincidunt</a><img src="Images/x_normal.gif" alt="Rename" /></li>
                <li><a href="#tabs-1">Proin dolor</a><img src="Images/x_normal.gif" alt="Rename" /></li>
            </ul>
            <div id="tabs-0">
                Proin elit arcu, rutrum commodo, vehicula tempus, commodo a, risus. Curabitur nec arcu. Donec 
                sollicitudin mi sit amet mauris. Nam elementum quam ullamcorper ante. Etiam aliquet massa et lorem. 
                Mauris dapibus lacus auctor risus. Aenean tempor ullamcorper leo. Vivamus sed magna quis ligula eleifend adipiscing. 
                Duis orci. Aliquam sodales tortor vitae ipsum. Aliquam nulla. Duis aliquam molestie erat. Ut et mauris vel 
                pede varius sollicitudin. Sed ut dolor nec orci tincidunt interdum. Phasellus ipsum. Nunc tristique tempus lectus.
            </div>
            <div id="tabs-1">            
                Morbi tincidunt, dui sit amet facilisis feugiat, odio metus gravida ante, ut pharetra massa metus 
                id nunc. Duis scelerisque molestie turpis. Sed fringilla, massa eget luctus malesuada, metus 
                eros molestie lectus, ut tempus eros massa ut dolor. Aenean aliquet fringilla sem. Suspendisse 
                sed ligula in ligula suscipit aliquam. Praesent in eros vestibulum mi adipiscing adipiscing. Morbi 
                facilisis. Curabitur ornare consequat nunc. Aenean vel metus. Ut posuere viverra nulla. Aliquam erat volutpat. 
                Pellentesque convallis. Maecenas feugiat, tellus pellentesque pretium posuere, felis lorem euismod felis, 
                eu ornare leo nisi vel felis. Mauris consectetur tortor et purus.
            </div>
        </div>        
    </form>
</body>
</html>
