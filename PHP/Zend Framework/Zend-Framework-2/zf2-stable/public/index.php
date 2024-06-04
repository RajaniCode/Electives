<?php

/**
 * Display all errors when APPLICATION_ENV is development.
 */
# Error: Undefined index: APPLICATION_ENV in C:\xampp\htdocs\zf2-tutorial\public\index.php on line 6
# Fix
// PHP CLI 
// echo getenv('APPLICATION_ENV');
if (getenv('APPLICATION_ENV') == 'development') {
// Apache
// if ($_SERVER['APPLICATION_ENV'] == 'development') {
    error_reporting(E_ALL);
    ini_set("display_errors", 1);
}

/**
 * This makes life easier when dealing with paths. Everything is relative
 * to the application root now.
 */
chdir(dirname(__DIR__));

// Decline static file requests back to the PHP built-in webserver
if (php_sapi_name() === 'cli-server' && is_file(__DIR__ . parse_url($_SERVER['REQUEST_URI'], PHP_URL_PATH))) {
    return false;
}

// Setup autoloading
require 'init_autoloader.php';

// Run the application!
Zend\Mvc\Application::init(require 'config/application.config.php')->run();