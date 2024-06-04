<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<DialogDemo.Models.Book>" %>
    <% using (Html.BeginForm("BookEdit", "SimpleDialog", FormMethod.Post, new { id = "target"} )) {%>
        <%: Html.ValidationSummary(true) %>
        
        <div class="sd-edit-set">
            
            <div class="sd-editor-field-hidden">
                <%: Html.TextBoxFor(model => model.CustomerID) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.BookId) %>
            </div>
            <div class="sd-editor-field readonly">
                <%: Html.TextBoxFor(model => model.BookId, new { @readonly = "readonly" })%>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Title) %>
            </div>
            <div class="sd-editor-field">
                <%: Html.TextBoxFor(model => model.Title) %>
                <%: Html.ValidationMessageFor(model => model.Title) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Author) %>
            </div>
            <div class="sd-editor-field">
                <%: Html.TextBoxFor(model => model.Author) %>
                <%: Html.ValidationMessageFor(model => model.Author) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.PublicationYear) %>
            </div>
            <div class="sd-editor-field">
                <%: Html.TextBoxFor(model => model.PublicationYear) %>
                <%: Html.ValidationMessageFor(model => model.PublicationYear) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Price) %>
            </div>
            <div class="sd-editor-field">
                <%: Html.TextBoxFor(model => model.Price) %>
                <%: Html.ValidationMessageFor(model => model.Price) %>
            </div>
        </div>

       <div class="sd_footer nonAjax">
            <input type="submit" value="Save" id="btGridSubmit" class="tedit_btn" name="#bookInfo"/>&nbsp;&nbsp;
            <input type="button" value="Cancel" class="close tedit_btn" />
       </div>

    <% } %>