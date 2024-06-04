using System.Collections.Generic;
using System.Web.Mvc;
using UnleashedBlog.Models;
using UnleashedBlog.Models.EntityFramework;

namespace UnleashedBlog.Controllers
{
    public class BlogController : Controller
    {
        private BlogServiceBase _blogService;

        public BlogController()
        {
            _blogService = new BlogService(this.ModelState);
        }

        public BlogController(BlogRepositoryBase blogRepository)
        {
            _blogService = new BlogService(this.ModelState, blogRepository);
        }

        public ActionResult Index()
        {
            return View(_blogService.ListBlogEntries());
        }


        public ActionResult Create()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create([Bind(Exclude="Id")]BlogEntry blogEntryToCreate)
        {
            if (_blogService.CreateBlogEntry(blogEntryToCreate) == false)
                return View();

            return RedirectToAction("Index");
        }
    }
}
