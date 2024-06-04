<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

        
    <h1>Hello Browser without JavaScript!</h1>        
    <hr />
    Cached at <%= DateTime.Now.ToString("T") %>


</asp:Content>
