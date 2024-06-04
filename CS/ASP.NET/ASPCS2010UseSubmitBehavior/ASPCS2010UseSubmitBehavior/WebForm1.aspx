<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ASPCS2010UseSubmitBehavior.WebForm1" %>

<script runat="server">
  protected void SubmitBtn_Click(object sender, EventArgs e)
  {
      Message.Text = "The Button uses ASP.NET postback mechanism";    
  }
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>    
        Click the Submit button.
    <br /><br /> 
   <%--The value of the UseSubmitBehavior property is false. Therefore the button uses the ASP.NET postback mechanism.--%>
    <asp:Button id="Button1" runat="server" Text="Submit" OnClick="SubmitBtn_Click" UseSubmitBehavior="false" />  
    <br /><br />
    <asp:label id="Message" runat="server"/>
    </div>
    </form>
</body>
</html>
