<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Repeater ID="rptName" runat="server">
    <HeaderTemplate>
    <table> 
         <tr>
                <th>EmployeeID</th>
                <th>DepartmentID</th> 
                <th>EmployeeName</th> 
        </tr>    
    </HeaderTemplate>
      <ItemTemplate>
        <tr>
          <td> 
            <%#DirectCast(Container.DataItem, Employee).EmpID%>
          </td>
          <td> 
            <%#DirectCast(Container.DataItem, Employee).DeptID%>
          </td>
          <td>
            <%#DirectCast(Container.DataItem, Employee).EmpName%>
          </td>
        </tr>
      </ItemTemplate>
      <FooterTemplate>       
        </table><br />
    </FooterTemplate>
    </asp:Repeater>
    
    <asp:LinqDataSource ID="LinqDataSource1" 
    runat="server" ContextTypeName="EmployeeList" TableName="emp">
    </asp:LinqDataSource>
    </div>
    </form>
</body>
</html>
