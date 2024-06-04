<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

       
    <script type="text/javascript">

        alert("Hello JavaScript Browser!");
    
    </script>
    
    <hr />
    Cached at <%= DateTime.Now.ToString("T") %>


</asp:Content>
