<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    <asp:AccessDataSource ID="AccessDataSource1" runat="server" 
        DataFile="~/App_Data/student.accdb" SelectCommand="SELECT * FROM [Studtable]">
    </asp:AccessDataSource>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="ID" DataSourceID="AccessDataSource1">
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" 
                ReadOnly="True" SortExpression="ID" />
            <asp:BoundField DataField="Studname" HeaderText="Studname" 
                SortExpression="Studname" />
            <asp:BoundField DataField="Rollno" HeaderText="Rollno" 
                SortExpression="Rollno" />
            <asp:BoundField DataField="Class" HeaderText="Class" SortExpression="Class" />
        </Columns>
    </asp:GridView>
    </form>
</body>
</html>
