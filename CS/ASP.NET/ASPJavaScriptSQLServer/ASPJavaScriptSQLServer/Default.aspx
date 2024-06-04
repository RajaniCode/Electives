<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ASPJavaScriptSQLServer._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">

<script type="text/javascript">

//var adOpenDynamic = 2;
//var adLockOptimistic = 3;


var conn_str = "Provider=SQLOLEDB;Data Source=.\\SQLEXPRESS;Initial Catalog=Northwind;User ID=sa;Password=asdfglkjh;Trusted_Connection=yes;";

function getAdoDb(strAdoType)
{
    if (window.ActiveXObject)
    {
    return new ActiveXObject(strAdoType);
    }
    else
    {
        return new ActiveXObject(strAdoType);
    }
}

function showReports()
{
    try
    {
        var strHtml ="";
        strHtml += "<table cellpadding=0 cellspacing=0 border=1 width=500px align=center>";
        strHtml += "<tr ><td align=center colspan=4><b>Database: Northwind <br/> Table: Employees</b></td></tr>";
        strHtml += "<tr>";
        strHtml += " <td width=\"10px\"><b>FirsName</b></td>";
        strHtml += " <td width=\"50px\"><b>LastName</b></td>";
        strHtml += " <td width=\"10px\"><b>City</b></td>";
        strHtml += " <td width=\"5px\"><b>Country</b></td>";
        strHtml += "</tr>";
        
        //Database Connection
        var conn = getAdoDb("ADODB.Connection");
        conn.open(conn_str, "", "");

        //Recordset
        var rs = getAdoDb("ADODB.Recordset");
        strQuery = "SELECT FirstName, LastName, City, Country FROM Employees";
        //rs.open(strQuery, conn, adOpenDynamic, adLockOptimistic);

        rs.open(strQuery, conn);

        if (!rs.bof)
        {
            rs.MoveFirst();
            while (!rs.eof) 
            {
                strHtml += "<tr>";
                strHtml += " <td width=\"10px\">" + rs.fields(0).value + "</td>";
                strHtml += " <td width=\"50px\">" + rs.fields(1).value + "</td>";
                strHtml += " <td width=\"10px\">" + rs.fields(2).value + "</td>";
                strHtml += " <td width=\"5px\">" + rs.fields(3).value + "</td>";
                strHtml += "</tr>";

                rs.MoveNext();
            }
        }
        else
        {
            //No Records.
            strHtml += "<tr colspan=4><td align=center><font color=red>No Records.</font></td></tr>";
        }
        
        conn.close();
        
        strHtml += "</table>";
        document.write(strHtml);
    }
    catch (ex)
    {
        alert(ex.message);
    }
}

showReports();

</script>
    
<title>SQL Server using JavaScript</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
