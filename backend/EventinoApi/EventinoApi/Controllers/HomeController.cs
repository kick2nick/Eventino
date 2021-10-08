using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Net.Mime;

namespace EventinoApi.Controllers
{
    [Route("/")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public ActionResult Index()
        {
            return PhysicalFile(Path.Combine(Directory.GetCurrentDirectory(),
                "wwwroot", "index.html"), MediaTypeNames.Text.Html);
        }
    }
}
