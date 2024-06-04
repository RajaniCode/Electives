<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>jQuery Lazy Loading Tabs and LINQ to SQL</title>
    <link type="text/css" href="CSS/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <script type="text/javascript" src="Scripts/jquery-1.3.2.js"></script>
    <script type="text/javascript" src="Scripts/jquery-ui-1.7.2.custom.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function() {
            // Tabs
            $('#tabs').tabs({ selected: -1 });
            $('#tabs').bind('tabsshow', function(event, ui) {
                var tabSelected = "#tab" + ui.index + "Selected";
                $(tabSelected).html("isClicked");
            });

            $('#tabs').bind('tabsselect', function(event, ui) {
                var callMethod;
                var tabSelected = "#tab" + ui.index + "Selected";
                if ($(tabSelected).text() == "") {                    
                    switch (ui.index) {
                        case 0:
                            callMethod = "Default.aspx/GetCustomers";
                            break;
                        case 1:
                            callMethod = "Default.aspx/GetProducts";
                            break;
                    }

                    $.ajax({
                        type: "POST",
                        url: callMethod,
                        data: "{}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        async: true,
                        success: function(msg) {
                            switch (ui.index) {
                                case 0:
                                    var customers = msg.d;
                                    for (var i = 0; i < customers.length; i++) {
                                        $("#tabs-0").append(customers[i].CustomerID + ", " +
                                                customers[i].CompanyName + ", " +
                                                customers[i].ContactName + ", " +
                                                customers[i].Address + ", " +
                                                customers[i].City + ", " +
                                                customers[i].Country + "<br />");
                                    }
                                    break;
                                case 1:
                                    var products = msg.d;
                                    for (var i = 0; i < products.length; i++) {
                                        $("#tabs-1").append(products[i].ProductID + ", " +
                                                products[i].ProductName + ", " +
                                                products[i].QuantityPerUnit + ", " +
                                                products[i].UnitPrice + ", " +
                                                products[i].UnitsInStock + ", " +
                                                products[i].Discontinued + "<br />");
                                    }
                                    break;
                            }
                        }
                    });
                }
            });

            //hover states on the static widgets
            $('#dialog_link, ul#icons li').hover(
					function() { $(this).addClass('ui-state-hover'); },
					function() { $(this).removeClass('ui-state-hover'); }
				);
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="tabs">
        <ul>
            <li><a href="#tabs-0">Customers</a></li>
            <li><a href="#tabs-1">Products</a></li>
        </ul>
        <div id="tabs-0">
            <input type="hidden" id="tab0Selected" />
        </div>
        <div id="tabs-1">            
            <input type="hidden" id="tab1Selected" />
        </div>
    </div>
    </form>
</body>
</html>
