using BlogAPI.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;

namespace BlogAPI.Tests.Auth
{
    public class LoginTest
    {
        [Fact]
        public void Test1()
        {
            Starter.Start();

            //Thread.Sleep(5000);
            //Microsoft.AspNetCore.Mvc.Testing.WebApplicationFactory

            var response = Starter.SendRequestPost("http://localhost:50101/home", "hellooo");

            Console.WriteLine("ok");
            
            Starter.Stop();
        }
    }
}
