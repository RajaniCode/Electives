<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <%= Html.DropDownList("Numbers",(IEnumerable<SelectListItem>)ViewData["Services"]) %>
    
    <select id="Select1">        
    </select>
    
    <select id="Select2">        
    </select>
    
    <input type="button" id="Button1" value="Fill By Array" />
    <input type="button" id="Button2" value="Fill By jTemplates" />
    
    <script language="javascript" type="text/javascript" src="../../Scripts/jquery-1.3.2.js"></script>
    <script language="javascript" type="text/javascript" src="http://jtemplates.tpython.com/jTemplates/jquery-jtemplates.js"></script>
    <script language="javascript" type="text/javascript">
        $(function() {
            $("#Button1").click(function(e) {
                e.preventDefault();
                var data = [];
                $.getJSON("/Home/GetListViaJson", null, function(data) {
                    data = $.map(data, function(item, a) {
                        return "<option value=" + item.Value + ">" + item.Text + "</option>";
                    });
                    $("#Select1").html(data.join(""));
                });
            });

            $("#Button2").click(function(e) {
                e.preventDefault();                
                $.getJSON("/Home/GetListViaJson", null, function(data) {
                    $("#Select2").setTemplateURL("/Templates/DropDownList.htm").processTemplate(data);
                });
            });
        });    
    </script>
</asp:Content>
