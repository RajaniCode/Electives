<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Search and Filter a DropDownList</title>
    <script src="Scripts/jquery-1.3.2.min.js" 
        type="text/javascript"></script>
    
    <script type="text/javascript">
        $(function() {
            var $txt = $('input[id$=txtNew]');
            var $ddl = $('select[id$=DDL]');
            var $items = $('select[id$=DDL] option');

            $txt.keyup(function() {
                searchDdl($txt.val());
            });

            function searchDdl(item) {
                $ddl.empty();
                var exp = new RegExp(item, "i");
                var arr = $.grep($items,
                    function(n) {
                        return exp.test($(n).text());
                    });

                if (arr.length > 0) {
                    countItemsFound(arr.length);
                    $.each(arr, function() {
                        $ddl.append(this);
                        $ddl.get(0).selectedIndex = 0;
                    }
                    );
                }
                else {
                    countItemsFound(arr.length);
                    $ddl.append("<option>No Items Found</option>");
                }
            }

            function countItemsFound(num) {
                $("#para").empty();
                if ($txt.val().length) {
                    $("#para").html(num + " items found");
                }

            }
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>Enter Text in the TextBox to Filter the DropDownList </h2>
        <br />
        <asp:TextBox ID="txtNew" runat="server" 
            ToolTip="Enter Text Here"></asp:TextBox><br />
        <asp:DropDownList ID="DDL" runat="server" >
            <asp:ListItem Text="Apple" Value="1"></asp:ListItem>
            <asp:ListItem Text="Orange" Value="2"></asp:ListItem>
            <asp:ListItem Text="Peache" Value="3"></asp:ListItem>
            <asp:ListItem Text="Banana" Value="4"></asp:ListItem>
            <asp:ListItem Text="Melon" Value="5"></asp:ListItem>
            <asp:ListItem Text="Lemon" Value="6"></asp:ListItem>
            <asp:ListItem Text="Pineapple" Value="7"></asp:ListItem>
            <asp:ListItem Text="Pomegranate" Value="8"></asp:ListItem>
            <asp:ListItem Text="Mulberry" Value="9"></asp:ListItem>
            <asp:ListItem Text="Apricot" Value="10"></asp:ListItem>
            <asp:ListItem Text="Cherry" Value="11"></asp:ListItem>
            <asp:ListItem Text="Blackberry" Value="12"></asp:ListItem>
        </asp:DropDownList>
        <br />
        <p id="para"></p>
        <br /><br />
        Tip: Items get filtered as characters are entered in the textbox.
        Search is not case-sensitive
    </div>

    </form>
</body>
</html>
