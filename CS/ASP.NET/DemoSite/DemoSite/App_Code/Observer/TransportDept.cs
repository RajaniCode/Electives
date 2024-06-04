using System;
using System.Collections;
using System.Web;

// simple Observer class exposes
// count of number of times notified
public class TransportDept : IObserver
{
  Hashtable toDeliver = null;
  const String SESSION_KEY_NAME = "SavedTransportCount";
  //-------------------------------------------------

  public TransportDept()
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

  public void Update(Object subject) 
  {
    // called by ObserverHelper.Notify method
    // do any work required in Observer class here
    // parameter is the instance of the subject class
    // so code can query its properties if required
    // ...
    String carName = (subject as ProductionLine).CurrentMotorCarName;
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
