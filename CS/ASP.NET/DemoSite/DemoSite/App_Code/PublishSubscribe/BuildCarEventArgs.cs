using System;

// custom arguments class for BuildCarEvent
// this simple implementation exposes only
// the model name and build date, but could
// be extended to add any other values/data
public class BuildCarEventArgs : EventArgs
{
  private String argsModel;
  private DateTime argsDate;

  public BuildCarEventArgs(String modelName, DateTime buildDate)
  {
    // save model name and build date 
    argsModel = modelName;
    argsDate = buildDate;
  }

  public String ModelName
  {
    // public property to expose car model name
    get { return argsModel; }
    set { argsModel = value; }
  }

  public DateTime BuildDate
  {
    // public property to expose build date
    get { return argsDate; }
    set { argsDate = value; }
  }
}
