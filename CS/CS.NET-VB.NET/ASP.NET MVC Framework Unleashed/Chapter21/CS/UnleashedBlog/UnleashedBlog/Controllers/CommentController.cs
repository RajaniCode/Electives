using System.Web.Mvc;
using UnleashedBlog.Models;

namespace UnleashedBlog.Controllers
{
    public class CommentController : Controller
    {
        private BlogServiceBase _blogService;

        public CommentController()
        {
            _blogService = new BlogService(this.ModelState);
        }

        public CommentController(BlogRepositoryBase blogRepository)
        {
            _blogService = new BlogService(this.ModelState, blogRepository);
        }

        /// <summary>
        /// Enables you to create a new comment.
        /// </summary>
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create([Bind(Prefix="Comment", Exclude="Id")]Comment commentToCreate)
        {
            // Attempt to add comment
            var success = _blogService.CreateComment(commentToCreate);
            var blogEntry = _blogService.GetBlogEntry(commentToCreate.BlogEntryId);

            if (success)
                return RedirectToRoute("Details", new {year=blogEntry.DatePublished.Year, month=blogEntry.DatePublished.Month, day=blogEntry.DatePublished.Day, name=blogEntry.Name});
            
            return View("~/Views/Archive/Details.aspx", blogEntry);         
        }

    }
}
