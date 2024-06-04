using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class Consumer : System.Web.UI.UserControl
{
    [ConnectionConsumer("Text", "TextConsumer")]
    public void RetriveDataInterface(IDataTransmit sender)
    {
        Label2.Text = sender.RetriveData();
    }

}