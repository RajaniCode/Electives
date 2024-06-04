using System;
using System.Data;
using System.Web;
using System.Collections.Specialized;
using System.Xml;

// Singleton class to expose a list of URLs for
// Front Controller to use to transfer to when 
// special strings occur in requested URL
public class TransferUrlList
{
  private static TransferUrlList instance = null;
  private static StringDictionary urls;

  // --------------------------------------------
  private TransferUrlList()
	{
    // prevent code using the default constructor
    // by making it private
  }
  // --------------------------------------------

  // public method to return single instance of class
  public static TransferUrlList GetInstance()
  {
    // see if instance already created
    if (instance == null)
    {
      // create the instance
      instance = new TransferUrlList();
      urls = new StringDictionary();
      String xmlFilePath = HttpContext.Current.Request.MapPath(@"~/xmldata/TransferURLs.xml");
      // read list of transfer URLs from XML file
      try
      {
        using (XmlReader reader = XmlReader.Create(xmlFilePath))
        {
          while (reader.Read())
          {
            if (reader.LocalName == "item")
            {
              // populate StringDictionary
              urls.Add(reader.GetAttribute("name"), reader.GetAttribute("url"));
            }
          }
        }
      }
      catch (Exception ex)
      {
        throw new Exception("TransferUrlList: Cannot load URL transfer list", ex);
      }
    }
    return instance;
  }
  // --------------------------------------------

  // public method to return URL for a specified name
  // returns original URL if not found
  public String GetTransferUrl(String urlPathName)
  {
    if (urls.ContainsKey(urlPathName))
    {
      return urls[urlPathName];
    }
    else
    {
      return urlPathName;
    }
  }
  // --------------------------------------------
  
}
