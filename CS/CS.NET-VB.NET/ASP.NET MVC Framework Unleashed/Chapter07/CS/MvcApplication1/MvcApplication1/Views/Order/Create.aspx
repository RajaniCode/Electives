<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <% using (Html.BeginForm())
       {%>

        <fieldset>
            <legend>Billing Address</legend>

            <label for="Billing.Street">Street:</label>    
            <br /><%= Html.TextBox("Billing.Street")%>
      
            <br /><br />
            <label for="Billing.City">City:</label>    
            <br /><%= Html.TextBox("Billing.City")%>
      
      
            <br /><br />
            <label for="Billing.ZIP">ZIP:</label>    
            <br /><%= Html.TextBox("Billing.ZIP")%>
        </fieldset>

        <fieldset>
            <legend>Shipping Address</legend>

            <label for="Shipping.Street">Street:</label>    
            <br /><%= Html.TextBox("Shipping.Street")%>
      
            <br /><br />
            <label for="Shipping.City">City:</label>    
            <br /><%= Html.TextBox("Shipping.City")%>
      
      
            <br /><br />
            <label for="Shipping.ZIP">ZIP:</label>    
            <br /><%= Html.TextBox("Shipping.ZIP")%>
        </fieldset>

        <input type="submit" value="Submit Addresses" />
        
        <% } %>

</asp:Content>
