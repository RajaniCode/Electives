<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Highlight Selected CheckBox Items</title>
    <script language="javascript" type="text/javascript" src="http://ajax.microsoft.com/ajax/jquery/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" language="javascript">
        $(document).ready(function() {
            // The following code is for manually
            // selecting each item and highlighting the background
            $("table[id$=CheckBoxList1] input").click(function() {
                if ($(this).next().is(".selected")) {
                    $(this).next().removeClass("selected").addClass("default");
                }
                else {
                    $(this).next().removeClass("default").addClass("selected")
                }
            });

            // The following code is for automatically
            // selecting each item and highlighting the background
            $("table[id$=CheckBoxList1] input").hover(
                function() {
                    if ($(this).is(":checked")) {
                        $(this).attr("checked", "");
                        $(this).next().removeClass("selected").addClass("default")
                    } else {
                        $(this).attr("checked", "checked");
                        $(this).next().removeClass("default").addClass("selected");
                    }
            });       
        });
    </script>
    <style type="text/css">
        .selected
        {
            background-color:Yellow;
        }
        .default
        {
        	background-color:White;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">   
        <asp:CheckBoxList ID="CheckBoxList1" runat="server">
            <asp:ListItem Text="one"></asp:ListItem>
            <asp:ListItem Text="two"></asp:ListItem>
            <asp:ListItem Text="three"></asp:ListItem>
        </asp:CheckBoxList> 
    </form>
</body>
</html>
