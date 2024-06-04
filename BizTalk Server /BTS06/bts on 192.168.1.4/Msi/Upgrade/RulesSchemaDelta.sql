-- add 2 missing values if not already in the database
IF NOT EXISTS (SELECT * FROM [dbo].[re_config] WHERE strConfigName = N'deploymenthistory')
	INSERT INTO [dbo].[re_config](strConfigName, nConfigValue) VALUES(N'deploymenthistory', 48)
GO

IF NOT EXISTS (SELECT * FROM [dbo].[re_config] WHERE strConfigName = N'audithistory')
	INSERT INTO [dbo].[re_config](strConfigName, nConfigValue) VALUES(N'audithistory', 90)
GO

-- add column nTrackingConfig to re_tracking_id table if it's not there
IF NOT EXISTS (select name from syscolumns WHERE name = N'nTrackingConfig' AND id = object_id(N're_tracking_id'))
	ALTER TABLE [dbo].[re_tracking_id] ADD [nTrackingConfig] [bigint] NULL
GO

-- add 4 indecies to vocabulary<->vocabulary and ruleset<->vocabulary tables
IF NOT EXISTS (SELECT name FROM dbo.sysindexes WHERE name = N're_refering_id_index' AND id = object_id(N're_vocabulary_to_vocabulary_links'))
	CREATE CLUSTERED INDEX re_refering_id_index ON [dbo].[re_vocabulary_to_vocabulary_links](nReferingVocabulary)
GO

IF NOT EXISTS (SELECT name FROM dbo.sysindexes WHERE name = N're_vocabulary_id_index' AND id = object_id(N're_vocabulary_to_vocabulary_links'))
	CREATE INDEX re_vocabulary_id_index ON [dbo].[re_vocabulary_to_vocabulary_links](nVocabularyID)
GO

IF NOT EXISTS (SELECT name FROM dbo.sysindexes WHERE name = N're_refering_id_index' AND id = object_id(N're_ruleset_to_vocabulary_links'))
	CREATE CLUSTERED INDEX re_refering_id_index ON [dbo].[re_ruleset_to_vocabulary_links](nReferingRuleset)
GO

IF NOT EXISTS (SELECT name FROM dbo.sysindexes WHERE name = N're_vocabulary_id_index' AND id = object_id(N're_ruleset_to_vocabulary_links'))
	CREATE INDEX re_vocabulary_id_index ON [dbo].[re_ruleset_to_vocabulary_links](nVocabularyID)
GO

-- database is now at version 7
UPDATE [dbo].[re_config] SET nConfigValue = 7 WHERE strConfigName = N'version' AND nConfigValue < 7
GO
