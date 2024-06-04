using System;
using System.Collections.Specialized;
using System.Web.DynamicData;
using System.Web.UI;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

public partial class DynamicData_FieldTemplates_Url_Edit : FieldTemplateUserControl
{
    public bool? EnableTest { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        txtUrl.MaxLength = Column.MaxLength;
        txtUrl.ToolTip = Column.Description;

        ancTest.Visible = this.GetUIHintArg<bool>("EnableTest");

        if (EnableTest.HasValue)
        {
            ancTest.Visible = EnableTest.Value;
        }
        
        SetUpValidator(rfvUrl);
        SetUpValidator(regUrl);
        SetUpValidator(dyvUrl);
    }

    protected override void ExtractValues(IOrderedDictionary dictionary)
    {
        dictionary[Column.Name] = ConvertEditedValue(txtUrl.Text);
    }

    public override Control DataControl
    {
        get {return txtUrl;}
    }

    protected T GetUIHintArg<T>(string key)
    {
        UIHintAttribute hint = null;
        T returnValue = default(T);
        string value = string.Empty;

        hint = (UIHintAttribute)this.Column.Attributes[typeof(UIHintAttribute)];

        if (hint != null)
        {
            if (hint.ControlParameters.ContainsKey(key))
            {
                value = hint.ControlParameters[key].ToString();
                TypeConverter convert = new TypeConverter();

                var converter = TypeDescriptor.GetConverter(typeof(T));
                returnValue = (T)(converter.ConvertFromInvariantString(value));
            }
        }

        return returnValue;
    }
}