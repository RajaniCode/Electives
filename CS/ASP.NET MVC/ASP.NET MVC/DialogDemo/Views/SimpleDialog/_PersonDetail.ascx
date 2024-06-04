<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<DialogDemo.Models.Person>" %>

    <% using (Html.BeginForm("CustomerEdit", "SimpleDialog", FormMethod.Post, new { id = "target" }))
       {%>
        <%: Html.ValidationSummary(true) %>
        
        <div class="sd-edit-set">
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.PersonId) %>
            </div>
            <div class="sd-editor-field readonly">
                <%: Html.TextBoxFor(model => model.PersonId, new { @readonly = "readonly"})%>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.FirstName) %>
            </div>
            <div class="sd-editor-field">
                <%: Html.TextBoxFor(model => model.FirstName) %>
                <%: Html.ValidationMessageFor(model => model.FirstName) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.LastName) %>
            </div>
            <div class="sd-editor-field">
                <%: Html.TextBoxFor(model => model.LastName) %>
                <%: Html.ValidationMessageFor(model => model.LastName) %>
            </div>
        </div>

        <div class="sd_footer">
            <input type="submit" value="Save" id="btnSubmit" class="tedit_btn" name="#customerInfo" />&nbsp;&nbsp;
            <input type="button" value="Cancel" class="close tedit_btn" />
        </div>
         
    <% } %>
    <script type="text/javascript">

    $(document).ready(function(){

//        var options = { 
//                target:        '#customerInfo',     // target element(s) to be updated with server response 
//                //success:        showResponse,       // post-submit callback 
//                clearForm:      true,              // clear all form fields after successful submit 
//                resetForm:      true               // reset the form after successful submit 
//            };
//        
//        $("#btnSubmit").live('click', function(event){
//            event.preventDefault();
//            $('#targetP').ajaxSubmit(options); 
//            $.simpleDialog.close();
//        });

//        $("#btnSubmit").click( function(event){
//            event.preventDefault();
//            var $target = $("#customerInfo");
//            var $url = $("#target").attr("action");
//            alert ($url);
//            $.ajax({
//                url: $url,
//                type: 'POST',
//                data: $("#target").serialize(),
//                success: function (response) {
//                    $.simpleDialog.close();
//                    $target.html(response);
//                    $("#ajaxResult").hide().html('Record saved.').fadeIn(300, function(){
//		                var e = this;
//		                setTimeout(function() { $(e).fadeOut(400); }, 2500 );
//	                });
//                },
//                error: function (xhr,status) {
//                    displayError(xhr.responseText,status);
//                }
//            });
//        });

    }); 

    </script>