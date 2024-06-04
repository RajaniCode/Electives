CREATE PROCEDURE sp_check_column_exists
        @table_name2 char(64),
        @column_name2 char(64),
        @exists2 smallint OUTPUT 
AS
  SELECT        @exists2 = count(*)
  FROM  sysobjects, syscolumns
  WHERE ( syscolumns.id = sysobjects.id ) 
    AND ( sysobjects.name = @table_name2 )       
    AND ( syscolumns.name = @column_name2 )