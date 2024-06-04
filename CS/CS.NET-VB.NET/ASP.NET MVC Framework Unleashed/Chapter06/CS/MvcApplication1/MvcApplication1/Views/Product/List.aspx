<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="Helpers" %>
<%@ Import Namespace="MvcApplication1.Models" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<%= Html.DataGrid<Product>(ViewData["products"], new string[] {"Id", "Name"}) %>
    

</asp:Content>
