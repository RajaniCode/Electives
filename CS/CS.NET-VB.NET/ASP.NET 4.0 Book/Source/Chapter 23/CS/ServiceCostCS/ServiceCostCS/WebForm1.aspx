<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ServiceCostCS.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #Text1 {
            height: 22px;
            width: 128px;
        }
        #Button1
        {
            width: 142px;
        }
    </style>
    <script language="javascript" type="text/javascript">
// <![CDATA[

        function Button1_onclick() {
            var service = new ServiceCostCS.MyService();
            service.CostOfServices(Text1.value, onSucess, onerror, null, null);
        }

function onSucess(result)
{
    alert("The Total Cost is: " + result);
}
function onerror(a) {
    alert("Error" + a);
}


// ]]>
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
            <Services>
                <asp:ServiceReference Path="MyService.svc" />
            </Services>
        </asp:ScriptManager>
    </div>
    </form>
    <p>
        Enter a number: </p>
    <p>
        <br />
        <input id="Text1" type="text" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <input id="Button1" type="button" 
            value="Show Value" onclick="return Button1_onclick()" /></p>
</body>
</html>
