<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MvcApplication1.Models.ServiceData>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1/jquery.min.js" language="javascript" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        $(function() {
            var title = "";
            var toolTip = $("<div id=\"toolTipCss\"></div>")
                                .appendTo("body")
                                .hide();
            $("#listServices").bind("mouseover mouseout", function(event) {
                var link = $(event.target).closest("a");
                if (link.length == 0) {
                    return;
                }

                var linkFound = link[0];
                if (event.type == "mouseover") {
                    title = linkFound.title;
                    linkFound.title = "";
                    toolTip.html("<div class=\"toolTipText\">" + title + "</div><div class=\"toolTipText\"><br />" + linkFound.text + "</div>")
                          .show()
                          .css(
                          {
                              top: event.pageY - 40,
                              left: event.pageX + 10,
                              opacity: 0
                          })
                          .animate(
                          {
                              left: "+=25",
                              opacity: 1
                          }, "7000");
                }

                if (event.type == "mouseout") {
                    linkFound.title = title;
                    toolTip.animate(
                        {
                            opacity: 0
                        }, "5000");
                }
            });
        });
    </script>
    <h2>Get Services</h2>
    <div id="listServices">
        <% foreach (var service in (IEnumerable<MvcApplication1.Models.ServiceData>)Model)
           { %>
        <a href="#" title="<%= service.Description %>">
            <%= service.Caption %></a>
        <br />
        <br />
        <% } %>
    </div>
</asp:Content>
