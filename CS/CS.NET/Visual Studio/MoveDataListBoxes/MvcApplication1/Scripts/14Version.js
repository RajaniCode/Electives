$(function() {
    $("#MoveRight,#MoveLeft").click(function(event) { 
        var id = $(event.target).attr("id");
        var selectFrom = id == "MoveRight" ? "#SelectLeft" : "#SelectRight";
        var moveTo = id == "MoveRight" ? "#SelectRight" : "#SelectLeft";

        var selectedItems = $(selectFrom + " :selected").toArray();
        $(moveTo).append(selectedItems);
        selectedItems.remove;
    });
});