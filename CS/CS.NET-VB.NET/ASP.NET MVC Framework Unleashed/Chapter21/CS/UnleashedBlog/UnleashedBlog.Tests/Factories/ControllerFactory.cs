using UnleashedBlog.Controllers;
using UnleashedBlog.Models;
using UnleashedBlog.Tests.Models;


namespace UnleashedBlog.Tests.Factories
{
    /// <summary>
    /// Creates one repository and shares the single repository
    /// with every controller. When testing, you should retrieve a 
    /// controller from this controller factory.
    /// </summary>
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


        public CommentController GetCommentController()
        {
            return new CommentController(_blogRepository);
        }


        public ApplicationController GetApplicationController()
        {
            return new ApplicationControllerChild(_blogRepository);
        }


    }

    public class ApplicationControllerChild : ApplicationController
    {
        public ApplicationControllerChild(BlogRepositoryBase blogRepository) 
            : base(blogRepository) { }
    }
}
