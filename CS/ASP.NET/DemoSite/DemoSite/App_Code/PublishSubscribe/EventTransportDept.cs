using System;
using System.Collections;
using System.Web;

// simple subscriber class exposes
// count of number of times notified
public class EventTransportDept
{
  Hashtable toDeliver = null;
  const String SESSION_KEY_NAME = "SavedTransportCount";
  //-------------------------------------------------

  public EventTransportDept()
  {
    // class constructor, set counter value
    // get saved Hashtable from session if available 
    if (HttpContext.Current.Session[SESSION_KEY_NAME] != null)
    {
      toDeliver = (Hashtable)HttpContext.Current.Session[SESSION_KEY_NAME];
    }
    else
    {
      // create new empty Hashtable
      toDeliver = new Hashtable();
    }
  }
  //-------------------------------------------------

  public void BuildCarEventHandler(Object sender, BuildCarEventArgs args)
  {
    // the calling code links this to the BuildCarEvent so that
    // it executes automatically when a new car is built
    // code can query properties of custom BuildCarEventArgs
    // class to get information about the event if required
    String carName = args.ModelName;
    // in this example, just increment count of cars to deliver
    if (toDeliver.ContainsKey(carName))
    {
      toDeliver[carName] = (Int32)toDeliver[carName] + 1;
    }
    else
    {
      toDeliver.Add(carName, 1);
    }
    // save count in session
    HttpContext.Current.Session[SESSION_KEY_NAME] = toDeliver;
  }
  //-------------------------------------------------

  public Hashtable CountOfCarsToDeliver
  {
    // expose the number of notifications as a property
    get { return toDeliver; }
  }
  //-------------------------------------------------
}
