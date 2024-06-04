using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Text;
using DialogDemo.Models;
using DialogDemo.Repository;

namespace DialogDemo.Controllers
{
    public class ColorboxController : Controller
    {
        private demoRepository repo = new demoRepository();

        [OutputCache(CacheProfile = "ZeroCacheProfile")]
        public ActionResult SalesInfo(int customerid)
        {
            HomeViewModel viewModel = new HomeViewModel();
            viewModel.person = repo.SelectPerson(customerid);
            viewModel.cart = repo.SelectBooks(customerid);
            string msg = (TempData.ContainsKey("message") ? TempData["message"].ToString() : "");
            TempData["message"] = msg;
            return View("SalesInfo", viewModel);
        }

        [OutputCache(CacheProfile = "ZeroCacheProfile")]
        public ActionResult CustomerEdit(int customerid)
        {
            Person person = repo.SelectPerson(customerid);

            if (Request != null && Request.IsAjaxRequest())
                return PartialView("_PersonDetail", person);

            return View("PersonDetail", person);
        }

        [HttpPost]
        [OutputCache(CacheProfile = "ZeroCacheProfile")]
        public ActionResult CustomerEdit(Person person)
        {
            ValidatePerson(person);
            string errorMsg = string.Empty;
            StringBuilder errorMessage = null;

            if (ModelState.IsValid)
            {
                try
                {
                    repo.UpdatePerson(person);
                    TempData["message"] = "Customer information updated.<br/>";
                }
                catch (Exception exp)
                {
                    errorMessage = new StringBuilder(200);
                    errorMessage.AppendFormat("<div class=\"validation-summary-errors\">Server Error: {0}</div><br/>", exp.GetBaseException().Message);
                    TempData["message"] = errorMessage.ToString(); 
                }
            }
            else
            {
                // construct detailed validation error message for popup dialog
                errorMessage = new StringBuilder(400);
                errorMessage.Append("<div class=\"validation-summary-errors\">Invalid input:<ul>");
                foreach (var key in ModelState.Keys)
                {
                    var error = ModelState[key].Errors.FirstOrDefault();
                    if (error != null)
                    {
                        errorMessage.AppendFormat("<li class=\"field-validation-error\">{0}</li>", error.ErrorMessage);
                    }
                }
                errorMessage.Append("</ul></div><br/>");
                TempData["message"] = errorMessage.ToString();
            }

            return RedirectToAction("SalesInfo", new { customerid = person.PersonId });
        }

        private void ValidatePerson(Person personToCreate)
        {
            bool personIsNull = personToCreate == null ? true : false;
            // Validation logic
            if ((personIsNull) || (string.IsNullOrEmpty(personToCreate.FirstName)))
                ModelState.AddModelError("FirstName", "First Name is required.");
            if ((personIsNull) || (string.IsNullOrEmpty(personToCreate.LastName)))
                ModelState.AddModelError("LastName", "Last Name is required.");
        }

        #region Book Actions

        [OutputCache(CacheProfile = "ZeroCacheProfile")]
        public ActionResult BookEdit(int bookid, int customerid)
        {
            Book book = repo.SelectBook(bookid, customerid);

            if (Request != null && Request.IsAjaxRequest())
            {
                return PartialView("_BookEdit", book);
            }

            return View("BookEdit", book);
        }

        [HttpPost]
        [OutputCache(CacheProfile = "ZeroCacheProfile")]
        public ActionResult BookEdit(Book book)
        {
            int customerID = book.CustomerID;
            StringBuilder errorMessage = null;

            try
            {
                repo.UpdateBook(book);
                TempData["message"] = "Updated book information.<br/>";
            }
            catch (Exception exp)
            {
                errorMessage = new StringBuilder(200);
                errorMessage.AppendFormat("<div class=\"validation-summary-errors\">Server Error: {0}</div><br/>", exp.GetBaseException().Message);
                TempData["message"] = errorMessage.ToString();
            }

            return RedirectToAction("SalesInfo", new { customerid = customerID });
        }

        #endregion

    }
}
