CREATE PROCEDURE sp_check_index_exists
         @constraint_name3 sysname,
         @exists3 smallint OUTPUT  
AS
  SELECT  @exists3=count(*) 
  FROM    sysindexes 
  WHERE   name = @constraint_name3