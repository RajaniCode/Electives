using System;
using System.Collections;
using System.Web;

// simple Observer class exposes
// count of number of times notified
public class SalesDept : IObserver
{
  Hashtable carsBuilt = null;
  const String SESSION_KEY_NAME = "SavedSalesCount";
  //-------------------------------------------------

  public SalesDept()
	{
    // class constructor, set counter value
    // get saved Hashtable from session if available 
    if (HttpContext.Current.Session[SESSION_KEY_NAME] != null)
    {
      carsBuilt = (Hashtable)HttpContext.Current.Session[SESSION_KEY_NAME];
    }
    else
    {
      // create new empty Hashtable
      carsBuilt = new Hashtable();
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
    // in this example, just increment count of cars available
    if (carsBuilt.ContainsKey(carName))
    {
      carsBuilt[carName] = (Int32)carsBuilt[carName] + 1;
    }
    else
    {
      carsBuilt.Add(carName, 1);
    }
    // save count in session
    HttpContext.Current.Session[SESSION_KEY_NAME] = carsBuilt;
  }
  //-------------------------------------------------

  public Hashtable CountOfCarsBuilt
  {
    // expose the number of notifications as a property
    get { return carsBuilt; }
  }
  //-------------------------------------------------
}
