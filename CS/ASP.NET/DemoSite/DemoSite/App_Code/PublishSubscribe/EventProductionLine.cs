using System;

// this is the main subject class that carries out
// the main processing and notifies all subscribed
// observers when the main method (BuildNewMotorCar)
// is called by other code
public class EventProductionLine
{
  // holds a reference to an instance of the
  // helper class that raises the event to
  // notify any subscribers 
  private BuildCarHelper internalHelper = null;
  // name of car currently being built
  private String carName = String.Empty;

  //-------------------------------------------------

  // class constructor
  public EventProductionLine()
  {
    // create new helper class instance
    internalHelper = new BuildCarHelper();
  }
  //-------------------------------------------------

  // property that exposes the helper instance
  public BuildCarHelper Helper
  {
    get { return internalHelper; }
  }
  //-------------------------------------------------

  // any properties required to expose data that the 
  // subscribers may need to use. These property values
  // must be wrapped inside the custom EventArgs class
  // that the Helper uses when raising the event
  public String CurrentMotorCarName
  {
    get { return carName; }
  }
  //-------------------------------------------------

  // main method for class - this is called by the subject accomplish 
  // the main tasks. There can be more methods, but each must call the 
  // Notify or other equivalent method of the helper to raise an event
  public void BuildNewMotorCar(String motorCarName)
  {
    // save value of car name
    carName = motorCarName;

    // do whatever work required here
    // ...

    // notify all subscribers
    internalHelper.Notify(this);
  }
  //-------------------------------------------------
}
