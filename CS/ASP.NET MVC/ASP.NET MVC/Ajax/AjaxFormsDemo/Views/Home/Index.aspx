<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<AjaxFormsDemo.Models.Customer>" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Index</title>
    <script src='<%= Url.Content("~/Scripts/jquery-1.7.1.min.js") %>'></script>
    <script src='<%= Url.Content("~/Scripts/jquery.unobtrusive-ajax.min.js") %>'></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#divProgress").css("display","none");
        });
        function OnBegin() {
            $("#divMsg").append("<h3>Beginning Ajax request.</h3>");
        }
        function OnComplete() {
            $("#divMsg").append("<h3>Completing Ajax request.</h3>");
        }
        function OnSuccess() {
            $("#divMsg").append("<h3>Ajax request successful.</h3>");
        }
        function OnFailure() {
            $("#divMsg").append("<h3>Ajax request failed.</h3>");
        }
    </script>
</head>
<body>
    <%
        AjaxOptions options = new AjaxOptions();
        options.HttpMethod = "POST";
        options.Confirm = "Do you wish to submit this form?";
        options.OnBegin = "OnBegin";
        options.OnComplete = "OnComplete";
        options.OnFailure = "OnFailure";
        options.OnSuccess = "OnSuccess";
        options.LoadingElementDuration = 1000;
        options.LoadingElementId = "divProgress";
        options.UpdateTargetId = "divResponse";
        options.InsertionMode = InsertionMode.InsertAfter;
    %>

    <% using(Ajax.BeginForm("ProcessForm","Home",options)){ %>
    <%= Html.LabelFor(c=>c.CustomerID) %>
    <br />
    <%= Html.TextBoxFor(c=>c.CustomerID,new {@readonly="readonly"}) %>
    <br />
    <%= Html.LabelFor(c=>c.CompanyName) %>
    <br />
    <%= Html.TextBoxFor(c=>c.CompanyName) %>
    <br />
    <input type="submit" value="Submit" />
    <br />
    <br />
    <%= Ajax.ActionLink("Click here to invoke ProcessLink action.","ProcessLink",options) %>
    <%}%>

    <br />
    <br />
    <div id="divProgress">
        <img src='<%= Url.Content("~/images/ProgressCircle.gif") %>' />
    </div>
    <div id="divResponse"></div>
    <div id="divMsg"></div>
</body>
</html>
