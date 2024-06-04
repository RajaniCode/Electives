using UnleashedBlog.Controllers;
using UnleashedBlog.Models;
using UnleashedBlog.Tests.Models;


namespace UnleashedBlog.Tests.Factories
{
    public class ControllerFactory
    {
        private BlogRepositoryBase _blogRepository = new FakeBlogRepository();


        public BlogController GetBlogController()
        {
            return new BlogController(_blogRepository);
        }

        public ArchiveController GetArchiveController()
        {
            return new ArchiveController(_blogRepository);
        }

    }
}
