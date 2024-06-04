<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <script src="../../Scripts/MicrosoftAjax.js" type="text/javascript"></script>
    <script src="../../Scripts/MicrosoftMvcAjax.js" type="text/javascript"></script>

    <h2>Index</h2>

    <%= Ajax.ActionLink
        (
            "Delete",   // link text 
            "Delete",   // action name
            new {id=39}, // route values
            new AjaxOptions {HttpMethod="DELETE", Confirm="Delete Employee?"}
        ) %>

</asp:Content>
