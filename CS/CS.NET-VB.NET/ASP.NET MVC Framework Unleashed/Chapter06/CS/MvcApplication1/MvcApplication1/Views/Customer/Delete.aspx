<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="Helpers" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Delete Account?</h2>
    
    <%= Html.ImageLink("Delete", "~/Content/Delete.png", "Delete Account", new {AccountId=2}, null, new {border=0}) %>
    

</asp:Content>
