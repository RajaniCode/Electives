<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.jQuery132.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>jQuery 1.3.2 Live() Event</title>
    <script language="javascript" type="text/javascript" src="http://jqueryjs.googlecode.com/files/jquery-1.3.2.js"></script>
    <script language="javascript" type="text/javascript">
        $(function() {
            $("input[type=text]").bind("focus", function() {
                $("#result").text($(this).val());  
            });

            $("#btnAdd").click(function(e) {
                $("#Demo").clone().insertAfter($(this));
                $("<br /><br />").insertAfter($(this));
                e.preventDefault();
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <h1>jQuery 1.3.2 Live() Event</h1>
        <div>        
            <input id="Demo" type="text" maxlength="32" />
            <br /><br />
            <input id="btnAdd" type="button" value="Add Text Box" />   
            <div id="result"></div>     
        </div>    
    </form>
</body>
</html>

