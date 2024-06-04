<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ASPCS2010JavaScriptCallWebService.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        // Another way to add Web Service reference in the server-side code 
        ScriptManager1.Services.Add(new ServiceReference("~/WebServices/SampleWebService.asmx"));
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script language="javascript" type="text/javascript">
        function buttonOnClick() {
            SampleWebService.GetServerResponse(form1.text1.value, OnComplete, OnError, OnTimeOut);
        }

        function ButtonOnClientClick() {
            SampleWebService.GetServerResponse(form1.TextBox1.value, OnComplete, OnError, OnTimeOut);
        }

        function OnComplete(arg) {
            alert(arg);
        }

        function OnTimeOut(arg) {
            alert("Time Out occured");
        }

        function OnError(arg) {
            alert("Error has occured: " + arg._message);
        }
	</script>
</head>
<body>
    <form id="form1" runat="server">
		<asp:ScriptManager ID="ScriptManager1" runat="server">
			<%--<Services>
				<asp:ServiceReference Path="~/WebServices/SampleWebService.asmx" />
			</Services>--%>
		</asp:ScriptManager>
		<div>
			<input type="text" value="" id="text1" />
			<input type="button" value="Send Request to the Web Service" id="button1" onclick="return buttonOnClick();" />
            <br />
            <br />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Button ID="Button2" runat="server" Text="Send Request to the Web Service" OnClientClick="return ButtonOnClientClick();" />
		</div>
    </form>
</body>
</html>

