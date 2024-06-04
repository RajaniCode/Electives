<%@ Page Language="C#" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
 "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Show Web Service Method</title>
    <script type="text/javascript" src="./Scripts/jquery-1.4.1.js"></script>

    <script type="text/javascript">

        $(document).ready(function () {
            $("#btnGet").click(function () {
                $.ajax({
                    type: "POST",
                    dataType: "json",
                    contentType: "application/json",
                    url: "QuotationService.asmx/GetQuotex",
                    success: function (data) {
                        $("#spanQuote").html(data.d);
                    },
                    error: function () {
                        alert("The call to the web service failed.");
                    }
                })
            });
        });

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>

        <input id="btnGet" type="button" value="Get Quote" />
        <br /><br />
        <span id="spanQuote"></span>

    </div>
    </form>
</body>
</html>
