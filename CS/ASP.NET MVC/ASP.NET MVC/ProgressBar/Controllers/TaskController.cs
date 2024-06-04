using System;
using System.Threading;
using ProgressBar.Framework;

namespace ProgressBar.Controllers
{
    public class TaskController : ProgressBarController
    {
        public String DoWork(Int32 repeat)
        {
            var taskId = GetTaskId(); 
            for (var i = 1; i <= repeat; i++)
            {
                ProgressManager.SetCompleted(taskId, String.Format("Iteration #{0} completed...", i));
                Thread.Sleep(2000);

                if (ProgressManager.ShouldTerminate(taskId))
                {
                    // Compensate here
                    // 

                    // Update status
                    var status = String.Format("Task aborted: {0}/{1} step(s) completed.", i, repeat);
                    ProgressManager.SetCompleted(taskId, status);

                    // Return
                    return status;
                }
            }

            // Some return value
            return String.Format("Task completed @{0}", DateTime.Now.ToString("h:mm:ss"));
        }

        public String BookFlight(String from, String to)
        {
            var taskId = GetTaskId();

            // Book first leg
            ProgressManager.SetCompleted(taskId, "{2} || Booking flight: {0}-{1} ...", from, to, taskId);
            Thread.Sleep(2000);
            if (ProgressManager.ShouldTerminate(taskId))
            {
                // Compensate here
                // 
                return String.Format("One flight booked and then canceled");
            }

            // Book return 
            ProgressManager.SetCompleted(taskId, "{2} || Booking flight: {0}-{1} ...", to, from, taskId);
            Thread.Sleep(3000);
            if (ProgressManager.ShouldTerminate(taskId))
            {
                // Compensate here
                // 
                return String.Format("Two flights booked and then canceled");
            }

            // Book return 
            ProgressManager.SetCompleted(taskId, "{0} || Paying for the flight ...", taskId);
            Thread.Sleep(2000);
            if (ProgressManager.ShouldTerminate(taskId))
            {
                // Compensate here
                // 
                return String.Format("Payment canceled. No flights booked.");
            }

            // Some return value
            return String.Format("{0} || Flight booked successfully", taskId); 
        }
    }
}
