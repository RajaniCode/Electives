<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bind Repeater to List<></title>
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
            <%# ((Employee)Container.DataItem).EmpID %>
          </td>
          <td> 
            <%# ((Employee)Container.DataItem).DeptID %>
          </td>
          <td>
            <%# ((Employee)Container.DataItem).EmpName %>
          </td>
        </tr>
      </ItemTemplate>
      <FooterTemplate>       
        </table><br />
    </FooterTemplate>
    </asp:Repeater>

    </div>
    </form>
</body>
</html>
