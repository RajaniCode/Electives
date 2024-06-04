CREATE PROCEDURE sp_add_or_replace_segment
		@col_fc		smallint,
		@col_segnam	varchar(200),
		@col_segtag	char(5),
		@col_snvr	varchar(206),
		@col_ver	char(3),
		@col_rel	char(3),
		@sgmntExists	smallint OUTPUT
AS
BEGIN		
	SELECT @sgmntExists = count(*) FROM sgmnts WHERE fc = @col_fc	 AND lower(snvr) = lower( @col_snvr )
	
	SELECT case @sgmntExists when 0  then '..Insert segment' else '..Update segment' end ,
		'fc: '+ convert(char(2),@col_fc) + ',',
		'snvr: "' + @col_snvr + '"' from parame
	
	IF @sgmntExists = 0
		INSERT INTO sgmnts (fc, segnam, segtag, snvr, ver, rel)
			VALUES ( @col_fc, @col_segnam, @col_segtag, @col_snvr, @col_ver, @col_rel)
	ELSE
  		UPDATE sgmnts SET segnam = @col_segnam, segtag = @col_segtag, ver = @col_ver, rel = @col_rel WHERE fc = @col_fc	AND lower(snvr) = lower( @col_snvr )
  		
END