CREATE PROCEDURE sp_add_or_replace_element
        @col_fc		smallint,	@col_envr	varchar(206),
	@col_elmnam	varchar(200),	@col_ver	char (3),
	@col_rel	char (3),	@col_qualyn	smallint,
	@col_elmtag	smallint,	@col_elmtyp	char (2),
	@col_len	smallint,	@col_fxdlen	smallint,
	@col_minlen	smallint,	@col_internal	smallint,	
	@col_tablename	varchar (80),	@col_columnname	varchar (80),
	@ElmntExists	smallint OUTPUT
AS   
BEGIN
 
	SELECT @ElmntExists = count(*) FROM elmnts WHERE fc = @col_fc AND lower(envr) = lower( @col_envr )
	
	SELECT case @ElmntExists when 0  then '..Insert element' else '..Update element' end ,
		'fc: '+ convert(char(2),@col_fc) + ',',
		'envr: "' + @col_envr + '"' from parame
	
	IF @ElmntExists = 0 
		INSERT INTO elmnts ( fc, envr , elmnam , ver , rel , qualyn , elmtag , elmtyp , len , fxdlen ,  minlen , internal ,  tablename , columnname )
		       VALUES ( @col_fc, @col_envr , @col_elmnam , @col_ver , @col_rel , @col_qualyn , @col_elmtag , @col_elmtyp , @col_len , @col_fxdlen ,  @col_minlen , @col_internal ,  @col_tablename , @col_columnname )
	ELSE
	BEGIN
		UPDATE elmnts SET elmnam = @col_elmnam , ver = @col_ver , rel = @col_rel , qualyn = @col_qualyn , elmtag = @col_elmtag , elmtyp = @col_elmtyp , len = @col_len , fxdlen = @col_fxdlen ,  minlen = @col_minlen , internal = @col_internal , tablename = @col_tablename , columnname = @col_columnname 
			WHERE fc = @col_fc AND lower(envr) = lower( @col_envr )
		/* When no code set is used... remove all existing codset entries for the element */
		IF @col_qualyn = 0
		BEGIN
			SELECT '...Removing codesets for fc: '+ convert(char(2),@col_fc) + ',',
				'envr: "' + @col_envr + '"' from parame
				
		 	DELETE FROM codset WHERE ( codset.fc = @col_fc ) AND  ( codset.envr = @col_envr )
		 	DELETE FROM msgs4  WHERE (msgs4.fc =  @col_fc ) AND 
					 	 EXISTS ( SELECT * FROM msgs3, segcon, msgs2 
					 	 	   WHERE segcon.fc = @col_fc AND segcon.envr = @col_envr
							     AND msgs2.fc = segcon.fc AND msgs3.fc = segcon.fc
							     AND msgs2.snvr = segcon.snvr AND msgs3.mcvr = msgs2.mcvr
							     AND msgs3.ssnr = msgs2.ssnr AND msgs3.esnr = segcon.esnr
							     AND msgs3.esnr = msgs4.esnr AND msgs3.ssnr = msgs4.ssnr AND msgs3.mcvr = msgs4.mcvr )
					 	
		END
        END 

END     

