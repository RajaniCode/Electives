using System.Web.Mvc;
using UnleashedBlog.Models;
using UnleashedBlog.Models.EntityFramework;

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

        public ActionResult Index(int? year, int? month, int? day, string name)
        {
            return View(_blogService.ListBlogEntries(year, month, day, name));
        }

    }
}
