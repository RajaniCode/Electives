using System.Web.Mvc;
using UnleashedBlog.Models;
using UnleashedBlog.Models.EntityFramework;
using UnleashedBlog.Attributes;

namespace UnleashedBlog.Controllers
{
    public class ArchiveController : Controller
    {
        private BlogServiceBase _blogService;

        public ArchiveController()
        {
            _blogService = new BlogService(this.ModelState);
        }

        public ArchiveController(BlogRepositoryBase blogRepository)
        {
            _blogService = new BlogService(this.ModelState, blogRepository);
        }

        public ActionResult Index(int? page, int? year, int? month, int? day, string name)
        {
            return View(_blogService.ListBlogEntries(page, year, month, day, name));
        }

        [AcceptAjax]
        [ActionName("Index")]
        public ActionResult Index_Ajax(int? page, int? year, int? month, int? day, string name)
        {
            return PartialView("BlogEntries", _blogService.ListBlogEntries(page, year, month, day, name));
        }


    }
}
