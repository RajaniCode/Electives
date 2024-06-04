CREATE PROCEDURE sp_get_pk_constraint_name 
        @table_name char(64),
        @constraint_name sysname OUTPUT 
AS
SELECT  @constraint_name = name 
FROM    sysobjects 
WHERE   parent_obj = ( SELECT id FROM   sysobjects 
                       WHERE  name = @table_name)
                  AND   xtype = 'PK'