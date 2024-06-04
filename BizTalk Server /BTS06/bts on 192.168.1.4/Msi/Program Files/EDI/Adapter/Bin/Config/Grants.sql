/*****************************************************************************/
/* Assign select, insert, delete and update rights on all EDI Subsystem      */
/* tables to the database role edi_admin_users                               */
/*****************************************************************************/
IF NOT EXISTS (SELECT * from dbo.sysusers WHERE name = 'BTS_OPERATORS')
     EXEC sp_addrole 'BTS_OPERATORS'
GO

GRANT  REFERENCES ,  SELECT  ON audin  TO BTS_OPERATORS
GO
GRANT  REFERENCES ,  SELECT  ON audout  TO BTS_OPERATORS
GO
GRANT  REFERENCES ,  SELECT  ON errors  TO BTS_OPERATORS
GO
GRANT  REFERENCES ,  SELECT ,  INSERT ,  DELETE ,  UPDATE  ON audin  TO edi_admin_users
GO
GRANT  REFERENCES ,  SELECT ,  INSERT ,  DELETE ,  UPDATE  ON audout  TO edi_admin_users
GO
GRANT  REFERENCES ,  SELECT ,  INSERT ,  DELETE ,  UPDATE  ON agmaps  TO edi_admin_users
GO
GRANT  REFERENCES ,  SELECT ,  INSERT ,  DELETE ,  UPDATE  ON authgrps  TO edi_admin_users
GO
GRANT  REFERENCES ,  SELECT ,  INSERT ,  DELETE ,  UPDATE  ON bpauth  TO edi_admin_users
GO
GRANT  REFERENCES ,  SELECT ,  INSERT ,  DELETE ,  UPDATE  ON charset  TO edi_admin_users
GO
GRANT  REFERENCES ,  SELECT ,  INSERT ,  DELETE ,  UPDATE  ON cntrys  TO edi_admin_users
GO
GRANT  REFERENCES ,  SELECT ,  INSERT ,  DELETE ,  UPDATE  ON codset  TO edi_admin_users
GO
GRANT  REFERENCES ,  SELECT ,  INSERT ,  DELETE ,  UPDATE  ON custids  TO edi_admin_users
GO
GRANT  REFERENCES ,  SELECT ,  INSERT ,  DELETE ,  UPDATE  ON days  TO edi_admin_users
GO
GRANT  REFERENCES ,  SELECT ,  INSERT ,  DELETE ,  UPDATE  ON dom1  TO edi_admin_users
GO
GRANT  REFERENCES ,  SELECT ,  INSERT ,  DELETE ,  UPDATE  ON dom3  TO edi_admin_users
GO
GRANT  REFERENCES ,  SELECT ,  INSERT ,  DELETE ,  UPDATE  ON heartbeat  TO edi_admin_users
GO
GRANT  REFERENCES ,  SELECT ,  INSERT ,  DELETE ,  UPDATE  ON ediservers  TO edi_admin_users
GO
GRANT  REFERENCES ,  SELECT ,  INSERT ,  DELETE ,  UPDATE  ON eitra1  TO edi_admin_users
GO
GRANT  REFERENCES ,  SELECT ,  INSERT ,  DELETE ,  UPDATE  ON elmnts  TO edi_admin_users
GO
GRANT  REFERENCES ,  SELECT ,  INSERT ,  DELETE ,  UPDATE  ON eltype  TO edi_admin_users
GO
GRANT  REFERENCES ,  SELECT ,  INSERT ,  DELETE ,  UPDATE  ON errors  TO edi_admin_users
GO
GRANT  REFERENCES ,  SELECT ,  INSERT ,  DELETE ,  UPDATE  ON errtxt  TO edi_admin_users
GO
GRANT  REFERENCES ,  SELECT ,  INSERT ,  DELETE ,  UPDATE  ON esptxt  TO edi_admin_users
GO
GRANT  REFERENCES ,  SELECT ,  INSERT ,  DELETE ,  UPDATE  ON htmlba  TO edi_admin_users
GO
GRANT  REFERENCES ,  SELECT ,  INSERT ,  DELETE ,  UPDATE  ON htmlta  TO edi_admin_users
GO
GRANT  REFERENCES ,  SELECT ,  INSERT ,  DELETE ,  UPDATE  ON mfcvr  TO edi_admin_users
GO
GRANT  REFERENCES ,  SELECT ,  INSERT ,  DELETE ,  UPDATE  ON msgcon  TO edi_admin_users
GO
GRANT  REFERENCES ,  SELECT ,  INSERT ,  DELETE ,  UPDATE  ON msgfmt  TO edi_admin_users
GO
GRANT  REFERENCES ,  SELECT ,  INSERT ,  DELETE ,  UPDATE  ON msgipe  TO edi_admin_users
GO
GRANT  REFERENCES ,  SELECT ,  INSERT ,  DELETE ,  UPDATE  ON msgs1  TO edi_admin_users
GO
GRANT  REFERENCES ,  SELECT ,  INSERT ,  DELETE ,  UPDATE  ON msgs2  TO edi_admin_users
GO
GRANT  REFERENCES ,  SELECT ,  INSERT ,  DELETE ,  UPDATE  ON msgs3  TO edi_admin_users
GO
GRANT  REFERENCES ,  SELECT ,  INSERT ,  DELETE ,  UPDATE  ON msgs4  TO edi_admin_users
GO
GRANT  REFERENCES ,  SELECT ,  INSERT ,  DELETE ,  UPDATE  ON msgsrv  TO edi_admin_users
GO
GRANT  REFERENCES ,  SELECT ,  INSERT ,  DELETE ,  UPDATE  ON msgsts  TO edi_admin_users
GO
GRANT  REFERENCES ,  SELECT ,  INSERT ,  DELETE ,  UPDATE  ON numbers  TO edi_admin_users
GO
GRANT  REFERENCES ,  SELECT ,  INSERT ,  DELETE ,  UPDATE  ON parame  TO edi_admin_users
GO
GRANT  REFERENCES ,  SELECT ,  INSERT ,  DELETE ,  UPDATE  ON pbcatcol  TO edi_admin_users
GO
GRANT  REFERENCES ,  SELECT ,  INSERT ,  DELETE ,  UPDATE  ON pbcatedt  TO edi_admin_users
GO
GRANT  REFERENCES ,  SELECT ,  INSERT ,  DELETE ,  UPDATE  ON pbcatfmt  TO edi_admin_users
GO
GRANT  REFERENCES ,  SELECT ,  INSERT ,  DELETE ,  UPDATE  ON pbcattbl  TO edi_admin_users
GO
GRANT  REFERENCES ,  SELECT ,  INSERT ,  DELETE ,  UPDATE  ON pbcatvld  TO edi_admin_users
GO
GRANT  REFERENCES ,  SELECT ,  INSERT ,  DELETE ,  UPDATE  ON prtnr1  TO edi_admin_users
GO
GRANT  REFERENCES ,  SELECT ,  INSERT ,  DELETE ,  UPDATE  ON prtnr3  TO edi_admin_users
GO
GRANT  REFERENCES ,  SELECT ,  INSERT ,  DELETE ,  UPDATE  ON relrcpt  TO edi_admin_users
GO
GRANT  REFERENCES ,  SELECT ,  INSERT ,  DELETE ,  UPDATE  ON segcon  TO edi_admin_users
GO
GRANT  REFERENCES ,  SELECT ,  INSERT ,  DELETE ,  UPDATE  ON sgmnts  TO edi_admin_users
GO
GRANT  REFERENCES ,  SELECT ,  INSERT ,  DELETE ,  UPDATE  ON states  TO edi_admin_users
GO
GRANT  REFERENCES ,  SELECT ,  INSERT ,  DELETE ,  UPDATE  ON timefr  TO edi_admin_users
GO
GRANT  REFERENCES ,  SELECT ,  INSERT ,  DELETE ,  UPDATE  ON tracon  TO edi_admin_users
GO
GRANT  REFERENCES ,  SELECT ,  INSERT ,  DELETE ,  UPDATE  ON trafun  TO edi_admin_users
GO
GRANT  REFERENCES ,  SELECT ,  INSERT ,  DELETE ,  UPDATE  ON uritopc TO edi_admin_users
GO
GRANT  REFERENCES ,  SELECT ,  INSERT ,  DELETE ,  UPDATE  ON value1  TO edi_admin_users
GO
GRANT  REFERENCES ,  SELECT ,  INSERT ,  DELETE ,  UPDATE  ON value2  TO edi_admin_users
GO

