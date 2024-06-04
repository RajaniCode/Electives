<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DataKeyNamesApplication._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="grdCustomer" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="ID" onrowcommand="grdCustomer_RowCommand">
            <Columns>                
                <asp:CommandField CausesValidation="false" ButtonType="Image" SelectImageUrl="~/Users.gif" ShowSelectButton="true" />
                <asp:BoundField DataField="GivenName" HeaderText="Name" />
                <asp:BoundField DataField="Surname" HeaderText="Surname" />
                <asp:BoundField DataField="EmailAddress" HeaderText="Email" />
                <asp:BoundField DataField="NickName" HeaderText="Nick Name" />
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
