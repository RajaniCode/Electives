using System;
using System.Linq;
using System.Web.Mvc;

namespace AjaxProgressBarExample.Controllers
{
    /// <summary>
    /// Home Controller.
    /// </summary>
    [HandleError]
    public class HomeController : Controller
    {
        /// <summary>
        /// Index Action.
        /// </summary>
        public ActionResult Index()
        {
            ViewData["Message"] = "Ajax Progress Bar Example";
            return View();
        }

        delegate string ProcessTask(string id);
        MyLongRunningClass longRunningClass = new MyLongRunningClass();

        /// <summary>
        /// Starts the long running process.
        /// </summary>
        /// <param name="id">The id.</param>
        public void StartLongRunningProcess(string id)
        {
            longRunningClass.Add(id);            
            ProcessTask processTask = new ProcessTask(longRunningClass.ProcessLongRunningAction);
            processTask.BeginInvoke(id, new AsyncCallback(EndLongRunningProcess), processTask);
        }

        /// <summary>
        /// Ends the long running process.
        /// </summary>
        /// <param name="result">The result.</param>
        public void EndLongRunningProcess(IAsyncResult result)
        {
            ProcessTask processTask = (ProcessTask)result.AsyncState;
            string id = processTask.EndInvoke(result);
            longRunningClass.Remove(id);
        }

        /// <summary>
        /// Gets the current progress.
        /// </summary>
        /// <param name="id">The id.</param>
        public ContentResult GetCurrentProgress(string id)
        {
            this.ControllerContext.HttpContext.Response.AddHeader("cache-control", "no-cache");
            var currentProgress = longRunningClass.GetStatus(id).ToString();
            return Content(currentProgress);
        }
    }
}
