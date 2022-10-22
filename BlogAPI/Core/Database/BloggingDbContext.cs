﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using BlogAPI.Models;
using BlogAPI.Core.Configuration;

namespace BlogAPI.Core.Database
{
    public class BloggingDbContext : DbContext, IBloggingContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        internal string DbPath { get; }
        internal string DbUrl { get; }

        public BloggingDbContext()
        {
#if USE_SQLITE
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "blogging.db");
#endif
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
#if USE_SQLITE2
            options.UseSqlite($"Data Source={DbPath}");
#else
            options.UseSqlServer(!string.IsNullOrWhiteSpace(DbUrl) ? DbUrl : 
                @"Server=(localdb)\mssqllocaldb;Database=Blogging;Trusted_Connection=True");
#endif

        public string GetDbPath() => DbPath;
        public string GetDbURL() => DbUrl;
    }
}