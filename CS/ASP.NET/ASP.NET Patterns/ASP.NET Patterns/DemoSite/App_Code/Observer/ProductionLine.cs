using System;

// this is the main subject class that carries out
// the main processing and notifies all subscribed
// observers when the main method (BuildNewMotorCar)
// is called by other code
public class ProductionLine
{

  // holds a reference to an instance of the
  // helper class that handles subscriptions
  // and notifies all the subscribed observers
  private ObserverHelper internalHelper = null;
  // name of car currently being built
  private String carName = String.Empty;

  //-------------------------------------------------

  // class constructor
  public ProductionLine()
	{
    // create new helper class instance
    internalHelper = new ObserverHelper();
	}
  //-------------------------------------------------

  // property that exposes the helper instance
  public ObserverHelper Helper
  {
    get { return internalHelper; }
  }
  //-------------------------------------------------

  // any properties required to expose data that the 
  // observers may need to use. Actual properties 
  // depend on actions of subject and observer, but 
  // using properties maintains interface independence
  public String CurrentMotorCarName
  {
    get { return carName; }
  }
  //-------------------------------------------------

  // main method for class - this is called by the client to carry 
  // out the main tasks can be more methods, each must call the 
  // Notify method of the associated helper instance
  public void BuildNewMotorCar(String motorCarName)
  {
    // save value of car name
    carName = motorCarName;

    // do whatever work required here
    // ...

    // notify all subscribed observers
    internalHelper.Notify(this);
  }
  //-------------------------------------------------
}
