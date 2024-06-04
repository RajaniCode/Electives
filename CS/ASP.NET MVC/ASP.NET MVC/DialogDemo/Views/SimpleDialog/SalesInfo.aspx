<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<DialogDemo.Models.HomeViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	SalesInfo
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="font-size:1.2em; background-color: #FF9E9E; padding: 5px 0 5px 10px; border: 1px solid gray; width: 300px;">SimpleDialog &nbsp;&nbsp;&nbsp;&nbsp;
    <a href="http://code.google.com/p/jquery-simpledialog/" target="_blank"><span style="font-size: 0.85em; font-weight: normal">More information...</span></a></div> 
    <h3>Customer Information</h3>
    <div id="customerInfo">
    <% Html.RenderPartial("Customer", Model.person); %>
    </div>
    <p>     
        <%: Html.ActionLink("Edit", "CustomerEdit", new { customerid = Model.person.PersonId }, new { @class = "modalDlg", title = "Edit Customer" })%> 
    </p>
    <div id="ajaxResult"><%= TempData["message"].ToString() %></div>
    <hr />

    <h3>Sales Information</h3>
    <% Html.RenderPartial("BookList", Model.cart); %>
    <p>
    <%: Html.ActionLink("Home", "Index", "Home") %>
    </p>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="../../Content/simpleDialog/jquery.simpledialog.0.1.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/simpleDialog/jquery.simpledialog.0.1.js" type="text/javascript"></script>
    <script src="../../Scripts/simpleDialog/jquery.form.js" type="text/javascript"></script>

    <script type="text/javascript">

    $(document).ready(function(){

        $('a.modalDlg').simpleDialog({
            opacity: 0.3, 
            duration: 200, 
            width: 450,
            useTitleAttr: true,
            closeLabel: '<img src="../../Content/simpleDialog/CloseButton2.gif" border="0"/>',
            showCloseLabel: true
        });

        $('a.abookModal').simpleDialog({
                opacity: 0.3, 
                duration: 200, 
                width: 450,
                useTitleAttr: true,
                closeLabel: '<img src="../../Content/simpleDialog/CloseButton2.gif" border="0"/>',
                showCloseLabel: true
        });
 
        // jQuery Ajax-Post only works in repeatable manner when link that opens SimpleDialog can be placed 
        // outside the PartialView. Otherwise, calls to SimpleDialog fail on second and subsequent clicks. 
        // Need to use full postback in this case.
        $("#btnSubmit").live('click', function(event){
            event.preventDefault();
            var $target = $(this).attr("name");
            var $url = $("#target").attr("action");
            $.ajax({
                url: $url,
                type: 'POST',
                data: $("#target").serialize(),
                success: function (response) {
                    $.simpleDialog.close();
                    $($target).html(response);
                    $("#ajaxResult").hide().html('Record saved.').fadeIn(300, function(){
		                var e = this;
		                setTimeout(function() { $(e).fadeOut(400); }, 2000 );
	                });
                },
                error: function (xhr,status) {
                    $("#ajaxResult").html(xhr.responseText).show();
                    $.simpleDialog.close();
                }
            });
        });

    }); 

    </script>

</asp:Content>
