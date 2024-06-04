using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class CustomerController : Controller
    {

        private ICustomerRepository _repository;

        public CustomerController() 
            : this(new CustomerRepository()) { }


        public CustomerController(ICustomerRepository repository)
        {
            _repository = repository;
        }

        //
        // GET: /Customer/

        public ActionResult Index()
        {
            return View(_repository.ListCustomers());
        }

        //
        // GET: /Customer/Create

        public ActionResult Create()
        {
            return View();
        } 

//
// POST: /Customer/Create

[AcceptVerbs(HttpVerbs.Post)]
public ActionResult Create([Bind(Exclude="Id")]Customer customerToCreate )
{
    if (!ModelState.IsValid)
        return View();
    
    _repository.CreateCustomer(customerToCreate);
    return RedirectToAction("Index");
}


    }
}
