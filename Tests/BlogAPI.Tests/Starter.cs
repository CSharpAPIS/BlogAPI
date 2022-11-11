namespace BlogAPI.Tests;
using System;
using BlogAPI.Core.Database;
using BlogAPI.Core.Configuration;
using BlogAPI.Core;

/// <summary>
/// Starts a new instance of the BlogAPI server running at background.
/// </summary>
public sealed class Starter : IDisposable
{
    public static BloggingDbContext DbContext
    {
        get => APIClient.DbContext;
    }
    private static Starter _instance;
    public static string ServerUrl
    {
        get
        {
            return BlogConfig.TheConfig.UseUrls[0];
        }
    }
    public APIClient APIClient { get; private set; }
    public BlogConfig Config { get; private set; }
    


    private Starter()
    {

    }

    private void Run(bool runInThreadPool = true)
    {
        try
        {
            BlogConfig.TheConfig = Config = BlogConfig.ReadBlogConfig();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to read config file: {ex}");
            Console.WriteLine("Using default config settings.");
            BlogConfig.TheConfig = BlogConfig.GetDefaultBlogConfig();
            BlogConfig.TheConfig.RunInThreadPool = runInThreadPool;
        }

        APIClient = new APIClient(null);
        APIClient.StartAPI(null);
    }

    public static Starter Start(bool runInThreadPool = true)
    {
        if (_instance != null)
        {
            Console.WriteLine("Already an instance exists.");
            return _instance;
        }

        var s = new Starter();
        Console.WriteLine($"Created a new instance of {nameof(Starter)} class.");
        _instance = s;

        s.Run();

        // make the current thread sleep for a few miliseconds till we get server up.
        if (runInThreadPool)
            Thread.Sleep(250);
        
        return s;
    }

    public static HttpResponseMessage SendRequestPost(string url = null, string content = "")
    {
        if (url == null)
        {
            url = ServerUrl;
        }
        else if (url.StartsWith("/"))
        {
            url = ServerUrl + (url.EndsWith("/") ? url[..^1] : url);
        }

        var client = new HttpClient();
        var req = new HttpRequestMessage(HttpMethod.Post, url)
        {
            Content = new StringContent(content),
        };

        req.Options.TryAdd("Allow-Redirect", false);

        return client.Send(req);
    }


    public static HttpResponseMessage SendRequestGet(string url = null)
    {
        if (url == null)
        {
            url = ServerUrl;
        }
        else if (url.StartsWith("/"))
        {
            url = ServerUrl + (url.EndsWith("/") ? url[..^1] : url);
        }

        var client = new HttpClient(new HttpClientHandler()
        {
            AllowAutoRedirect = false,
        });
        var req = new HttpRequestMessage(HttpMethod.Get, url);

        return client.Send(req);
    }


    public static string ReadAsString(HttpContent content)
    {
        var stream = content.ReadAsStream();
        if (stream == null || !stream.CanRead)
        {
            return null;
        }

        return new StreamReader(stream).ReadToEnd();
    }

    public static bool Stop()
    {
        if (_instance == null)
        {
            return false;
        }

        _instance.Dispose();
        _instance = null;
        return true;
    }

    public void Dispose()
    {
        _instance = null;
        BlogConfig.TheConfig = null;
        APIClient.Dispose();
    }
}