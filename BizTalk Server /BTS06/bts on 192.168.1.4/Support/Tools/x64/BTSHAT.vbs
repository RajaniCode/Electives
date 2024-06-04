'script for doing HAT thing

'Ready to run 1 
'Active 2 
'Suspended (resumable) 4 
'Dehydrated 8 
'Completed with discarded messages 16 
'Suspended (not resumable) 32 
'In breakpoint 64 
'No operation 1 
'Suspend 2 
'Terminate 4 
'Resume 8 




   Dim objLocator : Set objLocator = CreateObject("WbemScripting.SWbemLocator")
   Dim objServices : Set objServices = objLocator.ConnectServer(, "root/MicrosoftBizTalkServer")
   Dim strQueryString
   Dim objQueue
   Dim svcInsts
   Dim count
   Dim inst
   Dim fso
   Dim tf
   Dim OutputFile



  On Error Resume Next

   OutputFile="output\5XUEHONGG__BizTalk_Base_GetBizTalkHAT_Shutdown.TXT"
   set fso=CreateObject("Scripting.FileSystemObject")
   if fso.FileExists(OutputFile) then
      fso.DeleteFile(OutputFile)
   end if

   Set tf = fso.CreateTextFile(OutputFile, True)


   ' Query for suspended (resumable) service instances of the specified orchestration

   'set svcInsts = objServices.ExecQuery("Select * from MSBTS_ServiceInstance where ServiceStatus = 4 OR ServiceStatus = 32 OR ServiceStatus = 8 OR ServiceStatus = 2")
      set svcInsts = objServices.ExecQuery("Select * from MSBTS_ServiceInstance")
   count = svcInsts.count

   tf.write "Total instances found: " & count & vbCrLf
   tf.write " " & vbCrLf

   If ( count > 0 ) Then

      Dim strHostName
      Dim aryClassIDs()
      Dim aryTypeIDs()
      Dim aryInstanceIDs()
      redim aryClassIDs(count-1)
      redim aryTypeIDs(count-1)
      redim aryInstanceIDs(count-1)

      ' Enumerate the ServiceInstance classes to construct ID arrays to be passed into ResumeServiceInstancesByID() method
      Dim i : i= 0
      For each inst in svcInsts
	tf.write "Service Name: " & inst.ServiceName  & vbCrLf
	tf.write "Service Class: " & inst.ServiceClass  & vbCrLf
	tf.write "Instance ID: " & inst.InstanceID  & vbCrLf
	tf.write "Activation Time: " & inst.ActivationTime  & vbCrLf
	tf.write "Service Status: " & inst.ServiceStatus  & vbCrLf
	tf.write "Host Name: " & inst.HostName  & vbCrLf
	tf.write "Suspend Time: " & inst.SuspendTime  & vbCrLf
	tf.write "Error Category: " & inst.ErrorCategory  & vbCrLf
	tf.write "Error Description: " & inst.ErrorDescription  & vbCrLf
	tf.write "Pending Operation: " & inst.PendingOperation  & vbCrLf
	tf.write " "  & vbCrLf
      Next
 
   End IF

   tf.Close
   Set objTextStream = Nothing
   Set objFSO = Nothing

   Set objLocator = Nothing
   Set objServices = Nothing
   Set objQueue = Nothing


