<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="DropDownListSelection.aspx.cs" Inherits="DropDownListSelection" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script type="text/javascript">
        $(document).ready(function () {
            $('select[id$=<%=DropDownList1.ClientID%>]').bind("keyup change", function () {
                var selectedItem = $(this).find(":selected");
                if (selectedItem.val() != "") {
                    var msg = "Text : " + selectedItem.text() + ' Value: ' + selectedItem.val();
                    $('#message').text(msg);
                }
                else {
                    $('#message').text("");
                }
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div align="center">
        <fieldset style="width: 400px; height: 80px;">
            <p>
                Select Language:</p>
            <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem Text="--Please Select--" Value=""></asp:ListItem>
                <asp:ListItem Text="C#" Value="1"></asp:ListItem>
                <asp:ListItem Text="VB" Value="2"></asp:ListItem>
                <asp:ListItem Text="Java" Value="3"></asp:ListItem>
                <asp:ListItem Text="PHP" Value="4"></asp:ListItem>
            </asp:DropDownList>
        </fieldset>
    </div>
    <br />
    <div align="center" id="message">
    </div>
</asp:Content>
