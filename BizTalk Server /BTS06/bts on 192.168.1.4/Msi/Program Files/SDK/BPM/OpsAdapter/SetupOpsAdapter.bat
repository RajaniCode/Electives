@REM
@REM Build the Ops adapter
@REM

@SET BASE_ADAPTER_PATH="..\..\..\..\SDK\Samples\AdaptersDevelopment\BaseAdapter\v1.0.2\"
@SET OPSADAPTER_SOLUTION_NAME=OpsAdapter.sln

@REM Create the public key for the base adapter
@REM
@PUSHD %BASE_ADAPTER_PATH%
@IF NOT EXIST BaseAdapter.snk (sn -k BaseAdapter.snk)
@POPD

@ECHO
@ECHO Building the ops adapter project
devenv %OPSADAPTER_SOLUTION_NAME% /Build "Debug" /Out OpsAdapterBuild.log

@REM
@REM DEPLOYMENT
@REM

@REM GAC the assemblies
@REM
gacutil -if .\bin\Microsoft.Samples.BizTalk.Adapter.Common.dll
gacutil -if .\bin\Microsoft.Samples.BizTalk.SouthridgeVideo.OpsAdapterMgmt.dll
gacutil -if .\bin\Microsoft.Samples.BizTalk.SouthridgeVideo.OpsTxAdapter.dll
gacutil -if .\bin\Microsoft.Samples.BizTalk.SouthridgeVideo.OpsAdater.IOpsAIC.dll

@REM Register the adapter
@REM
cscript .\Register_Ops_Adapter.vbs
