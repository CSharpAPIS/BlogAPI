using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using BlogAPI.Core.Security;

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
        /// <summary>
        /// Id of the blog that this post relates to.
        /// </summary>
        public int ParentBlog { get; set; }
        /// <summary>
        /// Permissions required for users to view this post.
        /// If this property is set to <see cref="UserPermission.BasicPermission"/>,
        /// user doesn't need auth to get content of this post.
        /// </summary>
        public UserPermission RequiredPermissions { get; set; }
    }
}
