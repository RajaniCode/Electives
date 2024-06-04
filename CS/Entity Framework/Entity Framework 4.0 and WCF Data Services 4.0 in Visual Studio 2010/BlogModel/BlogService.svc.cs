using System;
using System.Collections.Generic;
using System.Data.Services;
using System.Data.Services.Common;
using System.Linq;
using System.ServiceModel.Web;
using System.Web;
using System.Linq.Expressions;

namespace BlogModel
{
    [System.ServiceModel.ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class BlogService : DataService< BlogContext >
    {
       
        public static void InitializeService(DataServiceConfiguration config)
        {
            config.SetEntitySetAccessRule("Blogs", EntitySetRights.All);
            config.SetEntitySetAccessRule("Posts", EntitySetRights.All);
            config.SetEntitySetAccessRule("Tags", EntitySetRights.All);
            config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V2;
            config.SetEntitySetPageSize("Posts", 5);
                      
        }

        protected override void HandleException(HandleExceptionArgs args)
        {
            base.HandleException(args);
        }

        //returns only public posts and posts owned by the current user
        [QueryInterceptor("Posts")]
        public Expression<Func<Post, bool>> OnPostQuery()
        {
            return p => p.Blog.Owner.Equals(HttpContext.Current.User.Identity.Name);
        }

        //returns only the blogs the currently logged in user owns
        [QueryInterceptor("Blogs")]
        public Expression<Func<Blog, bool>> OnBlogQuery()
        {
            return b =>
                 b.Owner.Equals(HttpContext.Current.User.Identity.Name);
        }



    }
}
