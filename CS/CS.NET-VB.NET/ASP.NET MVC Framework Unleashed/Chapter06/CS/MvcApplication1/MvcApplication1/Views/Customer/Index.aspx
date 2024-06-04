<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <p>
    <%= Html.DropDownList("CustomerId") %>
    </p>

</asp:Content>
