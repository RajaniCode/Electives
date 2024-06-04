using System.Web.Mvc;
using UnleashedBlog.Attributes;
using UnleashedBlog.Models;

namespace UnleashedBlog.Controllers
{
    public class BlogController : ApplicationController
    {

        public BlogController()
        {}

        public BlogController(BlogRepositoryBase blogRepository)
            : base(blogRepository){}

        /// <summary>
        /// Returns a page of blog entries.
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult Index(int? page)
        {
            return View(_blogService.ListBlogEntries(page));
        }

        /// <summary>
        /// Only callable within an Ajax request. 
        /// Returns a page of blog entries.
        /// </summary>
        [AcceptAjax]
        [ActionName("Index")]
        public ActionResult Index_Ajax(int? page)
        {
            return PartialView("BlogEntries", _blogService.ListBlogEntries(page));
        }

        /// <summary>
        /// Displays the HTML form for creating a new blog entry.
        /// </summary>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Enables you to create a new blog entry.
        /// </summary>
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Exclude="Id")]BlogEntry blogEntryToCreate)
        {
            if (_blogService.CreateBlogEntry(blogEntryToCreate) == false)
                return View();

            return RedirectToAction("Index");
        }


    }
}
