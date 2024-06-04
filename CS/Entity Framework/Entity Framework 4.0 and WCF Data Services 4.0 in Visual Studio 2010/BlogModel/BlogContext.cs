using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Objects;

namespace BlogModel
{
    public class BlogContext : ObjectContext
    {
        public BlogContext()
            : base("name=BlogContext", "BlogContext")
        {
 
        }

        public ObjectSet<Blog> Blogs
        {
            get
            {
                if (_Blogs == null)
                {
                    _Blogs = base.CreateObjectSet<Blog>("Blogs");
                }
                return _Blogs;
            }
        }
        private ObjectSet<Blog> _Blogs;

        public ObjectSet<Post> Posts
        {
            get
            {
                if (_Posts == null)
                {
                    _Posts = base.CreateObjectSet<Post>("Posts");
                }
                return _Posts;
            }
        }
        private ObjectSet<Post> _Posts;

        public ObjectSet<Tag> Tags
        {
            get
            {
                if (_Tags == null)
                {
                    _Tags = base.CreateObjectSet<Tag>("Tags");
                }
                return _Tags;
            }
        }
        private ObjectSet<Tag> _Tags;
    }
}