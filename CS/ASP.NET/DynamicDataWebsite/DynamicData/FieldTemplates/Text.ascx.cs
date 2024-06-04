using System.Web.UI;

public partial class TextField : System.Web.DynamicData.FieldTemplateUserControl {
    public override Control DataControl {
        get {
            return Literal1;
        }
    }
}
