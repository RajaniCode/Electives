<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<DialogDemo.Models.Person>" %>

    <% using (Html.BeginForm("CustomerEdit", "Colorbox", FormMethod.Post, new { id = "target"} ) )
       {%>
        <%: Html.ValidationSummary(true) %>
        
        <div class="edit-set-cbox">
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.PersonId) %>
            </div>
            <div class="editor-field readonly">
                <%: Html.TextBoxFor(model => model.PersonId, new { @readonly = "readonly"})%>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.FirstName) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.FirstName) %>
                <%: Html.ValidationMessageFor(model => model.FirstName) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.LastName) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.LastName) %>
                <%: Html.ValidationMessageFor(model => model.LastName) %>
            </div>
        </div>
         <div class="nonAjax"><input type="submit" value="Save" class="button-cbox"/></div>
         
    <% } %>

    


