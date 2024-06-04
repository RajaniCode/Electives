using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Threading;

/// <summary>
/// Summary description for SampleAsynchronousHttpHandler
/// The code implements the BeginProcessRequest method. The method writes a string to the Response property of the current HttpContext object, 
/// creates a new instance of the AsyncOperation class, and calls the StartAsyncWork method. 
/// The StartAsyncWork method then adds the StartAsyncTask delegate to the ThreadPool object. 
/// When a thread becomes available, the StartAsyncTask method is called, which writes out another string to the Response property. 
/// The task then finishes by invoking the AsyncCallback delegate. 
/// </summary>
public class SampleAsynchronousHttpHandler : IHttpAsyncHandler
{
	public SampleAsynchronousHttpHandler()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    
    public bool IsReusable { get { return false; } }

    public IAsyncResult BeginProcessRequest(HttpContext context, AsyncCallback cb, Object extraData)
    {
        context.Response.Write("<p>Begin IsThreadPoolThread is " + Thread.CurrentThread.IsThreadPoolThread + "</p>\r\n");
        AsynchOperation asynch = new AsynchOperation(cb, context, extraData);
        asynch.StartAsyncWork();
        return asynch;

    }

    public void EndProcessRequest(IAsyncResult result)
    {
    }

    public void ProcessRequest(HttpContext context)
    {
        throw new InvalidOperationException();
    }
}

class AsynchOperation : IAsyncResult
{
    private bool _completed;
    private Object _state;
    private AsyncCallback _callback;
    private HttpContext _context;

    bool IAsyncResult.IsCompleted { get { return _completed; } }
    WaitHandle IAsyncResult.AsyncWaitHandle { get { return null; } }
    Object IAsyncResult.AsyncState { get { return _state; } }
    bool IAsyncResult.CompletedSynchronously { get { return false; } }

    public AsynchOperation(AsyncCallback callback, HttpContext context, Object state)
    {
        _callback = callback;
        _context = context;
        _state = state;
        _completed = false;
    }

    public void StartAsyncWork()
    {
        ThreadPool.QueueUserWorkItem(new WaitCallback(StartAsyncTask), null);
    }

    private void StartAsyncTask(Object workItemState)
    {

        _context.Response.Write("<p>Completion IsThreadPoolThread is " + Thread.CurrentThread.IsThreadPoolThread + "</p>\r\n");

        _context.Response.Write("Hello World from Async Handler!");
        _completed = true;
        _callback(this);
    }
}