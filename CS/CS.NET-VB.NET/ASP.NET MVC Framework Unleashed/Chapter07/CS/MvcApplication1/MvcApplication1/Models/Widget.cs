using System.Web.Mvc;

namespace MvcApplication1.Models
{
    [Bind(Exclude="Id")]
    public partial class Widget
    {
    }
}
