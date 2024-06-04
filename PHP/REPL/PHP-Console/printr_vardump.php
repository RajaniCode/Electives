<?php

class Client 
{   
    public $instance_var = "instance variable";
    public function class_method() 
    {
        print_r("Calling class method\n");
    }
}

print("#\$cli\n");
$cli = new Client();
print_r($cli);
print("\n");
var_dump($cli);

print("\n#\$cli->instance_var\n");
print_r($cli->instance_var);
print("\n");
var_dump($cli->instance_var);

print("\n#\$cli->class_method()\n");
$cli->class_method();

print("\n#get_class_methods(\$cli)\n");
$methods = get_class_methods($cli);
print_r($methods);
print("\n");
var_dump($methods);

print("\n#get_class_vars(get_class(\$cli)\n");
$vars = get_class_vars(get_class($cli)); 
print_r($vars);
print("\n");
var_dump($vars);

?>