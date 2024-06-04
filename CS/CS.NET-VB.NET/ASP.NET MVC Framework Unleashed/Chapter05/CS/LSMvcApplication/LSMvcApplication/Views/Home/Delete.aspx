<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<LSMvcApplication.Models.Product>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Delete</h2>
    
    

        <% using (Html.BeginForm()) {%>

        <fieldset>
            <legend>Delete</legend>
            <p>
            Delete <%= Html.Encode(Model.Name) %>?
            </p>
            <p>
                <input type="submit" value="Delete" />
            </p>
        </fieldset>

    <% } %>

    
    

</asp:Content>
