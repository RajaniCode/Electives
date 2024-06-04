using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class RatingController : Controller
    {
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult PostRating(int rating)
        {
            return Json("You rated this " + rating.ToString() + " star(s)");
        }
    }
}
