' VBScript source code
  Dim Connection, WQL, SystemClass, System
  
  'Get connection To local wmi
  Set Connection = GetObject("winmgmts:root\MicrosoftBizTalkServer")
  
  'Get Hws_Action objects
  WQL = "Select * From Hws_Action"
  Set Actions = Connection.ExecQuery(WQL)
  
  'Loop through each action to register
  For Each action In Actions
    ' Show the Display Name
    if action.DisplayName = "Microsoft.Samples.BizTalk.Actions.Assign" then
		action.ExecMethod_ "Register"
		AddAllowAllConstraint action.ID
    end if
  Next

WScript.Quit

Sub AddAllowAllConstraint(ActionTypeID)

	dim objLocator , objService, objBTSRecvSvc, obInst
	dim clause(0), targetclause(0)
	dim localMachineName
	localMachineName = WScript.CreateObject("WScript.Network").ComputerName

	' Create the Clause XML
	clause(0) = "<c:Clause xmlns:c='http://MicrosoftBizTalk2004/Hws/WMI/Clause'><ClauseID></ClauseID><IsNew>1</IsNew><IsModified>0</IsModified><AllowAll>1</AllowAll><FactRetrieverID></FactRetrieverID><ConstraintFactID></ConstraintFactID><Operator xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xsi:nil='1'></Operator></c:Clause>"

	targetclause(0) = "<c:Clause xmlns:c='http://MicrosoftBizTalk2004/Hws/WMI/Clause'><ClauseID></ClauseID><IsNew>1</IsNew><IsModified>0</IsModified><AllowAll>0</AllowAll><FactRetrieverID>{0A385380-77EB-4DFD-A3E1-9DC954643194}</FactRetrieverID><ConstraintFactID>{D6AE92A2-BD7A-48AA-AE58-3C6C8497250D}</ConstraintFactID><Operator>4</Operator><Value><Type>0</Type><StaticValue>" & localMachineName &"\Mary</StaticValue><FactRetrieverID></FactRetrieverID><ConstraintFactID></ConstraintFactID></Value><Value><Type>0</Type><StaticValue>" & localMachineName &"\John</StaticValue><FactRetrieverID></FactRetrieverID><ConstraintFactID></ConstraintFactID></Value><Value><Type>0</Type><StaticValue>" & localMachineName &"\Susan</StaticValue><FactRetrieverID></FactRetrieverID><ConstraintFactID></ConstraintFactID></Value></c:Clause>"

	' Open a connection to root/MicrosoftBizTalkServer namespace		
	Set objLocator = CreateObject("WbemScripting.SWbemLocator")
	Set objService = objLocator.ConnectServer(, "root/MicrosoftBizTalkServer")
	objService.Security_.AuthenticationLevel = 6 ' wbemAuthenticationLevelPktPrivacy
	objService.Security_.ImpersonationLevel = 3 'wbemImpersonationLevelImpersonate

	' Use the constraint class
	Set objBTSRecvSvc = objService.Get("Hws_Constraint")
	Set obInst = objBTSRecvSvc.SpawnInstance_

	' Set the action ID
	obInst.ActionID = trim(ActionTypeID)

	' Use AllowAll for Source/EnactedOn/Target clauses
	obInst.SourceClauses = clause 
	obInst.EnactedOnClauses = clause 
	obInst.TargetClauses = targetclause

	' Set IsNegative, LastModfiedTimeStamp and TargetGroupName
	obInst.IsNegative = false
	obInst.LastModifiedTimestamp = null
	obInst.TargetGroupName = null

	' Save the constraint
	obInst.Put_(wbemChangeFlagCreateOnly )

End Sub
