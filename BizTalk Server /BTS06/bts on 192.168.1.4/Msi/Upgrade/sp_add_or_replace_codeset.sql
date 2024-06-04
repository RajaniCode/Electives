CREATE PROCEDURE sp_add_or_replace_codeset
	@col_fc		smallint,	@col_envr	varchar(206),
	@col_code	varchar(254),	@col_descrp	char(35),
	@col_espcomment	varchar(160)
AS
BEGIN
	DECLARE @codsetExists int
	SELECT @codsetExists = count(*) FROM codset WHERE fc = @col_fc AND lower(envr) = lower(@col_envr) AND lower(code) =lower( @col_code )

	SELECT case @codsetExists when 0  then '...Insert codeset' else '...Update codeset' end ,
		'fc: '+ convert(char(2),@col_fc) + ',',
		'envr: "' + @col_envr + '",',
		'code: "' + @col_code + '"' from parame
	
	IF @codsetExists = 0 
		INSERT INTO codset (fc, envr, code, descrp, espcomment) VALUES (@col_fc, @col_envr, @col_code, @col_descrp, @col_espcomment)
	ELSE
		UPDATE codset SET descrp = @col_descrp ,espcomment = @col_espcomment WHERE fc = @col_fc AND lower(envr) = lower(@col_envr) AND lower(code) =lower( @col_code ) 
END
	
