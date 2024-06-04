<?php

class Client 
{    
    public static $static_var = "static variable\n\n";
    public $instance_var = "instance variable\n\n";

    public static function static_method() 
    {
        print_r("Calling static method\n\n");        
    }

    public function class_method() 
    {   
        print_r("Calling class method\n\n");
    }
}

print_r(Client::$static_var);

Client::static_method();

Client::class_method(); // Note /* In PHP 7, calling non-static methods statically is deprecated, and will generate an E_DEPRECATED warning. Support for calling non-static methods statically may be removed in the future. */

$cli = new Client();

print_r($cli->instance_var);
$cli->class_method(); 

$cli->static_method(); // Note

?>