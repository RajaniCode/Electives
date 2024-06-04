<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MockTest.aspx.cs" Inherits="WebApplication2.MockTest" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Testing jQuery With QUnit</title>
    <script type="text/javascript" language="javascript" src="http://code.jquery.com/jquery-latest.js"></script>    
    <link rel="stylesheet" href="http://github.com/jquery/qunit/raw/master/qunit/qunit.css" type="text/css" media="screen" />
    <script type="text/javascript" src="http://github.com/jquery/qunit/raw/master/qunit/qunit.js" language="javascript"></script>    
    <script type="text/javascript" language="javascript">
        $(document).ready(function() {
            $("body").after("<input type=\"text\" id=\"TextBox1\" /><span></span>");
            var txt = $("input[id$=TextBox1]");
            var span = $(txt).next();
            
            $(txt).live("keyup", function() {
                var length = $(txt).val().length;
                $(span).text(length + " characters long");
                $(span).css("background-color", length >= 8 ? "#FF0000" : "#FFFFFF");
            });

            test("Perform keyup - should fail", function() {
                $(txt).val("Hello World!");
                $(txt).trigger("keyup");
                var color = $(span).css("background-color");
                equals(color, "#ff0000", "The background color should be #ff0000");
            });

            test("Perform keyup - should pass", function() {
                $(txt).val("Hello!");
                $(txt).trigger("keyup");
                var color = $(span).css("background-color");
                equals(color, "#ffffff", "The background color should be #ffffff");
            });

            test("Perform keyup - should fail I think", function() {
                $(txt).val("Ok");
                $(txt).trigger("keyup");
                var color = $(span).css("background-color");
                equals(color, "#ff0000", "The background color should be #ff0000");
            });
        });
    </script>    
</head>
<body>
    <form id="form1" runat="server">        
        <h1 id="qunit-header">QUnit example</h1>               
        <ol id="qunit-tests"></ol>     
    </form>
</body>
</html>


