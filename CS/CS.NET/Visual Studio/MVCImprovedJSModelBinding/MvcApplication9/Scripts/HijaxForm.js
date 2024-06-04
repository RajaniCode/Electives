$(function () {    
    $("form:first").submit(function (e) {
        e.preventDefault();       
        var order = {
            Id: $("#Id").val(),
            GivenName: $("#GivenName").val(),
            Surname: $("#Surname").val(),
            Address: $("#Address").val(),
            DateOrdered: $("#DateOrdered").val(),
            Quantity: $("#Quantity").val()
        };

        $.ajax({
            url: $(this).attr("action"),
            type: "POST",
            data: JSON.stringify(order),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                
            }
        });
    });
});