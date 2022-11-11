using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Endpoints
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        [HttpGet(Name = "GetHome")]
        public string Get()
        {
            return "hi, this is home";
        }

        [HttpPost(Name = "PostHome")]
        public string Post()
        {
            return "hi, this is home with post";
        }
    }
}
