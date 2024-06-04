using System.Web.Mvc;
using UnleashedBlog.Models;
using UnleashedBlog.Models.EntityFramework;
using UnleashedBlog.Attributes;

namespace UnleashedBlog.Controllers
{
    public class ArchiveController : ApplicationController
    {
        public ArchiveController()
        { }

        public ArchiveController(BlogRepositoryBase blogRepository) 
            : base(blogRepository) { }


        /// <summary>
        /// Returns a single blog entry
        /// </summary>
        public ActionResult Details(int year, int month, int day, string name)
        {
            return View(_blogService.GetBlogEntry(year, month, day, name));
        }

        /// <summary>
        /// Returns a list of blog entries that match a specified year, month, or day
        /// </summary>
        public ActionResult Index(int? page, int? year, int? month, int? day)
        {
            return View(_blogService.ListBlogEntries(page, year, month, day));
        }

        /// <summary>
        /// Only callable within an Ajax request.
        /// Returns a list of blog entries that match a specified year, month, or day.
        /// </summary>
        [AcceptAjax]
        [ActionName("Index")]
        public ActionResult Index_Ajax(int? page, int? year, int? month, int? day)
        {
            return PartialView("BlogEntries", _blogService.ListBlogEntries(page, year, month, day));
        }


    }
}
