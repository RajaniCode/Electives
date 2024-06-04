<?php

// . "\n"
// OR
// . PHP_EOL 
// OR
// . "\xA"

function func() {
    try {
        throw new Exception("To Force Issue");
    }
    catch (Exception $e) {
        return 1;
    }
    finally {
        return 2;
    }
}

function funct() {
    try {
        try {
            throw new Exception("To Force Issue");
        }
        catch (Exception $e) {
            return 10;
        }
        finally {
            return 20;
        }
    }
    catch (Exception $e) {
        print(30 . "\n");
    }
    finally {
        print(40 . "\n");
    }
}
        
print(func() . "\n");

print(funct() . "\n");

/*

$ php nested_try.php
2
40
20

*/

?>