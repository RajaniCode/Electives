using System;
using System.Collections;

public class ObserverHelper
{
  private ArrayList observerList = new ArrayList();

  // subscribe an observer by adding them to the list
  public void AddObserver(IObserver observer)
  {
    observerList.Add(observer);
  }
  //-------------------------------------------

  // unsubscribe an observer by removing them from the list
  public void RemoveObserver(IObserver observer)
  {
    observerList.Remove(observer);
  }
  //-------------------------------------------

  // notify all subscribed observers, passing in a reference 
  // to the subject class that contains this helper
  public void Notify(Object subject)
  {
    foreach(IObserver observer in observerList)
    {
      // call update method on all subscribed observers
      observer.Update(subject);
    }
  }
  //-------------------------------------------
}
