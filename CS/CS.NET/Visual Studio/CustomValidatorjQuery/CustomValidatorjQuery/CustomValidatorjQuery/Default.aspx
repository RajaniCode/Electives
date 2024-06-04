<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CustomValidator using jQuery</title>

    <script src="Scripts/jquery-1.3.2.js" type="text/javascript"></script>
    
    <script type="text/javascript">
        function chkAddressField(sender, args) {
            args.IsValid = false;
            $(".txtAdd").each(function() {
                if (/^[A-Za-z0-9&()-]{10,50}$/.test(this.value)) {
                    args.IsValid = true;
                }               
            });            
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Address : "></asp:Label>
        <asp:TextBox ID="TextBox1" TextMode="MultiLine" runat="server" CssClass='txtAdd'/>
        <br />
    <asp:CustomValidator ID="CustomValidator1" runat="server" Display="Dynamic"
    ErrorMessage="Field cannot be blank<br/>Minimum 10, Maximum 50 chars allowed<br/>Only AlphaNumeric and Special Characters like &()- allowed" 
    ClientValidationFunction="chkAddressField" 
        onservervalidate="CustomValidator1_ServerValidate" >
    </asp:CustomValidator>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Submit" />
       </div>
    </form>
</body>
</html>
