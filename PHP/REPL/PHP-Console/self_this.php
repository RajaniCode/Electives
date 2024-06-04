<?php

class Client 
{    
    public static $static_var = "static variable";
    public $instance_var = "instance variable";

    public static function static_method() 
    {
        print self::$static_var . " in static method using self\n\n";

        // print Client::$static_var . " in static method using Client, unconventional\n\n";

        $cli = new Client();
        print $cli->instance_var . " in static method, \$this cannot be used in static method\n\n";
    }

    public function class_method() 
    {
        print self::$static_var . " in class method using self\n\n";
        // print Client::$static_var . " in class method using Client, unconventional\n\n"; 

        print $this->instance_var . " in class method\n\n";
        $cli = new Client();
        // print $cli->instance_var . " in class method using instance, unconventional\n\n";    
    }
}

Client::static_method(); 

// Client::class_method(); // Note // PHP Fatal error:  Uncaught Error: Using $this when not in object context

$cli = new Client();

$cli->class_method(); 

// $cli->static_method(); // Note

?>