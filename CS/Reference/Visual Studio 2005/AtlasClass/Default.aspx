<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <atlas:ScriptManager ID="ScriptManager1" runat="server" />
        <div>
        </div>
    </form>
    <script language="javascript" type="text/javascript" src="Components.js">
    </script>
    <script language="javascript">
        Check1();
        function Check1()
        {
        var obj = new NameSpaceCustomer.clsCustomer();
        obj.set_CustomerCode('Cust001');
        obj.set_CustomerName('Koirala Enterprises');
        obj.getCodeAndName();
        }
    </script>
    <script type="text/xml-script">
        <page xmlns:script="http://schemas.microsoft.com/xml-script/2005">
            <references>
            </references>
            <components>
            </components>
        </page>
    </script>
</body>
</html>
