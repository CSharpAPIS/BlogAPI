using BlogAPI.Core.Security;
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
        /// The title of this blog.
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
        /// Required permissions for a user to get content of posts (read) from
        /// this blog. 
        /// (each post does have its own permissions, which should be
        /// checked as well; this property here applies to all posts of this blog).
        /// </summary>
        public UserPermission ReadPermissions { get; set; }
        /// <summary>
        /// Required permissions for a user to edit the content of posts (write)
        /// from this blog.
        /// (each post does have its own permissions, which should be
        /// checked as well; this property here applies to all posts of this blog).
        /// </summary>
        public UserPermission WritePermissions { get; set; }
        /// <summary>
        /// Required permissions for a user to edit the content of posts (write)
        /// from this blog.
        /// </summary>
        public UserPermission ModifyPermissions { get; set; }

        /// <summary>
        /// A list of posts belonging to this blog.
        /// </summary>
        public List<Post> Posts { get; } = new();

        /// <summary>
        /// Checks if the user with the passed-by arg permission can have
        /// read-access to the posts of this blog or not.
        /// </summary>
        /// <param name="permission"></param>
        /// <returns></returns>
        public virtual bool CanRead(UserPermission permission)
        {
            return permission switch
            {
                UserPermission.OwnerPermission => true,
                UserPermission.DevPermission => !ReadPermissions.HasFlag(UserPermission.OwnerPermission),
                UserPermission.NotRegistered => ReadPermissions == UserPermission.NotRegistered,
                _ => ReadPermissions.HasFlag(permission),
            };
        }

        /// <summary>
        /// Checks if the user with the passed-by arg permission can have
        /// write-access to the posts of this blog or not.
        /// </summary>
        /// <param name="permission"></param>
        /// <returns></returns>
        public virtual bool CanWrite(UserPermission permission)
        {
            return permission switch
            {
                UserPermission.OwnerPermission => true,
                UserPermission.DevPermission => !WritePermissions.HasFlag(UserPermission.OwnerPermission),
                UserPermission.NotRegistered => WritePermissions == UserPermission.NotRegistered,
                _ => WritePermissions.HasFlag(permission),
            };
        }
    }
}
