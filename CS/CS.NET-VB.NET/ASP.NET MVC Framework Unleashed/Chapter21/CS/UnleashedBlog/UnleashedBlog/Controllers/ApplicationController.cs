using System.Web.Mvc;
using UnleashedBlog.Models;
using UnleashedBlog.Models.EntityFramework;

namespace UnleashedBlog.Controllers
{
    public abstract class ApplicationController : Controller
    {
        protected BlogServiceBase _blogService;

        public ApplicationController() 
            : this(new EntityFrameworkBlogRepository()) {}


        public ApplicationController(BlogRepositoryBase blogRepository)
        {
            _blogService = new BlogService(this.ModelState, blogRepository);

            ViewData["ArchiveInfo"] = _blogService.ListBlogEntriesByMonth();
        }


    }
}
