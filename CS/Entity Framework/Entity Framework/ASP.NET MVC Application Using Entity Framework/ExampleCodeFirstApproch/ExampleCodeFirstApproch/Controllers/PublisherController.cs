using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExampleCodeFirstApproch.Models;

namespace ExampleCodeFirstApproch.Controllers
{
    public class PublisherController : Controller
    {
        LibraryContext objContext;
        public PublisherController()
        {
            objContext = new LibraryContext();
        }

        #region List and Details Publisher

        public ActionResult Index()
        {
            var publishers = objContext.Publishers.ToList();
            return View(publishers);
        }

        public ViewResult Details(int id)
        {
            Publisher publisher = objContext.Publishers.Where(x=>x.PublisherId==id).SingleOrDefault();
            return View(publisher);
        }

        #endregion

        #region Create Publisher

        public ActionResult Create()
        {
            return View(new Publisher());
        }

        [HttpPost]
        public ActionResult Create(Publisher publish)
        {
            objContext.Publishers.Add(publish);
            objContext.SaveChanges();
            return RedirectToAction("Index");
        }

        #endregion

        #region edit publisher

        public ActionResult Edit(int id)
        {
            Publisher publisher = objContext.Publishers.Where(x => x.PublisherId == id).SingleOrDefault();
            return View(publisher);
        }


        [HttpPost]
        public ActionResult Edit(Publisher model)
        {
            Publisher publisher = objContext.Publishers.Where(x => x.PublisherId == model.PublisherId).SingleOrDefault();
            if (publisher != null)
            {
                objContext.Entry(publisher).CurrentValues.SetValues(model);
                objContext.SaveChanges();
                return RedirectToAction("Index");
            }
              
            return View(model);
        }

      #endregion

        #region Delete Publisher
        public ActionResult Delete(int id)
        {
            Publisher publisher = objContext.Publishers.Find(id);//.Where(x => x.PublisherId == id).SingleOrDefault();
            return View(publisher);
        }

        [HttpPost]
        public ActionResult Delete(int id, Publisher model)
        {
           var publisher = objContext.Publishers.Where(x => x.PublisherId == id).SingleOrDefault();
           if (publisher != null)
            {
                objContext.Publishers.Remove(publisher);
                objContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        #endregion

    }
}
