<?php

# MySQL 
$host = 'localhost';
$username = 'root';
http://localhost/phpmyadmin ## // mysql://localhost:3306
$password = null; ## $password = 'My$ql@Server#5.7';
$dbname = 'testdb';

function exception_error_handler($errno, $errstr, $errfile, $errline ) {
    throw new ErrorException($errstr, $errno, 0, $errfile, $errline);
}

set_error_handler("exception_error_handler");

try {

    $con = new mysqli($host, $username, $password, $dbname);
    
    if ($con->connect_errno) {
    	// Something you should not do on a public site, but this example will show you
    	// anyways, is print out MySQL error related information -- you might log this
   	echo "Error: Failed to make a MySQL connection, here is why: \n";
    	echo "Errno: " . $mysqli->connect_errno . "\n";
    	echo "Error: " . $mysqli->connect_error . "\n";
    }
 
} catch (mysqli_sql_exception $me) {
    die("Could not connect to the database $dbname :" . $me->getMessage());
} catch (Exception $e) {
    die("Could not connect to the database $dbname :" . $e->getMessage());
}

?>