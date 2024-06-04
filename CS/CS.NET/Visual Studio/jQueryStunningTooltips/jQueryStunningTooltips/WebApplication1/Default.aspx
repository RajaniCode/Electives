<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="CSS/styles.css" />
    <script language="javascript" type="text/javascript" src="Scripts/jquery-1.3.2.js"></script>
    <script language="javascript" type="text/javascript" src="http://cdn.jquerytools.org/1.1.1/jquery.tools.min.js"></script>
    <script language="javascript" type="text/javascript">
        function showToolTip() {            
            $("#results span[title]").tooltip({
                position: "center right",      
                opacity: 0.7,
                tip: "#demotip",
                effect: "fade"
            });            
        }

        $(document).ready(function() {
            $("#btnSearch").click(function() {
                $.ajax({
                    type: "POST",
                    url: "Default.aspx/GetRunningProcesses",
                    data: "{}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: true,
                    success: function(msg) {
                        var processInfo = msg.d;
                        $("#results").text("");
                        for (var i = 0; i < processInfo.length; i++) {
                            // create the title for each item
                            var title = "Process&nbsp;Name:&nbsp;" +
                                        processInfo[i].ProcessName +
                                        "&lt;BR&gt;" +
                                        "Paged&nbsp;Memory&nbsp;Size64:&nbsp;" + 
                                        processInfo[i].PagedMemorySize64;                            
                            $("#results").append("<span onmouseover=\"showToolTip()\" title=" + title + ">" +
                            processInfo[i].ProcessName +
                            "</span><div id=\"spacer\"></div><br />");
                        }
                    }
                });
            });
        });    
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <!-- the tooltip --> 
        <div id="demotip">&nbsp;</div> 
        <input id="btnSearch" type="button" value="Get Processes" />
        <div id="results"></div>        
    </form>
</body>
</html>
