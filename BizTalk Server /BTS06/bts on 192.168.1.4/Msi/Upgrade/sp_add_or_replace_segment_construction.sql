CREATE PROCEDURE sp_add_or_replace_segment_construction
		@col_fc		smallint,
		@col_snvr	varchar (206),
		@col_esnr	smallint,
		@col_espindex	smallint,
		@col_envr	varchar (206),
		@col_compos	smallint,
		@col_manc1	smallint,
		@col_manc2	smallint,
		@col_pos	smallint
AS
BEGIN
	DECLARE @segconExists int
	SELECT @segconExists = count(*) FROM segcon WHERE fc = @col_fc AND lower(snvr) = lower(@col_snvr) AND esnr = @col_esnr   
	
	SELECT case @segconExists when 0  then '...Insert segment construction' else '...segment construction' end ,
		'fc: '+ convert(char(2),@col_fc) + ',',
		'snvr: "' + @col_snvr + '",',
		'esnr: '+ convert(varchar(8),@col_esnr) from parame
		
	IF @segconExists = 0
		INSERT INTO segcon (fc , snvr , esnr , espindex , envr , compos , manc1 , manc2 , pos )
			VALUES (@col_fc , @col_snvr , @col_esnr , @col_espindex , @col_envr , @col_compos , @col_manc1 , @col_manc2 , @col_pos )
	ELSE
		UPDATE segcon SET espindex = @col_espindex , envr = @col_envr , compos = @col_compos , manc1 = @col_manc1 , manc2 = @col_manc2 , pos = @col_pos
		       WHERE fc = @col_fc AND lower(snvr) = lower(@col_snvr) AND esnr = @col_esnr 
END		       
