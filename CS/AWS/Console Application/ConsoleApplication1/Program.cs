using System;
using PayPal;
using System.Diagnostics;

class Program
{
    static Logger LOGGER = Logger.GetLogger(typeof(Program));
    static TraceSource mySource = TraceSourceUtil.GetTraceSource(typeof(Program));

    static void Main()
    { 
        try
        {
            int i = 1;

            int j = Convert.ToInt32(Console.ReadLine());

            int k = i / j;

            Console.WriteLine("Division = " + k);

            LOGGER.InfoFormat("Info Format for {0}", "Format 1");

            mySource.TraceInformation("Worked Fine");
            mySource.Flush();
        }
        catch(Exception ex)
        {
            LOGGER.Debug(ex, "Error: {0}", "Debug");

            LOGGER.Error(ex, "Error: {0} \n StackTrace: {1}", ex.Message, ex.StackTrace);
        }        
    }
}

