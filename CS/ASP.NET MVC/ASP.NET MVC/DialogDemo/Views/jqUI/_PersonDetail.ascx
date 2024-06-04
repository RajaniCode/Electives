<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<DialogDemo.Models.Person>" %>
    <div id="form-wrapper">
    <% using (Html.BeginForm("CustomerEdit", "jqUI", FormMethod.Post, new { id = "target"} ) )
       {%>
        <%: Html.ValidationSummary(true) %>
        
        <div class="edit-set">
            
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
            </div>
                <%: Html.ValidationMessageFor(model => model.FirstName) %>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.LastName) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.LastName) %>
            </div>
                <%: Html.ValidationMessageFor(model => model.LastName) %>
            
        </div>
         <div class="btn-Panel nonAjax"><input type="submit" value="Save" class="button"/></div>
         
    <% } %>
</div>
    


