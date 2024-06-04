REM
REM ===================================================================================== 
REM                                                                                       
REM Microsoft.Samples.BizTalk.WoodgroveBank
REM End to end Service Oriented Scenatio sample for BizTalk Server.                       
REM                                                                                       
REM Command file to run the Payment Tracker back end system simulator appliction.
REM                                                                                     
REM Copyright (c) Microsoft Corporation. All rights reserved                       
REM THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,          
REM EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES      
REM OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.                           
REM                                                                                       
REM =====================================================================================

cd bin\Debug

REM Change the values of the command line below to environment specific values.
REM Typically 5 threads are enough, unless you are running loadgen to generate load on the system and the simulator itself becomes a 
REM bottleneck.

BTSScnSOPaymentTracker.exe <name of queue to get input messages from> <Name of queue to send output messages to> <Queue Manager Name> <number of threads> 
exit
