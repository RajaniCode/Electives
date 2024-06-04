<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>
<%@ Register TagPrefix="CLV" Namespace="CustomListValidator" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Custom Validation Control</title>
</head>
<body>
    <form id="form1" runat="server">
<div>
<asp:CheckBoxList ID="CheckBoxList1" runat="server">
</asp:CheckBoxList></div>
        <CLV:ListValidator runat="server" ID="custLstVal" EnableClientScript="true" ControlToValidate="CheckBoxList1" ErrorMessage="At least one item in the checkboxlist should be checked" />

<asp:RadioButtonList ID="RadioButtonList1" runat="server">
</asp:RadioButtonList>
        <CLV:ListValidator runat="server" ID="custRadVal" EnableClientScript="true" ControlToValidate="RadioButtonList1" ErrorMessage="At least one item in the radiobuttonlist should be checked" />
<br />
<br />
<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
    </form>
</body>
</html>