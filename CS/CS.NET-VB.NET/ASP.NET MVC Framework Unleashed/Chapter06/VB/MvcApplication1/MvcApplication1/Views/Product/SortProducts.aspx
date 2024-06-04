<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of IEnumerable (Of MvcApplication1.Product))" %>
<%@ Import Namespace="MvcApplication1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <%= Html.DataGrid(Of Product)(ViewData("products"), new string() {"Id", "Name", "Price"}) %>

</asp:Content>
