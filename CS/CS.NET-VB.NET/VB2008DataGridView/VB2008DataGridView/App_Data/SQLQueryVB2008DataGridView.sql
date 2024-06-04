USE  master

IF OBJECT_ID('test', 'U') IS NOT NULL  
DROP TABLE test

CREATE TABLE test (
   id int IDENTITY(1, 1) NOT NULL ,
   column2 varchar(50) DEFAULT REPLICATE('A',1),
   column3 varchar(50) DEFAULT REPLICATE('B',1),
   column4 varchar(50) DEFAULT REPLICATE('C',1),
   column5 varchar(50) DEFAULT REPLICATE('D',1),
   column6 varchar(50) DEFAULT REPLICATE('E',1),
   column7 varchar(50) DEFAULT REPLICATE('F',1),
   column8 varchar(50) DEFAULT REPLICATE('G',1),
   column9 varchar(50) DEFAULT REPLICATE('H',1),
   column10 varchar(50) DEFAULT REPLICATE('I',1)
   PRIMARY KEY (id)
 ) 

SELECT * FROM test

-- INSERT 1000 ROWS INTO EACH TEST TABLE 
DECLARE @COUNTER INT
SET @COUNTER = 1

WHILE (@COUNTER <= 20000)
BEGIN
   INSERT INTO test DEFAULT VALUES 
   SET @COUNTER = @COUNTER + 1
END
GO

SELECT * FROM test

USE master;
GO
IF OBJECT_ID ( 'usp_test_select_all', 'P' ) IS NOT NULL 
    DROP PROCEDURE usp_test_select_all;
GO
CREATE PROCEDURE usp_test_select_all
AS
   SELECT id, column2, column3,column4, column5, 
          column6, column7,  column8, column9, column10
   FROM test
   ORDER BY id;
GO
