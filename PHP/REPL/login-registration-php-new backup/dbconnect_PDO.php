<?php

# MySQL 
$host = 'localhost';
$username = 'root';
http://localhost/phpmyadmin ## // mysql://localhost:3306
## $password = 'My$ql@Server#5.7';
$dbname = 'dbtest';

function exception_error_handler($errno, $errstr, $errfile, $errline ) {
    throw new ErrorException($errstr, $errno, 0, $errfile, $errline);
}

set_error_handler("exception_error_handler");

try {

    ## $pdo = new PDO("mysql:host=$host;dbname=$dbname", $username, $password);
    $pdo = new PDO("mysql:host=$host;dbname=$dbname", $username); ##
    
    $pdo->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
	
    $sql = 'SELECT * FROM users;';
 
    $q = $pdo->query($sql);

    $rowcount = $q->rowCount();

    $result = $q->setFetchMode(PDO::FETCH_ASSOC);
 
} catch (PDOException $pe) {
    die("Could not connect to the database $dbname :" . $pe->getMessage());
} catch (Exception $e) {
    die("Could not connect to the database $dbname :" . $e->getMessage());
}