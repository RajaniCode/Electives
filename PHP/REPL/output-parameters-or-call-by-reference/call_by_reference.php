<?php

function call_by_value($n)
{
    $n++;
}

$number = 5;
call_by_value($number);
print($number);
print("\n");

function call_by_reference(&$n)
{
    $n++;
}

$number = 5;
call_by_reference($number);
print($number);
print("\n");

function func(&$x)
{
    $x = ['new-value', 100];
}

$b = ['old-value', 99];
print_r(implode(" ", $b));
print("\n");

func($b);
print_r(implode(" ", $b));
print("\n");

function foo()
{
    return array('newest-value', 102);
}

list($x, $y) = array('newer-value', 101);
print_r($x . " " . $y);
print("\n");

list($x, $y) = foo();
print_r($x . " " . $y);

?>