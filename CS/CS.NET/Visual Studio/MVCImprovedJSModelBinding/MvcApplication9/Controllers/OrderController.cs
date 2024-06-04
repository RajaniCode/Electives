using System.Linq;
using System.Web.Mvc;
using System.ComponentModel;
using MvcApplication9.Models;

namespace MvcApplication9.Controllers
{
    public class OrderController : Controller
    {
        [HttpGet]
        public ActionResult Edit([DefaultValue(1)]int id)
        {
            return View(Order.GetOrders().FirstOrDefault(o => o.Id == id));
        }

        [HttpPost]
        public ActionResult Edit(Order order)
        {
            return View();
        }
    }
}
