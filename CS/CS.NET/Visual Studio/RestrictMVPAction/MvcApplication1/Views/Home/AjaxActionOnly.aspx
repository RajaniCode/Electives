<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AjaxActionOnly</title>
</head>
<body>
    <div>
        <script language="javascript" type="text/javascript" src="<%: Url.Content("~/Scripts/jquery-1.4.1.js") %>"></script>
        <script language="javascript" type="text/javascript">
            $(function () {
                $("#Button1").click(function (e) {
                    e.preventDefault();
                    $.getJSON("/Home/AjaxActionOnly", null, function (data) {
                        alert(data);
                    });
                });
            });
        </script>
        <form>
            <input id="Button1" type="button" value="Get Session Timeout" />
        </form>
    </div>
</body>
</html>
