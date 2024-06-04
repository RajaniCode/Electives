<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ASPCS2008ClientCallbackwithValidation._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>ASP.NET Example</title>
<script type="text/javascript">    
    function ReceiveServerData(rValue)
    {
        Results.innerText = rValue;
    }
  </script>
</head>
<body>
  <form id="form1" runat="server">
    <div>
      <asp:ListBox id="ListBox1" runat="server"></asp:ListBox>
      <br />
      <br />
      <button id="LookUpStockButton" onclick="LookUpStock()">Look Up Stock</button>
      <asp:LoginView id="LoginView1" runat="server">
      <LoggedInTemplate>
         <button id="LookUpSaleButton" onclick="LookUpSale()">Look Up Back Order</button>
      </LoggedInTemplate>
      </asp:LoginView>
      <br />
      Item status: <span id="Results"></span>
    </div>
  </form>
</body>
</html>
