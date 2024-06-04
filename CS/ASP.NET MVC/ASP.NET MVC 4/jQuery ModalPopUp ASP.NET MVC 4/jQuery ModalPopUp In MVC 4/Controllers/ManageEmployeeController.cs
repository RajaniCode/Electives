using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using jQuery_ModalPopUp_In_MVC_4.Models;

namespace jQuery_ModalPopUp_In_MVC_4.Controllers
{
    public class ManageEmployeeController : Controller
    {
        ModelServices mobjModel = new ModelServices();

        public ActionResult Index()
        {
            return View();
        } 

        public ActionResult SearchEmployee(int page = 1, string sort = "name", string sortDir = "ASC")
        {
            const int pageSize = 5;
            var totalRows = mobjModel.CountAllEmployee();

            sortDir = sortDir.Equals("desc", StringComparison.CurrentCultureIgnoreCase) ? sortDir : "asc";

            var validColumns = new[] { "id", "name", "dept", "country" };
            if (!validColumns.Any(c => c.Equals(sort, StringComparison.CurrentCultureIgnoreCase)))
                sort = "id";

            var employee = mobjModel.GetEmployeePage(page, pageSize, "it." + sort + " " + sortDir);

            var data = new PagedEmployeeModel()
            {
                TotalRows = totalRows,
                PageSize = pageSize,
                Employee = employee
            };
            return View(data);
        }

        public ActionResult Create()
        {
            if (Request.IsAjaxRequest())
            {
                ViewBag.IsUpdate = false;
                return View("_CreateEmployee");
            }
            else

                return View();
        }

        [HttpPost]
        public ActionResult CreateEmployee(EmployeeModel emp, string Command)
        { 
            if (!ModelState.IsValid)
            {
                return PartialView("_CreateEmployee", emp);
            }
            else
            {
                Employee empObj = new Employee();
                empObj.Emp_ID = emp.Emp_ID;
                empObj.Name = emp.Name;
                empObj.Dept = emp.Dept;
                empObj.City = emp.City;
                empObj.State = emp.State;
                empObj.Country = emp.Country;
                empObj.Mobile = emp.Mobile;

                bool IsSuccess = mobjModel.AddEmployee(empObj);
                if (IsSuccess)
                {
                    TempData["OperStatus"] = "Employee added succeessfully";
                    ModelState.Clear();
                    return RedirectToAction("SearchEmployee", "ManageEmployee");
                }
            }

            return PartialView("_CreateEmployee");
        }

        public ActionResult EditEmployee(int id)
        {
            var data = mobjModel.GetEmployeeDetail(id);

            if (Request.IsAjaxRequest())
            {
                EmployeeModel empObj = new EmployeeModel();

                empObj.Emp_ID = data.Emp_ID;
                empObj.Name = data.Name;
                empObj.Dept = data.Dept;
                empObj.City = data.City;
                empObj.State = data.State;
                empObj.Country = data.Country;
                empObj.Mobile = data.Mobile;

                ViewBag.IsUpdate = true;
                return View("_EditEmployee", empObj);
            }
            else
                return View(data);
        }

        [HttpPost]
        public ActionResult UpdateEmployee(EmployeeModel emp, string Command)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("_EditEmployee", emp);
            }
            else
            {
                Employee empObj = new Employee();
                empObj.ID = emp.Id;
                empObj.Emp_ID = emp.Emp_ID;
                empObj.Name = emp.Name;
                empObj.Dept = emp.Dept;
                empObj.City = emp.City;
                empObj.State = emp.State;
                empObj.Country = emp.Country;
                empObj.Mobile = emp.Mobile;

                bool IsSuccess = mobjModel.UpdateEmployee(empObj);
                if (IsSuccess)
                {
                    TempData["OperStatus"] = "Employee updated succeessfully";
                    ModelState.Clear();
                    return RedirectToAction("SearchEmployee", "ManageEmployee");
                }
            }

            return PartialView("_EditEmployee");
        }

        public ActionResult ViewEmployeeDetail(int id)
        {
            var data = mobjModel.GetEmployeeDetail(id);
            if (Request.IsAjaxRequest())
            {
                EmployeeModel empObj = new EmployeeModel();

                empObj.Emp_ID = data.Emp_ID;
                empObj.Name = data.Name;
                empObj.Dept = data.Dept;
                empObj.City = data.City;
                empObj.State = data.State;
                empObj.Country = data.Country;
                empObj.Mobile = data.Mobile;

                return View("_EmployeeDetail", empObj);
            }
            else

                return View(data);
        }

        public ActionResult Delete(int id)
        {
            bool check = mobjModel.DeleteEmployee(id);
            var data = mobjModel.GetEmployee();
            return RedirectToAction("SearchEmployee");
        }
    }
}
