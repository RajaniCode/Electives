using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnleashedBlog.Controllers;
using System.Web.Mvc;
using UnleashedBlog.Tests.Factories;
using UnleashedBlog.Models;

namespace UnleashedBlog.Tests
{
    class TestHelpers
    {

        /// <summary>
        /// Enables you to create a large set of blog entries for
        /// testing purposes.
        /// </summary>
        public static void CreateBlogEntries(BlogController controller, int count)
        {
            for (int i = 0; i < count; i++)
            {
                var name = "Blog Entry " + i.ToString();
                var blogEntryToCreate = BlogEntryFactory.GetWithName(name);
                controller.Create(blogEntryToCreate);
            }
        }

        /// <summary>
        /// Enables you to check whether a particular error message can
        /// be found in the model state errors collection.
        /// </summary>
        public static bool HasErrorMessage(ModelState modelState, string errorMessage)
        {
            foreach (var error in modelState.Errors)
            {
                if (error.ErrorMessage == errorMessage)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Create a new blog entry
        /// </summary>
        public static BlogEntry CreateBlogEntry(ControllerFactory controllerFactory)
        {
            var blogController = controllerFactory.GetBlogController();
            var blogEntryToCreate = BlogEntryFactory.Get();
            blogController.Create(blogEntryToCreate);
            return blogEntryToCreate;
        }


        /// <summary>
        /// Creates a new comment for a blog entry.
        /// </summary>
        public static Comment CreateComment(CommentController commentController, BlogEntry blogEntry, string commentTitle, DateTime commentDatePublished)
        {
            // Create comment
            var commentToCreate = CommentFactory.Get();
            commentToCreate.BlogEntryId = blogEntry.Id;
            commentToCreate.Title = commentTitle;
            commentToCreate.DatePublished = commentDatePublished;

            // Add to blog entry
            commentController.Create(commentToCreate);

            return commentToCreate;
        }



    }
}
