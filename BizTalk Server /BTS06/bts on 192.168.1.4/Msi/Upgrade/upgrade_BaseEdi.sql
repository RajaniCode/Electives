/* **  SQLSERVER  **************************************** */
/* **                                                   ** */
/* **  Script for upgrading a Base EDI V4 SP0 R111 DB	** */
/* **    Step 1 - Create required stored procedures     ** */
/* **    Step 2 - Alter the database where needed       ** */
/* **             (Including related update statements) ** */
/* **    Step 3 - Drop stored procedures                ** */
/* **  upgrade_BaseEdiData.sql  			** */
/* **    Step 4 - Update (insert) data is needed        ** */
/* ** 	 Step 5 - Refresh (delete&insert)the errtxt     ** */
/* ** 		  table for language = 1 (english)      ** */
/* **                                                   ** */
/* **  Update statement that are used to fill columns	** */
/* **  newly added by an alter, must be done via 	** */
/* **  EXECUTE ('statement' because the script is       ** */
/* **  compiled before it is executed.                  ** */
/* **  -For newly created tabled with insert commands   ** */
/* **   this is not a problem because of 		** */
/* **   'deferred resolution'				** */
/* ** 				           Covast 2004  ** */
/* ******************************************************* */
/* ****************************************************** */
/* **  STEP 1 -  Created needed stored procedures      ** */
/* ****************************************************** */

/* ======================================================== */
/* == Get the primary key name                           == */
/* ==    Is handled in sp_get_pk_constraint_name.sql     == */
/* ==                                                    == */
/* == Check if a column exists                           == */
/* ==     Is handled in sp_check_column_exists.sql       == */
/* ==                                                    == */
/* == Check if a index exists                            == */
/* ==     Is handled in sp_check_index_exists.sql	 == */
/* ==                                                    == */
/* == Get the lenght of a field                          == */
/* ==     Is handled in sp_get_column_size               == */
/* ======================================================== */

/* ****************************************************** */
/* **  STEP 2 -  Make required changes to the database ** */
/* ****************************************************** */

/* ======================================================== */
/* == 07-01-2004   Add new columns to uritopc            == */
/* ======================================================== */

DECLARE @PnameExists smallint

EXEC sp_check_column_exists 'uritopc', 'pname', @PnameExists OUTPUT
IF @PnameExists = 0
BEGIN
	ALTER TABLE uritopc ADD pname varchar(256) NULL
END

/* ======================================================== */
/* == 08-01-2004   change primary key for value2         == */
/* ======================================================== */

DECLARE @value_constraint_name sysname

/* Drop primary key */
EXEC sp_get_pk_constraint_name 'value2', @value_constraint_name OUTPUT
IF LEN(@value_constraint_name) > 0
BEGIN    
	EXEC ('alter table value2 drop constraint ' + @value_constraint_name)
END
ALTER TABLE value2 ADD 
PRIMARY KEY CLUSTERED 
(
	valtcd,
	inval,
	exval,
	pc,
	dc
) ON [PRIMARY] 

/* ======================================================== */
/* == 18-02-2004   Add new columns to errtxt	         == */
/* ======================================================== */

DECLARE @oldetcExists smallint

EXEC sp_check_column_exists 'errtxt', 'oldetc', @oldetcExists OUTPUT
IF @oldetcExists = 0
BEGIN

	ALTER TABLE errtxt ADD oldetc smallint NULL
	EXEC ('ALTER TABLE errtxt ADD cause varchar(3750) NULL')
	EXEC ('ALTER TABLE errtxt ADD solution varchar(3750) NULL')
END

/* ======================================================== */
/* == 18-02-2004   Add new columns to msgsrv, audin and  == */
/* ==              audout	                         == */
/* ======================================================== */

DECLARE @ptenabledExists smallint

EXEC sp_check_column_exists 'msgsrv', 'ptenabled', @ptenabledExists OUTPUT
IF @ptenabledExists = 0
BEGIN

	ALTER TABLE msgsrv ADD ptenabled   smallint NULL
	ALTER TABLE msgsrv ADD ptformat    smallint NULL
	ALTER TABLE msgsrv ADD ptsender    smallint NULL
	ALTER TABLE msgsrv ADD ptrecipient smallint NULL
	ALTER TABLE msgsrv ADD ptdoctype   smallint NULL
	ALTER TABLE msgsrv ADD ptauth      smallint NULL

	ALTER TABLE audin  ADD passthru   smallint NULL
	ALTER TABLE audout ADD passthru   smallint NULL
END


/* ======================================================== */
/* == 19-02-2004   Remove obsolete indexes               == */
/* ======================================================== */
DECLARE @ObsoleteIndex smallint

	
EXEC sp_check_index_exists 'sk_audin_ttkeyin',@ObsoleteIndex OUTPUT
IF @ObsoleteIndex > 0
BEGIN
	DROP index audin.sk_audin_ttkeyin
END

EXEC sp_check_index_exists 'sk_audout_ttkeyout',@ObsoleteIndex OUTPUT
IF @ObsoleteIndex > 0
BEGIN
	DROP index audout.sk_audout_ttkeyout
END

EXEC sp_check_index_exists 'sk_id_nr',@ObsoleteIndex OUTPUT
IF @ObsoleteIndex > 0
BEGIN
	DROP index audout.sk_id_nr
END

EXEC sp_check_index_exists 'sk_value2_exval',@ObsoleteIndex OUTPUT
IF @ObsoleteIndex > 0
BEGIN
	DROP index value2.sk_value2_exval
END


/* ======================================================== */
/* == 25-02-2004   resize the blockno field              == */
/* ======================================================== */

DECLARE @blocknoSize integer,
        @dom_constraint_name sysname

EXEC sp_get_column_size 'dom1', 'blockno', @blocknoSize OUTPUT
IF @blocknoSize < 4
BEGIN

	/* Drop primary key */
 	EXEC sp_get_pk_constraint_name 'dom1', @dom_constraint_name OUTPUT
        EXEC ('alter table dom1 drop constraint ' + @dom_constraint_name)

	ALTER TABLE dom1 ALTER COLUMN blockno integer not null
	
	ALTER TABLE dom1 ADD 
	PRIMARY KEY CLUSTERED 
	(
		fc,
		mcvr,
		blockno
	) ON [PRIMARY] 
END

/* ======================================================== */
/* == 23-03-2004   Add new descrp fields to errors       == */
/* ======================================================== */

DECLARE @descrpExists smallint

EXEC sp_check_column_exists 'errors', 'descrp3', @descrpExists OUTPUT
IF @descrpExists = 0
BEGIN

	ALTER TABLE errors ADD descrp3 varchar(250) NULL
	ALTER TABLE errors ADD descrp4 varchar(250) NULL

END

/* ======================================================== */
/* == 24-03-2004   Add new fields to audin 		 == */
/* ==              (create/send datetime)     	         == */
/* ======================================================== */

DECLARE @intdateExists smallint

EXEC sp_check_column_exists 'audin', 'intdate', @intdateExists OUTPUT
IF @intdateExists = 0
BEGIN

	ALTER TABLE audin ADD intdate varchar(64) NULL
	ALTER TABLE audin ADD inttime varchar(64) NULL
END

/* ======================================================== */
/* == 25-03-2004   Add new fields and table for scaling  == */
/* ==              (create/send datetime)     	         == */
/* == 18-05-2004   Remove creation of ediserver table    == */
/* ==              replace by heartbeat table            == */
/* ======================================================== */

DECLARE @servernameExists smallint

EXEC sp_check_column_exists 'audin', 'servername', @servernameExists OUTPUT
IF @servernameExists = 0
BEGIN
	ALTER TABLE parame ADD documentshome varchar(255)

	ALTER TABLE audin ADD servername varchar(63)
	ALTER TABLE audout ADD servername varchar(63)
	ALTER TABLE errors ADD servername varchar(63)

	CREATE TABLE heartbeat
	( servername varchar(63) NOT NULL,
	  heartbeat datetime NOT NULL,
	  PRIMARY KEY (servername)
	 )
	 
	EXECUTE ('GRANT  REFERENCES ,  SELECT ,  INSERT ,  DELETE ,  UPDATE  ON heartbeat  TO edi_admin_users ') 
END

/* ======================================================== */
/* == 31-03-2004   Add lerrnr errors 			 == */
/* ======================================================== */

DECLARE @lerrnrExists smallint

EXEC sp_check_column_exists 'errors', 'lerrnr', @lerrnrExists OUTPUT
IF @lerrnrExists = 0
BEGIN
	ALTER TABLE errors ADD lerrnr integer
END

/* ======================================================== */
/* == 29-04-2004   Create new table numbers		 == */
/* == 12-05-2004   Definition changed			 == */
/* == 13-09-2004   Set start values in rows to matching  == */
/* ==              old values from parame table          == */
/* ======================================================== */

DECLARE @NumbersExists smallint

EXEC sp_check_column_exists 'numbers', 'typecd', @NumbersExists OUTPUT
IF @NumbersExists = 0
BEGIN
	CREATE TABLE numbers
	(
		typecd 			smallint NOT NULL,
		nextnr        		integer NOT NULL,
		timestamp     		timestamp NOT NULL ,
		filler        		char(2048) NULL,
		PRIMARY KEY (typecd)
	)
	
	EXECUTE ('GRANT  REFERENCES ,  SELECT ,  INSERT ,  DELETE ,  UPDATE  ON numbers  TO edi_admin_users ')
END
DECLARE @RowsInNumbers smallint
SELECT @RowsInNumbers = count(*) FROM numbers
IF @RowsInNumbers = 0
BEGIN
	INSERT INTO numbers SELECT 1,icin ,NULL,'icin' FROM parame
	INSERT INTO numbers SELECT 2,msgin,NULL,'msgin' FROM parame
	INSERT INTO numbers SELECT 3,msgout,NULL,'msgout' FROM parame
	INSERT INTO numbers SELECT 4,icout,NULL,'icout' FROM parame
	INSERT INTO numbers SELECT 5,errnr,NULL,'errnr'FROM parame
	INSERT INTO numbers SELECT 65,grpin,NULL,'grpin'FROM parame
	INSERT INTO numbers SELECT 66,grpout,NULL,'grpout'FROM parame
END

/* ======================================================== */
/* == 18-05-2004   Create table relrcpt			 == */
/* ======================================================== */

DECLARE	@RelrcptExists smallint

EXEC sp_check_column_exists 'relrcpt', 'servername', @RelrcptExists OUTPUT
IF @RelrcptExists = 0
BEGIN
	CREATE TABLE relrcpt
	(
	servername    		char(63) NOT NULL,
	uuid  			char(40) NOT NULL
	)
	
	EXECUTE ('GRANT  REFERENCES ,  SELECT ,  INSERT ,  DELETE ,  UPDATE  ON relrcpt TO edi_admin_users ')
END


/* ============================================================= */
/* == 11-06-2004   drop 4 indexes                             == */
/* ============================================================= */

DECLARE @indexhtml1Exists smallint

EXEC sp_check_index_exists 'sk_audin_html1',@indexhtml1Exists OUTPUT
IF @indexhtml1Exists > 0
BEGIN
	DROP index audin.sk_audin_html1
	DROP index audin.sk_audin_html2
	DROP index audout.sk_audout_html1
	DROP index audout.sk_audout_html2

END

/* ============================================================= */
/* == 29-06-2004   create erraccpt table with initial data    == */
/* ============================================================= */

DECLARE @ErrAccptExists smallint

EXEC sp_check_column_exists 'audin', 'erraccptd', @ErrAccptExists OUTPUT

IF @ErrAccptExists = 0
BEGIN
	ALTER TABLE audin ADD erraccptd smallint NULL


END

/* ============================================================= */
/* == 30-06-2004   Adjust column size ande drop/modify/create == */
/* ==              indexes                                    == */
/* ============================================================= */

DECLARE @indexAudoutClientIDExists smallint

EXEC sp_check_index_exists 'sk_audout_clientid',@indexAudoutClientIDExists OUTPUT
IF @indexAudoutClientIDExists = 0
BEGIN
	ALTER TABLE audin ALTER COLUMN routad CHAR(15) NULL
	ALTER TABLE audin ALTER COLUMN sroutad CHAR(15) NULL

	ALTER TABLE audout ALTER COLUMN routad CHAR(15) NULL
	ALTER TABLE audout ALTER COLUMN sroutad CHAR(15) NULL

	DROP INDEX prtnr3.sk_prtnr3_id
	ALTER TABLE prtnr3 ALTER COLUMN routad CHAR(15) NULL
	CREATE UNIQUE INDEX sk_prtnr3_id ON prtnr3 (id, idcdq, routad)

	DROP INDEX audout.sk_audout_reference
END
ELSE
IF @indexAudoutClientIDExists > 0
BEGIN
    DROP INDEX audout.sk_audout_clientid
END

CREATE INDEX sk_audout_clientid ON audout 
(
    clientid
)


/* ============================================================= */
/* == 02-07-2004   Change index for Audin  		      == */
/* ============================================================= */

DECLARE @indexaudinStatusExists smallint

EXEC sp_check_index_exists 'sk_audin_status',@indexaudinStatusExists OUTPUT
IF @indexaudinStatusExists> 0
BEGIN
	DROP INDEX audin.sk_audin_status
END

CREATE INDEX sk_audin_status ON audin 
(
    mstscd, msrvcdout
)

/* ============================================================= */
/* == 06-07-2004   Fix index for Audout  		      == */
/* ============================================================= */

DECLARE @indexStatusAudoutExists smallint

EXEC sp_check_index_exists 'sk_audout_status',@indexStatusAudoutExists OUTPUT
IF @indexStatusAudoutExists > 0
BEGIN
	DROP INDEX audout.sk_audout_status
END

CREATE INDEX sk_audout_status ON audout
(
	mstscd,
	ref
)


DECLARE @indexIcrmrnAudoutExists smallint

EXEC sp_check_index_exists 'sk_audout_icrmrn',@indexIcrmrnAudoutExists OUTPUT
IF @indexIcrmrnAudoutExists > 0
BEGIN
	DROP INDEX audout.sk_audout_icrmrn
END

CREATE INDEX sk_audout_icrmrn ON audout
(
	pc,
	dc,
	icr,
	mrn
)


DECLARE @indexGcrAudoutExists smallint

EXEC sp_check_index_exists 'sk_audout_gcr',@indexGcrAudoutExists OUTPUT
IF @indexGcrAudoutExists > 0
BEGIN
	DROP INDEX audout.sk_audout_gcr
END

CREATE INDEX sk_audout_gcr ON audout
(
	pc,
	dc,
	gcr,
	mrn
)


/* ============================================================= */
/* == 08-08-2004   Add columns to parame                      == */
/* ==                                                         == */
/* ============================================================= */

DECLARE @Mag1Exists smallint

EXEC sp_check_column_exists 'parame', 'mag1', @Mag1Exists OUTPUT

IF @Mag1Exists = 0
BEGIN
	ALTER TABLE parame ADD 	mag1 smallint
				, mag2 smallint
				, mag3 smallint
				, mag4 smallint
				, mag5 smallint
				, mag6 smallint
				, mag7 smallint
				, mag8 smallint
				, mag9 smallint
				, mag10 smallint
				, mag11 smallint
				, mag12 smallint
				, mag13 smallint
				, mag14 smallint

	
	EXECUTE ('UPDATE parame SET mag1 = IsNull(Ascii( substring( magic, 1,1) ), 32) WHERE mag1 IS NULL ')
	EXECUTE ('UPDATE parame SET mag2 = IsNull(Ascii( substring( magic, 2,1) ), 32) WHERE mag2 IS NULL ')
	EXECUTE ('UPDATE parame SET mag3 = IsNull(Ascii( substring( magic, 3,1) ), 32) WHERE mag3 IS NULL ')
	EXECUTE ('UPDATE parame SET mag4 = IsNull(Ascii( substring( magic, 4,1) ), 32) WHERE mag4 IS NULL ')
	EXECUTE ('UPDATE parame SET mag5 = IsNull(Ascii( substring( magic, 5,1) ), 32) WHERE mag5 IS NULL ')
	EXECUTE ('UPDATE parame SET mag6 = IsNull(Ascii( substring( magic, 6,1) ), 32) WHERE mag6 IS NULL ')
	EXECUTE ('UPDATE parame SET mag7 = IsNull(Ascii( substring( magic, 7,1) ), 32) WHERE mag7 IS NULL ')
	EXECUTE ('UPDATE parame SET mag8 = IsNull(Ascii( substring( magic, 8,1) ), 32) WHERE mag8 IS NULL ')
	EXECUTE ('UPDATE parame SET mag9 = IsNull(Ascii( substring( magic, 9,1) ), 32) WHERE mag9 IS NULL ')
	EXECUTE ('UPDATE parame SET mag10 = IsNull(Ascii( substring( magic, 10,1) ), 32) WHERE mag10 IS NULL')
	EXECUTE ('UPDATE parame SET mag11 = IsNull(Ascii( substring( magic, 11,1) ), 32) WHERE mag11 IS NULL')
	EXECUTE ('UPDATE parame SET mag12 = IsNull(Ascii( substring( magic, 12,1) ), 32) WHERE mag12 IS NULL')
	EXECUTE ('UPDATE parame SET mag13 = IsNull(Ascii( substring( magic, 13,1) ), 32) WHERE mag13 IS NULL')
	EXECUTE ('UPDATE parame SET mag14 = IsNull(Ascii( substring( magic, 14,1) ), 32) WHERE mag14 IS NULL')

	
	EXECUTE ('ALTER TABLE parame ALTER COLUMN mag1 smallint NOT NULL')
	EXECUTE ('ALTER TABLE parame ALTER COLUMN mag2 smallint NOT NULL')
	EXECUTE ('ALTER TABLE parame ALTER COLUMN mag3 smallint NOT NULL')
	EXECUTE ('ALTER TABLE parame ALTER COLUMN mag4 smallint NOT NULL')
	EXECUTE ('ALTER TABLE parame ALTER COLUMN mag5 smallint NOT NULL')
	EXECUTE ('ALTER TABLE parame ALTER COLUMN mag6 smallint NOT NULL')
	EXECUTE ('ALTER TABLE parame ALTER COLUMN mag7 smallint NOT NULL')
	EXECUTE ('ALTER TABLE parame ALTER COLUMN mag8 smallint NOT NULL')
	EXECUTE ('ALTER TABLE parame ALTER COLUMN mag9 smallint NOT NULL')
	EXECUTE ('ALTER TABLE parame ALTER COLUMN mag10 smallint NOT NULL')
	EXECUTE ('ALTER TABLE parame ALTER COLUMN mag11 smallint NOT NULL')
	EXECUTE ('ALTER TABLE parame ALTER COLUMN mag12 smallint NOT NULL')
	EXECUTE ('ALTER TABLE parame ALTER COLUMN mag13 smallint NOT NULL')
	EXECUTE ('ALTER TABLE parame ALTER COLUMN mag14 smallint NOT NULL')
END

/* ============================================================= */
/* == 11-08-2004   Add table ediservers                       == */
/* ============================================================= */

DECLARE @EDIServersExists smallint

EXEC sp_check_column_exists 'ediservers', 'servername', @EDIServersExists OUTPUT
IF @EDIServersExists = 0
BEGIN
  CREATE TABLE ediservers
   ( 	servername 	char(63) NOT NULL,
 	ipaddress  	char(20) ,
 	port 		integer NOT NULL,
 	active_date 	datetime,
 	active_time	datetime,
 	PRIMARY KEY (servername)
    )
    
    EXECUTE ('GRANT  REFERENCES ,  SELECT ,  INSERT ,  DELETE ,  UPDATE  ON ediservers TO edi_admin_users ')
END

/* ============================================================= */
/* == 18-08-2004   Add unique index for mfcvr                 == */
/* ============================================================= */

DECLARE @IndexMfcvrDescrp smallint

EXEC sp_check_index_exists 'sk_mfcvr_descrp',@IndexMfcvrDescrp OUTPUT
IF @IndexMfcvrDescrp = 0
BEGIN

	CREATE UNIQUE INDEX sk_mfcvr_descrp ON mfcvr
	(
		fc,
		descrp
	)
END


/* ============================================================= */
/* == 13-09-2004   Change uritopc.pc to non-identity          == */
/* ============================================================= */

declare @nrofURItoPC integer

SELECT @nrofURItoPC = count(*) FROM uritopc
IF @nrofURItoPC > 0
BEGIN

	CREATE TABLE tmp_uritopc
	(
		uri varchar(256) NOT NULL,
		pc integer NOT NULL,
		pname varchar(256) NULL
	)

	EXEC('INSERT INTO tmp_uritopc (uri, pc, pname) SELECT uri, pc, pname FROM uritopc')
END

DROP TABLE uritopc

CREATE TABLE uritopc
(
	uri   			varchar(256) NOT NULL,
	pc    			integer NOT NULL,
	pname 			varchar(256) NULL,
	PRIMARY KEY (uri)
)

CREATE UNIQUE INDEX sk_uritopc_pc ON uritopc
(
	pc
)

EXECUTE ('GRANT  REFERENCES ,  SELECT ,  INSERT ,  DELETE ,  UPDATE  ON uritopc TO edi_admin_users ')

IF @nrofURItoPC > 0
BEGIN
	EXEC('INSERT INTO uritopc (uri, pc, pname) SELECT uri, pc, pname FROM tmp_uritopc')
	DROP TABLE tmp_uritopc
END

/* ============================================================= */
/* == 13-09-2004   Add messagedigesty column                  == */
/* ============================================================= */

DECLARE @ReceiptExists smallint

EXEC sp_check_column_exists 'audin', 'messagedigest', @ReceiptExists OUTPUT
IF @ReceiptExists = 0
BEGIN
	ALTER TABLE audin ADD messagedigest varchar(128)
	ALTER TABLE audout ADD messagedigest varchar(128)

END

/* ============================================================= */
/* == 19-11-2004   Add origfilename to audin                  == */
/* ============================================================= */


DECLARE @OrigFnExists smallint

EXEC sp_check_column_exists 'audin', 'origfilename', @OrigFnExists OUTPUT
IF @OrigFnExists = 0
BEGIN
	ALTER TABLE audin ADD origfilename varchar(254) NULL
END

/* ============================================================= */
/* == 20-12-2004   Add setname to audin, audout               == */
/* ============================================================= */


DECLARE @SetnameExists smallint

EXEC sp_check_column_exists 'audin', 'setname', @SetnameExists OUTPUT
IF @SetnameExists = 0
BEGIN
	ALTER TABLE audin ADD setname varchar(15) NULL
	ALTER TABLE audout ADD setname varchar(15) NULL
END


/* ============================================================= */
/* == 21-12-2004   Add incrval to custids                      == */
/* ============================================================= */


DECLARE @IncrvalExists smallint

EXEC sp_check_column_exists 'custids', 'incrval', @IncrvalExists OUTPUT
IF @IncrvalExists = 0
BEGIN
	ALTER TABLE custids ADD incrval smallint NULL
	EXECUTE ('UPDATE custids SET incrval = 1' )
	EXECUTE ('ALTER TABLE custids ALTER COLUMN incrval smallint NOT NULL' )
	
END


/* ============================================================= */
/* == 23-12-2004   Add hashtot to msgs1                       == */
/* ============================================================= */


DECLARE @HashtotExists smallint

EXEC sp_check_column_exists 'msgs1', 'hashtot', @HashtotExists OUTPUT
IF @HashtotExists = 0
BEGIN
	ALTER TABLE msgs1 ADD hashtot varchar(64) NULL
END


/* ============================================================= */
/* == 17-01-2005   add ftpsrv to prtnr3                       == */
/* ============================================================= */

DECLARE @FTPSrvExists smallint
EXEC sp_check_column_exists 'prtnr3', 'ftpsrv', @FTPSrvExists OUTPUT               
IF @FTPSrvExists = 0
BEGIN
	ALTER TABLE prtnr3 ADD ftpsrv smallint NULL
	
END

/* ======================================================== */
/* == 19-01-2005 Add tslen to prtnr3                     == */
/* ======================================================== */

DECLARE @tslenExists smallint
EXEC sp_check_column_exists 'prtnr3', 'tslen', @tslenExists OUTPUT     
IF @tslenExists = 0
BEGIN
	ALTER TABLE prtnr3 ADD tslen smallint NULL
END 

/* ======================================================== */
/* == 11-05-2005 Case sensitivity for roles              == */
/* ======================================================== */

IF NOT EXISTS (SELECT * from dbo.sysusers WHERE name = 'BTS_OPERATORS')
     EXEC sp_addrole 'BTS_OPERATORS'
      
/* ======================================================== */
/* == 04-05-2005 Add role bts_operators                  == */
/* ======================================================== */
GRANT  REFERENCES ,  SELECT  ON audin  TO BTS_OPERATORS
GRANT  REFERENCES ,  SELECT  ON audout TO BTS_OPERATORS
GRANT  REFERENCES ,  SELECT  ON errors TO BTS_OPERATORS

/* ======================================================== */
/* == May 23, 2005: Add grant execute of                 == */
/* ==               adm_Query_BiztalkDBVersion		 == */
/* ======================================================== */
GRANT EXECUTE ON adm_Query_BizTalkDBVersion TO BTS_OPERATORS

/* ======================================================== */
/* == August 22, 2005: Remove column from trafun table   == */
/* ======================================================== */

DECLARE @functionExists smallint

EXEC sp_check_column_exists 'trafun', 'function', @functionExists OUTPUT
IF @functionExists > 0
BEGIN
	ALTER TABLE trafun
		DROP COLUMN [function]
END 

/* ======================================================== */
/* == September 22, 2005: Add column to parame table     == */
/* ======================================================== */	

DECLARE @subsystemusersgroupExists smallint

EXEC sp_check_column_exists 'parame', 'subsystemusersgroup', @subsystemusersgroupExists OUTPUT
IF @subsystemusersgroupExists = 0
BEGIN
	ALTER table parame 
	  ADD subsystemusersgroup varchar(128) NULL
END

	
/* ****************************************************** */
/* **  STEP 3 -  Cleanup procedures                    ** */
/* ****************************************************** */

DROP PROCEDURE sp_check_column_exists
DROP PROCEDURE sp_check_index_exists
DROP PROCEDURE sp_get_column_size
DROP PROCEDURE sp_get_pk_constraint_name