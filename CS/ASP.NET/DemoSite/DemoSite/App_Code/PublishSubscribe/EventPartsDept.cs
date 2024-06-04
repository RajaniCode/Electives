using System;
using System.Collections;
using System.Web;

// simple subscriber class exposes
// count of number of times notified
public class EventPartsDept
{
  Hashtable partsUsed = null;
  const String SESSION_KEY_NAME = "SavedPartsCount";
  //-------------------------------------------------

  public EventPartsDept()
	{
    // class constructor, set counter value
    // get saved Hashtable from session if available 
    if (HttpContext.Current.Session[SESSION_KEY_NAME] != null)
    {
      partsUsed = (Hashtable)HttpContext.Current.Session[SESSION_KEY_NAME];
    }
    else
    {
      // create new empty Hashtable
      partsUsed = new Hashtable();
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
    // in this example, just increment count of parts used
    if (partsUsed.ContainsKey(carName))
    {
      partsUsed[carName] = (Int32)partsUsed[carName] + 1;
    }
    else
    {
      partsUsed.Add(carName, 1);
    }
    // save count in session
    HttpContext.Current.Session[SESSION_KEY_NAME] = partsUsed;
  }
  //-------------------------------------------------

  public Hashtable CountOfPartsUsed
  {
    // expose the count of notifications as a property
    get { return partsUsed; }
  }
  //-------------------------------------------------
}
