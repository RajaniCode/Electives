<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <script>
    
    function TestTimeout()    
    {
        debug.trace("--Start--");
        TestService.set_defaultFailedCallback( function(result, userContext, methodName)
        {
            var timedOut = result.get_timedOut();
            if( timedOut )
                debug.trace( "Timedout: " + methodName );
            else
                debug.trace( "Error: " + methodName );
        });
        TestService.set_defaultSucceededCallback( function(result)
        {
            debug.trace( result );
        });
        
        TestService.set_timeout(5000);
        TestService.HelloWorld("Call 1");
        TestService.Timeout("Call 2");
        TestService.Timeout("Call 3");
        TestService.HelloWorld("Call 4");
        TestService.HelloWorld("Call 5");
        TestService.HelloWorld(null);
    }
    
    function enableAutoRetry()
    {
        document.getElementById('enableAutoRetryButton').disabled = true;
        
        Sys.Net.WebServiceProxy.retryOnFailure = 
            function(result, userContext, methodName, retryParams, onFailure)
        {
            if( result.get_timedOut() )
            {
                if( typeof retryParams != "undefined" )
                {
                    debug.trace("Retry: " + methodName);
                    Sys.Net.WebServiceProxy.original_invoke.apply(this, retryParams );
                }
                else
                {
                    if( onFailure ) onFailure(result, userContext, methodName);
                }
            }
            else
            {
                if( onFailure ) onFailure(result, userContext, methodName);
            }
        }
        
        Sys.Net.WebServiceProxy.original_invoke = Sys.Net.WebServiceProxy.invoke;
        Sys.Net.WebServiceProxy.invoke = 
            function Sys$Net$WebServiceProxy$invoke(servicePath, methodName, useGet, 
                params, onSuccess, onFailure, userContext, timeout)
        {   
            var retryParams = [ servicePath, methodName, useGet, params, 
                onSuccess, onFailure, userContext, timeout ];
            
            // Call original invoke but with a new onFailure handler which does the auto retry
            var newOnFailure = Function.createDelegate( this, 
                function(result, userContext, methodName) 
                { 
                    Sys.Net.WebServiceProxy.retryOnFailure(result, userContext, 
                        methodName, retryParams, onFailure); 
                } );
                
            Sys.Net.WebServiceProxy.original_invoke(servicePath, methodName, useGet, 
                params, onSuccess, newOnFailure, userContext, timeout);
        }
    }
    
    var GlobalCallQueue = {
        _callQueue : [],    // Maintains the list of webmethods to call
        _callInProgress : 0,    // Number of calls currently in progress by browser
        _maxConcurrentCall : 2, // Max number of calls to execute at a time
        _delayBetweenCalls : 50, // Delay between execution of calls 
        call : function(servicePath, methodName, useGet, 
            params, onSuccess, onFailure, userContext, timeout)
        {
            var queuedCall = new QueuedCall(servicePath, methodName, useGet, 
                params, onSuccess, onFailure, userContext, timeout);
                
            Array.add(GlobalCallQueue._callQueue,queuedCall);
            GlobalCallQueue.run();
        },
        run : function()
        {
            /// Execute a call from the call queue
            
            if( 0 == GlobalCallQueue._callQueue.length ) return;
            if( GlobalCallQueue._callInProgress < GlobalCallQueue._maxConcurrentCall )
            {
                GlobalCallQueue._callInProgress ++;
                // Get the first call queued
                var queuedCall = GlobalCallQueue._callQueue[0];
                Array.removeAt( GlobalCallQueue._callQueue, 0 );
                
                // Call the web method
                queuedCall.execute();
            }    
            else
            {
                // cannot run another call. Maximum concurrent 
                // webservice method call in progress
            }            
        },
        callComplete : function()
        {
            GlobalCallQueue._callInProgress --;
            GlobalCallQueue.run();
        }
    };
    
    QueuedCall = function( servicePath, methodName, useGet, params, 
        onSuccess, onFailure, userContext, timeout )
    {
        this._servicePath = servicePath;
        this._methodName = methodName;
        this._useGet = useGet;
        this._params = params;
        
        this._onSuccess = onSuccess;
        this._onFailure = onFailure;
        this._userContext = userContext;
        this._timeout = timeout;
    }
    
    QueuedCall.prototype = 
    {
        execute : function()
        {
            Sys.Net.WebServiceProxy.original_invoke( 
                this._servicePath, this._methodName, this._useGet, this._params,  
                Function.createDelegate(this, this.onSuccess), // Handle call complete
                Function.createDelegate(this, this.onFailure), // Handle call complete
                this._userContext, this._timeout );
        },
        onSuccess : function(result, userContext, methodName)
        {
            this._onSuccess(result, userContext, methodName);
            GlobalCallQueue.callComplete();            
        },        
        onFailure : function(result, userContext, methodName)
        {
            this._onFailure(result, userContext, methodName);
            GlobalCallQueue.callComplete();            
        }        
    };
    
    function enableQueuedCall()
    {
        document.getElementById('enableQueuedCallButton').disabled = true;
        
        Sys.Net.WebServiceProxy.original_invoke = Sys.Net.WebServiceProxy.invoke;
        Sys.Net.WebServiceProxy.invoke = 
            function Sys$Net$WebServiceProxy$invoke(servicePath, methodName, 
                useGet, params, onSuccess, onFailure, userContext, timeout)
        {   
            GlobalCallQueue.call(servicePath, methodName, useGet, params, 
                onSuccess, onFailure, userContext, timeout);
        }
    }
    
    function testCache()
    {
        TestService.CachedGet(function(result)
        {
            debug.trace(result);
        });
    }
    function testCache2()
    {
        TestService.CachedGet2(function(result)
        {
            debug.trace(result);
        });
    }
    
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" ScriptMode="Release" >
            <Services>
                <asp:ServiceReference InlineScript="true" Path="TestService.asmx" />
            </Services>
        </asp:ScriptManager>
        
        <table>
        <tr>
        <td>
        <div>
            Test 1: Click
            <input type="button" onclick="TestTimeout()" value="Test Timeout" />
            and see how methods timeout<br />
        </div>
        <div>
            Test 2:<ul>
                <li>Step 1:
                    <asp:Button ID="ResetButton" runat="server" Text="Reset" OnClick="ResetButton_Click" />&nbsp;</li>
                <li>Step 2:
                    <input id="enableAutoRetryButton" type="button" value="Enable auto retry" onclick="enableAutoRetry()" />&nbsp;</li>
                <li>Step 3:
                    <input type="button" onclick="TestTimeout()" value="Test Timeout" /><br />
                </li>
            </ul>
        </div>
        Test 3:
        <ul>
            <li>Step 1:
                    <asp:Button ID="Button1" runat="server" Text="Reset" OnClick="ResetButton_Click" />&nbsp;</li>
            <li>Step 2:
                <input id="enableQueuedCallButton" type="button" value="Enabled Call Queue" onclick="enableQueuedCall()" /></li>
            <li>Step 3:
                <input type="button" onclick="TestTimeout()" value="Test Timeout" /></li>
        </ul>
        <p>
            Test 4: &nbsp;<input type="button" onclick="testCache()" value="Test Cache (does not work)" /></p>
        <p>
            Test 5: &nbsp;<input type="button" onclick="testCache2()" value="Test Cache (works)" />
        </p>
        
        </td>
        
        <td>
        <textarea id="TraceConsole" rows="10" cols="40"></textarea>
        </td>
        </tr>
        </table>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
