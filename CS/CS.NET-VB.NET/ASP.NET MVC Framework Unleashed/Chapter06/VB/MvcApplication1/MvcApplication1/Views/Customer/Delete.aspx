<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="MvcApplication1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Delete Account?</h2>
    
    <%= Html.ImageLink("Delete", "~/Content/Delete.png", "Delete Account", New With {.AccountId=2}, Nothing, New With {.border=0}) %>
    

</asp:Content>
