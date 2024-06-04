on error resume next

Dim dsoServer : Set dsoServer = CreateObject("DSO.Server")  
Dim dsoDB, dsoCube, dsoPartition, dsoDimension, dsoLevel

' Create a connection to the Analysis server.
dsoServer.Connect WScript.Arguments(0)
if Err.Number <> 0 then
	wscript.quit Err.Number
end if

' Set the database object.
Set dsoDB = dsoServer.MDStores(WScript.Arguments(1))
if Err.Number <> 0 then
	wscript.quit Err.Number
end if

set dsoDataSource = dsoDB.DataSources(1)
dsoDataSource.Update
if Err.Number <> 0 then
	wscript.quit Err.Number
end if

Set dsoCube = dsoDB.MDStores("MessageMetrics")
if Err.Number <> 0 then
	wscript.quit Err.Number
end if

set dsoPartition = dsoCube.Partitions("MessageMetrics")
set dsoDbDimension = dsoDB.Dimensions("MessageMetrics^URL")
dsoDbDimension.FromClause = """dta_MessageInOutEvents"""

set dsoDbLevel = dsoDbDimension.Levels("URL")
dsoDbLevel.MemberKeyColumn = "dta_MessageInOutEvents.""strUrl"""
dsoDbLevel.MemberNameColumn = "dta_MessageInOutEvents.""strUrl"""
dsoDbDimension.Update
if Err.Number <> 0 then
	wscript.echo "Failed to Update DatabaseDimension MessageMetrics^URL: " & err.Description
	wscript.quit Err.Number
end if

dsoCube.JoinClause = """dta_MessageInOutEvents"".nStatus = dta_MessageStatus.nMessageStatusId AND ""dta_MessageInOutEvents"".nSchemaId = dta_SchemaName.nSchemaId AND ""dta_MessageInOutEvents"".nAdapterId = dta_Adapter.nAdapterId AND ""dta_MessageInOutEvents"".nDecryptionSubjectId = dta_DecryptionSubject.nDecryptionSubjectId AND ""dta_MessageInOutEvents"".nSigningSubjectId = dta_SigningSubject.nSigningSubjectId AND ""dta_MessageInOutEvents"".uidServiceInstanceId = dta_ServiceInstances.uidServiceInstanceId AND dta_ServiceInstances.uidServiceId = ""dta_Services"".uidServiceId AND ""dta_MessageInOutEvents"".uidServiceInstanceId = dta_ServiceInstances.uidServiceInstanceId AND dta_ServiceInstances.nMessageBoxId = ""dta_MessageBox"".nMessageBoxId AND ""dta_MessageInOutEvents"".uidServiceInstanceId = dta_ServiceInstances.uidServiceInstanceId AND dta_ServiceInstances.nHostId = ""dta_Host"".nHostId"
dsoCube.DrillThroughJoins = """dta_MessageInOutEvents"".nEventId=""dtav_MessageFacts"".""Event/EventID"""

dsoCube.Update
if Err.Number <> 0 then
	wscript.echo "Failed to Update: " & err.Description
	wscript.quit Err.Number
end if
dsoDb.Update
if Err.Number <> 0 then
	wscript.echo "Failed to Update db: " & err.Description
	wscript.quit Err.Number
end if

Set dsoCube = nothing

Set dsoCube = dsoDB.MDStores("ServiceMetrics")
if Err.Number <> 0 then
	wscript.quit Err.Number
end if

'-------------
'Fix the case of clauses for binary collation servers. We need to embed spaces initially to force DSO to accept changes since it ignores if values differ only by case.
dsoCube.JoinClause = """dta_ServiceInstances"".uidServiceId    = ""dta_Services"".uidServiceId AND ""dta_ServiceInstances"".nMessageBoxId = ""dta_MessageBox"".nMessageBoxId AND ""dta_ServiceInstances"".nHostId = ""dta_Host"".nHostId AND ""dta_ServiceInstances"".nServiceStateId = ""dta_ServiceState"".nServiceStateId"
dsoCube.DrillThroughColumns = " dtav_ServiceFacts.*"
dsoCube.DrillThroughFrom = " dtav_ServiceFacts"
dsoCube.DrillThroughJoins = "dta_ServiceInstances.uidServiceInstanceId  =dtav_ServiceFacts.[ServiceInstance/InstanceID]"
dsoCube.Update
if Err.Number <> 0 then
	wscript.echo "Failed to modify cube ServiceMetrics: " & err.Description
	wscript.quit Err.Number
end if

dsoCube.JoinClause = """dta_ServiceInstances"".uidServiceId = ""dta_Services"".uidServiceId AND ""dta_ServiceInstances"".nMessageBoxId = ""dta_MessageBox"".nMessageBoxId AND ""dta_ServiceInstances"".nHostId = ""dta_Host"".nHostId AND ""dta_ServiceInstances"".nServiceStateId = ""dta_ServiceState"".nServiceStateId"
dsoCube.DrillThroughColumns = "dtav_ServiceFacts.*"
dsoCube.DrillThroughFrom = "dtav_ServiceFacts"
dsoCube.DrillThroughJoins = "dta_ServiceInstances.uidServiceInstanceId=dtav_ServiceFacts.[ServiceInstance/InstanceID]"
dsoCube.Update
if Err.Number <> 0 then
	wscript.echo "Failed to update cube ServiceMetrics: " & err.Description
	wscript.quit Err.Number
end if
'-------------

'wscript.echo dsoCube.JoinClause
'wscript.echo dsoCube.DrillThroughFrom
'wscript.echo dsoCube.DrillThroughJoins

dsoDB.Update
if Err.Number <> 0 then
	wscript.echo "Failed to update db: " & err.Description
	wscript.quit Err.Number
end if

