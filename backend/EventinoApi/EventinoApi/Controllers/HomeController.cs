using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace EventinoApi.Controllers
{
    [Route("")]
    [ApiController]
    [AllowAnonymous]
    public class HomeController : ControllerBase
    {
        [Route("")]
        [Route("Home")]
        [Route("Home/Index")]
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index()
        {
            var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            var file = Path.Combine(folder, "index.html");

            return PhysicalFile(file, "text/html");
        }
    }
}
