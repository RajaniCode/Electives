using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcModalDialog.Models;

namespace MvcModalDialog.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Dialog1()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Dialog1(DialogModel model)
        {
            return ProcessDialog(model, 1, "Great, your answer is correct!");
        }

        public ActionResult Dialog2()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Dialog2(DialogModel model)
        {
            return ProcessDialog(model, 2);
        }

        public ActionResult Dialog3()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Dialog3(DialogModel model)
        {
            return ProcessDialog(model, 3);
        }

        ActionResult ProcessDialog(DialogModel model, int answer)
        {
            return ProcessDialog(model, answer, null);
        }

        ActionResult ProcessDialog(DialogModel model, int answer, string message)
        {
            if (ModelState.IsValid)
            {
                if (model.Value == answer)
                    return this.DialogResult(message);  // Close dialog via DialogResult call
                else
                    ModelState.AddModelError("", string.Format("Invalid input value. The correct value is {0}", answer));
            }

            return PartialView(model);
        }
    }
}
