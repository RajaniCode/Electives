CREATE PROCEDURE sp_get_column_size
        @table_name4 char(64),
        @column_name4 char(64),
        @size4 integer OUTPUT 
AS
  SELECT @size4 = syscolumns.length
  FROM  sysobjects, syscolumns
  WHERE ( syscolumns.id = sysobjects.id ) 
    AND ( sysobjects.name = @table_name4 )       
    AND ( syscolumns.name = @column_name4 )
