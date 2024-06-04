using System;
using System.Collections.Generic;

public class BuildCarHelper
{
  // event that this Helper class exposes to subscribers
  public event EventHandler<BuildCarEventArgs> BuildCarEvent;
  //----------------------------------------------------

  public void Notify(Object publisher)
  {
    // raise the event to notify all subscribers using
    // the custom event arguments class
    String carName = (publisher as EventProductionLine).CurrentMotorCarName;
    BuildCarEventArgs args = new BuildCarEventArgs(carName, DateTime.Now);
    // call method to publish event using standard
    // approach defined by MS for events - see .NET docs at
    // http://msdn2.microsoft.com/en-us/library/w369ty8x(VS.80).aspx
    OnBuildCarEvent(args);
  }
  //----------------------------------------------------

  // wrap event invocations inside a protected virtual method
  // to allow derived classes to override the event invocation behavior
  protected virtual void OnBuildCarEvent(BuildCarEventArgs e)
  {
    // make a temporary copy of the event to avoid possibility of
    // a race condition if the last subscriber unsubscribes
    // immediately after the null check and before the event is raised.
    EventHandler<BuildCarEventArgs> handler = BuildCarEvent;

    // event will be null if there are no subscribers
    if (handler != null)
    {
      // use the () operator to raise the event.
      handler(this, e);
    }
  }
  //----------------------------------------------------
}
