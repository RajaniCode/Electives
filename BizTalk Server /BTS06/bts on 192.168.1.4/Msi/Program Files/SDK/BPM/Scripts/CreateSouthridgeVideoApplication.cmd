
@echo off

REM
REM ===================================================================================== 
REM                                                                                       
REM Microsoft.Samples.BizTalk.SouthridgeVideo
REM End to end Businsiness Process Management sample for BizTalk Server.                       
REM                                                                                       
REM Command file to set the values of the configuration parameters in the SSO configuration
REM store application.  The configuration store application should have been created before 
REM running this command.
REM                                                                                     
REM Copyright (c) Microsoft Corporation. All rights reserved.                       
REM THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,          
REM EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES      
REM OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.                           
REM                                                                                       
REM =====================================================================================


REM Create the SSO configstore application
"%CommonProgramFiles%\Enterprise Single Sign-On\ssomanage.exe" -createapps SouthridgeVideoSSOConfiguration.xml

REM Change the following values specific to your environment.  Refer to the documentation for more details
REM on these parameters.
REM Keep the parameter names here in-sync with the parameter names in SouthridgeVideoSSOConfiguration.xml

REM Total number of stages
set TotalStages=2

REM Location and port for cable provisioning system application server
set CableProvisioningSystemLocation=localhost:8880

REM Configuration data cache refresh interval in milliseconds (default 1 min)
REM This is used internally by the SSOConfigHelper and the value can be changed 
REM but the parameter should not be renamed or removed
set CacheRefreshInterval=60000

REM End of settings to be changed...

SET ConfigApp=SouthridgeVideo.CableOrder
SET identity=ConfigProperties

echo Setting configuration values
..\..\common\SSOApplicationConfig\bin\BTSScnSSOApplicationConfig -set %ConfigApp% %identity% CableProvisioningSystemLocation %CableProvisioningSystemLocation% TotalStages %TotalStages% CacheRefreshInterval %CacheRefreshInterval%

echo The configuration values are the following
echo "" 

..\..\common\SSOApplicationConfig\bin\BTSScnSSOApplicationConfig -get %ConfigApp% %identity% CableProvisioningSystemLocation TotalStages CacheRefreshInterval

