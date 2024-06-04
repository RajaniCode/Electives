<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ASPJavaScriptAccess._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">

   <script type="text/javascript">

       //var adOpenDynamic = 2;
       //var adLockOptimistic = 3;

       /* Path of database.
       If you put the database "Inventory.mdb" in different location,
       you need to specify the correct path to this variable.
       But When you are running the webpage from Browsers only,
       you should use this keyword "window.location.pathname" for getting
       the current location. But If you are using FrontPage,
       you hav to specity the static path.
       */
       var strDbPath = "C:\\Documents and Settings\\RAJANI\\My Documents\\Code\\ASP.NET\\ASPJavaScriptAccess\\ASPJavaScriptAccess\\App_Data\\Inventory.mdb";

       /*
       Here is the ConnectionString for Microsoft Access.
       If you wanna use SQL or other databases, you hav
       to change the connection string..
       eg: SQL => var conn_str = "Provider=sqloledb; Data Source=itdev;" +
       "Initial Catalog=pubs; User ID=sa;Password=yourpassword";
       */
       var conn_str = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strDbPath;

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
               var strHtml = "";
               strHtml += "<table cellpadding=0 cellspacing=0 border=1 width=500px align=center>";
               strHtml += "<tr ><td align=center colspan=4><b>Database: Inventory <br/> Table: Stocks</b></td></tr>";
               strHtml += "<tr>";
               strHtml += " <td width=\"10px\"><b>StockID</b></td>";
               strHtml += " <td width=\"50px\"><b>StockName</b></td>";
               strHtml += " <td width=\"10px\"><b>ReOrderLevel</b></td>";
               strHtml += " <td width=\"5px\"><b>IsActive</b></td>";
               strHtml += "</tr>";
               
               //Database Connection
               var conn = getAdoDb("ADODB.Connection");
               conn.open(conn_str, "", "");

               //Recordset
               var rs = getAdoDb("ADODB.Recordset");
               strQuery = "SELECT StockID, StockName, ReOrderLevel,IsActive FROM Stocks";
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

    <title>Access using JavaScript</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
