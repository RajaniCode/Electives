' Filename: Register_Ops_Adapter.vbs
'
' Author: James Talbot <jtalbot@microsoft.com>
'
' Date: August 12, 2005
'
' Last Revision: August 31, 2005
'
' A simple tool to discover the correct path to the Ops Adapter
' and add the correct registry entries for BizTalk
'
' Assumption: Executed from ...\SDK\Scenarios\BPM\OpsAdapter

Option Explicit

Dim WSHShell
Dim AdapterClsid, BaseKey, BizTalkKey, ImplKey, CatIDKey
Dim RegValue(11)
Dim I

Set WSHShell = WScript.CreateObject("WScript.Shell")

AdapterClsid = "{05fdfef2-0d1a-4d8a-9243-f9c869277273}"
BaseKey = "HKEY_CLASSES_ROOT\CLSID\" & AdapterClsid & "\"
'BaseKey    = "HKEY_CLASSES_ROOT\CLSID\{05fdfef2-0d1a-4d8a-9243-f9c869277273}\"
BizTalkKey = BaseKey & "BizTalk\"
ImplKey    = BaseKey & "Implemented Categories\"
CatIDKey   = ImplKey & "{7F46FC3E-3C2C-405B-A47F-8D17942BA8F9}\"

RegValue(0)  = Array(BaseKey    & "AppID", "{21f48b10-1c29-4172-a67a-2f705f7c02e5}", "REG_SZ")
RegValue(1)  = Array(BizTalkKey & "AdapterMgmtAssemblyPath", GetFullBinPath() & "Microsoft.Samples.BizTalk.SouthridgeVideo.OpsAdapterMgmt.dll", "REG_SZ")
RegValue(2)  = Array(BizTalkKey & "AdapterMgmtTypeName", "Microsoft.Samples.BizTalk.SouthridgeVideo.Adapters.OpsAdapter.OpsDesignTime.AdapterManagement", "REG_SZ")
RegValue(3)  = Array(BizTalkKey & "AliasesXML", "<AdapterAliasList><AdapterAlias>OPS://</AdapterAlias></AdapterAliasList>", "REG_SZ")
RegValue(4)  = Array(BizTalkKey & "Constraints", "2", "REG_DWORD")
RegValue(5)  = Array(BizTalkKey & "OutboundAssemblyPath", GetFullBinPath() & "Microsoft.Samples.BizTalk.SouthridgeVideo.OpsTxAdapter.dll", "REG_SZ")
RegValue(6)  = Array(BizTalkKey & "OutboundEngineCLSID", "{fb1659a6-9a71-46aa-be4a-03488f0ca6a1}", "REG_SZ")
RegValue(7)  = Array(BizTalkKey & "OutboundTypeName", "Microsoft.Samples.BizTalk.SouthridgeVideo.Adapters.OpsAdapter.RunTime.OpsTransmitAdapter.OpsTransmitter", "REG_SZ")
RegValue(8)  = Array(BizTalkKey & "PropertyNameSpace", "http://schemas.microsoft.com/Samples/BizTalk/SouthridgeVideo/Adapters/OpsAdapter", "REG_SZ")
RegValue(9)  = Array(BizTalkKey & "SendLocationPropertiesXML", "<CustomProps><AdapterConfig vt=""8""/></CustomProps>", "REG_SZ")
RegValue(10) = Array(BizTalkKey & "TransmitLocation_PageProv", "{2DE93EE6-CB01-4007-93E9-C3D71689A282}", "REG_SZ")
RegValue(11) = Array(BizTalkKey & "TransPortType", "OPS", "REG_SZ")


'Add Registry Keys
WSHShell.RegWrite BaseKey,    "Ops Adapter"
WSHShell.RegWrite BizTalkKey, "BizTalk"
WSHShell.RegWrite ImplKey,    ""
WSHShell.RegWrite CatIDKey,   ""

'Add Registry Values
For I = 0 to 11
    WSHShell.RegWrite RegValue(I)(0), RegValue(I)(1), RegValue(I)(2)
Next

'Add the adapter to BizTalk
CreateAdapter "OPS", AdapterClsid, "Operations adapter for BPM Scenario"

'******** THE END ********'

Function GetFullBinPath()
    Dim ScriptFullPath, FullOpsPath, FullBinPath
    Dim Position

    ScriptFullPath = WScript.ScriptFullName

    Position = InStrRev(ScriptFullPath, "\", -1)

    FullOpsPath = Left(ScriptFullPath, Position)

    FullBinPath = FullOpsPath & "bin\"

    GetFullBinPath = FullBinPath
End Function


Sub CreateAdapter(strAdapterName, strAdapterClsid, strComment)
    Dim wmiObj, objBTSAdapter, objBTSAdapterInstance
    
    Set wmiObj = GetObject("Winmgmts:!root\MicrosoftBizTalkServer")
    Set objBTSAdapter = wmiObj.Get("MSBTS_AdapterSetting")
    Set objBTSAdapterInstance = objBTSAdapter.SpawnInstance_
    
    objBTSAdapterInstance.Name = strAdapterName
    objBTSAdapterInstance.MgmtCLSID = strAdapterClsid
    objBTSAdapterInstance.Comment = strComment

    On Error Resume Next
    objBTSAdapterInstance.Put_ (2) 'wbemChangeFlagCreateOnly
    if Err <> 0 Then
        WScript.Echo Err.Description
    End If
    On Error Goto 0
    
    Set objBTSAdapter = nothing
    Set objBTSAdapterInstance = nothing
    Set wmiObj = nothing
End Sub