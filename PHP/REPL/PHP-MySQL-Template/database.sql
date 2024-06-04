# SELECT DATABASE() FROM DUAL;
# SELECT DATABASE();

# SHOW DATABASES;
# SHOW TABLES;

# DROP DATABASE IF EXISTS `testdb`;

USE `phpmyadmin`;

CREATE DATABASE `testdb`;
USE `testdb`;

DROP TABLE  IF EXISTS `users`;

CREATE TABLE IF NOT EXISTS `users` (
  `id` int(8) NOT NULL AUTO_INCREMENT,
  `name` varchar(30) NOT NULL,
  `email` varchar(60) NOT NULL,
  `password` varchar(40) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `email` (`email`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;