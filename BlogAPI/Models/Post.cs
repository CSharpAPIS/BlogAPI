using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BlogAPI.Models
{
    public class Post
    {
        /// <summary>
        /// The id of this post, which should be set automatically by asp.net.
        /// </summary>
        public int PostId { get; set; }
        /// <summary>
        /// the title of this post.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// the content of this post.
        /// </summary>
        public string Content { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
