$(function() {
    $("#MoveRight,#MoveLeft").click(function(event) { 
        var id = $(event.target).attr("id");
        var selectFrom = id == "MoveRight" ? "#SelectLeft" : "#SelectRight";
        var moveTo = id == "MoveRight" ? "#SelectRight" : "#SelectLeft";

        var selectedItems = $(selectFrom + " :selected");
        var output = [];
        $.each(selectedItems, function(key, e) {
            output.push('<option value="' + e.value + '">' + e.text + '</option>');
        });

        $(moveTo).append(output.join(""));
        selectedItems.remove();
    });
});