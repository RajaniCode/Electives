using System;
using System.Collections;
using System.Web;

// simple subscriber class exposes
// count of number of times notified
public class EventSalesDept
{
  Hashtable carsBuilt = null;
  const String SESSION_KEY_NAME = "SavedSalesCount";
  //-------------------------------------------------

  public EventSalesDept()
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

  public void BuildCarEventHandler(Object sender, BuildCarEventArgs args)
  {
    // the calling code links this to the BuildCarEvent so that
    // it executes automatically when a new car is built
    // code can query properties of custom BuildCarEventArgs
    // class to get information about the event if required
    String carName = args.ModelName;
    // in this example, just increment count of cars to sell
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
