<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="Helpers" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>All Customers</h2>

    <%= Html.BulletedList("Customers") %>

</asp:Content>
