<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ASPCS2008tablecss._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link href="StyleSheet.css" type="text/css" rel="stylesheet" id="Link1" />
</head>
<body>
    <form id="form1" runat="server">
    
     <table class="table1" align="center">
        <tr>
            <td>
            
            </td>
        </tr>
    </table>

    <br />
    
    
    <table class="table2"> 
    <%--align="center" REQUIRED FOR IE 5.5 and Opera 9.64--%> 
    <%--cellpadding="0" INSTEAD OF border-collapse: collapse; (for table) padding: 0; (for td) IN CSS--%>
        <tr>
            <td class="table2td1" >
            
            <table class="table3">  <%--Will not work in Opera--%>
                <tr>
                    <td>
                    
                    </td>
                </tr>
            </table>
    
            </td>
        </tr>
    </table>
    
    </form>
</body>
</html>
