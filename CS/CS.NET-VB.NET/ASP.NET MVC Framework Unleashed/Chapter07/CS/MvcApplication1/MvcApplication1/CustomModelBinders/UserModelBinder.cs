using System.Web.Mvc;

namespace MvcApplication1.CustomModelBinders
{
    public class UserModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            return controllerContext.HttpContext.User;
        }

    }
}
