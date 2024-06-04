<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ASPCS2008ClientCallbackImplementation._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
  <title>Client Callback Example</title>
  <script type="text/ecmascript">
    function LookUpStock() {
//        try
//        {
            var lb = document.getElementById("ListBox1");
            var product = lb.options[lb.selectedIndex].text;
            CallServer(product, "");
//        }
//        catch(Error)
//        {
//            alert("Please select an item.");
//        }
    }

    function ReceiveServerData(rValue)
    {   
        document.getElementById("ResultsSpan").innerHTML = rValue;

    }
  </script>
</head>
<body>
  <form id="form1" runat="server">
    <div>
      <asp:ListBox ID="ListBox1" Runat="server"></asp:ListBox>
      <br />
      <br />
      <button type="Button" onclick="LookUpStock()">Look Up Stock</button>
      <br />
      <br />
      Items in stock: <span id="ResultsSpan" runat="server"></span>
      <br />
    </div>
  </form>
</body>

</html>
