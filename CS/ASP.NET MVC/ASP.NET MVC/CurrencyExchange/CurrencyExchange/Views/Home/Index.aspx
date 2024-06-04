<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>
<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">

<script type="text/javascript">
        function onBegin()
        {
            $("#divLoading").html('<image src="../Content/ajax-loader.gif" alt="Loading, please wait" />');
        }
        function onComplete()
        {
            $("#divLoading").html("");
        }
        function onSuccess(context)
        {
            var d = new Date();
            var day = d.getDate();
            var month = d.getMonth() + 1;
            var year = d.getFullYear();

           $("#divLoading").html("Live rates at " + day + "." + month + "." + year + " " + d.getHours() + ":" + d.getMinutes() + ":" + d.getSeconds()); 
        }
  </script>

    <h2>
        Currency Converter
    </h2>
    <div id="divLoading">   
    </div>
    <% using (Ajax.BeginForm("getConversionRate", new AjaxOptions { UpdateTargetId = "Result", OnSuccess = "onSuccess", OnBegin = "onBegin", OnComplete = "onComplete" }))
       { %>
    <%= Html.DropDownList( 
                    "CurrencyFrom", 
                     new [] 
                         { 
                                 new SelectListItem 
                                     { 
                                             Text = "Canada", 
                                             Value = "CAD" 
                                     }, 
                                  new SelectListItem 
                                     { 
                                             Text = "USA", 
                                             Value = "USD" 
                                     }, 
                                  new SelectListItem 
                                     { 
                                             Text = "UK", 
                                             Value = "GBP" 
                                     } 
                }, 
               "From this currency:"   
             ) %>
    <%= Html.DropDownList( 
                    "CurrencyTo", 
                     new [] 
                         { 
                                 new SelectListItem 
                                     { 
                                             Text = "Canada", 
                                             Value = "CAD" 
                                     }, 
                                  new SelectListItem 
                                     { 
                                             Text = "USA", 
                                             Value = "USD" 
                                     }, 
                                  new SelectListItem 
                                     { 
                                             Text = "UK", 
                                             Value = "GBP" 
                                     } 
                }, 
               "To this currency:"   
             ) %>
    <input type="submit" value="Submit" /><br />
    <h1>
        <span id="Result"></span>
    </h1>
    <% } %>
</asp:Content>
