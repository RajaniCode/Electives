--//
--// Update for BAM Messaging Deserializer
--//
DECLARE	@rowCount INT
SELECT	@rowCount = COUNT(*) 
FROM	TDDS_CustomFormats
WHERE	FormatID = N'{f3179eda-0da5-4f5f-818e-d231c85a52a9}'

IF (@rowCount = 0)
BEGIN
    INSERT INTO TDDS_CustomFormats(
        FormatID,
        DecoderClass,
        DllName
    ) 
	VALUES(
        N'{f3179eda-0da5-4f5f-818e-d231c85a52a9}', 
        N'Microsoft.BizTalk.Tracking.Deserializer.BamMessagingDeserializer', 
        N'Microsoft.BizTalk.TrackingService.dll'
    )
END
GO

--//
--// Update for Default Pipelines
--//
UPDATE bts_pipeline SET Release = 2 FROM bts_pipeline p
JOIN bts_assembly a ON p.nAssemblyID = a.nID
WHERE a.nvcName = N'Microsoft.BizTalk.DefaultPipelines' and a.nvcPublicKeyToken = N'31bf3856ad364e35'
GO

--//
--// Update for Deployment
--//

CREATE NONCLUSTERED INDEX [IX_bt_DocumentSpec_msgtype] ON [dbo].[bt_DocumentSpec] 
(
	[msgtype] ASC,
	[assemblyid] ASC,
	[shareid] ASC
)
GO

CREATE NONCLUSTERED INDEX [IX_bts_assembly] ON [dbo].[bts_assembly] 
(
	[nvcName] ASC,
	[nVersionMajor] ASC,
	[nVersionMinor] ASC,
	[nVersionBuild] ASC,
	[nVersionRevision] ASC,
	[nID] ASC
)
GO

