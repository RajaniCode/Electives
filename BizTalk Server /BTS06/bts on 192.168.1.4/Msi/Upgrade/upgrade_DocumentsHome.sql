
SET NOCOUNT ON

CREATE TABLE #EnvironmentVariables (output varchar(1000))  

INSERT #EnvironmentVariables EXEC master..xp_cmdshell 'set allusersprofile'
 
DECLARE @alluserspath sysname

SELECT @alluserspath = Substring (output,
                      CharIndex ('=',output) +1,
                      len(output) - CharIndex ('=',output))
FROM #EnvironmentVariables
WHERE
upper ('ALLUSERSPROFILE') = upper (Substring (output,1,CharIndex ('=',output)-1))

UPDATE parame SET documentshome = (@alluserspath + '\Application Data\Microsoft\BizTalk Server 2004\EDI\Subsystem')

DROP TABLE #EnvironmentVariables

SET NOCOUNT OFF