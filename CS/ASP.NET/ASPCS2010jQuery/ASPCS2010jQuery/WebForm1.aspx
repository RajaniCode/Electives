<%@ Page Language="C#" ClientIDMode="Static" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs"
    Inherits="ASPCS2010jQuery.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .Style1
        {
            color: Orange;
        }
        
        .Style2
        {
            color: Blue;
        }
    </style>
    <script type="text/javascript" src="http://code.jquery.com/jquery-latest.js"></script>
    <script type="text/javascript">
        function GetVal() {
            var v = $("#TextBox1");
            if ($.trim(v.val().toString()) == "") {
                alert("The TextBox is empty.");
            }
            else {
                alert($.trim(v.val().toString()));
            }
        }

        $(document).ready(function () {
            $("#Button2").click(function () {
                //$("#Button1").removeClass("Style1").addClass("Style2");
                //$("#Button1").css("color", "Blue");
                //$("input[id$=Button1]").removeClass("Style1").addClass("Style2");
                $("#Button1").toggleClass("Style1 Style2");
                return false; // to prevent the submit from going through
            });
        }); 
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Click" CssClass="Style1" />
        <br />
        <br />
        <asp:Button ID="Button2" runat="server" Text="Change" />
        <br />
        <br />
        <asp:Button ID="Button3" runat="server" Text="Get Textbox Value" OnClientClick="GetVal();" />
    </div>
    </form>
</body>
</html>
