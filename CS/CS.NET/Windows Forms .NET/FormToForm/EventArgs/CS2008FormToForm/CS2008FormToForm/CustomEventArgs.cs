using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


delegate void CustomEventHandler(object sender, CustomEventArgs e);

class CustomEventArgs : EventArgs 
{
    private string TextBoxText;

    public CustomEventArgs(string TextBoxText)
    {
        this.TextBoxText = TextBoxText;
    }

    internal string TextBoxTextChanged
    {
        get
        {
            return TextBoxText;
        }
    }
}

