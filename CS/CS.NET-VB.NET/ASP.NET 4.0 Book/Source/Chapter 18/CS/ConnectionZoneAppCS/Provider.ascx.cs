using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class Provider : System.Web.UI.UserControl, IDataTransmit
{
    [ConnectionProvider("Text", "TextProvider")]
    public IDataTransmit RetriveDataInterface()
    {
        return (IDataTransmit)this;
    }
    public string RetriveData()
    {
        return TextBox1.Text;
    }

}