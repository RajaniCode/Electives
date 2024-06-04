using System.Collections.Generic;
using System.Web.Mvc;
using UnleashedBlog.Models;
using UnleashedBlog.Models.EntityFramework;
using UnleashedBlog.Attributes;

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

        public ActionResult Index(int? page)
        {
            return View(_blogService.ListBlogEntries(page));
        }

        [AcceptAjax]
        [ActionName("Index")]
        public ActionResult Index_Ajax(int? page)
        {
            return PartialView("BlogEntries", _blogService.ListBlogEntries(page));
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
