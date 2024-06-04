<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Access ASP.NET WebService using jQuery</title>

    <script src="Scripts/jquery-1.3.2.js" type="text/javascript"></script>
    <script src="Scripts/jquery.jmsajax.js" type="text/javascript"></script>
    
    <script type="text/javascript">
        $(document).ready(function() {
            $.ajax({
                type: "POST",
                url: "EmployeeList.asmx/GetEmployees",
                data: "{}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(list) {
                    $("#Something").append("<ul id='bullets'></ul>");
                    for (i = 0; i < list.d.length; i++) {
                        $("#bullets").append("<li>" + list.d[i].FirstName
                        + " : " + list.d[i].LastName + " : " + list.d[i].BirthDate + "</li>");
                    }
                },
                error: function(e) {
                    $("#Something").html("There was an error retrieving records");
                }
            });

            $.jmsajax({
                url: "EmployeeList.asmx",
                method: "GetEmployees",
                dataType: "msjson",
                success: function(list) {
                    $("#Something").append("<ul id='bullets'></ul>");
                    for (i = 0; i < list.length; i++) {
                        $("#bullets").append("<li>" + list[i].FirstName
                        + " : " + list[i].LastName + " : " + list[i].BirthDate + "</li>");
                    }
                },
                error: function(e) {
                    $("#Something").html("There was an error retreiving records");
                }
            });
        });
    </script>
    
</head>
<body>
    <form id="form1" runat="server">
    <div id="Something">
    
    </div>
    </form>
</body>
</html>
