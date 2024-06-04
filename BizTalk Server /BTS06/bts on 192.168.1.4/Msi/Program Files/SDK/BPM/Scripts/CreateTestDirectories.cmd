echo off
REM ---------------------------------------------------------------------------------
REM  Microsoft.Samples.BizTalk.SouthridgeVideo
REM  
REM  Command file to create test receive and send file locations
REM 
REM  Copyright (c) Microsoft Corporation. All rights reserved.  
REM  THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
REM  EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
REM  OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE. 
REM ---------------------------------------------------------------------------------
REM 


SET TESTROOT=%SystemDrive%\BPMTest
echo on

md %TESTROOT%\CSRResponse-DSP
md %TESTROOT%\VendorResponse-DSP
md %TESTROOT%\OrderErrors-SP
md %TESTROOT%\ErrorResponse-RP-TestRL
md %TESTROOT%\Facilities-SP
md %TESTROOT%\Facilities-RP-TestRL
md %TESTROOT%\HistoryInsert-SP
md %TESTROOT%\HistoryUpdate-SP
md %TESTROOT%\Order-RP-TestRL
md %TESTROOT%\ServicingSystem-SP
md %TESTROOT%\Vendor-RP-TestRL
md %TESTROOT%\BizTalkErrors-SP


md %SystemDrive%\InetPub\ftproot\FromVendor

echo off
SET TESTROOT=
