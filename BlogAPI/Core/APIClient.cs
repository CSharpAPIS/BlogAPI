using BlogAPI.Core.Configuration;
using BlogAPI.Core.Database;
using BlogAPI.Core.Security;
using Newtonsoft.Json.Serialization;
using System;
using System.Text.Json;

namespace BlogAPI.Core
{
    public class APIClient: IDisposable
    {
        public static BloggingDbContext DbContext { get; protected set; }
        public static WebApplication TheApp { get; protected set; }


        public APIClient(string[] args)
        {
            DbContext = new BloggingDbContext();
#if USE_SQLITE
            Console.WriteLine($"Database path: {DbContext.DbPath}.");
#else
            Console.WriteLine($"Microsoft SQL Server has started.");
#endif
        }

        public virtual void StartAPI(string[] args)
        {

            var builder = WebApplication.CreateBuilder(new WebApplicationOptions()
            {
                Args = args,
                ApplicationName = "BlogAPI",
                EnvironmentName = "Development",
                WebRootPath = Directory.GetCurrentDirectory(),

            });

            // Add services to the container.
            

            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            if (BlogConfig.TheConfig.UseUrls != null && 
                BlogConfig.TheConfig.UseUrls.Length != 0)
            {
                builder.WebHost.UseUrls(BlogConfig.TheConfig.UseUrls);
            }


            //builder.Services.AddSwaggerGen();

            TheApp = builder.Build();

            // Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
            //    app.UseSwagger();
            //    app.UseSwaggerUI();
            //}

            //app.UseHttpsRedirection();

            //app.UseAuthorization();

            
            TheApp.MapControllers();
            if (BlogConfig.TheConfig.RunInThreadPool)
            {
                Task.Run(() =>
                {
                    TheApp.Run();
                });
            }
            else
            {
                TheApp.Run();
            }
        }

        public virtual async Task StopAPI(TimeSpan timeout)
        {
            await TheApp.StopAsync(timeout);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (DbContext != null)
                {
                    DbContext.Dispose();
                    DbContext = null;
                }
            }
        }
    }
}
