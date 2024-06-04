<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs"
    Inherits="WebApplication1._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>jQuery Example</title>
    <style type="text/css">
        .hideId
        {
            display: none;
        }
    </style>

    <script language="javascript" type="text/javascript" src="jquery-1.3.2.js"></script>
    <script type="text/javascript" language="javascript">
        $(document).ready(function() {
            $("tr").filter(function() {
                return $('td', this).length && !$('table', this).length
            })
            .click(function() {
                __doPostBack('javaScriptEvent', $(this).find("span").text());
            })
            .mouseover(function() {
                $(this).css("cursor", "hand");
            })
            .css({ background: "ffffff" }).hover(
                function() { $(this).css({ background: "#C1DAD7" }); },
                function() { $(this).css({ background: "#ffffff" }); }
                );
        }); 
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <asp:GridView ID="grdEmployee" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Image runat="server" ID="imgPeople" ImageUrl="~/People_031.gif" />
                    <asp:Label CssClass="hideId" runat="server" ID="lblID" Text='<%# Eval("ID") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="GivenName" />
            <asp:BoundField DataField="Surname" />
            <asp:BoundField DataField="Department" />
        </Columns>
    </asp:GridView>
    </form>
</body>
</html>
