<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<DialogDemo.Models.Book>" %>

    <% using (Html.BeginForm("BookCreate", "jqUi", FormMethod.Post, new { id = "frmData"} )) {%>
        <%: Html.ValidationSummary(true) %>
        
        <div class="edit-set">

            <div class="editor-label">
                <%: Html.LabelFor(model => model.Title) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Title) %>
                <%: Html.ValidationMessageFor(model => model.Title) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Author) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Author) %>
                <%: Html.ValidationMessageFor(model => model.Author) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.PublicationYear) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.PublicationYear) %>
                <%: Html.ValidationMessageFor(model => model.PublicationYear) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Price) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Price) %>
                <%: Html.ValidationMessageFor(model => model.Price) %>
            </div>
        </div>

    <% } %>


