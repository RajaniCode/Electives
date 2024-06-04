/// <reference path="/Scripts/jquery-1.4.1.js"/>

function spanClicked() {
    $("#colorSpan").addClass("redClass");
}

$(document).ready(function () {
    $("#clickSpan").click(spanClicked);
});