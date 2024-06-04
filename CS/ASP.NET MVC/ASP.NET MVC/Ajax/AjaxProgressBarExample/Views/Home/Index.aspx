<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>
<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <%= Html.Encode(ViewData["Message"]) %></h2>
    <div>
        <a href="#" id="startProcess">Start Long Running Process</a>
    </div>
    <br />
    <div id="statusBorder">
        <div id="statusFill">
        </div>
    </div>

    <script type="text/javascript">

        var uniqueId = '<%= Guid.NewGuid().ToString() %>';

        $(document).ready(function(event) {
            $('#startProcess').click(function() {
                $.post("Home/StartLongRunningProcess", { id: uniqueId }, function() {
                    $('#statusBorder').show();
                    getStatus();
                });
                event.preventDefault;
            });
        });

        function getStatus() {
            var url = 'Home/GetCurrentProgress/' + uniqueId;
            $.get(url, function(data) {
                if (data != "100") {
                    $('#status').html(data);
                    $('#statusFill').width(data);
                    window.setTimeout("getStatus()", 100);
                }
                else {
                    $('#status').html("Done");
                    $('#statusBorder').hide();
                    alert("The Long process has finished");
                };
            });
        }
    
    </script>

</asp:Content>
