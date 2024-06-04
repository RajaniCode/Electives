<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="CheckBoxListItems.aspx.cs" Inherits="CheckBoxListItems" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script type="text/javascript">

        $(document).ready(function () {
            $('#<%=CheckBoxList1.ClientID%>').click(function () {
                var str = "";

                $('#<%=CheckBoxList1.ClientID%> input[type=checkbox]').each(function () {
                    if ($(this).is(':checked')) {
                        str = str + " - " + $(this).next().text();
                    }
                });

                $('#message').text(str);
            });
        });    
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div align="left">
        <fieldset style="width: 400px; height: 150px;">
            <p>
                Select Language:</p>
            <asp:CheckBoxList ID="CheckBoxList1" runat="server">
                <asp:ListItem Text="C#" Value="1"></asp:ListItem>
                <asp:ListItem Text="VB" Value="2"></asp:ListItem>
                <asp:ListItem Text="Java" Value="3"></asp:ListItem>
                <asp:ListItem Text="PHP" Value="4"></asp:ListItem>
            </asp:CheckBoxList>
        </fieldset>
        <br />
        <div id="message">
        </div>
    </div>
</asp:Content>
