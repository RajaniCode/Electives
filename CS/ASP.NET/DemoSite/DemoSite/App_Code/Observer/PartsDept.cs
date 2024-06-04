using System;
using System.Collections;
using System.Web;

// simple Observer class exposes
// count of number of times notified
public class PartsDept : IObserver
{
  Hashtable partsUsed = null;
  const String SESSION_KEY_NAME = "SavedPartsCount";
  //-------------------------------------------------

  public PartsDept()
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

  public void Update(Object subject)
  {
    // called by ObserverHelper.Notify method
    // do any work required in Observer class here
    // parameter is the instance of the subject class
    // so code can query its properties if required
    // ...
    String carName = (subject as ProductionLine).CurrentMotorCarName;
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
