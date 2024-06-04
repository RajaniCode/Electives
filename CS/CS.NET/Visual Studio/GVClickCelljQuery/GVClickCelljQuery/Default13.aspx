<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default13.aspx.cs" Inherits="Default13" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Click and retrieve Cell Value</title>
    <style type="text/css">
        .highlite
        {
            background-color:Gray;
        }
    </style>

    <script type="text/javascript"
     src="http://ajax.googleapis.com/ajax/libs/jquery/1.3.2/jquery.min.js">
    </script>


    <script type="text/javascript">
        $(function() {
            $(".gv > tbody > tr:not(:has(table, th))")
                .css("cursor", "pointer")
                .click(function(e) {
                    $(".gv td").removeClass("highlite");
                    var $cell = $(e.target).closest("td");
                    $cell.addClass('highlite');
                    var $currentCellText = $cell.text();
                    var $leftCellText = $cell.prev().text();
                    var $rightCellText = $cell.next().text();
                    var $colIndex = $cell.parent().children().index($cell);
                    var $colName = $cell.closest("table")
                        .find('th:eq(' + $colIndex + ')').text();
                    $("#para").empty()
                    .append("<b>Current Cell Text: </b>"
                        + $currentCellText + "<br/>")
                    .append("<b>Text to Left of Clicked Cell: </b>"
                        + $leftCellText + "<br/>")
                    .append("<b>Text to Right of Clicked Cell: </b>"
                        + $rightCellText + "<br/>")
                    .append("<b>Column Name of Clicked Cell: </b>"
                        + $colName)
                });

        });
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div class="tableDiv">
        <h2>Click on any of the table cells to retrieve information
            about the cell and its surrounding elements</h2><br />
        <asp:GridView ID="grdEmployees" runat="server" 
             AllowPaging="True" PageSize="5" AutoGenerateColumns="False"  
            DataSourceID="ObjectDataSource1" class="gv">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" />
                <asp:BoundField DataField="FName" HeaderText="FName" />
                <asp:BoundField DataField="MName" HeaderText="MName"  />
                <asp:BoundField DataField="LName" HeaderText="LName" />
                <asp:BoundField DataField="DOB" HeaderText="DOB" 
                    DataFormatString="{0:MM/dd/yyyy}"/>
                <asp:BoundField DataField="Sex" HeaderText="Sex" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            SelectMethod="GetEmployeeList" TypeName="Employee">
        </asp:ObjectDataSource>
         <br />
        <p id="para"></p>
    </div>
   
    </form>
</body>
</html>
