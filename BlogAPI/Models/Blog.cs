using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAPI.Models
{
    public class Blog
    {
        /// <summary>
        /// The unique id of the blog.
        /// </summary>
        public int BlogId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string BlogTitle { get; set; }
        /// <summary>
        /// The url of the blog. This value can be passed by the person
        /// who is creating the blog, if not, it should be set to the url-encoded
        /// value of <see cref="BlogTitle"/> property.
        /// All posts will be after this url, for example:
        /// - Blog url: daily-news/EU
        ///   - Post1: daily-news/EU/what-should-we-do-here
        ///   - Post2: daily-news/EU/this-is-news2
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// The user identifier of the person who created this blog originally.
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// A list of posts belonging to this blog.
        /// </summary>
        public List<Post> Posts { get; } = new();
    }
}
