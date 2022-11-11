using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Endpoints
{
    [ApiController]
    [Route("/")]
    public class EmptyController : Controller
    {
        [HttpGet]
        [HttpPost]
        public IActionResult Get()
        {
            return RedirectPermanent("/home");
        }
    }
}
