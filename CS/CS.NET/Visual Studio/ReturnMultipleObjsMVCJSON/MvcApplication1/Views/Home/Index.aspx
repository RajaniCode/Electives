<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <div id="demo"></div>
    <form method="get" action="/Home/ReturnMultipleObjects" id="GetData">
        <input type="submit" value="Get Data" />
    </form>
    <script language="javascript" type="text/javascript" src="../../Scripts/jquery-1.3.2.js"></script>
    <script language="javascript" type="text/javascript" src="http://jtemplates.tpython.com/jTemplates/jquery-jtemplates.js"></script>
    <script language="javascript" type="text/javascript">
        $(function() {
            $("#GetData").submit(function(e) {
                e.preventDefault();
                $.getJSON($(this).attr("action"), $(this).serialize(), function(data) {
                    process.template($("#demo"), data, "/Templates/Demo.htm");
                });
            });
        });

        var process = function() {
            return {
                template: function(element, data, url) {
                    element.setTemplateURL(url).processTemplate(data);
                }
            }
        } ();        
    </script>
</asp:Content>
