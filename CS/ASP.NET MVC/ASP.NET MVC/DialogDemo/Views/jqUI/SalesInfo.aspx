<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<DialogDemo.Models.HomeViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	SalesInfo
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="font-size:1.2em; background-color: #BDFFEB; padding: 5px 0 5px 10px; border: 1px solid gray; width: 300px;">jQuery UI-Dialog&nbsp;&nbsp;&nbsp;&nbsp;
    <a href="http://jqueryui.com/demos/dialog/"><span style="font-size: 0.85em; font-weight: normal">More information...</span></a></div> 
    <h3>Customer Information</h3>
    <% Html.RenderPartial("Customer", Model.person); %>

    <hr />
    <div id="ajaxResult"></div>
    <h3>Sales Information</h3>
    <% Html.RenderPartial("BookList", Model.cart); %>

    <%: Html.ActionLink("Home", "Index", "Home") %>
    
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">

    <link href="../../Content/themes/pepper-grinder/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/uiDialog/jquery-ui-1.8.custom.min.js" type="text/javascript"></script>
    <script src="../../Scripts/uiDialog/jquery.effects.core.js" type="text/javascript"></script>
    <script src="../../Scripts/uiDialog/jquery.effects.fade.js" type="text/javascript"></script>
<style type="text/css"> 
div.btn-Panel 
{
    display: none;
}
</style>

    <script type="text/javascript">

    $(function () {

        $('a.modalDlg').live("click", function(event) {loadDialog(this, event, '#customerInfo');});
        $('a.abookModal').live("click", function(event) {loadDialog(this, event, '#bookInfo');});
        $('a.abookCreate').live("click", function(event) {addItem(this, event, '#bookInfo');});

        $(".deleteButton").live("click", function(e) {
		    e.preventDefault();
		    var $btn = $(this);
		    var $msg = $(this).attr("title");

		    confirmDelete($msg, 
			    function() {
				    deleteRow($btn);
			    });
        });
        
    }); /* end document.ready() */
    
    function loadDialog(tag, event, target) {
        event.preventDefault();
        var $loading = $('<img src="../../Content/images/ajaxLoading.gif" alt="loading" class="ui-loading-icon">');
        var $url = $(tag).attr('href');
        var $title = $(tag).attr('title');
        var $dialog = $('<div></div>');
        $dialog.empty();
        $dialog
            .append($loading)
            .load($url)
		    .dialog({
			    autoOpen: false
			    ,title: $title
			    ,width: 500
                ,modal: true
			    ,minHeight: 200
                ,show: 'fade'
                ,hide: 'fade'
		    });

        $dialog.dialog( "option", "buttons", {
                "Cancel": function() { 
                        $(this).dialog("close");
                        $(this).empty();
                    }, 
                "Submit": function () {
                    var dlg = $(this);
                    $.ajax({
                        url: $url,
                        type: 'POST',
                        data: $("#target").serialize(),
                        success: function (response) {
                            $(target).html(response);
                            dlg.dialog('close');
                            dlg.empty();
                            $("#ajaxResult").hide().html('Record saved').fadeIn(300, function(){
		                        var e = this;
		                        setTimeout(function() { $(e).fadeOut(400); }, 2500 );
	                        });
                        },
                        error: function (xhr) {
                            if (xhr.status == 400) 
                                dlg.html(xhr.responseText, xhr.status);     /* display validation errors in edit dialog */
                            else 
                                displayError(xhr.responseText, xhr.status); /* display other errors in separate dialog */
                                   
                        }
                    });
                }
        });

        $dialog.dialog('open');
    };

    function displayError(message, status)
    {
        var $dialog = $(message);
            $dialog
                .dialog({
			    modal: true,
                title: status + ' Error',
			    buttons: {
			    Ok: function() {
				    $(this).dialog( "close" );
			    }
		    }
	    }); 
        return false;             
    };

    function confirmDelete(message, callback) {
        var $deleteDialog = $('<div>Are you sure you want to delete ' + message + '?</div>');
            
        $deleteDialog
            .dialog({
			resizable: false,
			height:140,
            title: "Delete Record?",
			modal: true,
			buttons: {
				"Delete": function() {
					$(this).dialog( "close" );
                    callback.apply();
				},
				Cancel: function() {
					$(this).dialog( "close" );
				}
			}
		});
     };

    function deleteRow($btn) {
        $.ajax({
            url: $btn.attr('href'),
            //type: 'POST',
            success: function (response) { 
                $("#ajaxResult").hide().html(response).fadeIn(300, function(){
                    var e = this;
                    setTimeout(function() { $(e).fadeOut(400); }, 2500 );
                });
            },
            error: function (xhr) {
                displayError(xhr.responseText, xhr.status); /* display errors in separate dialog */                    
            }
        });
        return false;
    };

    function addItem(tag, event, target) {
        event.preventDefault();
        var $url = $(tag).attr('href');
        var $title = $(tag).attr('title');
        var $dialog = $('<div></div>');
        $dialog.empty();
        $dialog
            .load($url)
			.dialog({
				autoOpen: true
				,title: $title
				,width: 500
				,minHeight: 200
                ,show: 'fade'
                ,hide: 'fade'
			});

        $dialog.dialog( "option", "buttons", {
                "Cancel": function() { 
                        $(this).dialog("close"); 
                        $(this).empty();
                    }, 
                "Submit": function () {
                    var dlg = $(this);
                    var $frm = $("#frmData");
                    $.ajax({
                        url: $frm.attr('action'),
                        type: 'POST',
                        data: $frm.serialize(),
                        success: function (data, textStatus, xhr) {
                                $('#bookInfo').html(data);
                                $("#bookResult").hide().fadeIn(300, function(){
		                            var e = this;
		                            setTimeout(function() { $(e).fadeOut(400); }, 2500 );
	                            });
                                dlg.dialog('close');
                                dlg.empty();
                        },
                        error: function (xhr,status) {
                            displayError(xhr.responseText);
                        }
                    });
                }
        });
    };
    </script>

</asp:Content>

