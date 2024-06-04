<?php

class Client 
{   
    public $instance_var = "instance variable\n\n";
    public function class_method() 
    {
        print_r("Calling class method\n\n");
    }
}

$cli = new Client();
print_r($cli->instance_var);
$cli->class_method();

$methods = get_class_methods($cli);
print_r($methods);

$vars = get_class_vars(get_class($cli)); 
print_r($vars);

?>