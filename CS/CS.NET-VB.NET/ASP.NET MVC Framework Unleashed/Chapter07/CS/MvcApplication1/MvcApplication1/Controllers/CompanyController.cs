using System.Web.Mvc;
using MvcApplication1.CustomModelBinders;
using System.Security.Principal;

namespace MvcApplication1.Controllers
{
    public class CompanyController : Controller
    {

        public string GetSecret([ModelBinder(typeof(UserModelBinder))]IPrincipal user)
        {
            if (user.Identity.Name == "CEO")
                return "The secret is 42.";
            else
                return "You are not authorized!";
        }

    }
}
