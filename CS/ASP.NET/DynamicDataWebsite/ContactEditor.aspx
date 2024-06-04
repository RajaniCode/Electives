<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ContactEditor.aspx.cs" Inherits="ContactEditor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:FormView ID="frmContacts" runat="server" DataSourceID="lds">
        <ItemTemplate>
            <asp:DynamicControl 
                EnableTest="true"
                Mode="Edit"
                DataField="Url" 
                runat="server" />
        </ItemTemplate>
    </asp:FormView>
    <asp:LinqDataSource 
        ID="lds"
        TableName="Contacts"
        ContextTypeName="DBDataContext" 
        Select="new (Url)" 
        runat="server" />
    </form>
</body>
</html>
