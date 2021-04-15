using Microsoft.AspNetCore.Mvc;

namespace Emailer.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ApiVersion("1.0")]
    [ApiController]
    [Route("[controller]")]
    public class DefaultController : ControllerBase
    {
        [HttpGet("/")]
        [HttpHead("/")]
        public IActionResult Index()
        {
            return new RedirectResult("~/swagger/index.html");
        }
    }
}