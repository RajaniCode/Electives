<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <script src="../../Scripts/MicrosoftAjax.js" type="text/javascript"></script>
    <script src="../../Scripts/MicrosoftMvcAjax.js" type="text/javascript"></script>

    <h2>Index</h2>

    <%=Ajax.ActionLink( _
        "Delete", _
        "Delete", _
        New With {.id = 39}, _
        New AjaxOptions With {.HttpMethod = "DELETE", .Confirm = "Delete Employee?"} _
    )%>
    
    
    <%=DateTime.Now%>

</asp:Content>
