using System.Web.UI;
using System.Web.DynamicData;

public partial class DynamicData_FieldTemplates_Url : FieldTemplateUserControl
{
    public override Control DataControl
    {
        get { return this.litURL; }
    }
}