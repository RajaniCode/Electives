<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<DialogDemo.Models.HomeViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	SalesInfo
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="font-size:1.2em; background-color: #BDE2FF; padding: 5px 0 5px 10px; border: 1px solid gray; width: 300px;">ColorBox Dialog&nbsp;&nbsp;&nbsp;&nbsp;
    <a href="http://colorpowered.com/colorbox/" target="_blank"><span style="font-size: 0.85em; font-weight: normal">More information...</span></a></div> 
    <h3>Customer Information</h3>
    <% Html.RenderPartial("Customer", Model.person); %>
    <p>     
        <%: Html.ActionLink("Edit", "CustomerEdit", new { customerid = Model.person.PersonId }, new { @class = "modalDlg", title = "Edit Customer" })%> 
    </p>
    <hr />

    <h3>Sales Information</h3>
    <% Html.RenderPartial("BookList", Model.cart); %>
    <%= TempData["message"].ToString() %>
    <%: Html.ActionLink("Home", "Index", "Home") %>
    <div class="cbox"></div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="../../Content/colorbox/colorbox.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/colorbox/jquery.colorbox.js" type="text/javascript"></script>

<style type="text/css"> 
div.edit-set-cbox
{
    width: 440px;
    padding: 6px 10px 14px 10px;
    background-color: #BADABF;
    margin: 5px 5px 5px 5px;
    border: 3px double #8F8F8F;
}   
div.nonAjax
{
    display: block;
    margin: 5px 0 5px 30px;
}
.button-cbox:hover {
    background-color: white;
    color: #006EFF;
    font-weight: bold;
}
</style>

    <script type="text/javascript">

    $(function () {

        $("a.modalDlg").click(function(){ 
		        $("a.modalDlg").colorbox({
                    href:$(this).attr('href'),
                    close:"close", 
                    transition:"elastic",
                    speed: 500,
                    initialWidth: 400,
                    initialHeight: 200,
                    maxHeight: 300,
                    scalePhotos: true,
                    opacity: 0.50,
                    onComplete: function(){
                        $('.XClose').bind('click', function() {
                            $.colorbox.close();
                        });
                    }
                });
	        });

        $("a.abookModal").click(function(){ 
                $("a.abookModal").colorbox({
                    href:$(this).attr('href'),
                    close:"close", 
                    transition:"elastic",
                    speed: 500,
                    initialWidth: 400,
                    initialHeight: 200,
                    scalePhotos: true,
                    opacity: 0.50,
                    onComplete: function(){
                            $('.XClose').bind('click', function() {
                                $.colorbox.close();
                            });
                        }
                    });
	            });
        
    }); /* end document.ready() */
    

    </script>
</asp:Content>
