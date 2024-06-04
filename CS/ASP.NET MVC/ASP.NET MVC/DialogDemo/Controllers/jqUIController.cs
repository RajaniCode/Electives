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
    public class jqUIController : Controller
    {
        private demoRepository repo = new demoRepository();
        
        [OutputCache(CacheProfile = "ZeroCacheProfile")]
        public ActionResult SalesInfo(int customerid)
        {
            HomeViewModel viewModel = new HomeViewModel();
            viewModel.person = repo.SelectPerson(customerid);
            viewModel.cart = repo.SelectBooks(customerid);
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
            int statusCode = 0;
            string errorMsg = string.Empty;
            StringBuilder errorMessage = null;

            if (!ModelState.IsValid)
            {
                if (Request.IsAjaxRequest())
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return PartialView("_PersonDetail", person);
                }
                else
                    return PartialView("PersonDetail", person);
            }
            else
            {
                try
                {
                    repo.UpdatePerson(person);
                }
                catch (Exception exp)
                {
                    errorMessage = new StringBuilder(200);
                    errorMessage.AppendFormat("<div class=\"validation-summary-errors\" title=\"Server Error\">{0}</div>", exp.GetBaseException().Message);
                    statusCode = (int)HttpStatusCode.InternalServerError; // = 500
                }
            }

            //else
            //{
            //    // construct detailed validation error message for popup dialog
            //    errorMessage = new StringBuilder(400);
            //    errorMessage.Append("<div class=\"validation-summary-errors\" title=\"Validation Errors\">The following errors occurred:<ul>");
            //    foreach (var key in ModelState.Keys)
            //    {
            //        var error = ModelState[key].Errors.FirstOrDefault();
            //        if (error != null)
            //        {
            //            errorMessage.AppendFormat("<li class=\"field-validation-error\">{0}</li>", error.ErrorMessage);
            //        }
            //    }
            //    errorMessage.Append("</ul></div>");
            //    statusCode = (int)HttpStatusCode.BadRequest; // = 400
            //}


            if (Request.IsAjaxRequest())
            {
                if (statusCode > 0)
                {
                    Response.StatusCode = statusCode;
                    return Content(errorMessage.ToString());
                }
                else
                {
                    TempData["message"] = "Customer information updated.";
                    return PartialView("Customer", person);
                }
            }
            else
            {
                return RedirectToAction("SalesInfo", new { customerid = person.PersonId });
            }
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
            int statusCode = 0;
            int customerID = book.CustomerID;
            StringBuilder errorMessage = null;
            string resultMsg = string.Empty;

            try
            {
                repo.UpdateBook(book);
                resultMsg = "Updated book information.";
            }
            catch (Exception exp)
            {
                errorMessage = new StringBuilder(200);
                errorMessage.AppendFormat("<div class=\"validation-summary-errors\" title=\"Server Error\">{0}</div>", exp.GetBaseException().Message);
                statusCode = (int)HttpStatusCode.InternalServerError; ;
            }

            if (Request.IsAjaxRequest())
            {
                if (statusCode > 0)
                {
                    Response.StatusCode = statusCode;
                    return Content(errorMessage.ToString());
                }
                else
                {
                    var books = repo.SelectBooks(customerID);
                    TempData["message"] = resultMsg;
                    return PartialView("BookList", books);
                }
            }
            else
            {
                return RedirectToAction("SalesInfo", new { customerid = customerID });
            }
        }

        public ActionResult BookDelete(int bookid, int customerid)
        {
            Book book = repo.SelectBook(bookid, customerid);
            string resultMsg = string.Format("<span style='color: red'>{0} would have been deleted.</span>", book.Title);

            return Content(resultMsg);
        }

        [OutputCache(CacheProfile = "ZeroCacheProfile")]
        public ActionResult BookCreate()
        {
            Book book = new Book();

            if (Request != null && Request.IsAjaxRequest())
                return PartialView("_BookCreate", book);
            else
                return View("BookCreate", book);
        }

        [HttpPost]
        [OutputCache(CacheProfile = "ZeroCacheProfile")]
        public ActionResult BookCreate(Book book)
        {
            // Normally you would add this to the database,
            // but the demo is just going to add it 
            // to the list temporarily for this request; it 
            // will disappear on the next refresh.
            if (Request != null && Request.IsAjaxRequest())
            {
                book.BookId = new Random().Next(700, 5000);
                var books = repo.SelectBooks(93);
                books.Add(book);
                TempData["message"] = string.Format("Added: {0}", book.Title);
                return PartialView("BookList", books);
            }
            else
                return View("BookCreate", book);
        }

        #endregion
    }
}
