using System.Collections.Generic;
using System.Web.Mvc;
using UnleashedBlog.Models;
using UnleashedBlog.Models.EntityFramework;

namespace UnleashedBlog.Controllers
{
    public class BlogController : Controller
    {
        private BlogRepositoryBase _repository;


        public BlogController()
            : this(new EntityFrameworkBlogRepository()) { }

        public BlogController(BlogRepositoryBase repository)
        {
            _repository = repository;
        }

        public ActionResult Index()
        {
            return View(_repository.ListBlogEntries());
        }


        public ActionResult Create()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(BlogEntry blogEntryToCreate)
        {
            _repository.CreateBlogEntry(blogEntryToCreate);
            return RedirectToAction("Index");
        }
    }
}
