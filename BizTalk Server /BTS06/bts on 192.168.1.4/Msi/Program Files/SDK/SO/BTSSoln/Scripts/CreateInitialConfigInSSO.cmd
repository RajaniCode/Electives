@echo off

REM
REM ===================================================================================== 
REM                                                                                       
REM Microsoft.Samples.BizTalk.WoodgroveBank
REM End to end Service Oriented Scenatio sample for BizTalk Server.                       
REM                                                                                       
REM Command file to create the initial configuration settings in SSO
REM All the supporting configuration XML files should have been modified to 
REM reflect installation specific values before running this command
REM                                                                                     
REM Copyright (c) Microsoft Corporation. All rights reserved.                      
REM THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,          
REM EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES      
REM OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.                           
REM                                                                                       
REM =====================================================================================


REM Set path to include the enterprise single sign on, so we can find ssomanage

PATH=%PATH%;%ProgramFiles%\"Common Files\Enterprise Single Sign-On"

REM create the configuration store application in SSO...

echo Creating the configuration store application in SSO
ssomanage -createapps ConfigStoreApp.xml

REM Create the PaymentTracker Affiliate application - to map the user ids to the Payment Tracking system

echo Creating the PaymentTracker affiliate application in SSO to map users to the Payment Tracking System
ssomanage -createapps PmntTrckAffApp.xml

REM Create the PendingTransactions Affiliate application - to map the user ids to the Pending Transactions system

echo Creating the PendingTransactions affiliate application in SSO to map users to the Pending Transactions System
ssomanage -createapps PendTransAffApp.xml

REM Create the user mappings for the Payment Tracking system.
REM The user mapping files should have been updated with the right user ids

echo Creating user mappings for PaymentTracker
ssomanage -createmappings PmntTrckUserMap.xml

echo Creating user mappings for PendingTransactions
ssomanage -createmappings PendTransUserMap.xml

call SetConfigValuesInSSO.cmd

echo Use ssomanage -setcredentials to specify passwords for the users mapped

REM enable tickets in SSO - the default is not enabld...

echo Enabling Tickets in SSO
ssomanage -tickets yes yes
echo Tickets enabled

