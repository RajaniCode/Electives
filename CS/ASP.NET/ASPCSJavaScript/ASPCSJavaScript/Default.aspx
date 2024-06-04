<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ASPCSJavaScript._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <script type="text/javascript">
        function Check() {
            var v = document.getElementById('TextBox1');
            alert("isNaN(" + v.value + ") = " + isNaN(v.value) + "\n"
                + "isFinite(" + v.value + ") = " + isFinite(v.value));

            v.value = null;
            
            alert("isNaN(" + v.value + ") = " + isNaN(v.value) + "\n"
                + "isFinite(" + v.value + ") = " + isFinite(v.value));
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        
    
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Button" OnClientClick="Check();" />
    
        
    
    </div>
    </form>
</body>
</html>
