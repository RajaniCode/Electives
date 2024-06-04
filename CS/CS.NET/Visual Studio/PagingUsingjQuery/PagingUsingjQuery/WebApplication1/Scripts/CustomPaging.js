var pageSize = 10;
function pageData(e) {
    var skip = e == 1 ? 0 : (e * pageSize) - pageSize;
    $.ajax({
        type: "POST",
        url: "Default.aspx/FetchCustomers",
        data: "{skip:" + skip + ",take:" + pageSize + "}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        cache: false,
        success: function(msg) {
            printCustomer(msg);
        }
    });
    return false;
}

$(document).ready(function() {
    $("#btnSearch").click(function() {
        $.ajax({
            type: "POST",
            url: "Default.aspx/FetchCustomers",
            data: "{skip:0,take:" + pageSize + "}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: true,
            cache: false,
            success: function(msg) {
                var total = msg.d.TotalRecords;
                if (total > 0) {
                    printCustomer(msg);
                    $("#paging").text("");
                    // Get the page count by dividing the total records
                    // by the page size.  This has to be rounded up
                    // otherwise you might not get the last page 
                    var pageTotal = Math.ceil(total / pageSize);
                    for (var i = 0; i < pageTotal; i++) {
                        $("#paging").append("<a href=\"#\" onClick=\"pageData(" + (i + 1) + ")\">" + (i + 1) + "</a>&nbsp;");                        
                    }
                }
                else {
                    $("#paging").text("No records were found.");
                }
                $("#totalRecords").text("Total records: " + total);
            }
        });
    });
});

// This function accepts a customer object
// and prints the results to the div element. 
function printCustomer(msg) {
    $("#result").text("");
    var customers = msg.d.Customers;
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