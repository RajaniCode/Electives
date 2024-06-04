CREATE PROCEDURE sp_update_segment_construction
		@col_fc		smallint,
		@col_segnam	varchar(200),
		@col_segtag	char(5),
		@col_snvr 	varchar(206),
		@col_ver	char(3),
		@col_rel	char(3)
AS
BEGIN
	DECLARE @SegmentInUse int, @ElementExists int, @esnr smallint, @envr varchar(206), @manc1	smallint, @manc2 smallint

	SELECT @SegmentInUse = count(*) FROM msgs2 WHERE ( msgs2.fc = @col_fc ) AND (msgs2.snvr = @col_snvr )
	
	SELECT case @SegmentInUse when 0
		  then '..Segment is not used in any document' 
		  else '..Update document segment fc: '+ convert(char(2),@col_fc) + ', snvr: "' + @col_snvr + '"' 
		  end from parame
	
	IF @SegmentInUse > 0
	BEGIN
		DECLARE Construction CURSOR FOR
			SELECT segcon.esnr, segcon.envr, segcon.manc1, segcon.manc2  
		 	FROM segcon, sgmnts 
	  		WHERE  ( sgmnts.fc = segcon.fc ) and 
	     		( sgmnts.snvr = segcon.snvr ) and 
	     		( sgmnts.fc = @col_fc ) and 
	     		( sgmnts.snvr = @col_snvr )
	     	ORDER BY segcon.espindex
     	
		OPEN Construction 
 		FETCH NEXT FROM Construction INTO @esnr, @envr , @manc1, @manc2 

		WHILE @@FETCH_STATUS = 0
		BEGIN

	 		SELECT @ElementExists =count(*)	FROM msgs2, msgs3
  			WHERE 	( msgs3.fc = msgs2.fc ) and ( msgs3.mcvr = msgs2.mcvr ) and ( msgs3.ssnr = msgs2.ssnr ) and 
  				( msgs3.fc =@col_fc ) AND ( msgs2.snvr = msgs2.snvr ) AND ( msgs3.esnr = @esnr )
	
	     		IF @ElementExists = 0 
	     		BEGIN
	     			SELECT '....Insert document element fc: '+ convert(char(2),@col_fc) + ',',
	     				'mcvr: "' + msgs2.mcvr + '",',   'snvr: "' + @col_snvr + '"' 
				  FROM msgs2, segcon, sgmnts 
				  WHERE ( sgmnts.fc = segcon.fc ) and ( sgmnts.fc = msgs2.fc ) and 
				     ( sgmnts.snvr = segcon.snvr ) and ( sgmnts.snvr = msgs2.snvr ) and
				     ( msgs2.fc = @col_fc ) and ( msgs2.snvr = @col_snvr )
	     		
				INSERT INTO msgs3 (fc, mcvr, ssnr, esnr, manc1, manc2, numhan, valtyp, elmalign, labalign, hrefurl, imgurl )
				 SELECT @col_fc, msgs2.mcvr, msgs2.ssnr, @esnr, @manc1, @manc2, 0, 0, 0, 0, 0, 0 
				  FROM msgs2, segcon, sgmnts 
				  WHERE ( sgmnts.fc = segcon.fc ) and ( sgmnts.fc = msgs2.fc ) and 
				     ( sgmnts.snvr = segcon.snvr ) and ( sgmnts.snvr = msgs2.snvr ) and
				     ( msgs2.fc = @col_fc ) and ( msgs2.snvr = @col_snvr )

			END
			FETCH NEXT FROM Construction INTO @esnr, @envr , @manc1, @manc2
		END 

		CLOSE Construction
		DEALLOCATE Construction

		/* Remove all msgs3 that do not have a matching segcon */
		SELECT '....Delete document elements.' from parame
		
		DELETE FROM msgs3 WHERE not exists ( SELECT * FROM msgs2, segcon
       						      WHERE ( msgs2.fc = segcon.fc ) and ( msgs2.snvr = segcon.snvr ) and 
         						    ( (segcon.fc = @col_fc) AND ( segcon.snvr = @col_snvr ) AND
         						      (segcon.esnr = msgs3.esnr ) AND (msgs3.ssnr = msgs2.ssnr) ) )
	END
END
