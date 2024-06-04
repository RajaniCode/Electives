<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Save Retrieve Images</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="lblEmpName" runat="server" Text="Employee Name"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtEName" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblImage" runat="server" Text="Employee Image"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:FileUpload ID="imgUpload" runat="server" />
        <br />
        <br />
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" />
    
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblResult" runat="server" ForeColor="#0066FF"></asp:Label>
    <br />
    <hr />
   
   <asp:Image ID="Image1" style="width:200px" Runat="server" />

    
    
    </div>
    </form>
</body>
</html>
