function Multiplication(num1, num2) {
    WebService.Multiply(num1, num2, Succeeded);
}
function Succeeded(result, eventArgs) {
    var Res = document.getElementById("LblResult");
    Res.innerHTML = result;
}
