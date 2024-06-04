<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Create AJAX-enabled WCF Service</title>

    <script language="javascript" type="text/javascript">

        function btnCallWCF_onclick() {
            var greeto = new GreetNM.GreetingService();
            greeto.GreetUser($get("txtUNm").value, OnGreetingComplete, OnError);          
        }

        function OnGreetingComplete(result) {
            $get("dispGreeting").innerHTML = result;
        }

        function OnError(result) {
            alert(result.get_message());
        } 
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
            <Services>
                <asp:ServiceReference Path="~/GreetingService.svc" />
            </Services>
        </asp:ScriptManager>
        
        <input id="btnCallWCF" type="button" value="Greet User" onclick="return btnCallWCF_onclick()" />
        <input id="txtUNm" type="text" />
        <div id="dispGreeting">
        </div>
    </div>
    </form>
</body>
</html>
