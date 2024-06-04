<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script language="javascript" type="text/javascript">
        function SetUniqueRadioButton(nameregex, current) {
            re = new RegExp(nameregex);
            for (i = 0; i < document.forms[0].elements.length; i++) {
                elm = document.forms[0].elements[i]
                if (elm.type == 'radio') {
                    if (re.test(elm.name)) {
                        elm.checked = false;
                    }
                }
            }
            current.checked = true;
        }        
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Repeater ID="rptPeople" runat="server" 
            OnItemDataBound="rptPeople_ItemDataBound">
            <HeaderTemplate>
                <table>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:RadioButton ID="rdoSelected" GroupName="Person" 
                            TextAlign="Right" runat="server"
                            Text='<%# Eval("GivenName") %>' />
                        <asp:HiddenField ID="hdnUniqueId" runat="server" 
                            Value='<%# Eval("UniqueId") %>' />
                    </td>
                    <td>
                        <asp:Label ID="Label3" runat="server" 
                            Text='<%# Eval("Surname") %>' />
                    </td>
                    <td>
                        <asp:Label ID="lblSurname" runat="server" 
                            Text='<%# Eval("Height") %>' />
                    </td>
                    <td>
                        <asp:Label ID="Label1" runat="server" 
                            Text='<%# Eval("ShoeSize") %>' />
                    </td>
                    <td>
                        <asp:Label ID="Label2" runat="server" 
                            Text='<%# Eval("Age") %>' />
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        <asp:Button ID="btnSubmit" runat="server" 
                Text="Submit" OnClick="Button1_Click" />
    </div>
    </form>
</body>
</html>
