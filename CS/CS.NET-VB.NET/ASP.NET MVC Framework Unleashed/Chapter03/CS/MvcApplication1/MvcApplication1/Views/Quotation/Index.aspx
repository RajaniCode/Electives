<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

  <script src="../../Scripts/jquery-1.2.6.js" type="text/javascript"></script>

  <script type="text/javascript">

      $.ajaxSetup({ cache: false });
      $(getQuote);

      function getQuote() {
          $.getJSON("Quotation/List", showQuote);
      }
      
      function showQuote(data) {
          var index = Math.floor(Math.random() * 3);
          $("#quote").text(data[index]);      
      }
      
  </script>  

    
  <p id="quote"></p>

  <button onclick="getQuote()">Get Quote</button>  


</asp:Content>
