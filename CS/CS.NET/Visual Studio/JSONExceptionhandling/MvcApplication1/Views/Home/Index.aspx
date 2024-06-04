<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <form method="get" action="/Home/ThrowAjaxError" id="RunAjaxForm">
        <input type="submit" id="RunAjax" value="Run Ajax" />
    </form>    
    
    <script language="javascript" type="text/javascript" src="../../Scripts/jquery-1.3.2.js"></script>
    <script language="javascript" type="text/javascript" src="../../Scripts/json2.js"></script>
    <script language="javascript" type="text/javascript">
        $(function () {
            $("#RunAjaxForm").submit(function (e) {
                e.preventDefault();
                $.ajax({
                    type: "GET",
                    url: this.action,
                    data: {},
                    dataType: "json",
                    success: function (msg) {
                        alert(msg);
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        var msg = JSON.parse(XMLHttpRequest.responseText);
                        alert(msg.Message);
                    }
                });
            });
        });        
    </script>
</asp:Content>
