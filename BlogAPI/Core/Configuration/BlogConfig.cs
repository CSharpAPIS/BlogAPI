using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace BlogAPI.Core.Configuration
{
    public class BlogConfig
    {
        public static BlogConfig TheConfig { get; set; }


        public static BlogConfig ReadBlogConfig(string fileName = "config.json") =>
            JsonSerializer.Deserialize<BlogConfig>(File.ReadAllText(fileName));
        public static BlogConfig GetDefaultBlogConfig()
        {
            return new()
            {
                UseSQLite = true,
            };
        }
        /// <summary>
        /// Set it to <c>true</c> if you want the blog api to use sqlite as its
        /// database.
        /// </summary>
        public bool UseSQLite { get; set; }
        /// <summary>
        /// The url of the Microsoft SQL Server.
        /// </summary>
        /// <example>
        /// @"Server=(localdb)\mssqllocaldb;Database=Blogging;Trusted_Connection=True"
        /// </example>
        public string SQLServerUrl { get; set; }
    }
}
