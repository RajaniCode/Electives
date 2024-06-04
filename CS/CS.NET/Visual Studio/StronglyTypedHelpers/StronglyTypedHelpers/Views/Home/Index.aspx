<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcApplication1.Models.Person>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
        
        <fieldset>
            <legend>Fields</legend>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Name) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Name) %>
                <%= Html.TextBox("Name") %>
                <%: Html.ValidationMessageFor(model => model.Name) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Age) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Age) %>
                <%: Html.ValidationMessageFor(model => model.Age) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.DOB) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.DOB, String.Format("{0:g}", Model.DOB)) %>
                <%: Html.ValidationMessageFor(model => model.DOB) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Married) %>
            </div>
            <div class="editor-field">
                <%: Html.CheckBoxFor(model => model.Married) %>
                <%: Html.ValidationMessageFor(model => model.Married) %>
            </div>
            
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

