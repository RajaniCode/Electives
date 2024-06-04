<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Unknown</h2>

    <p>
    Sorry, I don't recognize 
    the action <b><%=Html.Encode(ViewData("actionName"))%></b>.
    </p>

</asp:Content>
