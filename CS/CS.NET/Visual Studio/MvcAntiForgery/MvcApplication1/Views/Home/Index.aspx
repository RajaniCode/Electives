<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Index</title>
</head>
<body>
    <script language="javascript" src="../../Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <script language="javascript" src="../../Scripts/jquery-jtemplates.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">

        $(function () {
            helper.GenerateForm();
        });

        var helper = function () {
            return {
                GenerateForm: function () {
                    var token = '<%: Html.AntiForgeryToken("DynamicToken") %>';
                    $("#generateSomeForm").setTemplateURL("/Templates/CustomForm.htm")
                                          .setParam("RequestVerificationToken", token)
                                          .processTemplate();
                }
            }
        } ();
        
    </script>    
    <div id="generateSomeForm"></div> 
</body>
</html>
