<?php

function func() {
    $num = 5;
    $num = $num + 1;
}
  
function main() {
    $num = 1;
    func();
    print($num);
}
  
main();


/*
1
*/


?>