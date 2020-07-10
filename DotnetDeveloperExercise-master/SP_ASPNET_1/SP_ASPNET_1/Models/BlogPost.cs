using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SP_ASPNET_1.Models
{
    public class BlogPost
    {
        public BlogPost()
        {
            BlogPostReactions = new HashSet<BlogPostReaction>();
        }
        public int BlogPostID { get; set; }
        public string Title { get; set; }
        public Author Author { get; set; }
        public DateTime DateTime { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public virtual ICollection<BlogPostReaction> BlogPostReactions { get; set; }

    }
}