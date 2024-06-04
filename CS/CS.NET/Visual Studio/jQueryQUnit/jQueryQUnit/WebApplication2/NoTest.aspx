<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NoTest.aspx.cs" Inherits="WebApplication2.NoTests" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Testing jQuery With QUnit</title>
    <script type="text/javascript" language="javascript" src="http://code.jquery.com/jquery-latest.js"></script>    
    <script type="text/javascript" language="javascript">
        $(document).ready(function() {
            var txt = $("input[id$=TextBox1]");
            var span = $(txt).next();
            $(txt).keyup(function() {
                var length = $(txt).val().length;
                $(span).text(length + " characters long");
                $(span).css("background-color", length >= 8 ? "#FF0000" : "#FFFFFF");
            });

            test("Sample", function() {
                var addThemTogether = (1 + 1);
                equals(2, addThemTogether, "Should equal two");
            });
        });
    </script>    
</head>
<body>
    <form id="form1" runat="server">
        <asp:TextBox ID="TextBox1" runat="server" />
        <span></span>        
    </form>
</body>
</html>
