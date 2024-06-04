<%@ Page Language="C#" AutoEventWireup="true" EnableViewState="false" EnableSessionState="False" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>jQuery BlockUI Plugin with LINQ to SQL</title>
    <script language="javascript" type="text/javascript" src="Scripts/jquery-1.3.2.js"></script>
    <script language="javascript" type="text/javascript" src="Scripts/jquery.blockUI.js?v2.24"></script>
    <script language="javascript" type="text/javascript">
        $(document).ready(function() {
            $('#btnFetchData').click(function() {
                $.blockUI({
                    css: {
                        padding: 0,
                        margin: 0,
                        width: '30%',
                        top: '40%',
                        left: '35%',
                        textAlign: 'center',
                        color: '#000000',
                        border: '3px solid #aaa',
                        backgroundColor: '#ffffff',
                        cursor: 'wait'
                    },
                    // styles for the overlay 
                    overlayCSS: {
                        backgroundColor: '#000',
                        opacity: 0.6
                    },
                    message: '<img src=wait.gif>&nbsp;<b>Searching the database.  Please wait.</b>',
                    bindEvents: true
                });
                $.ajax({
                    type: "POST",
                    url: "Default.aspx/FetchCustomers",
                    data: "{contactName:\"" + $("#txtContactName").val() + "\"}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: true,
                    cache: false,
                    success: function(msg) {
                        $.unblockUI();
                        var customers = msg.d;
                        if (customers.length > 0) {
                            $("#result").text("");
                            for (var i = 0; i < customers.length; i++) {
                                $("#result").append(customers[i].CustomerID + ", ");
                                $("#result").append(customers[i].CompanyName + ", ");
                                $("#result").append(customers[i].ContactName + ", ");
                                $("#result").append(customers[i].ContactTitle + ", ");
                                $("#result").append(customers[i].Address + ", ");
                                $("#result").append(customers[i].City + ", ");
                                $("#result").append(customers[i].Region + "<br />");
                            }
                        }
                        else {
                            // validation failed
                            $("#result").text("No matching records were found.");
                        }
                    },
                    error: function(XMLHttpRequest, textStatus, errorThrown) {
                        $.unblockUI();
                        alert(textStatus);
                    }
                });
                return false;
            });
        });      
    </script>
</head>
<body>
    <form id="form1" runat="server">    
        <input id="txtContactName" type="text" />
        <input id="btnFetchData" type="submit" value="Fetch Data"/>
        <div id="result"></div>        
    </form>
</body>
</html>
