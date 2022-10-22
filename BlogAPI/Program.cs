using System.Linq;
using BlogAPI.Core.Configuration;
using BlogAPI.Core.Database;
using BlogAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var config = BlogConfig.ReadBlogConfig();
                BlogConfig.TheConfig = config;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to read config file: {ex}");
                Console.WriteLine("Using default config settings.");
                BlogConfig.TheConfig = BlogConfig.GetDefaultBlogConfig();
            }

            using var db = new BloggingDbContext();
            // Note: This sample requires the database to be created before running.
            Console.WriteLine($"Database path: {db.DbPath}.");

            // Create
            Console.WriteLine("Inserting a new blog");
            var ok = db.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
            db.SaveChanges();
            Console.WriteLine(ok);

            // Read
            Console.WriteLine("Querying for a blog");
            var blog = db.Blogs
                .OrderBy(b => b.BlogId)
                .First();

            var myBlogs = db.Blogs
                .Where(b => b.BlogId < 20)
                .OrderBy(b => b.BlogId)
                .ToList();

            // Update
            Console.WriteLine("Updating the blog and adding a post");
            blog.Url = "https://devblogs.microsoft.com/dotnet";
            blog.Posts.Add(
                new Post { Title = "Hello World", Content = "I wrote an app using EF Core!" });
            db.SaveChanges();

            // Delete
            Console.WriteLine("Delete the blog");
            db.Remove(blog);
            db.SaveChanges();
        }
    }
}