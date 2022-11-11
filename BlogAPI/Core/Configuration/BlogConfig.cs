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
        public const string DEFAULT_URL = "http://127.0.0.1:50101";
        public static BlogConfig TheConfig { get; set; }


        public static BlogConfig ReadBlogConfig(string fileName = "config.json") =>
            JsonSerializer.Deserialize<BlogConfig>(File.ReadAllText(fileName));
        public static BlogConfig GetDefaultBlogConfig()
        {
            return new()
            {
                UseSQLite = true,
                UseUrls = new[] { DEFAULT_URL },
            };
        }
        /// <summary>
        /// Set it to <c>true</c> if you want the blog api to use sqlite as its
        /// database.
        /// </summary>
        public bool UseSQLite { get; set; }
        /// <summary>
        /// Set to <c>true</c> when you want to call the .Run() method of ASP.NET
        /// in ThreadPool, instead of the main thread.
        /// Default is <c>false</c>.
        /// </summary>
        public bool RunInThreadPool { get; set; }
        /// <summary>
        /// The url of the Microsoft SQL Server.
        /// </summary>
        /// <example>
        /// @"Server=(localdb)\mssqllocaldb;Database=Blogging;Trusted_Connection=True"
        /// </example>
        public string SQLServerUrl { get; set; }
        /// <summary>
        /// Urls used for when making a web host.
        /// </summary>
        public string[] UseUrls { get; set; }
        /// <summary>
        /// The Env name used for when making a web host.
        /// </summary>
        public string EnvironmentName { get; set; } = "";

        /// <summary>
        /// The Application name used for when making a web host.
        /// </summary>
        public string ApplicationName { get; set; } = "BlogAPI";
    }
}
