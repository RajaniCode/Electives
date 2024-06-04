using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnleashedBlog.Models;

namespace UnleashedBlog.Tests.Factories
{
    /// <summary>
    /// The Comment Factory creates comments. Because we might
    /// change the properties of a comment, creating comments
    /// at one central location makes our tests easier to change.
    /// </summary>
    public class CommentFactory
    {
        public static Comment Get()
        {
            var commentToCreate = new Comment();
            commentToCreate.BlogEntryId = 1;
            commentToCreate.Title = "New Comment";
            commentToCreate.DatePublished = new DateTime(2010, 12, 25);
            commentToCreate.Url = "http://myblog.com";
            commentToCreate.Name = "Bob";
            commentToCreate.Email = "Bob@somewhere.com";
            commentToCreate.Text = "Here is the comment";
            return commentToCreate;
        }


        public static Comment GetWithTitle(int blogEntryId, string title)
        {
            var commentToCreate = Get();
            commentToCreate.BlogEntryId = blogEntryId;
            commentToCreate.Title = title;
            return commentToCreate;
        }


        public static Comment GetWithName(int blogEntryId, string name)
        {
            var commentToCreate = Get();
            commentToCreate.BlogEntryId = blogEntryId;
            commentToCreate.Name = name;
            return commentToCreate;
        }

        public static Comment GetWithText(int blogEntryId, string text)
        {
            var commentToCreate = Get();
            commentToCreate.BlogEntryId = blogEntryId;
            commentToCreate.Text = text;
            return commentToCreate;
        }


    }

}
