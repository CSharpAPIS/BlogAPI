using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using BlogAPI.Models;
using BlogAPI.Core;
using BlogAPI.Core.Database;
using BlogAPI.Core.Configuration;
using System.Collections;
using BlogAPI.Endpoints.Response.Types;
using BlogAPI.Endpoints.Response;

namespace BlogAPI.Endpoints
{
    [ApiController]
    [Route("[controller]")]
    public class CreateBlogController : ControllerBase
    {
        private static BloggingDbContext Db
        {
            get => APIClient.DbContext;
        }
        [HttpGet(Name = "GetCreatePost")]
        public Post Get()
        {
            return new() { BlogId = 12 };
        }
        [HttpPost(Name = "PostCreatePost")]
        public async Task<EndpointResponse<CreatePostResult>> Post()
        {
            using var reader = new StreamReader(Request.Body);
            var content = await reader.ReadToEndAsync();
            var userData = JsonSerializer.Deserialize<Hashtable>(content);

            // Create
            Console.WriteLine("Inserting a new blog");
            var ok = Db.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
            Db.SaveChanges();
            Console.WriteLine(ok);
            return null;
        }
    }
}
